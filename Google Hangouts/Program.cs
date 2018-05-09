using System;
using System.Diagnostics;

namespace Google_Hangouts
{
    class Program
    {
        static void Main(string[] args)
        {
            var email = "";
            var name = "";

            if (args?.Length > 0)
            {
                email = args[0].Trim();
            }
            if (args?.Length > 1)
            {
                name = args[1].Trim();
            }

            if (string.IsNullOrWhiteSpace(name))
            {
                Console.Write("Hangout Name: ");
                name = Console.ReadLine().Trim();
            }

            if (string.IsNullOrWhiteSpace(email))
            {
                Console.Write("Email Address: ");
                email = Console.ReadLine().Trim();
            }

            if (!string.IsNullOrWhiteSpace(name))
            {
                if (!string.IsNullOrWhiteSpace(email))
                {
                    Process.Start($"https://www.google.com/accounts/AccountChooser?Email={email}&continue=https://hangouts.google.com/hangouts/_/{name}");
                }
                else
                {
                    Process.Start($"https://hangouts.google.com/hangouts/_/lsq.com/{name}");
                }
                
            }
        }
    }
}
