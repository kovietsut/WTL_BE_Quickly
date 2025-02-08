namespace Infrastructure.Configurations
{
    public class DatabaseSettings
    {
        public string? DBProvider { get; set; }
        public string? ConnectionString { get; set; }
        public string? ConnectionHangfireString { get; set; }
        public string? DatabaseName { get; set; }
    }
}
