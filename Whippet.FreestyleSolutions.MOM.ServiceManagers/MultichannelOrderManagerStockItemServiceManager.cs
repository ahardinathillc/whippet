using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Data;
using NodaTime;
using Athi.Whippet;
using Athi.Whippet.Extensions;
using Athi.Whippet.Extensions.IO;
using Athi.Whippet.ServiceManagers;
using Athi.Whippet.Services;
using Athi.Whippet.Data;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Security.Tenants;
using Athi.Whippet.Security.Tenants.Extensions;
using Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.ServiceManagers.Queries;
using Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.ServiceManagers.Commands;
using Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.ServiceManagers.Handlers.Commands;
using Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.ServiceManagers.Handlers.Queries;
using Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.Repositories;
using Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.Extensions;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.ServiceManagers
{
    /// <summary>
    /// Service manager for <see cref="IMultichannelOrderManagerStockItem"/> domain objects.
    /// </summary>
    public class MultichannelOrderManagerStockItemServiceManager : ServiceManager, IDisposable
    {
        /// <summary>
        /// Gets the <see cref="IMultichannelOrderManagerStockItemRepository"/> that queries are executed against. This property is read-only.
        /// </summary>
        protected virtual IMultichannelOrderManagerStockItemRepository ItemRepository
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultichannelOrderManagerStockItemServiceManager"/> class with the specified <see cref="IMultichannelOrderManagerStockItemRepository"/>.
        /// </summary>
        /// <param name="itemRepository"><see cref="IMultichannelOrderManagerStock"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public MultichannelOrderManagerStockItemServiceManager(IMultichannelOrderManagerStockItemRepository itemRepository)
            : base()
        {
            if (itemRepository == null)
            {
                throw new ArgumentNullException(nameof(itemRepository));
            }
            else
            {
                ItemRepository = itemRepository;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultichannelOrderManagerStockItemServiceManager"/> class with the specified <see cref="IMultichannelOrderManagerStockItemRepository"/> object.
        /// </summary>
        /// <param name="serviceLocator"><see cref="IWhippetServiceContext"/> object that serves as a service locator.</param>
        /// <param name="itemRepository"><see cref="IMultichannelOrderManagerStockItemRepository"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public MultichannelOrderManagerStockItemServiceManager(IWhippetServiceContext serviceLocator, IMultichannelOrderManagerStockItemRepository itemRepository)
            : base(serviceLocator)
        {
            if (itemRepository == null)
            {
                throw new ArgumentNullException(nameof(itemRepository));
            }
            else
            {
                ItemRepository = itemRepository;
            }
        }

        /// <summary>
        /// Imports <see cref="IMultichannelOrderManagerStockItem"/> objects from a CSV export.
        /// </summary>
        /// <param name="exportedFile"><see cref="FileInfo"/> that represents the exported file.</param>
        /// <returns><see cref="IEnumerable{T}"/> collection of <see cref="IMultichannelOrderManagerStockItem"/> objects.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual IEnumerable<IMultichannelOrderManagerStockItem> LoadFromCsvFile(FileInfo exportedFile)
        {
            if (exportedFile == null)
            {
                throw new ArgumentNullException(nameof(exportedFile));
            }
            else
            {
                const string COMMA_TOKEN = "$$_COMMA_TOKEN_$$";

                Func<string, string> commaSanitizer = new Func<string, string>(s =>
                {
                    return Regex.Replace(s, @"\""(.+?,.+)+\""", m => m.Value.Replace(",", COMMA_TOKEN));
                });

                IReadOnlyList<string[]> lines = exportedFile.ReadCsvFile(sanitizeFunction: commaSanitizer);

                List<IMultichannelOrderManagerStockItem> items = new List<IMultichannelOrderManagerStockItem>();

                Dictionary<int, string> columnPositionName = null;
                Dictionary<int, string> dataTableColumnPositionName = null;

                IMultichannelOrderManagerStockItem item = null;

                DataTable table = null;
                DataRow row = null;

                int columnIndex = -1;

                object rowValue = null;

                if (lines != null && lines.Count >= 2)
                {
                    item = new MultichannelOrderManagerStockItem();
                    table = item.CreateDataTable();

                    dataTableColumnPositionName = new Dictionary<int, string>();

                    // first row is headers
                    columnPositionName = new Dictionary<int, string>();

                    for (int i = 0; i < lines[0].Length; i++)
                    {
                        columnPositionName.Add(i, lines[0][i].Trim());

                        columnIndex = 0;

                        foreach (DataColumn column in table.Columns)
                        {
                            if (String.Equals(column.ColumnName.Trim(), lines[0][i].Trim()))
                            {
                                dataTableColumnPositionName.Add(columnIndex, lines[0][i].Trim());
                                break;
                            }
                            else
                            {
                                columnIndex++;
                            }
                        }
                    }

                    for (int i = 1; i < lines.Count; i++)
                    {
                        if (lines[i] == null || lines[i].Length < lines[0].Length)
                        {
                            continue;
                        }
                        else
                        {
                            item = new MultichannelOrderManagerStockItem();
                            row = table.NewRow();

                            // initialize default values for non-nullable columns

                            for (int ci = 0; ci < table.Columns.Count; ci++)
                            {
                                row[ci] = table.Columns[ci].DataType.GetDefault();
                            }

                            foreach (KeyValuePair<int, string> entry in columnPositionName)
                            {
                                columnIndex = dataTableColumnPositionName.Where(kvp => String.Equals(entry.Value, kvp.Value, StringComparison.InvariantCultureIgnoreCase)).First().Key;

                                if (String.IsNullOrWhiteSpace(lines[i][entry.Key]))
                                {
                                    if (table.Columns[columnIndex].DataType == typeof(string))
                                    {
                                        rowValue = " ";
                                    }
                                    else if (table.Columns[columnIndex].DataType == typeof(char))
                                    {
                                        rowValue = ' ';
                                    }
                                    else
                                    {
                                        rowValue = DBNull.Value;
                                    }
                                }
                                else
                                {
                                    if (table.Columns[columnIndex].DataType == typeof(DateTime))
                                    {
                                        rowValue = DateTime.Parse(lines[i][entry.Key]);
                                    }
                                    else
                                    {
                                        rowValue = Convert.ChangeType(lines[i][entry.Key], table.Columns[columnIndex].DataType);

                                        if (table.Columns[columnIndex].DataType == typeof(string))
                                        {
                                            rowValue = ((string)(rowValue)).Replace(COMMA_TOKEN, ",");
                                            rowValue = ((string)(rowValue)).Replace("\\\"", "\"");

                                            // check the ending of the line because MOM likes to pad these things

                                            if (((string)(rowValue)).EndsWith('\"'))
                                            {
                                                rowValue = ((string)(rowValue)).Remove(((string)(rowValue)).Length - 1);
                                                rowValue = ((string)(rowValue)).Trim();
                                                rowValue = ((string)(rowValue)) + "\"";
                                            }
                                        }
                                    }
                                }

                                row[columnIndex] = rowValue;
                            }

                            item.ImportDataRow(row);
                            row = null;

                            items.Add(item);
                        }
                    }
                }

                return items;
            }
        }

        /// <summary>
        /// Disposes of the current object and releases its resources from memory.
        /// </summary>
        public override void Dispose()
        {
            if (ItemRepository != null)
            {
                ItemRepository.Dispose();
                ItemRepository = null;
            }

            base.Dispose();
        }
    }
}

