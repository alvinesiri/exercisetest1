using retailstore.service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace retailstore.service.Services
{
    public class PaymentService
    {
        readonly List<Affiliate>? affiliates;
        readonly List<Customer>? customers;
        readonly List<Employee>? employees;

        public PaymentService(List<Affiliate>? _affiliates, List<Customer>? _customers, List<Employee>? _employees) 
        {
            affiliates = _affiliates;
            customers = _customers;
            employees = _employees;
        }

        public decimal GetNetPayableAmount(Bill bill) 
        {
            decimal amount = bill.Amount;
            decimal discount = 0;
            Customer? customer = customers?.FirstOrDefault(x => x.PhoneNumber == bill.PhoneNumber);
            bool isAffiliate = affiliates?.Any(x => x.PhoneNumber == bill.PhoneNumber) ?? false;
            bool isEmployee = employees?.Any(x => x.PhoneNumber == bill.PhoneNumber) ?? false;

            if (bill.IsGroceries)
            {
                if (isEmployee)
                {
                    discount += amount * 0.3M;
                }
                else if (isAffiliate)
                {
                    discount += amount * 0.1M;
                }
                else if (customer.DateJoined <= DateTime.Now.AddYears(-2))
                {
                    discount += amount * 0.05M;
                };
            }

            decimal hundredDollarDiscount = Math.Floor(amount/100) * 5;
            discount += hundredDollarDiscount;

            decimal netPayableAmount = amount - discount;

            return Math.Round(netPayableAmount, 2);
        }
    }
}
