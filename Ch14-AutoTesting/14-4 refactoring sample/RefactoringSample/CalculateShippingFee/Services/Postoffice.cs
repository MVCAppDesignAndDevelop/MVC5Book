namespace CalculateShippingFee.Services
{
    public class Postoffice : IShipper
    {
        public double CalculateFee(Models.ProductModels product)
        {
            double fee = 0;

            var feeByWeight = 80 + product.Weight * 10;

            var size = product.Length * product.Width * product.Height;
            var feeBySize = size * 0.0000353 * 1100;

            if (feeByWeight < feeBySize)
            {
                fee = feeByWeight;
            }
            else
            {
                fee = feeBySize;
            }
            return fee;
        }
    }
}