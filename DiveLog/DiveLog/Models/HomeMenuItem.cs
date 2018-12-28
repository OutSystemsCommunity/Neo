using System;
using System.Collections.Generic;
using System.Text;

namespace DiveLog.Models
{
    public enum MenuItemType
    {
        Browse,
        Settings, 
        Logout
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
