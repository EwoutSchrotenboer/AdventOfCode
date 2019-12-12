using AoC.Helpers.Utils;
using System.Drawing;

namespace AoC.Helpers.Models.Day04
{
    public class FabricClaim
    {
        public int Id { get; set; }

        public Rectangle Surface { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="FabricClaim"/> class.
        /// </summary>
        /// <param name="input">Input format: #1 @ 335,861: 14x10</param>
        public FabricClaim(string input)
        {
            var parts = input.Split(' ');

            this.SetId(parts[0]);

            var coordinate = this.GetCoordinate(parts[2]);
            var size = this.GetSize(parts[3]);
            this.Surface = new Rectangle(coordinate, size);
        }

        /// <summary>
        /// Sets the coordinates.
        /// </summary>
        /// <param name="input">Input format: 335,861:</param>
        private Point GetCoordinate(string input)
        {
            var cleanedInput = input.RemoveChar(':');
            var splitInput = cleanedInput.Split(',');

            var x = int.Parse(splitInput[0]);
            var y = int.Parse(splitInput[1]);

            return new Point(x, y);
        }

        /// <summary>
        /// Sets the size.
        /// </summary>
        /// <param name="input">Input format: 14x10</param>
        private Size GetSize(string input)
        {
            var splitInput = input.Split('x');

            var width = int.Parse(splitInput[0]);
            var height = int.Parse(splitInput[1]);

            return new Size(width, height);
        }

        /// <summary>
        /// Sets the identifier.
        /// </summary>
        /// <param name="input">Input format: #1</param>
        private void SetId(string input)
        {
            var cleanedInput = input.RemoveChar('#');
            this.Id = int.Parse(cleanedInput);
        }
    }
}