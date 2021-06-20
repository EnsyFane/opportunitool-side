namespace OpportunitoolApi.Errors
{
    /// <summary>
    /// Defines an error.
    /// </summary>
    public class Error
    {
        public bool External { get; set; }

        public string ErrorCode { get; set; }

        public string ErrorMessage { get; set; }
    }
}