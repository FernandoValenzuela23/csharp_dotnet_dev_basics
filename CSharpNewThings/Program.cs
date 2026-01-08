string text = "Hola Sarah";

if(text.StartsWith('H') && text.EndsWith('h'))
{
    Console.WriteLine("The text starts with 'H' and ends with 'h'.");
}

if (text[0] == 'H' && text[^1] == 'h')
{
    Console.WriteLine("The text starts with 'H' and ends with 'h' using indexers.");
}

if(text is ['H', .., 'h' ])
{
    Console.WriteLine("The text starts with 'H' and ends with 'h' using pattern matching.");
}