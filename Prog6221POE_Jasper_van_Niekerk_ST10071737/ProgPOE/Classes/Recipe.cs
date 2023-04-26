//Jasper van Niekerk ST10071737
using System;

namespace ProgPOE.Classes
{
    internal class Recipe
    {
        /// <summary>
        /// Stores the name of a recipe.
        /// </summary>

        private String RecipeName = String.Empty;
        //___________________________________________________________________________________________________________

        /// <summary>
        /// Creates a new instance of the Ingredients class.
        /// </summary>
        private Ingredients IngredientsHere;
        //___________________________________________________________________________________________________________

        /// <summary>
        /// Creates a new instance of the Steps class.
        /// </summary>
        private Steps StepsHere = new Steps();
        //___________________________________________________________________________________________________________

        private IngredientUnitArr ingredientUnitArr = new IngredientUnitArr();

        /// <summary>
        /// Stores the length of the ingredients Array.
        /// </summary>
        private int IngrediantsLength = 0;
        //___________________________________________________________________________________________________________
        /// <summary>
        /// Stores the length of the steps Array.
        /// </summary>
        private int StepsLength = 0;
        //___________________________________________________________________________________________________________

        /// <summary>
        /// Represents an array of Ingredients objects.
        /// </summary>
        public Ingredients[] IngredientsArr;
        //___________________________________________________________________________________________________________

        /// <summary>
        /// Represents an array of Steps objects.
        /// </summary>
        public Steps[] StepsArr;
        //___________________________________________________________________________________________________________

        /// <summary>
        /// Constructor for the Recipe class. 
        /// </summary>
        /// <returns>
        /// A new instance of the Recipe class. 
        /// </returns>
        public Recipe()
        {
        }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// This method prompts the user to input the amount of ingredients their recipe has and then creates an array of Ingredients objects to store the ingredients. 
        /// </summary>
        public void inputIngredients()
        {
            Console.WriteLine("<>-----------------------------------------------------------<>");
            Console.WriteLine("Please input amount of ingredients your recipe has");
            while (true)
            {
                try
                {
                    this.IngrediantsLength = int.Parse(Console.ReadLine());
                    IngredientsArr = new Ingredients[this.IngrediantsLength];
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("<>-----------------------------------------------------------<>");
                    Console.WriteLine("Please enter a number");
                }
            }

            for (int i = 0; i < IngredientsArr.Length; i++)
            {
                IngredientsHere = new Ingredients();
                IngredientsHere.IngrediantsInput();
                IngredientsArr[i] = IngredientsHere;
            }
        }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// This method prompts the user to input the amount of steps their recipe has and then creates an array of Steps objects with the length of the amount of steps the user inputted.
        /// It then iterates through the array and calls the GetStepDescription() method for each Steps object.
        /// </summary>
        public void inputSteps()
        {
            Console.WriteLine("<>-----------------------------------------------------------<>");
            Console.WriteLine("Please input amount of steps your recipe has");
            while (true)
            {
                try
                {
                    this.StepsLength = int.Parse(Console.ReadLine());
                    StepsArr = new Steps[this.StepsLength];
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("<>-----------------------------------------------------------<>");
                    Console.WriteLine("Please enter a number");
                }
            }

            for (int i = 0; i < StepsArr.Length; i++)
            {
                StepsHere = new Steps();
                StepsHere.GetStepDescription();
                StepsArr[i] = StepsHere;
            }
        }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// Prompts the user to enter a recipe name and validates the input.
        /// </summary>
        /// <returns>The name of the recipe.</returns>
        private string GetRecipeName()
        {
            Console.WriteLine("<>-----------------------------------------------------------<>");
            Console.WriteLine("please enter the Recipe's name");

            bool IsValid = false;
            while (!IsValid)
            {
                var input = Console.ReadLine().Trim();

                try
                {
                    if (String.IsNullOrEmpty(input))
                    {
                        throw new ArgumentException("Input can not be empty");
                    }

                    this.RecipeName = input;
                    IsValid = true;
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("<>-----------------------------------------------------------<>");
                    Console.WriteLine("Invalid input please enter a recipe name");
                }
                catch (Exception)
                {
                    Console.WriteLine("<>-----------------------------------------------------------<>");
                    Console.WriteLine("Invalid input Please enter a valid recipe name");
                }
            }
            return this.RecipeName;
        }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// This method prompts the user to enter the recipe name, ingredients, and steps to create the recipe. 
        /// </summary>
        public void RecipeInput()
        {
            Console.WriteLine("<>-----------------------------------------------------------<>");
            Console.WriteLine("Please follow the steps to enter your recipe");
            this.GetRecipeName();
            this.inputIngredients();
            this.inputSteps();
        }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// Prints the recipe name and all of its ingredients and steps.
        /// </summary>
        public void printRecipe()
        {
            Console.WriteLine("<>-----------------------------------------------------------<>");
            Console.WriteLine("here is your recipe: " + this.RecipeName);
            Console.WriteLine("<>-----------------------------------------------------------<>");
            for (int i = 0; i < IngredientsArr.Length; i++)
            {
                IngredientsHere.PrintIngredient(IngredientsArr[i]);
            }
            Console.WriteLine("<>-----------------------------------------------------------<>");
            for (int i = 0; i < StepsArr.Length; i++)
            {
                StepsHere.PrintStepDescription(StepsArr[i]);
            }
        }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// This method scales the recipe by a given scaler. It prints the recipe and converts the ingredient units to the appropriate unit. 
        /// </summary>
        public void ScaleRecipe(double scaler, double descaler)
        {
            Console.WriteLine("<>-----------------------------------------------------------<>");
            Console.WriteLine("here is your recipe " + this.RecipeName + " scaled by " + scaler);
            bool convert = true;
            foreach (Ingredients ingredients in IngredientsArr)
            {
                string convertToDouble = ingredients.GetIngredientUoMQuantity();
                double toBeScaled = ingredientUnitArr.ReverseQuantityUnit(convertToDouble, convert);
                double isScaled = ingredientUnitArr.ScaleQuantity(toBeScaled, scaler);
                string final = ingredientUnitArr.GetQuantityUnit(isScaled);
                ingredients.SetIngredientUoMQuantity(final);
            }

            this.printRecipe();
            convert = false;

            foreach (Ingredients ingredients in IngredientsArr)
            {
                string convertToDouble = ingredients.GetIngredientUoMQuantity();
                double toBeScaled = ingredientUnitArr.ReverseQuantityUnit(convertToDouble, convert);
                double isScaled = ingredientUnitArr.ScaleQuantity(toBeScaled, descaler);
                string final = ingredientUnitArr.GetQuantityUnit(isScaled);
                ingredients.SetIngredientUoMQuantity(final);
            }
        }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// Clears the recipe by setting the recipe name to null and all ingredients and steps to null.
        /// </summary>
        public void clearRecipe()
        {
            RecipeName = null;

            for (int i = 0; i < IngrediantsLength; i++)
            {
                IngredientsArr[i] = null;
            }
            for (int i = 0; i < StepsLength; i++)
            {
                StepsArr[i] = null;
            }

        }

    }
}
//____________________________________EOF_________________________________________________________________________