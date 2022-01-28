namespace Store
{
    using Store.Models;
    using System;
    using System.Collections.Generic;

    public class ShoppingCartVisitor : IShoppingCartVisitor
    {
        private readonly ICollection<Product> products;
        public ShoppingCartVisitor()
        {
            products = new List<Product>();
        }
        ICollection<Product> IShoppingCartVisitor.Products => products;

        public void Visit(Food food)
        {
            if(food.ExpirationDate == DateTime.Today)
            {
                food.Discount = 50;
            }
            else if ((food.ExpirationDate - DateTime.Now).TotalDays <= 5)
            {
                food.Discount = 10;
            }

            products.Add(food);
        }

        public void Visit(Clothes clothes)
        {
            DayOfWeek day = DateTime.Now.DayOfWeek;

            if (!(day == DayOfWeek.Saturday || day == DayOfWeek.Sunday))
            {
                clothes.Discount = 10;
            }

            products.Add(clothes);
        }

        public void Visit(Beverage beverage)
        {
            if (beverage.ExpirationDate == DateTime.Today)
            {
                beverage.Discount = 50;
            }
            else if ((beverage.ExpirationDate - DateTime.Now).TotalDays <= 5)
            {
                beverage.Discount = 10;
            }

            products.Add(beverage);
        }

        public void Visit(Appliance appliance)
        {
            DayOfWeek day = DateTime.Now.DayOfWeek;

            if ((day == DayOfWeek.Saturday || day == DayOfWeek.Sunday) && appliance.Price > 999)
            {
                appliance.Discount = 5;
            }

            products.Add(appliance);
        }
    }
}
