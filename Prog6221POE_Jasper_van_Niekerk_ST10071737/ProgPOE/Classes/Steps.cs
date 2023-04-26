//Jasper van Niekerk ST10071737
using System;

namespace ProgPOE.Classes
{
    internal class Steps
    {

        /// <summary>
        /// Property to store the description of a step.
        /// </summary>
        private string StepDescription { get; set; } = String.Empty;
        //___________________________________________________________________________________________________________

        /// <summary>
        /// Constructor for Steps class to set the StepDescription property.
        /// </summary>
        /// <param name="SD">Step Description</param>
        /// <returns>
        /// N/A
        /// </returns>
        public Steps(string SD)
        {
            this.StepDescription = SD;
        }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// Constructor for the Steps class. 
        /// </summary>
        /// <returns>
        /// Nothing. 
        /// </returns>
        public Steps()
        {
        }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// Prompts the user to enter a description for the step and validates the input.
        /// </summary>
        /// <returns>The description of the step.</returns>
        public String GetStepDescription()
        {
            Console.WriteLine("<>-----------------------------------------------------------<>");
            Console.WriteLine("please enter a decription of this step");

            bool IsValid = false;
            while (!IsValid)
            {
                var step = Console.ReadLine().Trim();

                try
                {
                    if (String.IsNullOrEmpty(step))
                    {
                        throw new ArgumentException("Input can not be empty");
                    }
                    this.StepDescription = step;

                    IsValid = true;
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("<>-----------------------------------------------------------<>");
                    Console.WriteLine("Invalid input please enter a description");
                }
                catch (Exception)
                {
                    Console.WriteLine("<>-----------------------------------------------------------<>");
                    Console.WriteLine("Invalid input please enter a valid decription");
                }
            }
            return this.StepDescription;
        }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// Splits a string into multiple lines of a maximum character length
        /// </summary>
        /// <param name="description">The string to be split</param>
        /// <returns>The split string</returns>
        public string SplitStepDescription(string description)
        {
            const int MAXCHARSPERLINE = 60;
            string[] words = description.Split(' ');
            string output = String.Empty;
            string currentline = String.Empty;

            foreach (string word in words)
            {
                if (currentline.Length + word.Length + 1 <= MAXCHARSPERLINE)
                {
                    currentline += (currentline == "" ? "" : " ") + word;
                }
                else
                {
                    output += currentline + "\n\r";
                    currentline = word;
                }
            }

            output += currentline;
            return output;

        }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// Prints the step description to the console.
        /// </summary>
        public void PrintStepDescription(Steps step)
        {
            Console.WriteLine(this.SplitStepDescription(step.StepDescription));
        }
    }
}
//____________________________________EOF_________________________________________________________________________