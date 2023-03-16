using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactorFinder.Model
{
    internal class DirectSearch : IDerivePrimes
    {
        #region Public Properties
        public string Name { get { return "Direct Search"; } }
        #endregion

        #region Private Fields
        private Eratosthenes _eratosthenes = new Eratosthenes();
        #endregion

        #region Constructor
        public DirectSearch() { }
        #endregion

        #region IDerivePrimes Implementation
        public IEnumerable<int> DerivePrimes(int number)
        {
            List<int> factors = new List<int>();

            foreach (int prime in _eratosthenes)
            {
                while (number % prime == 0)
                {
                    number /= prime;
                    factors.Add(prime);
                }

                if (number == 1)
                {
                    break;
                }
            }

            return factors;
        }
        #endregion
    }
}
