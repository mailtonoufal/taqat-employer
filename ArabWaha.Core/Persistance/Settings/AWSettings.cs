
// Helpers/Settings.cs This file was automatically added when you installed the Settings Plugin. If you are not using a PCL then comment this file back in to use it.
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace ArabWaha.Persistance.Login
{
    /// <summary>
    /// This is the Settings static class that can be used in your Core solution or in any
    /// of your client applications. All settings are laid out the same exact way with getters
    /// and setters. 
    /// </summary>
    public static class AWSettings
    {
        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }

        #region Setting Constants

        private const string ApplicationConnectionIdKey = "application_connection_id";
        private static readonly string ApplicationConnectionIdDefault = string.Empty;

        #endregion


        public static string ApplicationConnectionId
        {
            get
            {
                return AppSettings.GetValueOrDefault<string>(ApplicationConnectionIdKey, ApplicationConnectionIdDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue<string>(ApplicationConnectionIdKey, value);
            }
        }

    }
}