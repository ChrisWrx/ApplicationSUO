namespace ApplicationSUOWeb
{
    public class ApiSettings
    {
        public ApiSettings(string apiSettings)
        {
            BaseUrl = apiSettings;
        }
        public string BaseUrl { get; set; }
    }
}
