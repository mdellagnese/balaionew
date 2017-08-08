// Helpers/Settings.cs
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace BalaioCulturalNew.Helpers
{
	/// <summary>
	/// This is the Settings static class that can be used in your Core solution or in any
	/// of your client applications. All settings are laid out the same exact way with getters
	/// and setters. 
	/// </summary>
	public static class Settings
	{
		private static ISettings AppSettings
		{
			get
			{
				return CrossSettings.Current;
			}
		}

		#region Setting Constants

		private const string AccessTokenKey = "access_token_key";
        private const string LastEmailKey = "last_email_key";
        private const string IsLoggedInKey = "is_logged_in_key";
        
        private static readonly string SettingsDefault = string.Empty;

        #endregion


        public static string LastEmail
        {
            get
            {
                return AppSettings.GetValueOrDefault(LastEmailKey, SettingsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(LastEmailKey, value);
            }
        }

        public static string AccessToken
		{
			get
			{
				return AppSettings.GetValueOrDefault(AccessTokenKey, SettingsDefault);
			}
			set
			{
				AppSettings.AddOrUpdateValue(AccessTokenKey, value);
			}
		}

        public static string IsLoggedIn
        {
            get
            {
                return AppSettings.GetValueOrDefault(IsLoggedInKey, SettingsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(IsLoggedInKey, value);
            }
        }
    }
}