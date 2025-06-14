namespace SilveOakDemo.Models
{
    public class User
    {
        public int uid { get; set; }
        public string uname { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        public string pass { get; set; } = string.Empty;

        public int roleid { get; set; }
        public string profilephoto { get; set; } = string.Empty;

    }
}
