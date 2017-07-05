using Xamarin.Forms;

namespace ArabWaha.Common
{
    public class Constants
    {
        public static string NSTACK_APPID = "f62a6QY85fo8s52gXEi3OQ1LIwjtdEXxKpyf";
        public static string NSTACK_RESTKEY = "cVjZMkF2VslG5F7qNjGAaj6pGoofiADEt80E";
        public static string signUpUrl = "https://www.taqat.sa/web/guest/individualregistration";
        public static string DevicePlatform = Device.RuntimePlatform == Device.Android ? "android" : "iPhone";
#if DEBUG
        public static bool IsDebugRtl = false;
#else
        public static bool IsDebugRtl = false;
#endif

        //#if __IOS__
        //        DevicePlatform= "iPhone";
        //#endif

        public static bool IsGuest = false;
        public static bool IsRtl;
        public static string AcceptLanguage => IsRtl ? "AR" : "EN";
        public static bool IsStaticDataRequired = true;

	}
}
