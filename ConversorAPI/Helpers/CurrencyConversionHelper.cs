namespace ConversorAPI.Helpers
{
    public class CurrencyConversionHelper
    {

        public double DivideResult(double Amount, double IC)
        {
            double result = Amount / IC;
            return result;
        }

        public double MultiplicateResult(double Amount, double IC)
        {
            double result = Amount * IC;
            return result;
        }
    }
}
