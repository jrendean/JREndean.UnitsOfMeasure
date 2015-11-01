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
using JREndean.UnitsOfMeasure.Measurement;

namespace JREndean.UnitsOfMeasure
{

    #region Extension methods for Scalar!1

    /// <summary>
    /// Extension methods for Scalar!1
    /// </summary>
    public static class ScalarExtensions
    {
        /// <summary>
        /// Extension method that converts a double into a Scalar with a UnitPower equal to 1.
        /// </summary>
        /// <typeparam name="T1">The type of this Scalar value.</typeparam>
        /// <param name="value">The double value to convert to a Scalar.</param>
        /// <returns>A new Scalar instance of type <typeparamref name="T1"/> with value of <paramref name="value"/> and UnitPower of 1.</returns>
        public static Scalar<T1> Scalar<T1>(this double value)
            where T1 : class, IUnit, new()
        {
            return new Scalar<T1>()
            {
                Value = value,
            };
        }

        /// <summary>
        /// Extension method that converts a double into a Scalar with a UnitPower equal to <paramref name="unit1Power"/>.
        /// </summary>
        /// <typeparam name="T1">The type of this Scalar value.</typeparam>
        /// <param name="value">The double value to convert to a Scalar.</param>
        /// <param name="unit1Power">The power of the unit.</param>
        /// <returns>A new Scalar instance of type <typeparamref name="T1"/> with value of <paramref name="value"/> and UnitPower equal to <paramref name="unit1Power"/>.</returns>
        public static Scalar<T1> Scalar<T1>(this double value, int unit1Power)
           where T1 : class, IUnit, new()
        {
            return new Scalar<T1>()
            {
                Value = value,
                Unit1Power = unit1Power,
            };
        }

        /// <summary>
        /// Extension method that converts a Int32 into a Scalar with a UnitPower equal to 1.
        /// </summary>
        /// <typeparam name="T1">The type of this Scalar value.</typeparam>
        /// <param name="value">The Int32 value to convert to a Scalar.</param>
        /// <returns>A new Scalar instance of type <typeparamref name="T1"/> with value of <paramref name="value"/> and UnitPower of 1.</returns>
        public static Scalar<T1> Scalar<T1>(this int value)
            where T1 : class, IUnit, new()
        {
            return new Scalar<T1>()
            {
                Value = value,
            };
        }

        /// <summary>
        /// Extension method that converts a Int32 into a Scalar with a UnitPower equal to <paramref name="unit1Power"/>.
        /// </summary>
        /// <typeparam name="T1">The type of this Scalar value.</typeparam>
        /// <param name="value">The Int32 value to convert to a Scalar.</param>
        /// <param name="unit1Power">The power of the unit.</param>
        /// <returns>A new Scalar instance of type <typeparamref name="T1"/> with value of <paramref name="value"/> and UnitPower equal to <paramref name="unit1Power"/>.</returns>
        public static Scalar<T1> Scalar<T1>(this int value, int unit1Power)
            where T1 : class, IUnit, new()
        {
            return new Scalar<T1>()
            {
                Value = value,
                Unit1Power = unit1Power,
            };
        }

        /// <summary>
        /// Extension method that converts a Int64 into a Scalar with a UnitPower equal to 1.
        /// </summary>
        /// <typeparam name="T1">The type of this Scalar value.</typeparam>
        /// <param name="value">The Int64 value to convert to a Scalar.</param>
        /// <returns>A new Scalar instance of type <typeparamref name="T1"/> with value of <paramref name="value"/> and UnitPower of 1.</returns>
        public static Scalar<T1> Scalar<T1>(this long value)
            where T1 : class, IUnit, new()
        {
            return new Scalar<T1>()
            {
                Value = value,
            };
        }

