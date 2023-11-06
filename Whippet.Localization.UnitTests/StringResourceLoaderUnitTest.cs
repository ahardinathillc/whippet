using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Athi.Whippet.Localization.UnitTests
{
    /// <summary>
    /// Unit tests for the <see cref="LocalizedStringResourceLoader"/> class. This class cannot be inherited.
    /// </summary>
    [TestClass]
    public sealed class StringResourceLoaderUnitTest
    {
        private const string RESOURCE_FILE_NAME = "Athi.Whippet.Localization.UnitTests.UnitTests";
        private const string RESOURCE_ENTRY = "____UnitTest____";

        /// <summary>
        /// Initializes a new instance of the <see cref="StringResourceLoaderUnitTest"/> class with no arguments.
        /// </summary>
        public StringResourceLoaderUnitTest()
        { }

        /// <summary>
        /// Tests the <see cref="LocalizedStringResourceLoader.GetResource(string, string, IEnumerable{object}, CultureInfo)"/> method to see if a resource can be loaded successfully.
        /// </summary>
        [TestMethod]
        public void GetResourceTest()
        {
            Assert.IsFalse(String.IsNullOrWhiteSpace(LocalizedStringResourceLoader.GetResource(RESOURCE_FILE_NAME, RESOURCE_ENTRY)));
        }

        /// <summary>
        /// Tests the <see cref="LocalizedStringResourceLoader.GetResource(string, string, IEnumerable{object}, CultureInfo)"/> method to see if a resource can be loaded successfully using a different culture.
        /// </summary>
        [TestMethod]
        public void GetResourceWithDifferentLocaleTest()
        {
            Assert.IsFalse(String.IsNullOrWhiteSpace(LocalizedStringResourceLoader.GetResource(RESOURCE_FILE_NAME, RESOURCE_ENTRY, culture: new CultureInfo("fr-FR"), throwOnCultureNotFound: true)));
        }
    }
}
