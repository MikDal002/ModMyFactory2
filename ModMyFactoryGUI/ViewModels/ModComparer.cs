//  Copyright (C) 2020 Mathis Rech
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.

using System.Collections.Generic;
using System.ComponentModel;

namespace ModMyFactoryGUI.ViewModels
{
    internal abstract class ModComparer : NotifyPropertyChangedBase, IComparer<OnlineModViewModel>
    {
        public abstract string DisplayNameKey { get; }

        protected ModComparer()
        {
            // Technically we should unsubscribe from this however these object have
            // the same lifetime as the entire app so it doesn't really matter
            App.Current.Locales.UICultureChanged += (sender, e)
                => OnPropertyChanged(new PropertyChangedEventArgs(nameof(DisplayNameKey)));
        }

        public abstract int Compare(OnlineModViewModel first, OnlineModViewModel second);
    }

    internal sealed class AlphabeticalComparer : ModComparer
    {
        public override string DisplayNameKey => "Compare_Alphabetical";

        public override int Compare(OnlineModViewModel first, OnlineModViewModel second)
            => first.DisplayName.CompareTo(second.DisplayName);
    }

    internal sealed class DownloadCountComparer : ModComparer
    {
        public override string DisplayNameKey => "Compare_DownloadCount";

        public override int Compare(OnlineModViewModel first, OnlineModViewModel second)
            => second.DownloadCount.CompareTo(first.DownloadCount);
    }
}
