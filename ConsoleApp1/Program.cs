// See https://aka.ms/new-console-template for more information

using FizzBuzzApp;

FizzBuzzDetector fizzBuzzDetector = new FizzBuzzDetector();
string input = "Mary had a little lamb Little lamb, little lamb Mary had a little lamb It's fleece was white as snow";
FizzBuzzDetectorResult result = fizzBuzzDetector.getOverlappings(input);
Console.WriteLine(result.ResultString);
Console.WriteLine("count: " + result.Count);