        /// <summary>
        /// Extension method that converts a Int64 into a Scalar with a UnitPower equal to <paramref name="unit1Power"/>.
        /// </summary>
        /// <typeparam name="T1">The type of this Scalar value.</typeparam>
        /// <param name="value">The Int64 value to convert to a Scalar.</param>
        /// <param name="unit1Power">The power of the unit.</param>
        /// <returns>A new Scalar instance of type <typeparamref name="T1"/> with value of <paramref name="value"/> and UnitPower equal to <paramref name="unit1Power"/>.</returns>
        public static Scalar<T1> Scalar<T1>(this long value, int unit1Power)
            where T1 : class, IUnit, new()
        {
            return new Scalar<T1>()
            {
                Value = value,
                Unit1Power = unit1Power,
            };
        }
    }

    #endregion

    #region Extension methods for Scalar!2

    /// <summary>
    /// Extension methods for Scalar!2
    /// </summary>
    public static class Scalar2Extensions
    {
        /// <summary>
        /// Extension method that converts a double into a Scalar with both UnitPowers equal to 1.
        /// </summary>
        /// <typeparam name="T1">The first type of this Scalar value.</typeparam>
        /// <typeparam name="T2">The second type of this Scalar value.</typeparam>
        /// <param name="value">The double value to convert to a Scalar.</param>
        /// <returns>A new Scalar instance of type <typeparamref name="T1"/>, <typeparamref name="T2"/> with value of <paramref name="value"/> with both UnitPowers equal to 1.</returns>
        public static Scalar<T1, T2> Scalar<T1, T2>(this double value)
            where T1 : class, IUnit, new()
            where T2 : class, IUnit, new()
        {
            return new Scalar<T1, T2>()
            {
                Value = value,
            };
        }

        /// <summary>
        /// Extension method that converts a double into a Scalar with the first UnitPower equal to <paramref name="unit1Power"/> and the second UnitPower equal to <paramref name="unit2Power"/>.
        /// </summary>
        /// <typeparam name="T1">The first type of this Scalar value.</typeparam>
        /// <typeparam name="T2">The second type of this Scalar value.</typeparam>
        /// <param name="value">The double value to convert to a Scalar.</param>
        /// <param name="unit1Power">The power of the first unit.</param>
        /// <param name="unit2Power">The power of the second unit.</param>
        /// <returns>A new Scalar instance of type <typeparamref name="T1"/>, <typeparamref name="T2"/> with value of <paramref name="value"/> with the first UnitPower equal to <paramref name="unit1Power"/> and the second UnitPower equal to <paramref name="unit2Power"/>.</returns>
        public static Scalar<T1, T2> Scalar<T1, T2>(this double value, int unit1Power, int unit2Power)
            where T1 : class, IUnit, new()
            where T2 : class, IUnit, new()
        {
            if (unit1Power == 0 || unit2Power == 0)
                throw new NotSupportedException("You should not have a power of 0 in the first or second unit. Try Scalar!1 instead");

            if (unit1Power < 0)
                throw new NotSupportedException("The first unit cannot be negative");

            return new Scalar<T1, T2>()
            {
                Value = value,
                Unit1Power = unit1Power,
                Unit2Power = unit2Power,
            };
        }

        /// <summary>
        /// Extension method that converts a Int32 into a Scalar with both UnitPowers equal to 1.
        /// </summary>
        /// <typeparam name="T1">The first type of this Scalar value.</typeparam>
        /// <typeparam name="T2">The second type of this Scalar value.</typeparam>
        /// <param name="value">The Int32 value to convert to a Scalar.</param>
        /// <returns>A new Scalar instance of type <typeparamref name="T1"/>, <typeparamref name="T2"/> with value of <paramref name="value"/> with both UnitPowers equal to 1.</returns>
        public static Scalar<T1, T2> Scalar<T1, T2>(this int value)
            where T1 : class, IUnit, new()
            where T2 : class, IUnit, new()
        {
            return new Scalar<T1, T2>()
            {
                Value = value,
            };
        }

