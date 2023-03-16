using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactorFinder.Model
{
    public class PrimeFactorsModel : IPrimeModel
    {
        #region Public Properties
        public int Number { get; set; }
        public IEnumerable<int> PrimeFactors { get; set; }
        public IDerivePrimes PrimeDeriver { get; set; }
        
        #endregion

        #region Constructor
        public PrimeFactorsModel(IDerivePrimes derivePrimes)
        {
            PrimeFactors = new List<int>();
            PrimeDeriver = derivePrimes;
        }
        #endregion

        #region Public Methods
        public void CalculatePrimeFactors()
        {
            PrimeFactors = PrimeDeriver.DerivePrimes(Number);
        }
        #endregion
    }

    #region IPrimeModel Interface
    public interface IPrimeModel
    {
        int Number { get; set; }
        IEnumerable<int> PrimeFactors { get; set; }
        IDerivePrimes PrimeDeriver { get; set; }
        void CalculatePrimeFactors();
    }
    #endregion
}
