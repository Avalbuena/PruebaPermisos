namespace Permissions.Infrastructure
{
    /// <summary>
    /// Defines error codes.
    /// </summary>
    public enum ErrorCodes
    {
        /// <summary>
        /// Bad request.
        /// </summary>
        BadRequest = 400,

        /// <summary>
        /// Item not found.
        /// </summary>
        NotFound = 404,

        /// <summary>
        /// Internal server error.
        /// </summary>
        InternalServerError = 500
    }
}