        /// <summary>
        /// Extension method that converts a Int32 into a Scalar with the first UnitPower equal to <paramref name="unit1Power"/> and the second UnitPower equal to <paramref name="unit2Power"/>.
        /// </summary>
        /// <typeparam name="T1">The first type of this Scalar value.</typeparam>
        /// <typeparam name="T2">The second type of this Scalar value.</typeparam>
        /// <param name="value">The Int32 value to convert to a Scalar.</param>
        /// <param name="unit1Power">The power of the first unit.</param>
        /// <param name="unit2Power">The power of the second unit.</param>
        /// <returns>A new Scalar instance of type <typeparamref name="T1"/>, <typeparamref name="T2"/> with value of <paramref name="value"/> with the first UnitPower equal to <paramref name="unit1Power"/> and the second UnitPower equal to <paramref name="unit2Power"/>.</returns>
        public static Scalar<T1, T2> Scalar<T1, T2>(this int value, int unit1Power, int unit2Power)
            where T1 : class, IUnit, new()
            where T2 : class, IUnit, new()
        {
            if (unit1Power == 0 || unit2Power == 0)
                throw new NotSupportedException("You should not have a power of 0 in the first or second unit. Try Scalar!1 instead");

            if (unit1Power < 0)
                throw new NotSupportedException("The first unit cannot be negative");

            return new Scalar<T1, T2>()
            {
                Value = value,
                Unit1Power = unit1Power,
                Unit2Power = unit2Power,
            };
        }

        /// <summary>
        /// Extension method that converts a Int64 into a Scalar with both UnitPowers equal to 1.
        /// </summary>
        /// <typeparam name="T1">The first type of this Scalar value.</typeparam>
        /// <typeparam name="T2">The second type of this Scalar value.</typeparam>
        /// <param name="value">The Int64 value to convert to a Scalar.</param>
        /// <returns>A new Scalar instance of type <typeparamref name="T1"/>, <typeparamref name="T2"/> with value of <paramref name="value"/> with both UnitPowers equal to 1.</returns>
        public static Scalar<T1, T2> Scalar<T1, T2>(this long value)
            where T1 : class, IUnit, new()
            where T2 : class, IUnit, new()
        {
            return new Scalar<T1, T2>()
            {
                Value = value,
            };
        }

        /// <summary>
        /// Extension method that converts a Int64 into a Scalar with the first UnitPower equal to <paramref name="unit1Power"/> and the second UnitPower equal to <paramref name="unit2Power"/>.
        /// </summary>
        /// <typeparam name="T1">The first type of this Scalar value.</typeparam>
        /// <typeparam name="T2">The second type of this Scalar value.</typeparam>
        /// <param name="value">The Int64 value to convert to a Scalar.</param>
        /// <param name="unit1Power">The power of the first unit.</param>
        /// <param name="unit2Power">The power of the second unit.</param>
        /// <returns>A new Scalar instance of type <typeparamref name="T1"/>, <typeparamref name="T2"/> with value of <paramref name="value"/> with the first UnitPower equal to <paramref name="unit1Power"/> and the second UnitPower equal to <paramref name="unit2Power"/>.</returns>
        public static Scalar<T1, T2> Scalar<T1, T2>(this long value, int unit1Power, int unit2Power)
            where T1 : class, IUnit, new()
            where T2 : class, IUnit, new()
        {
            if (unit1Power == 0 || unit2Power == 0)
                throw new NotSupportedException("You should not have a power of 0 in the first or second unit. Try Scalar!1 instead");

            if (unit1Power < 0)
                throw new NotSupportedException("The first unit cannot be negative");

            return new Scalar<T1, T2>()
            {
                Value = value,
                Unit1Power = unit1Power,
                Unit2Power = unit2Power,
            };
        }
    }

    #endregion

    #region Extension methods for Scalar!3

    /// <summary>
    /// Extension methods for Scalar!3
    /// </summary>
    public static class Scalar3Extensions
    {
        /// <summary>
        /// Extension method that converts a double into a Scalar with all UnitPowers equal to 1.
        /// </summary>
        /// <typeparam name="T1">The first type of this Scalar value.</typeparam>
        /// <typeparam name="T2">The second type of this Scalar value.</typeparam>
        /// <typeparam name="T3">The third type of this Scalar value.</typeparam>
        /// <param name="value">The double value to convert to a Scalar.</param>
        /// <returns>A new Scalar instance of type <typeparamref name="T1"/>, <typeparamref name="T2"/>, <typeparamref name="T3"/> with value of <paramref name="value"/> with all UnitPowers equal to 1.</returns>
        public static Scalar<T1, T2, T3> Scalar<T1, T2, T3>(this double value)
            where T1 : class, IUnit, new()
            where T2 : class, IUnit, new()
            where T3 : class, IUnit, new()
        {
            return new Scalar<T1, T2, T3>()
            {
                Value = value,
            };
        }

