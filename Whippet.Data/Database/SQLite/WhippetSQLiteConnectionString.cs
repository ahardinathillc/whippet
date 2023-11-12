using System;
using SQLite;

namespace Athi.Whippet.Data.Database.SQLite
{
    /// <summary>
    /// Represents a parsed connection string for SQLite.
    /// </summary>
    public class WhippetSQLiteConnectionString : SQLiteConnectionString
    {
        private const byte MAX_KEY_LEN_UB = 48;

        /// <summary>
        /// Constructs a new <see cref="WhippetSQLiteConnectionString"/> with all the data needed to open a <see cref="WhippetSQLiteConnection"/>.
        /// </summary>
        /// <param name="databasePath">Specifies the path to the database file.</param>
        /// <param name="storeDateTimeAsTicks">Specifies whether to store DateTime properties as ticks (true) or strings (false). You absolutely do want to store them as Ticks in all new projects. The value of false is only here for backwards compatibility. There is a *significant* speed advantage, with no down sides, when setting storeDateTimeAsTicks = true. If you use DateTimeOffset properties, it will be always stored as ticks regardingless the storeDateTimeAsTicks parameter.</param>
        public WhippetSQLiteConnectionString(string databasePath, bool storeDateTimeAsTicks = true)
            : base(databasePath, storeDateTimeAsTicks)
        { }

        /// <summary>
        /// Constructs a new <see cref="WhippetSQLiteConnectionString"/> with all the data needed to open a <see cref="WhippetSQLiteConnection"/>.
        /// </summary>
        /// <param name="databasePath">Specifies the path to the database file.</param>
        /// <param name="storeDateTimeAsTicks">Specifies whether to store DateTime properties as ticks (true) or strings (false). You absolutely do want to store them as Ticks in all new projects. The value of false is only here for backwards compatibility. There is a *significant* speed advantage, with no down sides, when setting storeDateTimeAsTicks = true. If you use DateTimeOffset properties, it will be always stored as ticks regardingless the storeDateTimeAsTicks parameter.</param>
        /// <param name="key">Specifies the encryption key to use on the database. Should be a <see cref="string"/> or a <see cref="byte"/>[].</param>
        /// <param name="preKeyAction">Executes prior to setting key for SQLCipher databases.</param>
        /// <param name="postKeyAction">Executes after setting key for SQLCipher databases.</param>
        /// <param name="vfsName">Specifies the Virtual File System to use on the database.</param>
        public WhippetSQLiteConnectionString(string databasePath, bool storeDateTimeAsTicks, object key = null, Action<SQLiteConnection> preKeyAction = null, Action<SQLiteConnection> postKeyAction = null, string vfsName = null)
            : base(databasePath, storeDateTimeAsTicks, TrimKey(key), preKeyAction, postKeyAction, vfsName)
        { }

        /// <summary>
        /// Constructs a new <see cref="WhippetSQLiteConnectionString"/> with all the data needed to open a <see cref="WhippetSQLiteConnection"/>.
        /// </summary>
        /// <param name="databasePath">Specifies the path to the database file.</param>
        /// <param name="openFlags">Flags controlling how the connection should be opened.</param>
        /// <param name="storeDateTimeAsTicks">Specifies whether to store DateTime properties as ticks (true) or strings (false). You absolutely do want to store them as Ticks in all new projects. The value of false is only here for backwards compatibility. There is a *significant* speed advantage, with no down sides, when setting storeDateTimeAsTicks = true. If you use DateTimeOffset properties, it will be always stored as ticks regardingless the storeDateTimeAsTicks parameter.</param>
        /// <param name="key">Specifies the encryption key to use on the database. Should be a <see cref="string"/> or a <see cref="byte"/>[].</param>
        /// <param name="preKeyAction">Executes prior to setting key for SQLCipher databases.</param>
        /// <param name="postKeyAction">Executes after setting key for SQLCipher databases.</param>
        /// <param name="vfsName">Specifies the Virtual File System to use on the database.</param>
        /// <param name="dateTimeStringFormat">Specifies the format to use when storing <see cref="DateTime"/> properties as strings.</param>
        /// <param name="storeTimeSpanAsTicks">Specifies whether to store TimeSpan properties as ticks (true) or strings (false). You absolutely do want to store them as Ticks in all new projects. The value of false is only here for backwards compatibility. There is a *significant* speed advantage, with no down sides, when setting storeTimeSpanAsTicks = true.</param>
        public WhippetSQLiteConnectionString(string databasePath, SQLiteOpenFlags openFlags, bool storeDateTimeAsTicks, object key = null, Action<SQLiteConnection> preKeyAction = null, Action<SQLiteConnection> postKeyAction = null, string vfsName = null, string dateTimeStringFormat = "yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff", bool storeTimeSpanAsTicks = true)
            : base(databasePath, openFlags, storeDateTimeAsTicks, TrimKey(key), preKeyAction, postKeyAction, vfsName, dateTimeStringFormat, storeTimeSpanAsTicks)
        { }

        /// <summary>
        /// Trims the specified encryption key to the maximum upper-bound length supported by SQLite.
        /// </summary>
        /// <param name="key">SQLite encryption key byte array.</param>
        /// <returns>Encryption key.</returns>
        private static object TrimKey(object key)
        {
            byte[] trimmedKey = null;

            if (key != null && (key is byte[]))
            {
                trimmedKey = (byte[])(key);

                if (trimmedKey.Length > MAX_KEY_LEN_UB)
                {
                    trimmedKey = new byte[MAX_KEY_LEN_UB];

                    for (int i = 0; i < MAX_KEY_LEN_UB; i++)
                    {
                        trimmedKey[i] = ((byte[])(key))[i];
                    }
                }

                key = trimmedKey;
            }

            return key;
        }
    }
}