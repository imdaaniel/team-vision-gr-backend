namespace TeamVisionGR.Application.Settings
{
    public class AppSettings
    {
        public string AppUrl { get; set; }
        public string ApiUrl { get; set; }
        public ConnectionStrings ConnectionStrings { get; set; }
        public Jwt Jwt { get; set; }
        public MailSettings Mail { get; set; }
    }

    public class ConnectionStrings
    {
        public string DefaultConnection { get; set; }
    }

    public class Jwt
    {
        public string Secret { get; set; }
    }
}