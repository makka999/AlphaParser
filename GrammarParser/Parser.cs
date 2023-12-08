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

            // Parse pierwszego Term
            node.Children.Add(ParseTerm());

            // Parsowanie dalszej części wyrażenia
            while (CurrentChar() == '+')
            {
                Advance(); // Przesunięcie o znak '+'
                node.Children.Add(ParseTerm()); // Parse kolejnego Term
            }

            return node;
        }

        private Node ParseTerm()
        {
            var node = new Node { Type = "Term" };

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

        private void Advance()
        {
            _position++;
        }
    }

}
