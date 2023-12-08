namespace GrammarParser
{
    public class Grammar
    {
        public Dictionary<string, string> Rules { get; set; } = new Dictionary<string, string>();

        public void AddRule(string name, string definition)
        {
            Rules[name] = definition;
        }

    }
}