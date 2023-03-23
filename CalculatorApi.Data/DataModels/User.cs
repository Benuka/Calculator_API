namespace CalculatorApi.Data
{
    /// <summary>
	/// User data model.
	/// </summary>
	public class User
	{
        /// <summary>
        /// User name.
        /// </summary>
        public string UserName { get; set; } = string.Empty;

        /// <summary>
        /// User password hash string.
        /// </summary>
        public string PasswordHash { get; set; } = string.Empty;
    }
}

