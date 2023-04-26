//Jasper van Niekerk ST10071737
namespace ProgPOE.Classes
{
    internal class IngredientUnit
    {

        /// <summary>
        /// Property to store the index of the unit of measure. 
        /// </summary>
        public int UoMIndex { get; set; } = 0;
        //___________________________________________________________________________________________________________

        /// <summary>
        /// Property to store the name of the unit of measure.
        /// </summary>
        public string UoMName { get; set; } = string.Empty;
        //___________________________________________________________________________________________________________

        /// <summary>
        /// Property to store the value of UoM in milliliters.
        /// </summary>
        public double UoMValueMl { get; set; } = 0;
        //___________________________________________________________________________________________________________

        /// <summary>
        /// Constructor for IngredientUnit class which adds different units of measurement to the UnitFactors list.
        /// </summary>
        /// <returns>
        /// A list of IngredientUnit objects containing different units of measurement.
        /// </returns>
        public IngredientUnit()
        {

        }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// Constructor for IngredientUnit class.
        /// </summary>
        /// <param name="UoMI">Unit of Measurement Index</param>
        /// <param name="UoMN">Unit of Measurement Name</param>
        /// <param name="UoMML">Unit of Measurement Value in Milliliters</param>
        /// <param name="UoMG">Unit of Measurement Value in Grams</param>
        /// <returns>
        /// An instance of IngredientUnit class.
        /// </returns>
        public IngredientUnit(int UoMI, string UoMN, double UoMML)
        {
            this.UoMIndex = UoMI;
            this.UoMName = UoMN;
            this.UoMValueMl = UoMML;
        }
        //___________________________________________________________________________________________________________

    }
}
//____________________________________EOF_________________________________________________________________________