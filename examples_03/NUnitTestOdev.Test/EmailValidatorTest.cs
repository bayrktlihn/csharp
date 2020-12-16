using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NUnitTestOdev.Test
{
    [TestFixture]
    public class EmailValidatorTest
    {

        [Test]
        [TestCase("alihan.bayraktar@bayrktlihn.com")]
        [TestCase("deniz.bayraktar@bayrktlihn.com")]
        [TestCase("deniz.bayraktar@bayrktlihn")]
        public void Valid_GiveTrueEmail_IsTrue(String email)
        {

            Thread.Sleep(1000);

            EmailValidator emailValidator = new EmailValidator();

                emailValidator.Name = email;
                bool actual = emailValidator.Valid();

            Assert.IsTrue(actual);

          
        }


    }
}
