namespace ConsoleCalculator.Node
{
    public class Chain
    {
        private double _left;
        private double _right;
        private readonly IOperator _operator;
        private Chain _next;
        private Chain _prev;

        public Chain(double left, double right, IOperator oper, Chain prev = null, Chain next = null)
        {
            _left = left;
            _right = right;
            _operator = oper;
            _next = next;
            _prev = prev;
        }

        public IOperator Operator => _operator;

        public double Evaluate() => _operator.Calculate(_left, _right);

        public void UpdateNeighbors()
        {
            var value = Evaluate();
            _next?.SetLeft(value);
            _prev?.SetRight(value);
            _next?.SetPrevChain(_prev);
            _prev?.SetNextChain(_next);
        }

        private void SetLeft(double value) => _left = value;
        private void SetRight(double value) => _right = value;

        public void SetPrevChain(Chain chain) => _prev = chain;
        public void SetNextChain(Chain chain) => _next = chain;
    }
}
