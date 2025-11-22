using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase01.Models
{
    public class CalculatorModel
    {
        public double EvaluateExpression(string expression)
        {
            try
            {
                var dataTable = new System.Data.DataTable();
                var result = dataTable.Compute(expression.Replace("×", "*").Replace("÷", "/"), null);
                return Convert.ToDouble(result);
            }
            catch (Exception)
            {
                return double.NaN;
            }
        }
    }
}
