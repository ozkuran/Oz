using System.Collections.Generic;

namespace Oz.Algorithms.Math
{
    /// <summary>
    /// Calculates result of Polynomial At Given 'x' value
    /// </summary>
    public class CalculatePolynomial
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public CalculatePolynomial()
        {
            
        }

        public double calculate(List<double> _inputPolynomial, double x)
        {
            double result = 0.0;
            int size = _inputPolynomial.Count;
            foreach (var val in _inputPolynomial)
            {
                if(--size == 0){
                    result += val;
                }
                else{
                    result += (val * System.Math.Pow(x,size));
                }                
            }
            return result;
        }
    }
}
