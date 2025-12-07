using Microsoft.Maui.Controls;

namespace CalculadoraIMCApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new Views.MainPage();
        }
    }
}
