namespace to_do_sth_with_attribute_dotnet
{
    public class AppSettings
    {
        public SystemInfo SystemInfo { get; set; }
    }

    public class SystemInfo
    {
        public string? SecretKey { get; set; }

        public string? AccessKey { get; set; }
    }
}
