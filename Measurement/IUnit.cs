﻿/*  Units of Measure in C# - Attempt at a best scenerio reproduction of the Units
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

namespace JREndean.UnitsOfMeasure.Measurement
{
    /// <summary>
    /// The interface that all unit based classes must implement.
    /// </summary>
    public interface IUnit
    {
        /// <summary>
        /// Convert the current value to the base unit value.
        /// </summary>
        /// <param name="input">The value to be converted.</param>
        /// <returns>The value converted to the base unit value.</returns>
        double ToBase(double input);

        /// <summary>
        /// Convert the current value from the base unit value.
        /// </summary>
        /// <param name="input">The value to be converted.</param>
        /// <returns>The value converted from the base unit value.</returns>
        double FromBase(double input);
    }
}
