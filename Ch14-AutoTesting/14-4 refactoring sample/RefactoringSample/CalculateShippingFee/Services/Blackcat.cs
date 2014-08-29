namespace CalculateShippingFee.Services
{
    public class Blackcat : IShipper
    {
        /// <summary>
        /// 計算運費
        /// </summary>
        /// <param name="product">商品規格</param>
        /// <returns>運費</returns>
        public double CalculateFee(Models.ProductModels product)
        {
            double fee = 0;

            var weight = product.Weight;
            if (weight > 20)
            {
                fee = 500;
            }
            else
            {
                fee = 100 + weight * 10;
            }

            return fee;
        }
    }
}