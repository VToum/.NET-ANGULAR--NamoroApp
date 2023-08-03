namespace NamoroApp.Errors
{
    public class ApiException
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public string Messsage { get; }
        public string Details { get; set; }

        public ApiException(int statusCode, string messsage, string details)
        {
            StatusCode = statusCode;
            Messsage = messsage;
            Details = details;
        }
    }
}
