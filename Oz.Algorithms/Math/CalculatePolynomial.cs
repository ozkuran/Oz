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

        /// <summary>
        /// Calculator method
        /// </summary>
        /// <param name="inputPolynomial"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        public double Calculate(List<double> inputPolynomial, double x)
        {
            double result = 0.0;
            int size = inputPolynomial.Count;
            foreach (var val in inputPolynomial)
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
