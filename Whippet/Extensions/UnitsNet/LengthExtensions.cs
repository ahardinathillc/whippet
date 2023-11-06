using System;
using UnitsNet;
using UnitsNet.Units;

namespace Athi.Whippet.Extensions.UnitsNet
{
    /// <summary>
    /// Provides extension methods to <see cref="Length"/> objects. This class cannot be inherited.
    /// </summary>
    public static class LengthExtensions
    {
        /// <summary>
        /// Updates the original dimensions with the new <see cref="LengthUnit"/> and updates their new values.
        /// </summary>
        /// <param name="l"><see cref="Length"/> object.</param>
        /// <param name="newUnit">New unit of measure to apply.</param>
        /// <param name="oldLength">Original length.</param>
        /// <param name="oldWidth">Original width.</param>
        /// <param name="oldHeight">Original height.</param>
        /// <param name="newLength">New length.</param>
        /// <param name="newWidth">New width.</param>
        /// <param name="newHeight">New height.</param>
        public static void UnitOfMeasureChanged(this Length l, LengthUnit newUnit, Length oldLength, Length oldWidth, Length oldHeight, out Length newLength, out Length newWidth, out Length newHeight)
        {
            newLength = Length.From(UnitConverter.Convert(oldLength.Value, oldLength.Unit, newUnit), newUnit);
            newWidth = Length.From(UnitConverter.Convert(oldWidth.Value, oldWidth.Unit, newUnit), newUnit);
            newHeight = Length.From(UnitConverter.Convert(oldHeight.Value, oldHeight.Unit, newUnit), newUnit);
        }
    }
}

