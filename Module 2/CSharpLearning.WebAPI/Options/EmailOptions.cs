namespace CSharpLearning.WebAPI.Options
{
    public class EmailOptions
    {
        public string Smtp { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public int Port { get; set; }
        public bool UseSsl { get; set; }
    }
}
