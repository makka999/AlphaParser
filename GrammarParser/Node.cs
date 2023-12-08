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
                    int sum = 0;
                    foreach (var child in Children)
                    {
                        sum += child.Evaluate();
                    }
                    return sum;

                case "Term":
                    return int.Parse(Value);

                default:
                    throw new NotImplementedException($"Nieznany typ węzła: {Type}");
            }
        }

    }
}
