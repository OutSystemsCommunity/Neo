using System;

using DiveLog.Models;

namespace DiveLog.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Dive Dive { get; set; }
        public ItemDetailViewModel(Dive dive = null)
        {
            Title = dive?.Text;
            Dive = dive;
        }
    }
}
