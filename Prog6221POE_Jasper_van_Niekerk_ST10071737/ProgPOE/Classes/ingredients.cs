//Jasper van Niekerk ST10071737
using System;

namespace ProgPOE.Classes
{
    internal class Ingredients
    {

        /// <summary>
        /// Creates a new IngredientUnit object.
        /// </summary>
        private IngredientUnitArr unitArrHere = new IngredientUnitArr();
        //___________________________________________________________________________________________________________

        /// <summary>
        /// Property to store the name of an ingredient.
        /// </summary>
        private string IngredientName { get; set; } = String.Empty;
        //___________________________________________________________________________________________________________

        /// <summary>
        /// Property to store the quantity of an ingredient.
        /// </summary>
        private double IngredientQuantity { get; set; } = 0;
        //___________________________________________________________________________________________________________

        /// <summary>
        /// Property to store the ingredient unit of measure.
        /// </summary>
        private string IngredientUoM { get; set; } = String.Empty;
        //___________________________________________________________________________________________________________

        /// <summary>
        /// Property to store the ingredient unit of measure and quantity. 
        /// </summary>
        private string IngredientUoMQuantity { get; set; } = String.Empty;
        //___________________________________________________________________________________________________________

        /// <summary>
        /// Constructor for the ingredients class.
        /// </summary>
        /// <param name="IN">Name of the ingredient.</param>
        /// <param name="IQ">Quantity of the ingredient.</param>
        /// <param name="IUoM">Unit of measure of the ingredient.</param>
        /// <returns>
        /// An instance of the ingredients class.
        /// </returns>
        public Ingredients(string IN, int IQ, string IUoM)
        {
            this.IngredientName = IN;
            this.IngredientQuantity = IQ;
            this.IngredientUoM = IUoM;
        }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// Constructor for the Ingredients class. 
        /// </summary>
        /// <returns>
        /// Nothing. 
        /// </returns>
        public Ingredients()
        {
        }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// This method prompts the user to enter the details of an ingredient.
        /// </summary>
        public void IngrediantsInput()
        {
            Console.WriteLine("<>-----------------------------------------------------------<>");
            Console.WriteLine("Please enter the Ingredient Details");
            this.GetIngredientName();
            this.GetIngredientUoM();
            this.GetIngredientQuantity();
        }

        //___________________________________________________________________________________________________________

        /// <summary>
        /// Prints the ingredient name and quantity to the console.
        /// </summary>
        public void PrintIngredient(Ingredients ingredients)
        {
            string output = ingredients.IngredientUoMQuantity.Trim();
            bool valid = false;
            try
            {
                double testParse = double.Parse(output);
                valid = true;
            }
            catch
            {
                valid = false;
            }
            if (valid)
            {
                Console.WriteLine(ingredients.IngredientUoMQuantity.Trim() + " " + ingredients.IngredientName);
            }
            else
            {
                Console.WriteLine(ingredients.IngredientUoMQuantity.Trim() + " of " + ingredients.IngredientName);
            }

        }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// Prompts the user to enter an ingredient name and validates the input.
        /// </summary>
        /// <returns>The ingredient name entered by the user.</returns>
        private string GetIngredientName()
        {
            Console.WriteLine("<>-----------------------------------------------------------<>");
            Console.WriteLine("please enter the ingredients name");

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

                    this.IngredientName = input;
                    IsValid = true;
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("<>-----------------------------------------------------------<>");
                    Console.WriteLine("Invalid input please enter a ingrediant name");
                }
                catch (Exception)
                {
                    Console.WriteLine("<>-----------------------------------------------------------<>");
                    Console.WriteLine("Invalid input Please enter a valid ingrediant name");
                }
            }
            return this.IngredientName;
        }
        //___________________________________________________________________________________________________________


        /// <summary>
        /// Gets the quantity of an ingredient from the user and stores it in the IngredientQuantity property.
        /// </summary>
        /// <returns>The quantity of the ingredient.</returns>
        private double GetIngredientQuantity()
        {
            Console.WriteLine("<>-----------------------------------------------------------<>");
            Console.WriteLine("Please enter how many " + this.IngredientUoM + this.IngredientName + " your recipe needs");

            double quantity;
            double unitToBeScaled = 0;

            if (this.IngredientUoM.Trim().Equals(""))
            {
                unitToBeScaled = 1;
            }
            else
            {
                foreach (IngredientUnit unit in unitArrHere.UnitFactors)
                {
                    if (unit.UoMName.Trim().Equals(this.IngredientUoM.Trim()))
                    {
                        unitToBeScaled = unit.UoMValueMl;
                    }
                }
            }

            bool IsValid = false;
            while (!IsValid)
            {
                try
                {
                    if (unitToBeScaled == 1)
                    {
                        quantity = double.Parse(Console.ReadLine().Trim());
                        this.IngredientUoMQuantity = (quantity * unitToBeScaled).ToString();
                        this.IngredientQuantity = quantity;
                        IsValid = true;
                    }
                    else
                    {
                        quantity = double.Parse(Console.ReadLine().Trim());
                        this.IngredientUoMQuantity = unitArrHere.GetQuantityUnit(quantity * unitToBeScaled);
                        this.IngredientQuantity = quantity;
                        IsValid = true;
                    }


                }
                catch (FormatException)
                {
                    Console.WriteLine("<>-----------------------------------------------------------<>");
                    Console.WriteLine("Invalid input please enter a number");
                }
            }

            return this.IngredientQuantity;

        }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// Gets the ingredient unit of measure from the user.
        /// </summary>
        /// <returns>The name of the unit of measure.</returns>
        private string GetIngredientUoM()
        {
            Console.WriteLine("<>-----------------------------------------------------------<>");
            Console.WriteLine("please enter number of the unit you would like to use");
            unitArrHere.PrintUnitFactors();

            string UoMName = String.Empty;
            bool IsValid = false;
            while (!IsValid)
            {
                try
                {
                    int uom = int.Parse(Console.ReadLine().Trim());
                    if (uom == 0)
                    {
                        this.IngredientUoM = "";
                        IsValid = true;
                    }
                    else
                    {
                        UoMName = (unitArrHere.GetUoMName(uom)).Trim();
                        this.IngredientUoM = UoMName + " of ";
                        IsValid = true;
                    }

                }
                catch (FormatException)
                {
                    Console.WriteLine("<>-----------------------------------------------------------<>");
                    Console.WriteLine("Invalid input please enter a number");
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("<>-----------------------------------------------------------<>");
                    Console.WriteLine("Invalid input please enter a number from the list");
                }
            }

            return UoMName;
        }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// Gets the ingredient unit of measure quantity.
        /// </summary>
        /// <returns>The ingredient unit of measure quantity.</returns>
        public string GetIngredientUoMQuantity()
        {
            return this.IngredientUoMQuantity;
        }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// Sets the IngredientUoMQuantity of the ingredient object.
        /// </summary>
        /// <param name="newIUoMQ">The new IngredientUoMQuantity to set.</param>
        /// <returns>The IngredientUoMQuantity of the ingredient object.</returns>
        public string SetIngredientUoMQuantity(string newIUoMQ)
        {
            this.IngredientUoMQuantity = newIUoMQ;
            return this.IngredientUoMQuantity;
        }
    }
}
//____________________________________EOF_________________________________________________________________________