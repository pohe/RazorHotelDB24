namespace RazorHotelDB24.Services
{
    public class Connection
    {
        protected String connectionString = Secret.ConnectionString;
        //public IConfiguration Configuration { get; }

        //public Connection(IConfiguration configuration)
        //{
        //    connectionString = Secret.ConnectionString;
        //    Configuration = configuration;
        //    //connectionString = Configuration["ConnectionStrings:DefaultConnection"];
        //}

    }
}
