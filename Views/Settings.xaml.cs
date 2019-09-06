using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace YAPPA.Views
{
    public class Settings : Window
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}