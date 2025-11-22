namespace Clase01
{
    public partial class MainPage : ContentPage
    {
        int numero1 = 0;
        int numero2 = 0;
        int resultado = 0;

        public MainPage()
        {
            InitializeComponent();
            BtnSumar.Clicked += BtnSumar_Clicked;
            BtnRestar.Clicked += BtnRestar_Clicked;
            BtnMultiplicar.Clicked += BtnMultiplicar_Clicked;
            BtnDividir.Clicked += BtnDividir_Clicked;
        }

        private void BtnDividir_Clicked(object? sender, EventArgs e)
        {
            if (int.TryParse(TxtNumero1.Text, out numero1) && int.TryParse(TxtNumero2.Text, out numero2))
            {
                if (numero2 == 0)
                {
                    LblResultado.Text = "Err: División por 0";
                }
                else
                {
                    resultado = numero1 / numero2;
                    LblResultado.Text = "El resultado es: " + resultado.ToString();
                }
            }
            else
            {
                LblResultado.Text = "Por favor, ingrese números válidos.";
            }
        }

        private void BtnMultiplicar_Clicked(object? sender, EventArgs e)
        {
            if (int.TryParse(TxtNumero1.Text, out numero1) && int.TryParse(TxtNumero2.Text, out numero2))
            {
                resultado = numero1 * numero2;
                LblResultado.Text = "El resultado es: " + resultado.ToString();
            }
            else
            {
                LblResultado.Text = "Por favor, ingrese números válidos.";
            }
        }

        private void BtnRestar_Clicked(object? sender, EventArgs e)
        {
            if (int.TryParse(TxtNumero1.Text, out numero1) && int.TryParse(TxtNumero2.Text, out numero2))
            {
                resultado = numero1 - numero2;
                LblResultado.Text = "El resultado es: " + resultado.ToString();
            }
            else
            {
                LblResultado.Text = "Por favor, ingrese números válidos.";
            }
        }

        private void BtnSumar_Clicked(object? sender, EventArgs e)
        {
            if (int.TryParse(TxtNumero1.Text, out numero1) && int.TryParse(TxtNumero2.Text, out numero2))
            {
                resultado = numero1 + numero2;
                LblResultado.Text = "El resultado es: " + resultado.ToString();
            }
            else
            {
                LblResultado.Text = "Por favor, ingrese números válidos.";
            }

        }
    }

}
