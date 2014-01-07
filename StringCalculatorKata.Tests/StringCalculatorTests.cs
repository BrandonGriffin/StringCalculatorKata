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
        private StringCalculator calculator;

        [SetUp]
        public void SetUp()
        {
            calculator = new StringCalculator();
        }

        [Test]
        public void EmptyStringReturns0()
        {
            var actual = calculator.Calculate(String.Empty);

            Assert.That(actual, Is.EqualTo(0));
        }

        [Test]
        public void ASingleNumberShouldReturnItself()
        {
            var actual = calculator.Calculate("1");

            Assert.That(actual, Is.EqualTo(1));
        }

        [Test]
        public void TwoNumbersShouldReturnTheirSum()
        {
            var actual = calculator.Calculate("2, 4");

            Assert.That(actual, Is.EqualTo(6));
        }

        [Test]
        public void AnyAmountOfNumbersShouldReturnTheirSum()
        {
            var actual = calculator.Calculate("3, 1, 5, 7");

            Assert.That(actual, Is.EqualTo(16));
        }
    }
}
