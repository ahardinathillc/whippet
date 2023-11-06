using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Athi.Whippet.Data.Database.Microsoft
{
    /// <summary>
    /// Represents a generic key store provider for SQL Server.
    /// </summary>
    public class WhippetSqlServerColumnEncryptionKeyStoreProvider
    {
        /// <summary>
        /// Gets or sets the internal <see cref="SqlColumnEncryptionKeyStoreProvider"/> object.
        /// </summary>
        private SqlColumnEncryptionKeyStoreProvider InternalProvider
        { get; set; }

        /// <summary>
        /// Specifies the lifespan of the decrypted column encryption key in the cache.
        /// </summary>
        public TimeSpan? ColumnEncryptionKeyCacheTtl
        {
            get
            {
                return InternalProvider.ColumnEncryptionKeyCacheTtl;
            }
            set
            {
                InternalProvider.ColumnEncryptionKeyCacheTtl = value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetSqlServerColumnEncryptionKeyStoreProvider"/> class with the specified <see cref="SqlColumnEncryptionCertificateStoreProvider"/> object.
        /// </summary>
        /// <param name="provider"><see cref="SqlColumnEncryptionKeyStoreProvider"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public WhippetSqlServerColumnEncryptionKeyStoreProvider(SqlColumnEncryptionKeyStoreProvider provider)
        {
            if (provider == null)
            {
                throw new ArgumentNullException(nameof(provider));
            }
            else
            {
                InternalProvider = provider;
            }
        }

        /// <summary>
        /// Decrypts the specified encrypted value of a column encryption key. The encrypted value is expected to be encrypted using the column master key with the specified key path and using the specified algorithm.
        /// </summary>
        /// <param name="masterKeyPath">The master key path.</param>
        /// <param name="encryptionAlgorithm">The encryption algorithm.</param>
        /// <param name="encryptedColumnEncryptionKey">The encrypted column encryption key.</param>
        /// <returns>An array of <see cref="byte"/> objects representing the decrypted column encryption key.</returns>
        public virtual byte[] DecryptColumnEncryptionKey(string masterKeyPath, string encryptionAlgorithm, byte[] encryptedColumnEncryptionKey)
        {
            return InternalProvider.DecryptColumnEncryptionKey(masterKeyPath, encryptionAlgorithm, encryptedColumnEncryptionKey);
        }

        /// <summary>
        /// Encrypts a column encryption key using the column master key with the specified key path and using the specified algorithm.
        /// </summary>
        /// <param name="masterKeyPath">The master key path.</param>
        /// <param name="encryptionAlgorithm">The encryption algorithm.</param>
        /// <param name="columnEncryptionKey">The plaintext column encryption key.</param>
        /// <returns>An array of <see cref="byte"/> objects representing the encrypted column encryption key.</returns>
        public virtual byte[] EncryptColumnEncryptionKey(string masterKeyPath, string encryptionAlgorithm, byte[] columnEncryptionKey)
        {
            return InternalProvider.EncryptColumnEncryptionKey(masterKeyPath, encryptionAlgorithm, columnEncryptionKey);
        }

        /// <summary>
        /// When implemented in a derived class, digitally signs the column master key metadata with the column master key referenced by the masterKeyPath parameter. The input values used to generate the signature should be the specified values of the <paramref name="masterKeyPath"/> and <paramref name="allowEnclaveComputations"/> parameters.
        /// </summary>
        /// <param name="masterKeyPath">The column master key path.</param>
        /// <param name="allowEnclaveComputations"><see langword="true"/> to indicate that the column master key supports enclave computations; otherwise, <see langword="false"/>.</param>
        /// <returns>The signature of the column master key metadata.</returns>
        /// <exception cref="NotImplementedException" />
        public virtual byte[] SignColumnMasterKeyMetadata(string masterKeyPath, bool allowEnclaveComputations)
        {
            return InternalProvider.SignColumnMasterKeyMetadata(masterKeyPath, allowEnclaveComputations);
        }

        /// <summary>
        /// When implemented in a derived class, this method is expected to verify the specified signature is valid for the column master key with the specified key path and the specified enclave behavior.
        /// </summary>
        /// <param name="masterKeyPath">The column master key path.</param>
        /// <param name="allowEnclaveComputations">Specifies whether the column master key supports enclave computations.</param>
        /// <param name="signature">The signature of the column master key metadata.</param>
        /// <returns><see langword="true"/> if the specified signature is valid; otherwise, <see langword="false"/>.</returns>
        /// <exception cref="NotImplementedException" />
        public virtual bool VerifyColumnMasterKeyMetadata(string masterKeyPath, bool allowEnclaveComputations, byte[] signature)
        {
            return InternalProvider.VerifyColumnMasterKeyMetadata(masterKeyPath, allowEnclaveComputations, signature);
        }

        public static implicit operator WhippetSqlServerColumnEncryptionKeyStoreProvider(SqlColumnEncryptionKeyStoreProvider provider)
        {
            return (provider == null) ? null : new WhippetSqlServerColumnEncryptionKeyStoreProvider(provider);
        }

        public static implicit operator SqlColumnEncryptionKeyStoreProvider(WhippetSqlServerColumnEncryptionKeyStoreProvider provider)
        {
            return (provider == null) ? null : provider.InternalProvider;
        }
    }
}
