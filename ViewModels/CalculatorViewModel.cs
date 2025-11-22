using Clase01.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Clase01.ViewModels
{
    // Clase base para implementar INotifyPropertyChanged de forma sencilla
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class CalculatorViewModel : BaseViewModel
    {
        private string _currentCalculation = "0";
        private string _expression = string.Empty;
        private CalculatorModel _model;

        // Propiedad que la Vista enlaza (Label.Text)
        public string CurrentCalculation
        {
            get => _currentCalculation;
            set
            {
                if (_currentCalculation != value)
                {
                    _currentCalculation = value;
                    OnPropertyChanged(nameof(CurrentCalculation));
                }
            }
        }

        // Comandos para manejar la interacción de la Vista
        public ICommand CommandNumber { get; private set; }
        public ICommand CommandOperation { get; private set; }

        public CalculatorViewModel()
        {
            _model = new CalculatorModel();
            CommandNumber = new Command<string>(OnNumberPressed);
            CommandOperation = new Command<string>(OnOperationPressed);
        }

        // Lógica para manejar botones numéricos y el punto decimal
        private void OnNumberPressed(string number)
        {
            if (CurrentCalculation == "0" || CurrentCalculation == "Error")
            {
                CurrentCalculation = number;
                _expression = number;
            }
            else
            {
                CurrentCalculation += number;
                _expression += number;
            }
        }

        // Lógica para manejar operaciones (AC, +, -, =, etc.)
        private void OnOperationPressed(string operation)
        {
            if (operation == "AC")
            {
                CurrentCalculation = "0";
                _expression = string.Empty;
                return;
            }

            if (operation == "DEL" && CurrentCalculation.Length > 1)
            {
                // Elimina el último caracter en la pantalla y en la expresión
                CurrentCalculation = CurrentCalculation.Substring(0, CurrentCalculation.Length - 1);
                _expression = _expression.Substring(0, _expression.Length - 1);
                return;
            }
            else if (operation == "DEL" && CurrentCalculation.Length == 1)
            {
                CurrentCalculation = "0";
                _expression = string.Empty;
                return;
            }

            if (operation == "=")
            {
                CalculateResult();
                return;
            }

            // Para operadores (+, -, ×, ÷, %)
            if (!string.IsNullOrEmpty(_expression) && !IsLastCharOperator(_expression))
            {
                _expression += operation;
                CurrentCalculation += operation;
            }
            else if (IsLastCharOperator(_expression))
            {
                // Reemplazar el último operador si se presiona otro
                _expression = _expression.Substring(0, _expression.Length - 1) + operation;
                CurrentCalculation = CurrentCalculation.Substring(0, CurrentCalculation.Length - 1) + operation;
            }
        }

        private void CalculateResult()
        {
            if (string.IsNullOrEmpty(_expression)) return;

            // Llama al Modelo para que evalúe la expresión
            double result = _model.EvaluateExpression(_expression);

            if (double.IsNaN(result))
            {
                CurrentCalculation = "Error";
            }
            else
            {
                CurrentCalculation = result.ToString();
                _expression = result.ToString();
            }
        }

        private bool IsLastCharOperator(string s)
        {
            if (string.IsNullOrEmpty(s)) return false;
            char lastChar = s[s.Length - 1];
            return lastChar == '+' || lastChar == '-' || lastChar == '×' || lastChar == '÷' || lastChar == '%';
        }
    }
}