using Newtonsoft.Json;

namespace Permissions.Api.Extensions
{
    public class ErrorResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorResponse"/> class.
        /// </summary>
        /// <param name="statusCode">Error code.</param>
        /// <param name="message">Error message.</param>
        public ErrorResponse(int statusCode, string message)
        {
            StatusCode = statusCode;
            Error = message;
        }

        /// <summary>
        /// Gets the error code.
        /// </summary>
        public int StatusCode { get; }

        /// <summary>
        /// Gets the error message.
        /// </summary>
        public string Error { get; }

        /// <summary>
        /// Gets or sets error detail.
        /// </summary>
        public string ErrorDetail { get; set; }

        /// <inheritdoc />
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
