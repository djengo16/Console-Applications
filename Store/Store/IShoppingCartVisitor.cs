namespace Store
{
    using Store.Models;
    using System.Collections.Generic;

    public interface IShoppingCartVisitor
    {
        ICollection<Product> Products { get; }
        void Visit(Food food);
        void Visit(Clothes clothes);
        void Visit(Beverage beverage);
        void Visit(Appliance appliance);
    }
}
