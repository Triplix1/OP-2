using static OP_Labs_new.Funcs;

string inputfile = "input.txt";
string outputfile = "output.txt";

Overwrite(inputfile, outputfile);

List<string> text = InputText();

WriteFile(inputfile, text);

Console.WriteLine("\nInput file:");
OutputFile(inputfile);

Console.WriteLine();

Console.Write("Enter your word: ");

string word = Console.ReadLine();

GetNewFile(outputfile, inputfile, word);

Console.WriteLine("\nOutput file:");
OutputFile(outputfile);

Console.WriteLine("\nInfo about output.txt:");
GetInfo(outputfile);