using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DiveLog.Utility
{
    [ContentProperty("Member")]
    public class StaticExtension : IMarkupExtension
    {
        private StaticExtension()
        {
        }

        public string Member { get; set; }

        object IMarkupExtension.ProvideValue(IServiceProvider serviceProvider)
        {
            DebugLogger.Log("Not sure what implementation needs to go here...");
            return null;
        }
    }
}
