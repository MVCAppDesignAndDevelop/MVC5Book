namespace CalculateShippingFee.Services
{
    public class Hsinchu : IShipper
    {
        public double CalculateFee(Models.ProductModels product)
        {
            double fee = 0;

            var size = product.Length * product.Width * product.Height;
            //長 x 寬 x 高（公分）x 0.0000353
            if (product.Length > 100 || product.Width > 100 || product.Height > 100)
            {
                fee = size * 0.0000353 * 1100 + 500;
            }
            else
            {
                fee = size * 0.0000353 * 1200;
            }
            return fee;
        }
    }
}