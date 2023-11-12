using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager
{
    /// <summary>
    /// Represents a JSON response from the Multichannel Order Manager (M.O.M.) REST API. This class cannot be inherited.
    /// </summary>
    public sealed class MultichannelOrderManagerJsonResponse
    {
        private const string JP__IS_SUCCESS = "isSuccess";
        private const string JP__EXCEPTION = "exception";
        private const string JP__MESSAGE = "message";
        private const string JP__SEVERITY = "severity";
        private const string JP__VALUE = "value";

        /// <summary>
        /// Indicates whether the operation was successful.
        /// </summary>
        [JsonProperty(JP__IS_SUCCESS)]
        public bool IsSuccess
        { get; set; }

        /// <summary>
        /// Gets or sets the exception message that was returned by the server.
        /// </summary>
        [JsonProperty(JP__EXCEPTION)]
        public string Exception
        { get; set; }

        /// <summary>
        /// Gets or sets the message that was returned by the server.
        /// </summary>
        [JsonProperty(JP__MESSAGE)]
        public string Message
        { get; set; }

        /// <summary>
        /// Gets or sets the result serverity of the operation.
        /// </summary>
        [JsonProperty(JP__SEVERITY)]
        public string Severity
        { get; set; }

        /// <summary>
        /// Gets or sets the return value of the operation.
        /// </summary>
        [JsonProperty(JP__VALUE)]
        public string Value
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultichannelOrderManagerJsonResponse"/> class with no arguments.
        /// </summary>
        public MultichannelOrderManagerJsonResponse()
        { }

        /// <summary>
        /// Creates a new <see cref="MultichannelOrderManagerJsonResponse"/> object from the specified <see cref="JObject"/> instance.
        /// </summary>
        /// <param name="jObject"><see cref="JObject"/> instance to create a new <see cref="MultichannelOrderManagerJsonResponse"/> from.</param>
        /// <returns><see cref="MultichannelOrderManagerJsonResponse"/> object.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static MultichannelOrderManagerJsonResponse FromJObject(JObject jObject)
        {
            if (jObject == null)
            {
                throw new ArgumentNullException(nameof(jObject));
            }
            else
            {
                MultichannelOrderManagerJsonResponse response = null;

                if (jObject.HasValues)
                {
                    response = new MultichannelOrderManagerJsonResponse();

                    if (jObject[JP__IS_SUCCESS] != null)
                    {
                        response.IsSuccess = Convert.ToBoolean(Convert.ToString(jObject[JP__IS_SUCCESS]));
                    }

                    if (jObject[JP__EXCEPTION.ToLower()] != null)
                    {
                        response.Exception = Convert.ToString(jObject[JP__EXCEPTION]);
                    }

                    if (jObject[JP__MESSAGE.ToLower()] != null)
                    {
                        response.Message = Convert.ToString(jObject[JP__MESSAGE]);
                    }

                    if (jObject[JP__SEVERITY.ToLower()] != null)
                    {
                        response.Severity = Convert.ToString(jObject[JP__SEVERITY]);
                    }

                    if (jObject[JP__VALUE.ToLower()] != null)
                    {
                        response.Value = Convert.ToString(jObject[JP__VALUE]);
                    }
                }

                return response;
            }
        }
    }
}