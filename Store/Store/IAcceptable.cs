namespace Store
{
    public interface IAcceptable
    {
        void Accept(IShoppingCartVisitor shoppingCartVisitor);
    }
}