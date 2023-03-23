namespace CalculatorApi.Model
{
    /// <summary>
    /// User model.
    /// </summary>
	public class UserDto
	{
        /// <summary>
        /// User name.
        /// </summary>
        public required string UserName { get; set; }

        /// <summary>
        /// User password.
        /// </summary>
        public required string Password { get; set; }
    }
}

