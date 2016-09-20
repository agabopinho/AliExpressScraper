using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopifySharp;

namespace ISAA.Suppliers.Ali.Automation.Common
{
    public class UpdateConciliationProductParameter
    {
        public IEnumerable<ShopifyLineItem> OpenOrders { get; set; }

        public ShopifyProduct ShopifyProduct { get; set; }
    }
}
