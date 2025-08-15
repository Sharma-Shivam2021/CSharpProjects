using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCode_SOLID_
{
    public enum CustomerType
    {
        Regular, Premium, Employee
    }
    internal class DRY_Example
    {
        /*
         * --------------- BAD METHOD OF REPEATING SAME CODE ---------------
         * 
        public double CalculateDiscountForRegularCustomer(double totalAmount)
        {
            if (totalAmount>1000)
            {
                return totalAmount*0.1;
            }
            else
            {
                return totalAmount * 0.05;
            }
        }
        public double CalculateDiscountForPremiumCustomer(double totalAmount)
        {
            if (totalAmount>1000)
            {
                return totalAmount*0.15;
            }
            else
            {
                return totalAmount * 0.1;
            }
        }
        public double CalculateDiscountForEmployeeCustomer(double totalAmount)
        {
            if (totalAmount>1000)
            {
                return totalAmount*0.1;
            }
            else
            {
                return totalAmount * 0.05;
            }
        }
        */


        // GOOD METHOD

        private const double DISCOUNT_THRESHOLD = 1000;

        public double CalculateDiscount(CustomerType customerType, double totalAmount)
        {
            double discount = 0;
            switch (customerType)
            {
                case CustomerType.Regular:
                    discount = totalAmount > DISCOUNT_THRESHOLD ? 0.1 : 0.05;
                    break;
                case CustomerType.Premium:
                    discount = totalAmount > DISCOUNT_THRESHOLD ? 0.15 : 0.1;
                    break;
                case CustomerType.Employee:
                    discount = totalAmount > DISCOUNT_THRESHOLD ? 0.20 : 0.15;
                    break;
                default:
                    break;
            }
            return totalAmount * discount;
        }


    }
}
