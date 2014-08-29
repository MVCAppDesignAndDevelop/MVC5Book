namespace CalculateShippingFee.Services
{
    public class Factory
    {
        internal static IShipper GetShipper(int company)
        {
            IShipper shipper = null;
            if (company == 1) // 當貨運商為黑貓時
            {
                shipper = new Blackcat();
            }
            else if (company == 2) // 當貨運商為新竹貨運時
            {
                shipper = new Hsinchu();
            }
            else if (company == 3) // 當貨運商為郵局時
            {
                shipper = new Postoffice();
            }

            return shipper;
        }
    }
}