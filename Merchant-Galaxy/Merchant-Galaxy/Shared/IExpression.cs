namespace Merchant_Galaxy.Shared {
    public interface IExpression {
        bool Match(string input);
        void Execute(string input);
    }
}
