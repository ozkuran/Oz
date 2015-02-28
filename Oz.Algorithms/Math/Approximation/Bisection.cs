using System;
using System.Collections.Generic;

namespace Oz.Algorithms.Math.Approximation
{
    public class Bisection
    {
        private List<double> _polynomial;
        private int _maxIteration;
        private Double _tolerance;
        private int _currentIteration;

        /// <summary>
        /// Calculates the roots of given polynomial using Bisection method
        /// </summary>
        /// <param name="polynomial"></param>
        /// <param name="maxIterations"></param>
        /// <param name="tolerance"></param>
        public Bisection(List<double> polynomial, int maxIterations, double tolerance )
        {
            _polynomial = polynomial;
            _maxIteration = _maxIteration;
            _tolerance = tolerance;
            _currentIteration = 0;
        }

        /// <summary>
        /// Calculator Method
        /// </summary>
        /// <returns></returns>
        public double Calculate()
        {
            return Calculate(-100000.0, 100000.0);
        }

        private Double Calculate(Double small, Double big)
        {
            var cp = new CalculatePolynomial();

            if (small >= big)
            {
                throw new ArgumentException("Small guess is not smaller than big guess");
            }
            if (System.Math.Sign(cp.Calculate(_polynomial, small)) == System.Math.Sign(cp.Calculate(_polynomial, big)))
            {
                throw new ArgumentException("_polynomial(small) and _polynomial(small) have the same sign");
            }

            if (System.Math.Abs(cp.Calculate(_polynomial, small)) < _tolerance)
            {
                return small;
            }

            if (System.Math.Abs(cp.Calculate(_polynomial, big)) < _tolerance)
            {
                return big;
            }

            Double mid = (small + big) / 2;

            if ((System.Math.Abs(cp.Calculate(_polynomial, small)) < _tolerance) || (System.Math.Abs(cp.Calculate(_polynomial, big)) < _tolerance))
                return mid;
            if (System.Math.Sign(cp.Calculate(_polynomial, small)) == System.Math.Sign(cp.Calculate(_polynomial, big)))
            {
                small = mid;
            }
            else
            {
                big = mid;
            }

            return Calculate(small, big);
        }


    }
}
