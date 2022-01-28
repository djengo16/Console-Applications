namespace Store.Models
{
    using System;

    public class Beverage : Product, IAcceptable
    {
        public Beverage(string name, string brand, decimal price, double quantity, DateTime expirationDate)
            : base(name, brand, price, quantity)
        {
            this.ExpirationDate = expirationDate;
        }
        public void Accept(IShoppingCartVisitor shoppingCartVisitor)
        {
            shoppingCartVisitor.Visit(this);
        }

        public DateTime ExpirationDate { get; }
    }
}