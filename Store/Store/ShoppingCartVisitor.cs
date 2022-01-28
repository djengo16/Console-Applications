namespace Store
{
    using Store.Models;
    using System;
    using System.Collections.Generic;

    public class ShoppingCartVisitor : IShoppingCartVisitor
    {
        private readonly ICollection<Product> products;

        private const decimal perishableTodayDiscount = 50;
        private const decimal perishableWithinFiveDaysDiscount = 10;
        private const decimal workDayClothesDiscount = 10;
        private const decimal applianceWeekendDiscount = 5;
        public ShoppingCartVisitor()
        {
            products = new List<Product>();
        }
        ICollection<Product> IShoppingCartVisitor.Products => products;

        public void Visit(Food food)
        {
            if(food.ExpirationDate == DateTime.Today)
            {
                food.Discount = perishableTodayDiscount;
            }
            else if ((food.ExpirationDate - DateTime.Now).TotalDays <= 5)
            {
                food.Discount = perishableWithinFiveDaysDiscount;
            }

            products.Add(food);
        }

        public void Visit(Clothes clothes)
        {
            DayOfWeek day = DateTime.Now.DayOfWeek;

            if (!(day == DayOfWeek.Saturday || day == DayOfWeek.Sunday))
            {
                clothes.Discount = workDayClothesDiscount;
            }

            products.Add(clothes);
        }

        public void Visit(Beverage beverage)
        {
            if (beverage.ExpirationDate == DateTime.Today)
            {
                beverage.Discount = perishableTodayDiscount;
            }
            else if ((beverage.ExpirationDate - DateTime.Now).TotalDays <= 5)
            {
                beverage.Discount = perishableWithinFiveDaysDiscount;
            }

            products.Add(beverage);
        }

        public void Visit(Appliance appliance)
        {
            DayOfWeek day = DateTime.Now.DayOfWeek;

            if ((day == DayOfWeek.Saturday || day == DayOfWeek.Sunday) && appliance.Price > 999)
            {
                appliance.Discount = applianceWeekendDiscount;
            }

            products.Add(appliance);
        }
    }
}
