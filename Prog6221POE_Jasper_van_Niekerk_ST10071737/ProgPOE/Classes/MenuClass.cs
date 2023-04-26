//Jasper van Niekerk ST10071737
using System;

namespace ProgPOE.Classes
{
    internal class MenuClass
    {


        /// <summary>
        /// Creates a new instance of the Recipe class.
        /// </summary>
        Recipe recipeHere = new Recipe();
        //___________________________________________________________________________________________________________

        /// <summary>
        /// Displays the main menu for the user to choose from.
        /// </summary>
        public void MainMenu()
        {
            bool loop = false;

            while (!loop)
            {
                Console.WriteLine("<>-----------------------------------------------------------<>");
                Console.WriteLine("please choose what you want to do");
                Console.WriteLine("<>-----------------------------------------------------------<>");
                Console.WriteLine("press 1 to add your recipe");
                Console.WriteLine("press 2 to print your recipe");
                Console.WriteLine("press 3 to scale your recipe");
                Console.WriteLine("press 4 to clear your recipe");
                Console.WriteLine("press 5 to exit");
                Console.WriteLine("<>-----------------------------------------------------------<>");

                int choice;
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("<>-----------------------------------------------------------<>");
                    Console.WriteLine("Invalid input enter one of the given choices");
                }
                if (choice < 1 || choice > 5)
                {
                    Console.WriteLine("<>-----------------------------------------------------------<>");
                    Console.WriteLine("Invalid Input enter one of the given choices");
                }

                switch (choice)
                {
                    case 1:
                        this.RecipeInput();
                        break;
                    case 2:
                        this.RecipeOutput();
                        break;
                    case 3:
                        this.ScaleMenu();
                        break;
                    case 4:
                        this.clear();
                        break;
                    case 5:
                        Console.WriteLine("<>-----------------------------------------------------------<>");
                        Console.WriteLine("Goodbye");
                        return;

                }

            }
        }

        //___________________________________________________________________________________________________________

        /// <summary>
        /// This method calls the RecipeInput() method of the recipeHere object.
        /// </summary>
        public void RecipeInput()
        {
            recipeHere.RecipeInput();
        }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// Prints the recipe stored in the recipeHere object.
        /// </summary>
        public void RecipeOutput()
        {
            try
            {
                recipeHere.printRecipe();
            }
            catch (Exception)
            {
                Console.WriteLine("<>-----------------------------------------------------------<>");
                Console.WriteLine("there is no recipe at the moment ");
            }

        }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// Displays a menu to the user to select a scale for their recipe and calls the ScaleRecipe method with the selected scale.
        /// </summary>
        public void ScaleMenu()
        {
            Console.WriteLine("<>-----------------------------------------------------------<>");
            Console.WriteLine("please select a scale for your recipe");
            Console.WriteLine("<>-----------------------------------------------------------<>");
            Console.WriteLine("for a scale of 0.5 press 1");
            Console.WriteLine("for a scale of 2 press 2");
            Console.WriteLine("for a scale of 3 press 3");
            Console.WriteLine("for a scale of 1 press 4");
            Console.WriteLine("<>-----------------------------------------------------------<>");
            int choice = 0;
            bool isValid = false;

            while (!isValid)
            {
                try
                {
                    choice = int.Parse(Console.ReadLine());

                    if (choice < 1 || choice > 4)
                    {
                        Console.WriteLine("<>-----------------------------------------------------------<>");
                        Console.WriteLine("Invalid Input please enter one of the given options");
                    }
                    else
                    {
                        isValid = true;
                    }

                }
                catch (FormatException)
                {
                    Console.WriteLine("<>-----------------------------------------------------------<>");
                    Console.WriteLine("Invalid Input please enter one of the given options");
                }
            }
            switch (choice)
            {
                case 1:
                    recipeHere.ScaleRecipe(0.5, 2);
                    break;
                case 2:
                    recipeHere.ScaleRecipe(2, 2);
                    break;
                case 3:
                    recipeHere.ScaleRecipe(3,2);
                    break;
                case 4:
                    recipeHere.ScaleRecipe(1,1);
                    break;

            }
        }

        //___________________________________________________________________________________________________________

        /// <summary>
        /// Clears the recipe from the recipeHere object.
        /// </summary>
        public void clear()
        {
            Console.WriteLine("<>-----------------------------------------------------------<>");
            Console.WriteLine("recipe cleared");
            recipeHere.clearRecipe();
        }

        //___________________________________________________________________________________________________________

    }
}
//____________________________________EOF_________________________________________________________________________