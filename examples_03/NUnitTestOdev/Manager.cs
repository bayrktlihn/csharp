using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NUnitTestOdev
{
    public class Manager
    {
        public String ApproveOrder(Order order)
        {
            if (order.Customer == null)
                throw new ArgumentException("No owner of the order");

            if (order.Customer.Email == null)
                throw new ArgumentException("No email owner of order");

            if (order.Status == Status.Approved)
                throw new ArgumentException("Already The order is approved");

            order.Status = Status.Approved;

            double discountAmount = GetDiscountCouponAmount(order);
            Coupon coupon =  CreateFreeCoupon(discountAmount);

            return CreateEmailMessage(order, coupon);
        }

        public double GetDiscountCouponAmount(Order order)
        {
            Cart cart = order.Cart;

            double discountCouponAmount = 0;

            if (cart.TotalPrice >= 250 && cart.TotalPrice <= 500)
                discountCouponAmount = cart.TotalPrice * 0.1;

            return discountCouponAmount;
        }

        private String CreateEmailMessage(Order order, Coupon coupon)
        {
            Cart cart = order.Cart;
            Customer customer = order.Customer;

            StringBuilder sb = new StringBuilder();
            sb.Append($"Merhaba {customer.FirstName } {customer.LastName}\n");
            sb.Append(cart.TotalPrice+" tutarında alışverişiniz onaylandı.\n");
            if(coupon.Amount > 0)
                sb.Append($"Ayrıca bizden kupon kazandınız. kupon codu: {coupon.Code} kupon tutarı {coupon.Amount}");
            return sb.ToString();
        }

        public Coupon CreateFreeCoupon(double amount)
        {
            String code = Guid.NewGuid().ToString();
            Coupon coupon = new Coupon
            {
                Code = code,
                Amount = amount
            };
            return coupon;
        }

        
    }
}
