using System;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Odev.Test
{
    [TestFixture]
    public class OperationTest
    {
     


        [Test]
        [TestCase(10, 20, '+', 30)]
        [TestCase(10, 20, '*', 200)]
        [TestCase(10, 20, '-', -10)]
        [TestCase(10, 20, '/', 0.5)]
        public async Task Apply_GiveArguments_TrueResult(int num1, int num2, char operationSysmbol, double expected)
        {
            Operation operation = OperationFactory.Create(num1, num2, operationSysmbol);

            double actual =  await operation.ApplyAsync();

            
            Assert.AreEqual(expected, actual);
        
        }

        public void Aaa()
        {
            Operation operation = OperationFactory.Create(1, 1, '+');

            Task<double> r = operation.ApplyAsync();
        }

        
    }
}
