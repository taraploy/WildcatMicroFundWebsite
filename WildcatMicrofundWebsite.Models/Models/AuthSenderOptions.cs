namespace WMF.Models
{
    public class AuthSenderOptions
    {
        private readonly string user = "Wildcat Microfund"; // The name you want to show up on your email
                                           // Make sure the string passed in below matches your API Key
        private readonly string key = "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";
        public string SendGridUser { get { return user; } }
        public string SendGridKey { get { return key; } }
    }
}
