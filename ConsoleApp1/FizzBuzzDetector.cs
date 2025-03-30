using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzzApp
{
    /// <summary>
    /// Class for detecting and replacing words in input text based on specific rules.
    /// </summary>
    public class FizzBuzzDetector
    {
        /// <summary>
        /// Processes the input string and replaces words according to FizzBuzz rules.
        /// </summary>
        /// <param name="input">Input string.</param>
        /// <returns>An object containing the modified output string and counts of replacements.</returns>
        public FizzBuzzDetectorResult getOverlappings(string input)
        {
            if(String.IsNullOrEmpty(input)) 
                throw new ArgumentNullException(nameof(input), "Input string is null or empty");

            if (input.Length < 7 || input.Length > 100)
                throw new ArgumentException("Length of input string is less than 7 or more than 100 symbols", nameof(input));
            
            char[] separators = [' ', ',', '.', ':', '\t', '\r', '\n'];

            var words = input.Split(separators, StringSplitOptions.RemoveEmptyEntries).
                Where(w => w.Any(x => char.IsLetter(x))).
                ToList();

            for (int i = 0; i < words.Count; i++)
            {
                if ((i + 1) % 3 == 0 && (i + 1) % 5 == 0)
                    words[i] = "FizzBuzz";
                else if ((i + 1) % 3 == 0)
                    words[i] = "Fizz";
                else if ((i + 1) % 5 == 0)
                    words[i] = "Buzz";               
            }

            int count = words.Where(p => p == "Fizz" || p == "Buzz" || p == "FizzBuzz")
                .Count();
            return new FizzBuzzDetectorResult { ResultString = String.Join(" ", words), Count = count };
        }
    }

    /// <summary>
    /// Class representing the result of the FizzBuzz detection.
    /// </summary>
    public struct FizzBuzzDetectorResult
    {
        public string ResultString { get; set; }
        public int Count { get; set; }
    }
}
