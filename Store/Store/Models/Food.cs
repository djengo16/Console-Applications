namespace Store.Models
{
    using System;
    public class Food : Product, IAcceptable
    {
        public Food(string name, string brand, decimal price, double quantity, DateTime expirationDate)
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