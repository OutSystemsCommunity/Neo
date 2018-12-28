using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using Xamarin.Forms;

using DiveLog.Models;
using DiveLog.Services;
using DiveLog.Utility;

namespace DiveLog.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public IDataStore<Item> DataStore => DependencyService.Get<IDataStore<Item>>() ?? new MockDataStore();

        protected bool IsDark = false;
        public Color BackgroundColor { get; protected set; }
        public Color TextColor { get; protected set; }
        public Color ButtonBackgroundColor { get; protected set; }
        public Color ButtonTextColor { get; protected set; }

        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        string title = string.Empty;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName]string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
            {
                return false;
            }
            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        protected void SetTheme()
        {
            DebugLogger.Log();

            if (Application.Current.Properties.ContainsKey(Constants.THEME_KEY))
            {
                var theme = Application.Current.Properties[Constants.THEME_KEY] as string;
                if (theme.Equals(Constants.DARK_THEME_VALUE))
                {
                    IsDark = true;
                }
            }

            if (IsDark)
            {
                BackgroundColor = Color.Black;
                TextColor = Color.White;
                ButtonBackgroundColor = Color.White;
                ButtonTextColor = Color.Blue;
            }
            else
            {
                BackgroundColor = Color.White;
                TextColor = Color.Black;
                ButtonBackgroundColor = Color.Blue;
                ButtonTextColor = Color.White;
            }
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
            {
                return;
            }
            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