        /// <summary>
        /// Extension method that converts a double into a Scalar with the first UnitPower equal to <paramref name="unit1Power"/>, the second UnitPower equal to <paramref name="unit2Power"/> and the thrid UnitPower equal to <paramref name="unit3Power"/>.
        /// </summary>
        /// <typeparam name="T1">The first type of this Scalar value.</typeparam>
        /// <typeparam name="T2">The second type of this Scalar value.</typeparam>
        /// <typeparam name="T3">The third type of this Scalar value.</typeparam>
        /// <param name="value">The double value to convert to a Scalar.</param>
        /// <param name="unit1Power">The power of the first unit.</param>
        /// <param name="unit2Power">The power of the second unit.</param>
        /// <param name="unit3Power">The power of the third unit.</param>
        /// <returns>A new Scalar instance of type <typeparamref name="T1"/>, <typeparamref name="T2"/>, <typeparamref name="T3"/> with value of <paramref name="value"/> with the first UnitPower equal to <paramref name="unit1Power"/>, the second UnitPower equal to <paramref name="unit2Power"/> and the thrid UnitPower equal to <paramref name="unit3Power"/>.</returns>
        public static Scalar<T1, T2, T3> Scalar<T1, T2, T3>(this double value, int unit1Power, int unit2Power, int unit3Power)
            where T1 : class, IUnit, new()
            where T2 : class, IUnit, new()
            where T3 : class, IUnit, new()
        {
            if (unit1Power == 0 || unit2Power == 0 || unit3Power == 0)
                throw new NotSupportedException("You should not have a power of 0 in the first, second or third unit. Try Scalar!2 or Scalar!1 instead");

            if (unit1Power < 0)
                throw new NotSupportedException("The first unit cannot be negative");

            return new Scalar<T1, T2, T3>()
            {
                Value = value,
                Unit1Power = unit1Power,
                Unit2Power = unit2Power,
                Unit3Power = unit3Power,
            };
        }

        /// <summary>
        /// Extension method that converts a Int32 into a Scalar with all UnitPowers equal to 1.
        /// </summary>
        /// <typeparam name="T1">The first type of this Scalar value.</typeparam>
        /// <typeparam name="T2">The second type of this Scalar value.</typeparam>
        /// <typeparam name="T3">The third type of this Scalar value.</typeparam>
        /// <param name="value">The Int32 value to convert to a Scalar.</param>
        /// <returns>A new Scalar instance of type <typeparamref name="T1"/>, <typeparamref name="T2"/>, <typeparamref name="T3"/> with value of <paramref name="value"/> with all UnitPowers equal to 1.</returns>
        public static Scalar<T1, T2, T3> Scalar<T1, T2, T3>(this int value)
            where T1 : class, IUnit, new()
            where T2 : class, IUnit, new()
            where T3 : class, IUnit, new()
        {
            return new Scalar<T1, T2, T3>()
            {
                Value = value,
            };
        }

