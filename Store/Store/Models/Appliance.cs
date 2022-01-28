namespace Store.Models
{
    public class Appliance : Product, IAcceptable
    {
        public Appliance(string name, string brand, decimal price, double quantity)
            :base(name, brand, price, quantity)
        {

        }
        public void Accept(IShoppingCartVisitor shoppingCartVisitor)
        {
            shoppingCartVisitor.Visit(this);
        }
    }
}
