//using ClassLibrary1;
using GrammarParser;


// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");



var grammar = new Grammar();
grammar.AddRule("Expression", "Term '+' Expression | Term '-' Expression | Term");
grammar.AddRule("Term", "Factor '*' Term | Factor '/' Term | Factor");
grammar.AddRule("Factor", "Number | '(' Expression ')'");
grammar.AddRule("Number", "[0-9]+");
grammar.AddOperator("+", (a, b) => a + b);
grammar.AddOperator("-", (a, b) => a - b);
grammar.AddOperator("*", (a, b) => a * b);
grammar.AddOperator("/", (a, b) => a / b);


var parser = new Parser(grammar);
var result = parser.Parse("11+22*33+(4*5+6*7)*(108+109)+(201+202)");
Console.WriteLine(result.Evaluate());





//działające dodawanie bez dodawania znaków
//var grammar = new Grammar();
//grammar.AddRule("Expression", "Term '+' Expression | Term");
//grammar.AddRule("Term", "[0-9]+");

//var parser = new Parser(grammar);
//var result = parser.Parse("4+42+7+7");

//Console.WriteLine(result.Evaluate());



//parser podstawowy pierwszy 
//var parser = new RecursiveDescentParser("2+1222222222-1");
//try
//{
//    int result = parser.Parse();
//    Console.WriteLine($"Result: {result}");
//}
//catch (Exception ex)
//{
//    Console.WriteLine($"Error: {ex.Message}");
//}
