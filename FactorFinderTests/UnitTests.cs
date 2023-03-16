using FactorFinder.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;

namespace FactorFinderTests
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void DerivePrimesTest()
        {
            var primeDeriver = new Mock<IDerivePrimes>();

            primeDeriver.Setup(x => x.DerivePrimes(66)).Returns(new List<int> { 2, 3, 11 }.AsEnumerable());

            var primeFactorsModel = new PrimeFactorsModel(primeDeriver.Object);

            primeFactorsModel.Number = 66;
            primeFactorsModel.CalculatePrimeFactors();
            Assert.AreEqual(3, primeFactorsModel.PrimeFactors.Count());
        }
    }
}
