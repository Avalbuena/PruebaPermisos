using System;

namespace Permissions.Infrastructure
{
    /// <summary>
    /// Generic command result.
    /// </summary>
    public class CommandResult
    {
        private CommandResult() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandResult"/> class.
        /// </summary>
        /// <param name="failureReason">Failure reason.</param>
        private CommandResult(string failureReason)
        {
            FailureReason = failureReason;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandResult"/> class.
        /// </summary>
        /// <param name="code">Error code.</param>
        /// <param name="failureReason">Failure reason.</param>
        private CommandResult(int code, string failureReason)
        {
            FailureReason = failureReason;
            Code = code;
        }

        /// <summary>
        /// Gets the failure reason.
        /// </summary>
        public string FailureReason { get; }

        /// <summary>
        /// Gets the data.
        /// </summary>
        public dynamic Data { get; set; }

        /// <summary>
        /// Gets the error code. Default error code 500 - Internal Server Error.
        /// </summary>
        public int Code { get; } = 500;

        /// <summary>
        /// Gets a value indicating the result of the command.
        /// </summary>
        public bool IsSuccess => string.IsNullOrWhiteSpace(FailureReason);

        /// <summary>
        /// Creates a new successful command result.
        /// </summary>
        /// <returns>Successful command result.</returns>
        public static CommandResult Success() => new CommandResult();

        /// <summary>
        /// Creates a new success instance of the <see cref="CommandResult"/> class.
        /// </summary>
        /// <param name="data">Data.</param>
        /// <returns>Successful command result.</returns>
        public static CommandResult Success(dynamic data)
        {
            return new CommandResult
            {
                Data = data
            };
        }

        /// <summary>
        /// Creates a new fail instance of the <see cref="CommandResult"/> class.
        /// </summary>
        /// <param name="reason">Failure reason.</param>
        /// <returns>Successful command result.</returns>
        public static CommandResult Fail(string reason)
        {
            return new CommandResult(reason);
        }

        /// <summary>
        /// Creates a new fail instance of the <see cref="CommandResult"/> class.
        /// </summary>
        /// <param name="errorCode">Error code.</param>
        /// <param name="reason">Failure reason.</param>
        /// <returns>Successful command result.</returns>
        public static CommandResult Fail(ErrorCodes errorCode, string reason)
        {
            return new CommandResult(Convert.ToInt32(errorCode), reason);
        }

        /// <summary>
        /// Overrides the bool operator.
        /// </summary>
        /// <param name="result">Command result.</param>
        public static implicit operator bool(CommandResult result)
        {
            return result.IsSuccess;
        }
    }
}
