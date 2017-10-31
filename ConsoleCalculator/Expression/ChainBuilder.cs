using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using ConsoleCalculator.Node;

namespace ConsoleCalculator.Expression
{
    public class ChainBuilder : IChainBuilder
    {
        private string _input;
        private readonly char[] _operators = { '+', '-', '/', '*' };
        private int _position;

        private bool EndOfString => _position > _input.Length - 1;
        private bool LastChar(int index) => index == _input.Length - 1;


        public IEnumerable<Chain> CreateChain(string input)
        {
            _input = input;
            _position = 0;

            var firstMultiplier = 1;

            if (_input[0] == '-')
            {
                _position++;
                firstMultiplier = -1;
            }

            bool findResult;
            double prevNumber = FindNumber(out findResult);
            prevNumber *= firstMultiplier;

            Chain nextChain = null;

            while (findResult && !EndOfString)
            {
                var oper = GetOperator(_input[_position++]);
                var nextNumber = FindNumber(out findResult);

                var lastChain = nextChain;
                nextChain = new Chain(prevNumber, nextNumber, oper, lastChain);
                lastChain?.SetNextChain(nextChain);

                yield return nextChain;

                prevNumber = nextNumber;
            }
        }

        private double FindNumber(out bool result)
        {
            if (_position - 1 >= _input.Length)
            {
                result = false;
                return 0;
            }

            int startIndex = _position;
            char value = _input[startIndex];

            for (int i = startIndex; i < _input.Length; i++)
            {
                value = _input[i];
                if (_operators.Contains(value))
                {
                    _position = i;
                    break;
                }
                if (LastChar(i))
                {
                    _position = i + 1;
                    break;
                }
            }
            result = true;
            return double.Parse(_input.Substring(startIndex, _position - startIndex), new CultureInfo("en-US"));
        }

        private IOperator GetOperator(char c)
        {
            switch (c)
            {
                case '+': return new AdditionOperator();
                case '-': return new SubtractionOperator();
                case '*': return new MultiplicationOperator();
                case '/': return new DivisionOperator();
                default: throw new Exception();
            }
        }
    }
}
