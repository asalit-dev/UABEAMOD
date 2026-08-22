using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System;
using System.Globalization;

namespace UABEAvalonia
{
    public partial class LzmaSizeWindow : Window
    {
        public LzmaSizeWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
            btnOk.Click += BtnOk_Click;
            btnCancel.Click += BtnCancel_Click;
        }

        private async void BtnOk_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            if (!long.TryParse(boxFinalSize.Text, NumberStyles.None, CultureInfo.InvariantCulture, out long finalSize) || finalSize <= 0)
            {
                await MessageBoxUtil.ShowDialog(this, "Error", "Final size must be a positive decimal number of bytes.");
                return;
            }

            Close(finalSize);
        }

        private void BtnCancel_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            Close(null);
        }
    }
}

