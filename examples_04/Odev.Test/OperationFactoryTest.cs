using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Odev.Test
{
    [TestFixture]
    public class OperationFactoryTest {

        [Test]
        [TestCase(10, 10, '3')]
        public void Create_GiveWrongOperationSymbol_ThrowArgumentOutOfRangeException(double num1, double num2, char operationSymbol)
        {


            TestDelegate testDelegate = () =>
            {
                OperationFactory.Create(num1, num2, operationSymbol);
            };

            Assert.That(testDelegate, Throws.ArgumentException);
        }


    }
}
