using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace NUnitTestOdev.Test
{
    [TestFixture]
    public class ManagerTest
    {
        private Manager _manager;
        private IDictionary<int, Product> _products;

        [SetUp]
        public void SetUp()
        {
            _manager = new Manager();

            _products = new Dictionary<int, Product>();

            _products.Add(1, new Product { Id = 1, Name = "Lenovo Kulaklık", UnitPrice = 30, StockAmount = 10 });
            _products.Add(2, new Product { Id = 2, Name = "Logitech M185 Mouse", UnitPrice = 100, StockAmount = 10 });
            _products.Add(3, new Product { Id = 3, Name = "Sony AUX Girişi", UnitPrice = 30, StockAmount = 10 });
            _products.Add(4, new Product { Id = 4, Name = "Hp Kablosuz Mouse", UnitPrice = 60, StockAmount = 10 });

        }

        [Test]
        public void Approve_AlreadyApprovedOrder_ThrowArgumenException()
        {
            Cart cart = new Cart();
            cart.AddProduct(_products[1], 10);
            cart.AddProduct(_products[2], 2);

            Order order = new Order(cart);

            Customer customer = new Customer
            {
                FirstName = "alihan",
                LastName = "bayraktar",
            };
            customer.GiveOrder(order);

            _manager.ApproveOrder(order);
            TestDelegate testDelegate = () =>
            {
                _manager.ApproveOrder(order);
            };

            Assert.That(testDelegate, Throws.ArgumentException);
        }

        [Test]
        public void CreateFreeCoupon_DifferenceCoupon_IsTrue()
        {
            String actual = _manager.CreateFreeCoupon(100).Code;
            String expected = _manager.CreateFreeCoupon(100).Code;

            Assert.That(expected, Is.Not.EqualTo(actual));
        }

        [Test]
        public void Approve_MessageText_NotEmpty()
        {
            Cart cart = new Cart();
            cart.AddProduct(_products[1], 10);
            cart.AddProduct(_products[2], 2);

            Order order = new Order(cart);
            Customer customer = new Customer
            {
                FirstName = "alihan",
                LastName = "bayraktar"
            };
            customer.GiveOrder(order);

            String messageText = _manager.ApproveOrder(order);

            Assert.That(messageText, Is.Not.Empty);
        }

        [Test]
        public void GetDiscountCouponAmount_GiveOrderDiscountAmount_IsEqual()
        {
            Cart cart = new Cart();
            cart.AddProduct(_products[1], 10); // 300
            cart.AddProduct(_products[2], 2); // 200

            Order order = new Order(cart);

            int expected = 50;
            int actual = (int)_manager.GetDiscountCouponAmount(order);

            Assert.That(expected, Is.EqualTo(actual));
            

        }

        [Test]
        public void ApproveOrder_NoOwnerOfTheOrder_ThrowException()
        {
            Cart cart = new Cart();
            cart.AddProduct(_products[1], 10); // 300
            cart.AddProduct(_products[2], 2); // 200

            Order order = new Order(cart);

            TestDelegate testDelegate = () =>
            {
                _manager.ApproveOrder(order);
            };

            Assert.That(testDelegate, Throws.ArgumentException);


        }

        [Test]
        public void ApproveOrder_NoEmail_ThrowException()
        {
            Cart cart = new Cart();
            cart.AddProduct(_products[1], 10); // 300
            cart.AddProduct(_products[2], 2); // 200

            Order order = new Order(cart);

            Customer customer = new Customer() { 
                FirstName = "alihan",
                LastName = "bayraktar"
            };

            customer.GiveOrder(order);

            TestDelegate testDelegate = () =>
            {
                _manager.ApproveOrder(order);
            };

            Assert.That(testDelegate, Throws.ArgumentException);
        }

    }
}
