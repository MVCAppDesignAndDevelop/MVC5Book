using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CalculateShippingFee.Services
{
    public interface IShipper
    {
        double CalculateFee(Models.ProductModels product);
    }
}
