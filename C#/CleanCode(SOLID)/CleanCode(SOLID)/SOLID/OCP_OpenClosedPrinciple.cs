using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// Open for extension
// And
// Closed for modification
namespace CleanCode_SOLID_.SOLID;

internal class Invoice
{
    public double Amount { get; set; }
}

// Created new class instead of modifying exisiting class
internal class DiscountedInvoice : Invoice
{
    public double Discount { get; set; }

}

internal class BillingService
{
    public virtual double CalculateTotal(Invoice invoice)
    {
        return invoice.Amount;
    }
}
// Created new class instead of modifying exisiting class
internal class DiscountedBillingService : BillingService
{
    public override double CalculateTotal(Invoice invoice)
    {
        if (invoice is DiscountedInvoice discountedInvoice)
        {
            return discountedInvoice.Amount-discountedInvoice.Discount;
        }
        return base.CalculateTotal(invoice);
    }
}
