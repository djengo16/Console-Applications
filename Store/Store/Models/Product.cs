namespace Store.Models
{
    using Store.Messages;
    using System;
    using System.Text;

    public abstract class Product
    {
        private decimal price;
        private decimal discount;
        private double quantity;

        protected Product(string name, string brand, decimal price, double quantity)
        {
            Name = name;
            Brand = brand;
            Price = price;
            Quantity = quantity;
            Discount = 0;
        }

        public string Name { get; }
        public string Brand { get; }
        public decimal GetTotalFinalProductPriceWithDiscount() => (decimal)this.Quantity * (this.Price - this.GetDiscount());
        public decimal GetDiscount() => this.Price * (this.Discount / 100);
        public decimal GetOriginalTotalPrice() => this.Price * (decimal)this.Quantity;
        public double Quantity
        {
            get => quantity; 
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidQuantity);
                }
                quantity = value;
            }
        }
        public decimal Discount
        {
            get => discount;
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidDiscount);
                }
                discount = value;
            }
        }
        public decimal Price
        {
            get => price;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPrice);
                }
                price = value;
            }
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{this.Name} {this.Brand}\n");
            sb.Append($"{this.Quantity} x {this.Price} = {this.GetOriginalTotalPrice()}\n");
            if(this.Discount != 0)
            {
                sb.Append($"#discount %{this.Discount} {this.GetDiscount()}");
            }

            return sb.ToString();
        }
    }
}