using System;

using DiveLog.Models;
using DiveLog.Utility;

namespace DiveLog.ViewModels
{
    public class DiveDetailViewModel : BaseViewModel
    {
        public Dive Dive { get; set; }

        public DiveDetailViewModel(Dive dive = null)
        {
            DebugLogger.Log();

            Title = dive?.Location + " - " + dive?.Date.ToShortDateString();
            Dive = dive;
        }
    }
}
