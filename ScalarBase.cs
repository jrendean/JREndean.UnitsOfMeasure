/*  Units of Measure in C# - Attempt at a best scenerio reproduction of the Units
    of Measure feature in the F# power pack (http://fsharppowerpack.codeplex.com/).
    Copyright (C) 2010 JR Endean

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/
using System;
using System.Reflection;
using System.Globalization;

namespace JREndean.UnitsOfMeasure
{
    /// <summary>
    /// Base class for Scalar types.
    /// </summary>
    public abstract class ScalarBase
    {
        /// <summary>
        /// Function that allows for conversion of <see cref="JREndean.UnitsOfMeasure.Measurement.IUnit"/> values.
        /// </summary>
        /// <param name="newUnitType">The type of the unit to convert to.</param>
        /// <param name="unitType">The type of the unit to convert from.</param>
        /// <param name="initialValue">The initial value of the unit.</param>
        /// <param name="power">The exponent value of the unit that is being converted.</param>
        /// <returns>The calculated value.</returns>
        protected double ConvertUnits(Type newUnitType, Type unitType, double initialValue, int power)
        {
            // walk the base class hierarchy for newUnitType looking for unitType
            bool foundBase = false;
            double newValue = initialValue;
            Type newUnitTypeWalker = newUnitType;

            while (newUnitTypeWalker != typeof(Object))
            {
                if (newUnitTypeWalker == unitType)
                {
                    foundBase = true;
                    break;
                }

                for (int i = 1; i <= Math.Abs(power); i++)
                    newValue =
                        Double.Parse(
                            newUnitTypeWalker.InvokeMember(
                                power > 0 ? "FromBase" : "ToBase",
                                BindingFlags.Instance | BindingFlags.InvokeMethod | BindingFlags.Public,
                                null,
                                Activator.CreateInstance(newUnitTypeWalker),
                                new object[] { newValue },
                                CultureInfo.InvariantCulture).ToString(),
                            CultureInfo.InvariantCulture);

                newUnitTypeWalker = newUnitTypeWalker.BaseType;
            }

            // newUnitType is not derived from unitType, try the other way
            if (!foundBase)
            {
                newValue = initialValue;
                Type unitTypeWalker = unitType;

                while (unitTypeWalker != typeof(Object))
                {
                    if (unitTypeWalker == newUnitType)
                        break;

                    for (int i = 1; i <= Math.Abs(power); i++)
                        newValue =
                            Double.Parse(
                                unitTypeWalker.InvokeMember(
                                    power > 0 ? "ToBase" : "FromBase",
                                    BindingFlags.Instance | BindingFlags.InvokeMethod | BindingFlags.Public,
                                    null,
                                    Activator.CreateInstance(unitTypeWalker),
                                    new object[] { newValue },
                                    CultureInfo.InvariantCulture).ToString(),
                                CultureInfo.InvariantCulture);

                    unitTypeWalker = unitTypeWalker.BaseType;
                }
            }

            return newValue;
        }
    }
}
