/*
 * This project demonstrates the use of a try, catch with custom
 * Argument Exception to output to the line. The idea is to catch
 * number entries and stop blank entries.
 */

using System;

// Call System Linq for All | Any & IsDigit
using System.Linq;

namespace stringValidationNoNumbersProject
{
    class Program
    {
        static void Main(string[] args)
        {
            // Boolean to exit look if X pressed
            bool processing = true;
                       
            while (processing == true)
            {
                //Validate String
                ValidateStringInformation();                

                // Console WriteLine Method, Directions =>
                Console.WriteLine(@"Keep going? <press 'x' & then 'Enter' to exit)");
                
                // Exit Here with X  
                processing = !(Console.ReadLine() == "x");
            }
        }

        // Validate String Information
        private static void ValidateStringInformation()
        {
            try
            {
                // Console Output
                Console.Write("Enter a phrase: ");

                // Var for auto datatype
                var readCommandLinePrompt = Console.ReadLine();

                // Blank Space
                Console.WriteLine();

                // To catch any number just change All to Any
                bool isDigitPresent = readCommandLinePrompt.All(c => char.IsDigit(c));

                // If Statement to throw Exception if All numbers & !equal 0 or null. 
                if (isDigitPresent == true && readCommandLinePrompt != string.Empty)
                {
                    // Throw new Custom ArugmentException with Message
                    throw new ArgumentException("Numbers are not accepted");
                }

                // From Var to String Type
                string workWithThisText = readCommandLinePrompt.ToString();
                if (workWithThisText == null || workWithThisText == string.Empty)
                {
                    // Throw new Custom ArugmentException with Message
                    throw new ArgumentException("Can not be an empty field");
                }

                // Write Text to console
                Console.WriteLine($"You said,\"{workWithThisText}\"");

            }
            // Catch Exception and Message to console
            catch (ArgumentException aExc)
            {
                Console.WriteLine(aExc.Message.ToString());
            }
        }
    }
}

// Output
//*****************************

// Enter a phrase: 2222222222

// Numbers are not accepted
// Keep going? <press 'x' & then 'Enter' to exit)

// Enter a phrase:

// Can not be an empty field
// Keep going? <press 'x' & then 'Enter' to exit)

// Enter a phrase: This is acceptable.

// You said,"This is acceptable."
// Keep going? <press 'x' & then 'Enter' to exit)

// Enter a phrase: This is 2 also acceptable.

// You said,"This is 2 also acceptable."
// Keep going? <press 'x' & then 'Enter' to exit)



// All Number caught example
// ******************************

// Enter a phrase: hello world.This is a message with no numbers.

// You said,"hello world. This is a message with no numbers."
// Keep going? <press 'x' & then 'Enter' to exit)

// Enter a phrase: Hello.This has a number 1.

// Numbers are not accepted
// Keep going? <press 'x' & then 'Enter' to exit)
