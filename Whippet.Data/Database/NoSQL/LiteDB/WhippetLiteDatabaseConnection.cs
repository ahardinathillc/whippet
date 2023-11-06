using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using LiteDB;
using LiteDB.Engine;

namespace Athi.Whippet.Data.Database.NoSQL.LiteDB
{
    /// <summary>
    /// Provides a connection to a file-based <a href="https://www.litedb.org">LiteDB</a> NoSQL database.
    /// </summary>
    public class WhippetLiteDatabaseConnection : LiteDatabase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetLiteDatabaseConnection"/> class with the specified database file path.
        /// </summary>
        /// <param name="filePath">Relative or absolute filepath to the LiteDB database file. The file will be created if it doesn't exist.</param>
        /// <param name="mapper">Custom <see cref="BsonMapper"/> to use.</param>
        public WhippetLiteDatabaseConnection(string filePath, BsonMapper mapper = null)
            : base(filePath, mapper)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetLiteDatabaseConnection"/> class with the specified database file.
        /// </summary>
        /// <param name="databaseFile">LiteDB database file to open.</param>
        /// <param name="mapper">Custom <see cref="BsonMapper"/> to use.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public WhippetLiteDatabaseConnection(FileInfo databaseFile, BsonMapper mapper = null)
            : this(databaseFile?.FullName, mapper)
        {
            if(databaseFile == null)
            {
                throw new ArgumentNullException(nameof(databaseFile));
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetLiteDatabaseConnection"/> class with the specified parsed connection string.
        /// </summary>
        /// <param name="connectionString">Parsed connection string consisting of key/value pairs.</param>
        /// <param name="mapper">Custom <see cref="BsonMapper"/> to use.</param>
        public WhippetLiteDatabaseConnection(ConnectionString connectionString, BsonMapper mapper = null)
            : base(connectionString, mapper)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetLiteDatabaseConnection"/> class with the specified <see cref="Stream"/>.
        /// </summary>
        /// <param name="stream"><see cref="Stream"/> to host the database file in.</param>
        /// <param name="mapper">Custom <see cref="BsonMapper"/> to use.</param>
        /// <param name="logStream"><see cref="Stream"/> to push log updates to.</param>
        public WhippetLiteDatabaseConnection(Stream stream, BsonMapper mapper = null, Stream logStream = null)
            : base(stream, mapper, logStream)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetLiteDatabaseConnection"/> class with the specified <see cref="ILiteEngine"/>.
        /// </summary>
        /// <param name="engine">Existing <see cref="ILiteEngine"/> instance to use.</param>
        /// <param name="mapper">Custom <see cref="BsonMapper"/> to use.</param>
        /// <param name="disposeOnClose">If <see langword="true"/>, will dispose of <paramref name="engine"/> on closing.</param>
        public WhippetLiteDatabaseConnection(ILiteEngine engine, BsonMapper mapper = null, bool disposeOnClose = true)
            : base(engine, mapper, disposeOnClose)
        { }
    }
}
