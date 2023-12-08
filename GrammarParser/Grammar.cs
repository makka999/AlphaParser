namespace GrammarParser
{
    public class Grammar
    {
        public Dictionary<string, string> Rules { get; set; } = new Dictionary<string, string>();
        public Dictionary<string, Func<int, int, int>> Operators { get; set; } = new Dictionary<string, Func<int, int, int>>();

        public void AddRule(string name, string definition)
        {
            Rules[name] = definition;
        }

        public void AddOperator(string symbol, Func<int, int, int> operation)
        {
            Operators[symbol] = operation;
        }

    }
}