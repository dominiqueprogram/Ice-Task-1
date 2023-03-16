using System;

namespace ScriptDistributionApp
{
    class Program_MsMulumbaApp
    {
        static void Main(string[] args)
        {
            // Get input values from user
            Console.Write("Enter the total number of scripts to be marked: ");
            int totalScripts = int.Parse(Console.ReadLine());

            Console.Write("Enter the number of questions constituting the test (1-10): ");
            int numQuestions = int.Parse(Console.ReadLine());

            // Create an array to hold subtotals of each question
            double[] subtotals = new double[numQuestions];

            // Get subtotals of each question
            for (int i = 0; i < numQuestions; i++)
            {
                Console.Write($"Enter the subtotal of question {i + 1}: ");
                subtotals[i] = double.Parse(Console.ReadLine());
            }

            Console.Write("Enter the number of lecturers who will mark the scripts: ");
            int numLecturers = int.Parse(Console.ReadLine());

            // Calculate the number of scripts each lecturer will mark
            int scriptsPerLecturer = totalScripts / numLecturers;

            // Calculate the estimated time it will take each lecturer to finish marking their allocated scripts
            double timePerScript = 2.0 / 60.0; // Two seconds to mark a script
            double timePerLecturer = scriptsPerLecturer * subtotals.Sum() * timePerScript;

            // Display the results
            Console.WriteLine($"Each lecturer will mark {scriptsPerLecturer} scripts.");
            Console.WriteLine($"Estimated time for each lecturer to finish marking: {FormatTime(timePerLecturer)}");

            // If there are remaining scripts, assign them to the last lecturer
            int remainingScripts = totalScripts % numLecturers;
            if (remainingScripts > 0)
            {
                Console.WriteLine($"The last lecturer will mark {remainingScripts} additional scripts.");
            }

            Console.ReadLine(); // Wait for user to press Enter before closing console
        }

        // Method to format time in hours and minutes
        static string FormatTime(double hours)
        {
            int totalMinutes = (int)Math.Round(hours * 60);
            int hoursPart = totalMinutes / 60;
            int minutesPart = totalMinutes % 60;

            if (minutesPart >= 30)
            {
                hoursPart++; // If remaining seconds are more than 30
            }

            return $"{hoursPart} hours {minutesPart} minutes";


            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }


    }
}