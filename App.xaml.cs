using Avalonia;
using Avalonia.Markup.Xaml;

namespace YAAPA
{
    public class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }
   }
}