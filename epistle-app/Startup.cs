namespace epistle_app
{
    public class Startup
    {
        public static string CnnString { get; set; }
        public IConfiguration _configuration { get; }
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
            CnnString = _configuration.GetConnectionString("Akali");
        }
    }
}
