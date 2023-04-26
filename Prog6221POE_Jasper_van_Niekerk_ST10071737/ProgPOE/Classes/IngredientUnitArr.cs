//Jasper van Niekerk ST10071737
using System;
using System.Collections;

namespace ProgPOE.Classes
{
    internal class IngredientUnitArr
    {
        /// <summary>
        /// Constructor for IngredientUnitArr class. 
        /// </summary>
        /// <returns>
        /// No return value. 
        /// </returns>
        public IngredientUnitArr()
        {
        }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// Stores a list of unit factors.
        /// </summary>
        public ArrayList UnitFactors = new ArrayList()
        {
            new IngredientUnit() { UoMIndex = 1, UoMName = "Cup(s)  ", UoMValueMl = 250},
            new IngredientUnit() { UoMIndex = 2, UoMName = "1/2 Cup(s)", UoMValueMl = 125 },
            new IngredientUnit() { UoMIndex = 3, UoMName = "1/4 Cup(s)", UoMValueMl = 62.5},
            new IngredientUnit() { UoMIndex = 4, UoMName = "1/8 Cup(s)", UoMValueMl = 31.25},
            new IngredientUnit() { UoMIndex = 5, UoMName = "Tablespoon(s)", UoMValueMl = 15},
            new IngredientUnit() { UoMIndex = 6, UoMName = "Teaspoon(s)", UoMValueMl = 5},
        };
        //___________________________________________________________________________________________________________

        /// <summary>
        /// Prints the unit measurements in ml for reference.
        /// </summary>
        public void PrintUnitFactors()
        {
            Console.WriteLine("<>-----------------------------------------------------------<>");
            Console.WriteLine("here are the unit measurements in ml for reference");
            Console.WriteLine("<>-----------------------------------------------------------<>");

            foreach (IngredientUnit unit in UnitFactors)
            {
                Console.WriteLine(unit.UoMIndex + " " + unit.UoMName + "\t Milliliter value: " + unit.UoMValueMl);
            }
            Console.WriteLine("if no unit of measurement is aplicable press 0");
        }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// Gets the name of the unit of measure for the given index.
        /// </summary>
        /// <param name="index">The index of the unit of measure.</param>
        /// <returns>The name of the unit of measure.</returns>
        public string GetUoMName(int index)
        {
            //return ((IngredientUnit)UnitFactors[index]).UoMName;
            foreach (IngredientUnit unit in UnitFactors)
            {
                if (unit.UoMIndex == index)
                {
                    return unit.UoMName;
                }
            }
            return "";

        }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// Gets the quantity unit for a given quantity.
        /// </summary>
        /// <param name="Quantity">The quantity.</param>
        /// <returns>
        /// The quantity unit.
        /// </returns>
        public string GetQuantityUnit(double Quantity)
        {
            double MlValue = Quantity;
            string result = string.Empty;

            for (int i = 0; i < this.UnitFactors.Count; i++)
            {
                IngredientUnit unit = (IngredientUnit)this.UnitFactors[i];

                if (MlValue >= unit.UoMValueMl)
                {
                    var NumberOfUnits = (int)(MlValue / unit.UoMValueMl);
                    result += NumberOfUnits + " " + unit.UoMName;

                    MlValue -= NumberOfUnits * unit.UoMValueMl;
                    if (MlValue > 0 && i < this.UnitFactors.Count - 1 && MlValue >= ((IngredientUnit)this.UnitFactors[i + 1]).UoMValueMl)
                    {
                        result += " ";
                    }
                }
            }

            if (result == string.Empty)
            {
                result = "1";
            }
            return result;
        }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// This method reverses the quantity unit of an input string.
        /// </summary>
        /// <param name="input">The input string.</param>
        /// <param name="type">The type of conversion.</param>
        /// <returns>The reversed quantity unit.</returns>
        public double ReverseQuantityUnit(string input, bool type)
        {
            string[] inputArr = input.Split(' ');
            double output = 0;

            for (int i = 0; i < inputArr.Length; i++)
            {

                for (int j = 0; j < UnitFactors.Count; j++)
                {
                    IngredientUnit unit = (IngredientUnit)this.UnitFactors[j];

                    if (inputArr[i].Equals(unit.UoMName.Trim()))
                    {
                        double multiplier = double.Parse(inputArr[i - 1].Trim());
                        if (type)
                        {
                            output += unit.UoMValueMl * multiplier;
                        }
                        if (!type)
                        {
                            output += unit.UoMValueMl;
                        }

                    }
                }
            }
            return output;
        }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// This method scales a given quantity by a given factor.
        /// </summary>
        /// <param name="quantity">The quantity to be scaled.</param>
        /// <param name="factor">The factor to scale the quantity by.</param>
        /// <returns>The scaled quantity.</returns>
        public double ScaleQuantity(double quantity, double factor)
        {
            return quantity * factor;
        }
        //___________________________________________________________________________________________________________
    }
}
//____________________________________EOF_________________________________________________________________________