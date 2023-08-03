using System.ComponentModel.DataAnnotations;

namespace RRHHCapucasCoffe.Validators
{
    public class PrimeraLetraMayusAtribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                return true;
            }

            var primeraLetra = value.ToString()[0].ToString();

            if (primeraLetra != primeraLetra.ToUpper())
            {
                return false;
            }

            return true;
        }
    }
}
