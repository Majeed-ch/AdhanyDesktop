using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdhanyDesktop.Services
{
    class AppSettingsService
    {
        private const string RegistryKeyPath = @"Software\Microsoft\Windows\CurrentVersion\Run";
        private const string AppName = "AdhanyDesktop";

        /// <summary>
        /// Checks if the app is set to run on startup by checking the registry.
        /// </summary>
        /// <returns>True if run on startup is enabled, false otherwise</returns>
        public static bool IsStartupEnabled()
        {
            using (var key = Registry.CurrentUser.OpenSubKey(RegistryKeyPath, true))
            {
                if (key == null)
                    return false;

                return key.GetValue(AppName) != null;
            }
        }

        /// <summary>
        /// Sets the app to run on startup by adding a registry key to the registry.
        /// </summary>
        /// <param name="runOnStartup">Indicates if the app should run on startup or not.</param>
        public static void SetRunOnStartup(bool runOnStartup)
        {
            using (var key = Registry.CurrentUser.OpenSubKey(RegistryKeyPath, true))
            {
                if (key == null)
                    return;
                if (runOnStartup)
                {
                    key.SetValue(AppName, Application.ExecutablePath.ToString());
                }
                else
                {
                    key.DeleteValue(AppName, false);
                }
            }
        }

        /// <summary>
        /// Gets the path of the app in the registry.
        /// </summary>
        /// <returns>The value of the registry key that runs the app on startup</returns>
        public static string? GetStartupKeyPath()
        {
            using (var key = Registry.CurrentUser.OpenSubKey(RegistryKeyPath, true))
            {
                if (key == null)
                    return "";

                return Convert.ToString(key.GetValue(AppName));
            }
        }
    }
}
