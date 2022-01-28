namespace Store.Models
{
    using System;
    using Store.Messages;

    public class Clothes : Product, IAcceptable
    {
        private string size;
        private string color;

        public Clothes(string name, string brand, decimal price, double quantity, string size, string color)
            : base(name, brand, price, quantity)
        {
            this.Size = size;
            this.Color = color;
        }

        public void Accept(IShoppingCartVisitor shoppingCartVisitor)
        {
            shoppingCartVisitor.Visit(this);
        }

        public string Color
        {
            get => color;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidColor);
                }
                color = value;
            }
        }

        public string Size
        {
            get => size;
            set
            {
                if (!Enum.IsDefined(typeof(Enums.Size), value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidSize);
                }
                size = value;
            }
        }
    }
}