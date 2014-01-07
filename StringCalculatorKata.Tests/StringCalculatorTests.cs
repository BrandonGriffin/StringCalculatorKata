using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculatorKata.Tests
{
    [TestFixture]
    public class StringCalculatorTests
    {
        [Test]
        public void EmptyStringReturns0()
        {
            var calculator = new StringCalculator();
            
            var actual = calculator.Calculate("");

            Assert.That(actual, Is.EqualTo(0));
        }
    }
}
