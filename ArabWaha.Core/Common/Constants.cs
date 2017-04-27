namespace ArabWaha.Common
{
    public class Constants
    {
        public static string NSTACK_APPID = "f62a6QY85fo8s52gXEi3OQ1LIwjtdEXxKpyf";
        public static string NSTACK_RESTKEY = "cVjZMkF2VslG5F7qNjGAaj6pGoofiADEt80E";
        public static string signUpUrl = "https://www.taqat.sa/web/guest/individualregistration";

#if DEBUG
        public static bool IsDebugRtl = false;
#else
        public static bool IsDebugRtl = false;
#endif

#if __ANDROID__
        public static string Device = "android";
#endif
#if __IOS__
        public static string Device = "iPhone";
#endif

        public static bool IsGuest = true;
        public static bool IsRtl;
        public static string AcceptLanguage => IsRtl ? "AR" : "EN";
    }
}
