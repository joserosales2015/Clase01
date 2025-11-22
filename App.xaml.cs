using Clase01.Views;
using System.Runtime.CompilerServices;

namespace Clase01
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new CalculatorPage(); // AppShell();
        }

        protected override Window CreateWindow(IActivationState activationState)
        {
            var window = base.CreateWindow(activationState);
            window.Width = 400;
            window.Height = 600;
            return window;
        }
    }
}
