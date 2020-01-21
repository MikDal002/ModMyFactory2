using Avalonia;
using Avalonia.Markup.Xaml;
using ModMyFactory.Win32;
using ModMyFactoryGUI.Controls;
using ModMyFactoryGUI.Helpers;
using System;

namespace ModMyFactoryGUI.Views
{
    partial class AboutWindow : WindowBase
    {
        public AboutWindow()
        {
            this.InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);

            // Need to disable resize buttons manually on Windows since Avalonia doesn't.
            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
            {
                var handle = PlatformImpl.Handle.Handle;
                var styles = User32.GetWindowStyles(handle);
                styles = styles.UnsetFlag(WindowStyles.MaximizeBox | WindowStyles.MinimizeBox);
                User32.SetWindowStyles(handle, styles);
            }
        }
    }
}
