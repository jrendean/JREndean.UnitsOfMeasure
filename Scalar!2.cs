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
using System.Text;
using System.Globalization;
using System.Collections.Generic;
using JREndean.UnitsOfMeasure.Measurement;

namespace JREndean.UnitsOfMeasure
{
    /// <summary>
    /// A bianry scalar value types.
    /// </summary>
    /// <typeparam name="T1">The <see cref="IUnit"/> derived type.</typeparam>
    /// <typeparam name="T2">The <see cref="IUnit"/> derived type.</typeparam>
    public class Scalar<T1, T2>
        : ScalarBase, IComparable, IComparable<Scalar<T1, T2>>, IEquatable<Scalar<T1, T2>>, IEqualityComparer<Scalar<T1, T2>>
        where T1 : class, IUnit, new()
        where T2 : class, IUnit, new()
    {
        /// <summary>
        /// Default constructor. Sets Value = 0.0, all Units = new() and UnitPower = 1
        /// </summary>
        public Scalar()
        {
            Value = 0.0;
            Unit1 = new T1();
            Unit2 = new T2();
            Unit1Power = 1;
            Unit2Power = 1;
        }

        /// <summary>
        /// Implicit converter from a double
        /// </summary>
        /// <param name="value">The double value</param>
        /// <returns>A new instance of the Scalar</returns>
        public static implicit operator Scalar<T1, T2>(double value)
        {
            return new Scalar<T1, T2>()
            {
                Value = value,
            };
        }

        /// <summary>
        /// Allows for conversion of <see cref="IUnit"/> derived type.
        /// </summary>
        /// <remarks>
        /// Note: the type <typeparamref name="TN1"/> must be a relative of <typeparamref name="T1"/>.
        /// Note: the type <typeparamref name="TN2"/> must be a relative of <typeparamref name="T2"/>.
        /// </remarks>
        /// <typeparam name="TN1">The new type you want to convert the current scalar's type to.</typeparam>
        /// <typeparam name="TN2">The new type you want to convert the current scalar's type to.</typeparam>
        /// <returns>A new scalar with type of <typeparamref name="TN1"/>, <typeparamref name="TN2"/> who's value has been converted to <typeparamref name="TN1"/>, <typeparamref name="TN2"/>.</returns>
        public Scalar<TN1, TN2> To<TN1, TN2>()
            where TN1 : class, IUnit, new()
            where TN2 : class, IUnit, new()
        {
            TN1 newUnit1 = new TN1();
            TN2 newUnit2 = new TN2();

            foreach (Type t in Unit1.GetType().GetInterfaces())
                if (newUnit1.GetType().GetInterface(t.Name) == null)
                    throw new InvalidCastException(String.Format(CultureInfo.CurrentCulture, "You cannot convert {0} to {1}", Unit1.GetType(), newUnit1.GetType()));
            foreach (Type t in Unit2.GetType().GetInterfaces())
                if (newUnit2.GetType().GetInterface(t.Name) == null)
                    throw new InvalidCastException(String.Format(CultureInfo.CurrentCulture, "You cannot convert {0} to {1}", Unit2.GetType(), newUnit2.GetType()));

            double firstUnitValue = ConvertUnits(newUnit1.GetType(), Unit1.GetType(), Value, Unit1Power);
            double newValue = ConvertUnits(newUnit2.GetType(), Unit2.GetType(), firstUnitValue, Unit2Power);

            return new Scalar<TN1, TN2>()
            {
                Value = newValue,
                Unit1 = newUnit1,
                Unit2 = newUnit2,
                Unit1Power = Unit1Power,
                Unit2Power = Unit2Power,
            };
        }

        #region Algebraic operators

        /// <summary>
        /// The addition operator
        /// </summary>
        /// <param name="left">The first Scalar</param>
        /// <param name="right">The second Scalar</param>
        /// <returns>The result of the operation</returns>
        public static Scalar<T1, T2> operator +(Scalar<T1, T2> left, Scalar<T1, T2> right)
        {
            if (left == null)
                throw new ArgumentNullException("left");

            if (right == null)
                throw new ArgumentNullException("right");

            return new Scalar<T1, T2>()
                {
                    Value = left.Value + right.Value,
                };
        }

        /// <summary>
        /// Adds the current Scalar with another
        /// </summary>
        /// <param name="other">The other Scalar</param>
        /// <returns>The result of the operation</returns>
        public Scalar<T1, T2> Add(Scalar<T1, T2> other)
        {
            return this + other;
        }

        /// <summary>
        /// The subtraction operator
        /// </summary>
        /// <param name="left">The first Scalar</param>
        /// <param name="right">The second Scalar</param>
        /// <returns>The result of the operation</returns>
        public static Scalar<T1, T2> operator -(Scalar<T1, T2> left, Scalar<T1, T2> right)
        {
            if (left == null)
                throw new ArgumentNullException("left");

            if (right == null)
                throw new ArgumentNullException("right");

            return new Scalar<T1, T2>()
                {
                    Value = left.Value - right.Value,
                };
        }

        /// <summary>
        /// Subtracts the current Scalar with another
        /// </summary>
        /// <param name="other">The other Scalar</param>
        /// <returns>The result of the operation</returns>
        public Scalar<T1, T2> Subtract(Scalar<T1, T2> other)
        {
            return this + other;
        }

        #region Multiplication

        /// <summary>
        /// The multiplication operator
        /// </summary>
        /// <param name="left">The first Scalar</param>
        /// <param name="right">The second Scalar</param>
        /// <returns>The result of the operation</returns>
        public static Scalar<T1, T2> operator *(Scalar<T1, T2> left, Scalar<T1> right)
        {
            return Mulitplication<T1, T2>(left, right);
        }

        /// <summary>
        /// Multiplies the current Scalar with another
        /// </summary>
        /// <param name="other">The other Scalar</param>
        /// <returns>The result of the operation</returns>
        public Scalar<T1, T2> Multiply(Scalar<T1> other)
        {
            return this * other;
        }

        /// <summary>
        /// The multiplication operator
        /// </summary>
        /// <param name="left">The first Scalar</param>
        /// <param name="right">The second Scalar</param>
        /// <returns>The result of the operation</returns>
        public static Scalar<T1, T2> operator *(Scalar<T1, T2> left, Scalar<T2> right)
        {
            return Mulitplication<T1, T2>(left, right);
        }

        /// <summary>
        /// Multiplies the current Scalar with another
        /// </summary>
        /// <param name="other">The other Scalar</param>
        /// <returns>The result of the operation</returns>
        public Scalar<T1, T2> Multiply(Scalar<T2> other)
        {
            return this * other;
        }

        /// <summary>
        /// The multiplication operator
        /// </summary>
        /// <param name="left">The first Scalar</param>
        /// <param name="right">The second Scalar</param>
        /// <returns>The result of the operation</returns>
        public static Scalar<T1, T2> operator *(Scalar<T1, T2> left, Scalar<T1, T2> right)
        {
            return Mulitplication<T1, T2>(left, right);
        }

        /// <summary>
        /// Multiplies the current Scalar with another
        /// </summary>
        /// <param name="other">The other Scalar</param>
        /// <returns>The result of the operation</returns>
        public Scalar<T1, T2> Multiply(Scalar<T1, T2> other)
        {
            return this * other;
        }

        private static dynamic Mulitplication<T1, T2>(Scalar<T1, T2> left, dynamic right)
            where T1 : class, IUnit, new()
            where T2 : class, IUnit, new()
        {
            if (left == null)
                throw new ArgumentNullException("left");

            if (right == null)
                throw new ArgumentNullException("right");

            double newValue = left.Value * right.Value;
            int unit1Power = 0;
            int unit2Power = 0;

            if (right is Scalar<T1>)
            {
                unit1Power = left.Unit1Power + right.Unit1Power;
                unit2Power = left.Unit2Power;
            }
            else if (right is Scalar<T2>)
            {
                unit1Power = left.Unit1Power;
                unit2Power = left.Unit2Power + right.Unit1Power;
            }
            else if (right is Scalar<T1, T2>)
            {
                unit1Power = left.Unit1Power + right.Unit1Power;
                unit2Power = left.Unit2Power + right.Unit2Power;
            }

            if (unit1Power == 0)
                return new Scalar<T2>()
                {
                    Value = newValue,
                    Unit1Power = unit2Power,
                };
            else if (unit2Power == 0)
                return new Scalar<T1>()
                {
                    Value = newValue,
                    Unit1Power = unit1Power,
                };
            else
                return new Scalar<T1, T2>()
                {
                    Value = newValue,
                    Unit1Power = unit1Power,
                    Unit2Power = unit2Power,
                };
        }

        #endregion

        #region Division

        /// <summary>
        /// The division operator
        /// </summary>
        /// <param name="left">The first Scalar</param>
        /// <param name="right">The second Scalar</param>
        /// <returns>The result of the operation</returns>
        public static Scalar<T1, T2> operator /(Scalar<T1, T2> left, Scalar<T1> right)
        {
            return Division<T1, T2>(left, right);
        }

        /// <summary>
        /// Divides the current Scalar with another
        /// </summary>
        /// <param name="other">The other Scalar</param>
        /// <returns>The result of the operation</returns>
        public Scalar<T1, T2> Divide(Scalar<T1> other)
        {
            return this / other;
        }

        /// <summary>
        /// The division operator
        /// </summary>
        /// <param name="left">The first Scalar</param>
        /// <param name="right">The second Scalar</param>
        /// <returns>The result of the operation</returns>
        public static Scalar<T1, T2> operator /(Scalar<T1, T2> left, Scalar<T2> right)
        {
            return Division<T1, T2>(left, right);
        }

        /// <summary>
        /// Divides the current Scalar with another
        /// </summary>
        /// <param name="other">The other Scalar</param>
        /// <returns>The result of the operation</returns>
        public Scalar<T1, T2> Divide(Scalar<T2> other)
        {
            return this / other;
        }

        /// <summary>
        /// The division operator
        /// </summary>
        /// <param name="left">The first Scalar</param>
        /// <param name="right">The second Scalar</param>
        /// <returns>The result of the operation</returns>
        public static Scalar<T1, T2> operator /(Scalar<T1, T2> left, Scalar<T1, T2> right)
        {
            return Division<T1, T2>(left, right);
        }

        /// <summary>
        /// Divides the current Scalar with another
        /// </summary>
        /// <param name="other">The other Scalar</param>
        /// <returns>The result of the operation</returns>
        public Scalar<T1, T2> Divide(Scalar<T1, T2> other)
        {
            return this / other;
        }

        private static dynamic Division<T1, T2>(Scalar<T1, T2> left, dynamic right)
            where T1 : class, IUnit, new()
            where T2 : class, IUnit, new()
        {
            if (left == null)
                throw new ArgumentNullException("left");

            if (right == null)
                throw new ArgumentNullException("right");

            double newValue = left.Value / right.Value;
            int unit1Power = 0;
            int unit2Power = 0;

            if (right is Scalar<T1>)
            {
                unit1Power = left.Unit1Power - right.Unit1Power;
                unit2Power = left.Unit2Power;
            }
            else if (right is Scalar<T2>)
            {
                unit1Power = left.Unit1Power;
                unit2Power = left.Unit2Power - right.Unit1Power;
            }
            else if (right is Scalar<T1, T2>)
            {
                unit1Power = left.Unit1Power - right.Unit1Power;
                unit2Power = left.Unit2Power - right.Unit2Power;
            }

            if (unit1Power == 0)
                return new Scalar<T2>()
                {
                    Value = newValue,
                    Unit1Power = unit2Power,
                };
            else if (unit2Power == 0)
                return new Scalar<T1>()
                {
                    Value = newValue,
                    Unit1Power = unit1Power,
                };
            else
                return new Scalar<T1, T2>()
                {
                    Value = newValue,
                    Unit1Power = unit1Power,
                    Unit2Power = unit2Power,
                };
        }

        #endregion

        #endregion

        #region Comparison operators

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator <(Scalar<T1, T2> left, Scalar<T1, T2> right)
        {
            if (left == null)
                throw new ArgumentNullException("left");

            if (right == null)
                throw new ArgumentNullException("right");

            return left.Value < right.Value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator <=(Scalar<T1, T2> left, Scalar<T1, T2> right)
        {
            if (left == null)
                throw new ArgumentNullException("left");

            if (right == null)
                throw new ArgumentNullException("right");

            return left.Value <= right.Value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator >(Scalar<T1, T2> left, Scalar<T1, T2> right)
        {
            if (left == null)
                throw new ArgumentNullException("left");

            if (right == null)
                throw new ArgumentNullException("right");

            return left.Value > right.Value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator >=(Scalar<T1, T2> left, Scalar<T1, T2> right)
        {
            if (left == null)
                throw new ArgumentNullException("left");

            if (right == null)
                throw new ArgumentNullException("right");

            return left.Value >= right.Value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(Scalar<T1, T2> left, Scalar<T1, T2> right)
        {
            if (left == null)
                return false;

            if (right == null)
                return false;

            return left.Value == right.Value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(Scalar<T1, T2> left, Scalar<T1, T2> right)
        {
            if (left == null)
                return false;

            if (right == null)
                return false;

            return left.Value != right.Value;
        }

        #endregion

        #region Interface implimentations and Overrides

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int CompareTo(object obj)
        {
            Scalar<T1, T2> temp = obj as Scalar<T1, T2>;
            if (temp == null)
                throw new InvalidCastException("Cannot convert parameter \"obj\" into Scalar<T1, T2>");

            return CompareTo(temp);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(Scalar<T1, T2> other)
        {
            if (other == null)
                throw new ArgumentNullException("other");

            return this.Value.CompareTo(other.Value) + this.Unit1Power.CompareTo(other.Unit1Power) + this.Unit2Power.CompareTo(other.Unit2Power);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Scalar<T1, T2> other)
        {
            return this == other;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool Equals(Scalar<T1, T2> x, Scalar<T1, T2> y)
        {
            return x == y;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            Scalar<T1, T2> temp = obj as Scalar<T1, T2>;
            if (temp == null)
                return false;

            return this.Equals(temp); 
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return this.Value.GetHashCode() ^ this.Unit1.GetHashCode() ^ this.Unit1Power.GetHashCode() ^ this.Unit2.GetHashCode() ^ this.Unit2Power.GetHashCode();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int GetHashCode(Scalar<T1, T2> obj)
        {
            if (obj == null)
                throw new ArgumentNullException("obj");

            return obj.GetHashCode();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            // number
            StringBuilder returnString = new StringBuilder(Value.ToString(CultureInfo.CurrentCulture));

            // first unit
            returnString.AppendFormat(
                " {0}{1}",
                Unit1.GetType().Name, 
                ((Unit1Power == 1) ?
                    String.Empty :
                    ("^" + Unit1Power)));

            // divider
            returnString.Append((Unit2Power < 0) ? "/" : "*");

            //second unit
            returnString.AppendFormat(
                "{0}{1}",
                Unit2.GetType().Name,
                ((Math.Abs(Unit2Power) == 1) ?
                    String.Empty :
                    ("^" + Math.Abs(Unit2Power))));

            return returnString.ToString();
        }

        #endregion

        #region Properties

        /// <summary>
        /// The value of the scalar.
        /// </summary>
        public double Value
        {
            get;
            set;
        }

        /// <summary>
        /// The type of the first unit value.
        /// </summary>
        public T1 Unit1
        {
            get;
            internal set;
        }

        /// <summary>
        /// The type of the second unit value.
        /// </summary>
        public T2 Unit2
        {
            get;
            internal set;
        }

        /// <summary>
        ///  The power of the first unit.
        /// <remarks>Only positive values are allowed.</remarks>
        /// </summary>
        public int Unit1Power
        {
            get;
            set;
        }

        /// <summary>
        ///  The power of the second unit.
        /// <remarks>Negative values will give a division in the units. Positive values a multiplication in the units.</remarks>
        /// </summary>
        public int Unit2Power
        {
            get;
            set;
        }

        #endregion
    }
}

