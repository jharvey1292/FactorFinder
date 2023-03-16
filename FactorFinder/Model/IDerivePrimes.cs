using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactorFinder.Model
{
    public interface IDerivePrimes
    {
        IEnumerable<int> DerivePrimes(int number);

        string Name { get; }
    }
}
