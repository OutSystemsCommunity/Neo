using System;
namespace DiveLog.Utility
{
    public static class Constants
    {
        public const string LIGHT_THEME_VALUE = "LIGHT";
        public const string DARK_THEME_VALUE = "DARK";
        public const string THEME_KEY = "theme";

        public static DateTime MAX_DATE() { return new DateTime(2020, 12, 31); }
        public static DateTime MIN_DATE() { return new DateTime(2017, 12, 31); }
        public static string[] Locations() { return new string[] { "OV", "CW7", "Other"}; }
    }
}
