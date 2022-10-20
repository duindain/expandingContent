﻿using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ExpandingContent
{
	public class BindableBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] String propertyName = null)
        {
            if (Equals(storage, value))
            {
                return false;
            }

            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler eventHandler = this.PropertyChanged;
            if (eventHandler != null)
            {
                eventHandler(this, new PropertyChangedEventArgs(propertyName));
                var now = DateTime.Now;
                //Logger.WriteLine($"BindableBase.OnPropertyChanged: VM:{TypeDescriptor.GetClassName(this)}, propertyName:{propertyName}, timestamp{now.ToString("hh:mm:ss")}");
            }
        }
    }
}
