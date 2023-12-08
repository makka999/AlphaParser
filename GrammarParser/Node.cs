using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrammarParser
{
    public class Node
    {
        public string Type { get; set; }
        public string Value { get; set; }
        public List<Node> Children { get; set; } = new List<Node>();

        public int Evaluate()
        {
            switch (Type)
            {
                case "Expression":
                    return EvaluateExpression();

                case "Term":
                    return EvaluateTerm();

                case "Factor":
                    // Jeśli Factor ma tylko jedno dziecko, to musi to być Number lub innego typu węzeł
                    return Children.Count == 1 ? Children[0].Evaluate() : int.Parse(Value);

                case "Number":
                    return int.Parse(Value);

                default:
                    throw new NotImplementedException($"Nieznany typ węzła: {Type}");
            }
        }

        private int EvaluateExpression()
        {
            int result = Children[0].Evaluate();
            for (int i = 1; i < Children.Count; i += 2)
            {
                var operation = Children[i].Value;
                var nextTermValue = Children[i + 1].Evaluate();

                switch (operation)
                {
                    case "+":
                        result += nextTermValue;
                        break;
                    case "-":
                        result -= nextTermValue;
                        break;
                }
            }
            return result;
        }

        private int EvaluateTerm()
        {
            int result = Children[0].Evaluate();
            for (int i = 1; i < Children.Count; i += 2)
            {
                var operation = Children[i].Value;
                var nextFactorValue = Children[i + 1].Evaluate();

                switch (operation)
                {
                    case "*":
                        result *= nextFactorValue;
                        break;
                    case "/":
                        // Pamiętaj o sprawdzeniu dzielenia przez zero
                        if (nextFactorValue == 0)
                            throw new DivideByZeroException();
                        result /= nextFactorValue;
                        break;
                }
            }
            return result;
        }

    }
}
