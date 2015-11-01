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
    /// <summary>
    /// Math functions for Physics
    /// </summary>
    public static class Math
    {

        #region Sqrt for Scalar!1, Scalar!2, Scalar!3

        /// <summary>
        /// Square root method for Scalar!1
        /// </summary>
        /// <typeparam name="T1">The type of the Scalar!1.</typeparam>
        /// <param name="scalar">The Scalar value to perform the square root on.</param>
        /// <returns>The square root of the Scalar!1.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Sqrt", Justification="This is how it is System.Math spells it")]
        public static Scalar<T1> Sqrt<T1>(Scalar<T1> scalar)
            where T1 : class, IUnit, new()
        {
            if (scalar == null)
                throw new ArgumentNullException("scalar");

            return new Scalar<T1>()
                {
                    Value = System.Math.Sqrt(scalar.Value),
                    Unit1Power = scalar.Unit1Power,
                };
        }

        /// <summary>
        /// Square root method for Scalar!2
        /// </summary>
        /// <typeparam name="T1">The first type of the Scalar!2.</typeparam>
        /// <typeparam name="T2">The second of the Scalar!2.</typeparam>
        /// <param name="scalar">The Scalar value to perform the square root on.</param>
        /// <returns>The square root of the Scalar!2.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Sqrt", Justification = "This is how it is System.Math spells it")]
        public static Scalar<T1, T2> Sqrt<T1, T2>(Scalar<T1, T2> scalar)
            where T1 : class, IUnit, new()
            where T2 : class, IUnit, new()
        {
            if (scalar == null)
                throw new ArgumentNullException("scalar");

            return new Scalar<T1, T2>()
                {
                    Value = System.Math.Sqrt(scalar.Value),
                    Unit1Power = scalar.Unit1Power,
                    Unit2Power = scalar.Unit2Power,
                };
        }

        /// <summary>
        /// Square root method for Scalar!3
        /// </summary>
        /// <typeparam name="T1">The first type of the Scalar!3.</typeparam>
        /// <typeparam name="T2">The second of the Scalar!3.</typeparam>
        /// <typeparam name="T3">The thrid of the Scalar!3.</typeparam>
        /// <param name="scalar">The Scalar value to perform the square root on.</param>
        /// <returns>The square root of the Scalar!3.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Sqrt", Justification = "This is how it is System.Math spells it")]
        public static Scalar<T1, T2, T3> Sqrt<T1, T2, T3>(Scalar<T1, T2, T3> scalar)
            where T1 : class, IUnit, new()
            where T2 : class, IUnit, new()
            where T3 : class, IUnit, new()
        {
            if (scalar == null)
                throw new ArgumentNullException("scalar");

            return new Scalar<T1, T2, T3>()
                {
                    Value = System.Math.Sqrt(scalar.Value),
                    Unit1Power = scalar.Unit1Power,
                    Unit2Power = scalar.Unit2Power,
                    Unit3Power = scalar.Unit3Power,
                };
        }

        #endregion

        #region Pow for Scalar!1, Scalar!2, Scalar!3

        /// <summary>
        /// Power method for Scalar!1
        /// </summary>
        /// <typeparam name="T1">The type of the Scalar!1.</typeparam>
        /// <param name="scalar">The Scalar value to perform the power operation on.</param>
        /// <param name="power">The power to raise the Scalar!1 value to.</param>
        /// <returns>The Scalar!1 raised to a power of <paramref name="power"/>.</returns>
        public static Scalar<T1> Pow<T1>(Scalar<T1> scalar, double power)
            where T1 : class, IUnit, new()
        {
            if (scalar == null)
                throw new ArgumentNullException("scalar");

            return new Scalar<T1>()
                {
                    Value = System.Math.Pow(scalar.Value, power),
                    Unit1Power = (int)(scalar.Unit1Power * power),
                };
        }

        /// <summary>
        /// Power method for Scalar!1
        /// </summary>
        /// <typeparam name="T1">The type of the Scalar!1.</typeparam>
        /// <param name="scalar">The Scalar value to perform the power operation on.</param>
        /// <param name="power">The Scalar to raise the Scalar!1 value to.</param>
        /// <returns>The Scalar!1 raised to a power of <paramref name="power"/>.</returns>
        public static Scalar<T1> Pow<T1>(Scalar<T1> scalar, Scalar<T1> power)
            where T1 : class, IUnit, new()
        {
            if (scalar == null)
                throw new ArgumentNullException("scalar");

            if (power == null)
                throw new ArgumentNullException("power");
            
            return new Scalar<T1>()
                {
                    Value = System.Math.Pow(scalar.Value, power.Value),
                    Unit1Power = scalar.Unit1Power + power.Unit1Power,
                };
        }

        /// <summary>
        /// Power method for Scalar!2
        /// </summary>
        /// <typeparam name="T1">The first type of the Scalar!2.</typeparam>
        /// <typeparam name="T2">The second type of the Scalar!2.</typeparam>
        /// <param name="scalar">The Scalar value to perform the power operation on.</param>
        /// <param name="power">The power to raise the Scalar!2 value to.</param>
        /// <returns>The Scalar!2 raised to a power of <paramref name="power"/>.</returns>
        public static Scalar<T1, T2> Pow<T1, T2>(Scalar<T1, T2> scalar, double power)
            where T1 : class, IUnit, new()
            where T2 : class, IUnit, new()
        {
            if (scalar == null)
                throw new ArgumentNullException("scalar");

            return new Scalar<T1, T2>()
                {
                    Value = System.Math.Pow(scalar.Value, power),
                    Unit1Power = (int)(scalar.Unit1Power * power),
                    Unit2Power = (int)(scalar.Unit2Power * power),
                };
        }

        /// <summary>
        /// Power method for Scalar!2
        /// </summary>
        /// <typeparam name="T1">The first type of the Scalar!2.</typeparam>
        /// <typeparam name="T2">The second type of the Scalar!2.</typeparam>
        /// <param name="scalar">The Scalar value to perform the power operation on.</param>
        /// <param name="power">The Scalar to raise the Scalar!2 value to.</param>
        /// <returns>The Scalar!2 raised to a power of <paramref name="power"/>.</returns>
        public static Scalar<T1, T2> Pow<T1, T2>(Scalar<T1, T2> scalar, Scalar<T1, T2> power)
            where T1 : class, IUnit, new()
            where T2 : class, IUnit, new()
        {
            if (scalar == null)
                throw new ArgumentNullException("scalar");

            if (power == null)
                throw new ArgumentNullException("power");

            return new Scalar<T1, T2>()
                {
                    Value = System.Math.Pow(scalar.Value, power.Value),
                    Unit1Power = scalar.Unit1Power + power.Unit1Power,
                    Unit2Power = scalar.Unit2Power + power.Unit2Power,
                };
        }

        /// <summary>
        /// Power method for Scalar!3
        /// </summary>
        /// <typeparam name="T1">The first type of the Scalar!3.</typeparam>
        /// <typeparam name="T2">The second type of the Scalar!3.</typeparam>
        /// <typeparam name="T3">The third type of the Scalar!3.</typeparam>
        /// <param name="scalar">The Scalar value to perform the power operation on.</param>
        /// <param name="power">The power to raise the Scalar!3 value to.</param>
        /// <returns>The Scalar!2 raised to a power of <paramref name="power"/>.</returns>
        public static Scalar<T1, T2, T3> Pow<T1, T2, T3>(Scalar<T1, T2, T3> scalar, double power)
            where T1 : class, IUnit, new()
            where T2 : class, IUnit, new()
            where T3 : class, IUnit, new()
        {
            if (scalar == null)
                throw new ArgumentNullException("scalar");

            return new Scalar<T1, T2, T3>()
                {
                    Value = System.Math.Pow(scalar.Value, power),
                    Unit1Power = (int)(scalar.Unit1Power * power),
                    Unit2Power = (int)(scalar.Unit2Power * power),
                    Unit3Power = (int)(scalar.Unit3Power * power),
                };
        }

        /// <summary>
        /// Power method for Scalar!3
        /// </summary>
        /// <typeparam name="T1">The first type of the Scalar!3.</typeparam>
        /// <typeparam name="T2">The second type of the Scalar!3.</typeparam>
        /// <typeparam name="T3">The third type of the Scalar!3.</typeparam>
        /// <param name="scalar">The Scalar value to perform the power operation on.</param>
        /// <param name="power">The Scalar to raise the Scalar!3 value to.</param>
        /// <returns>The Scalar!3 raised to a power of <paramref name="power"/>.</returns>
        public static Scalar<T1, T2, T3> Pow<T1, T2, T3>(Scalar<T1, T2, T3> scalar, Scalar<T1, T2, T3> power)
            where T1 : class, IUnit, new()
            where T2 : class, IUnit, new()
            where T3 : class, IUnit, new()
        {
            if (scalar == null)
                throw new ArgumentNullException("scalar");

            if (power == null)
                throw new ArgumentNullException("power");

            return new Scalar<T1, T2, T3>()
                {
                    Value = System.Math.Pow(scalar.Value, power.Value),
                    Unit1Power = scalar.Unit1Power + power.Unit1Power,
                    Unit2Power = scalar.Unit2Power + power.Unit2Power,
                    Unit3Power = scalar.Unit3Power + power.Unit3Power,
                };
        }

        #endregion

        /// <summary>
        /// Pass through property for PI.
        /// </summary>
        public static double PI
        {
            get { return System.Math.PI; }
        }

        /// <summary>
        /// Pass through method for Abs.
        /// </summary>
        /// <param name="data">The value</param>
        /// <returns>The absolute value of <paramref name="data"/>.</returns>
        public static int Abs(int data)
        {
            return System.Math.Abs(data);
        }
    }
}
