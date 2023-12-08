using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GrammarParser
{
    public class Parser
    {
        private readonly Grammar _grammar;
        private string _input;
        private int _position;

        public Parser(Grammar grammar)
        {
            _grammar = grammar;
        }

        public Node Parse(string input)
        {
            _input = input;
            _position = 0;

            return ParseExpression();
        }

        private Node ParseExpression()
        {
            var node = new Node { Type = "Expression" };
            node.Children.Add(ParseTerm());

            while (true)
            {
                var op = FindOperator();
                if (op == "+" || op == "-")
                {
                    Advance(op.Length);
                    node.Children.Add(new Node { Type = "Operator", Value = op });
                    node.Children.Add(ParseTerm());
                }
                else
                {
                    break;
                }
            }

            return node;
        }

        private string FindOperator()
        {
            foreach (var op in _grammar.Operators.Keys)
            {
                if (_input.Substring(_position).StartsWith(op))
                {
                    return op;
                }
            }
            return null;
        }

        private Node ParseTerm()
        {
            var node = new Node { Type = "Term" };
            node.Children.Add(ParseFactor());

            while (true)
            {
                var op = FindOperator();
                if (op == "*" || op == "/")
                {
                    Advance(op.Length);
                    node.Children.Add(new Node { Type = "Operator", Value = op });
                    node.Children.Add(ParseFactor());
                }
                else
                {
                    break;
                }
            }

            return node;
        }

        private Node ParseFactor()
        {
            if (CurrentChar() == '(')
            {
                Advance(); // Przesuń pozycję za nawias otwierający '('
                var node = ParseExpression();
                if (CurrentChar() != ')')
                {
                    throw new Exception("Oczekiwano nawiasu zamykającego ')'");
                }
                Advance(); // Przesuń pozycję za nawias zamykający ')'
                return node;
            }

            return ParseNumber();
        }

        private Node ParseNumber()
        {
            var node = new Node { Type = "Number" };

            while (char.IsDigit(CurrentChar()))
            {
                node.Value += CurrentChar();
                Advance();
            }

            return node;
        }



        private char CurrentChar()
        {
            if (_position < _input.Length)
            {
                return _input[_position];
            }

            return '\0'; // Znak końca ciągu
        }

        private void Advance(int steps = 1)
        {
            _position += steps;
        }
    }


}
