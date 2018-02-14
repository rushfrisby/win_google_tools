using Microsoft.Win32;
using System;
using System.Diagnostics;

namespace Google_Docs
{
    class Program
    {
        static void Main(string[] args)
        {
            var email = "";
            var folder = "";

            if (args?.Length > 0)
            {
                email = args[0].Trim();
            }
            if (args?.Length > 1)
            {
                folder = args[1].Trim();
            }

            var url = "https://docs.google.com/document/create";

            if (!string.IsNullOrWhiteSpace(email))
            {
                url = $"https://www.google.com/accounts/AccountChooser?Email={email}&continue={url}";
            }

            if (!string.IsNullOrWhiteSpace(folder))
            {
                url = $"{url}?folder={folder}";
            }

            var startInfo = new ProcessStartInfo(GetDefaultBrowserPath())
            {
                Arguments = url,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true,
                WindowStyle = ProcessWindowStyle.Hidden
            };

            var process = new Process()
            {
                StartInfo = startInfo,
                EnableRaisingEvents = true
            };
            process.Start();
        }

        private static string GetDefaultBrowserPath()
        {
            var urlAssociation = @"Software\Microsoft\Windows\Shell\Associations\UrlAssociations\http";
            var browserPathKey = @"$BROWSER$\shell\open\command";

            try
            {
                string progId;

                //Read default browser path from userChoiceLKey
                using (var userChoiceKey = Registry.CurrentUser.OpenSubKey(urlAssociation + @"\UserChoice", false))
                {
                    //If user choice was not found, try machine default
                    if (userChoiceKey == null)
                    {
                        //Read default browser path from Win XP registry key, if not try Win Vista (and newer) registry key
                        var browserKey = Registry.ClassesRoot.OpenSubKey(@"HTTP\shell\open\command", false) ?? Registry.CurrentUser.OpenSubKey(urlAssociation, false);

                        if (browserKey == null)
                        {
                            return "";
                        }

                        var path = CleanBrowserPath(browserKey.GetValue(null) as string);
                        browserKey.Close();
                        return path;
                    }

                    // user defined browser choice was found
                    progId = (userChoiceKey.GetValue("ProgId").ToString());
                }

                // now look up the path of the executable
                var concreteBrowserKey = browserPathKey.Replace("$BROWSER$", progId);
                using (var kp = Registry.ClassesRoot.OpenSubKey(concreteBrowserKey, false))
                {
                    return CleanBrowserPath(kp.GetValue(null) as string);
                }
            }
            catch (Exception)
            {
                return "";
            }
        }

        private static string CleanBrowserPath(string browserPath)
        {
            //If browser path was found, clean it
            if (!string.IsNullOrWhiteSpace(browserPath))
            {
                //Remove quotation marks
                browserPath = browserPath.ToLower().Replace("\"", "");

                //Cut off optional parameters
                if (!browserPath.EndsWith("exe"))
                {
                    browserPath = browserPath.Substring(0, browserPath.LastIndexOf(".exe") + 4);
                }
            }
            return browserPath;
        }
    }
}
