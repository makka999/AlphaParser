//using ClassLibrary1;
using GrammarParser;


// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");



//Class1.Daj();


//    string a = Console.ReadLine();

//    var parser = new RecursiveDescentParser(a);
//    //var parser = new RecursiveDescentParser(a.ToString());
//    try
//    {
//        int result = parser.Parse();
//        Console.WriteLine($"Result: {result}");
//    }
//    catch (Exception ex)
//    {
//        Console.WriteLine($"Error: {ex.Message}");
//    }

//var result = parser.Parse("3 + 4");
//var evaluationResult = result.Evaluate();

//Console.WriteLine(evaluationResult); // Wyświetli 7


var grammar = new Grammar();
grammar.AddRule("Expression", "Term '+' Expression | Term");
grammar.AddRule("Term", "[0-9]+");

var parser = new Parser(grammar);
var result = parser.Parse("4+42+7+7");

Console.WriteLine(result.Evaluate());




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
