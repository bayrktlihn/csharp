using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;

namespace NUnitTestOdev.Test
{
    [TestFixture]
    public class CustomerTest
    {
        private Customer _customer;
        private IDictionary<int, Product> _products;
        private Manager _manager;

        [SetUp]
        public void SetUp()
        {
            _customer = new Customer();

            _products = new Dictionary<int, Product>();

            _products.Add(1, new Product { Id = 1, Name = "Lenovo Kulaklık", UnitPrice = 30, StockAmount = 10 });
            _products.Add(2, new Product { Id = 2, Name = "Logitech M185 Mouse", UnitPrice = 100, StockAmount = 10 });
            _products.Add(3, new Product { Id = 3, Name = "Sony AUX Girişi", UnitPrice = 30, StockAmount = 10 });
            _products.Add(4, new Product { Id = 4, Name = "Hp Kablosuz Mouse", UnitPrice = 60, StockAmount = 10 });

            _manager = new Manager();

        }

        [Test]
        public void GiveOrder_GiveAgainOrder_ThrowsArgumentException()
        {
            Cart cart = new Cart();

            cart.AddProduct(_products[1], 10);
            cart.AddProduct(_products[2], 10);

            Order order = new Order(cart);

            _customer.GiveOrder(order);

            TestDelegate testDelegate = () =>
            {
                _customer.GiveOrder(order);
            };

            Assert.That(testDelegate, Throws.ArgumentException);

            
        }
        
        [Test]
        [TestCase("alihan.bayraktar@bayrktlihn")]
        [TestCase("deniz.bayraktar@bayrktlihn.com")]
        [TestCase("merve.bayraktar@bayrktlihn")]
        public void Email_InvalidEmail_ThrowsArgumentException(String email)
        {

            Thread.Sleep(1000);

            _customer = new Customer();
            TestDelegate testDelegate = () =>
            {
                _customer.Email = email;
            };

            Assert.That(testDelegate, Throws.ArgumentException);


        }

        
    }
}