        /// <summary>
        /// Extension method that converts a Int32 into a Scalar with the first UnitPower equal to <paramref name="unit1Power"/>, the second UnitPower equal to <paramref name="unit2Power"/> and the thrid UnitPower equal to <paramref name="unit3Power"/>.
        /// </summary>
        /// <typeparam name="T1">The first type of this Scalar value.</typeparam>
        /// <typeparam name="T2">The second type of this Scalar value.</typeparam>
        /// <typeparam name="T3">The third type of this Scalar value.</typeparam>
        /// <param name="value">The Int32 value to convert to a Scalar.</param>
        /// <param name="unit1Power">The power of the first unit.</param>
        /// <param name="unit2Power">The power of the second unit.</param>
        /// <param name="unit3Power">The power of the third unit.</param>
        /// <returns>A new Scalar instance of type <typeparamref name="T1"/>, <typeparamref name="T2"/>, <typeparamref name="T3"/> with value of <paramref name="value"/> with the first UnitPower equal to <paramref name="unit1Power"/>, the second UnitPower equal to <paramref name="unit2Power"/> and the thrid UnitPower equal to <paramref name="unit3Power"/>.</returns>
        public static Scalar<T1, T2, T3> Scalar<T1, T2, T3>(this int value, int unit1Power, int unit2Power, int unit3Power)
            where T1 : class, IUnit, new()
            where T2 : class, IUnit, new()
            where T3 : class, IUnit, new()
        {
            if (unit1Power == 0 || unit2Power == 0 || unit3Power == 0)
                throw new NotSupportedException("You should not have a power of 0 in the first, second or third unit. Try Scalar!2 or Scalar!1 instead");

            if (unit1Power < 0)
                throw new NotSupportedException("The first unit cannot be negative");

            return new Scalar<T1, T2, T3>()
            {
                Value = value,
                Unit1Power = unit1Power,
                Unit2Power = unit2Power,
                Unit3Power = unit3Power,
            };
        }

        /// <summary>
        /// Extension method that converts a Int64 into a Scalar with all UnitPowers equal to 1.
        /// </summary>
        /// <typeparam name="T1">The first type of this Scalar value.</typeparam>
        /// <typeparam name="T2">The second type of this Scalar value.</typeparam>
        /// <typeparam name="T3">The third type of this Scalar value.</typeparam>
        /// <param name="value">The Int64 value to convert to a Scalar.</param>
        /// <returns>A new Scalar instance of type <typeparamref name="T1"/>, <typeparamref name="T2"/>, <typeparamref name="T3"/> with value of <paramref name="value"/> with all UnitPowers equal to 1.</returns>
        public static Scalar<T1, T2, T3> Scalar<T1, T2, T3>(this long value)
            where T1 : class, IUnit, new()
            where T2 : class, IUnit, new()
            where T3 : class, IUnit, new()
        {
            return new Scalar<T1, T2, T3>()
            {
                Value = value,
            };
        }

        /// <summary>
        /// Extension method that converts a Int64 into a Scalar with the first UnitPower equal to <paramref name="unit1Power"/>, the second UnitPower equal to <paramref name="unit2Power"/> and the thrid UnitPower equal to <paramref name="unit3Power"/>.
        /// </summary>
        /// <typeparam name="T1">The first type of this Scalar value.</typeparam>
        /// <typeparam name="T2">The second type of this Scalar value.</typeparam>
        /// <typeparam name="T3">The third type of this Scalar value.</typeparam>
        /// <param name="value">The Int64 value to convert to a Scalar.</param>
        /// <param name="unit1Power">The power of the first unit.</param>
        /// <param name="unit2Power">The power of the second unit.</param>
        /// <param name="unit3Power">The power of the third unit.</param>
        /// <returns>A new Scalar instance of type <typeparamref name="T1"/>, <typeparamref name="T2"/>, <typeparamref name="T3"/> with value of <paramref name="value"/> with the first UnitPower equal to <paramref name="unit1Power"/>, the second UnitPower equal to <paramref name="unit2Power"/> and the thrid UnitPower equal to <paramref name="unit3Power"/>.</returns>
        public static Scalar<T1, T2, T3> Scalar<T1, T2, T3>(this long value, int unit1Power, int unit2Power, int unit3Power)
            where T1 : class, IUnit, new()
            where T2 : class, IUnit, new()
            where T3 : class, IUnit, new()
        {
            if (unit1Power == 0 || unit2Power == 0 || unit3Power == 0)
                throw new NotSupportedException("You should not have a power of 0 in the first, second or third unit. Try Scalar!2 or Scalar!1 instead");

            if (unit1Power < 0)
                throw new NotSupportedException("The first unit cannot be negative");

            return new Scalar<T1, T2, T3>()
            {
                Value = value,
                Unit1Power = unit1Power,
                Unit2Power = unit2Power,
                Unit3Power = unit3Power,
            };
        }
    }

    #endregion

}
