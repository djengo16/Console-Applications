namespace Store.Models
{
    using System;
    using System.Linq;
    using System.Text;
    public class Cashier
    {
        private decimal totalSum;
        private decimal totalDiscount;
        private decimal totalSumWithDiscount;
        public string PrintReceipt(IShoppingCartVisitor shoppingCart, DateTime purchaseDate)
        {
            totalDiscount = shoppingCart.Products.Sum(x => x.GetDiscount());
            totalSum = shoppingCart.Products.Sum(x => x.GetOriginalTotalPrice());
            totalSumWithDiscount = shoppingCart.Products.Sum(x => x.GetTotalFinalProductPriceWithDiscount());

            StringBuilder sb = new StringBuilder();
            sb.Append($"SUBTOTAL: ${totalSum}:F2 \n");
            sb.Append($"DISCOUNT: -${totalDiscount}:F2 \n");
            sb.Append($"TOTAL: ${totalSumWithDiscount}:F2");

            return sb.ToString();
        }
    }
}
