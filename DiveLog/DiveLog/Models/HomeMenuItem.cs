
namespace DiveLog.Models
{
    public enum MenuItemType
    {
        Dives,
        Settings, 
        Logout
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
