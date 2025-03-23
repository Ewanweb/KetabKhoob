using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Domain;

namespace Shop.Domain.OrderAgg.ValueObjects
{
    public class ShippingMethod : ValueObject
    {
        public ShippingMethod(string shippingTypes, int shippingCost)
        {
            ShippingTypes = shippingTypes;
            ShippingCost = shippingCost;
        }
        public string ShippingTypes { get; private set; }
        public int ShippingCost { get; private set; }
    }
}
