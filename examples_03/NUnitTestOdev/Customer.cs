using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTestOdev
{
    public class Customer
    {
        private EmailValidator _emailValidator = new EmailValidator();
        private String _email;
        public String FirstName { get; set; }
        public String  LastName { get; set; }
        private List<Order> _orders = new List<Order>();
        public String Email {
            get
            {
                return _email;
            }
            set
            {

                if(value == null)
                    throw new ArgumentException();

                _emailValidator.Name = value;
                bool isTrueEmail = _emailValidator.Valid();
                if (isTrueEmail)
                    _email = value;
                else
                    throw new ArgumentException();
            }
        }




        public int OrderCount
        {
            get
            {
                return _orders.Count;
            }
        }

        public Order GiveOrder(Order order)
        {
           

            if (IsIncludeOrder(order))
                throw new ArgumentException("Already you gave order");

            order.Customer = this;

            _orders.Add(order);


            return order;

        }

        private bool IsIncludeOrder(Order order)
        {
            return _orders.Where(or => or == order).Count() > 0;
        }
    }
}
