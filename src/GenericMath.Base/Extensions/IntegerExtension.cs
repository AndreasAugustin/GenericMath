//  *************************************************************
// <copyright file="IntegerExtension.cs" company="SuperDevelop">
//     Copyright (c) 2014 andy. All rights reserved.
// </copyright>
// <author>andy</author>
// <email>andreas.augustinba@gmx.de</email>
// *************************************************************
//   1.0.0 15/7/ 2014 Created the Class
// *************************************************************

namespace GenericMath.Base
{
    using System;
    using System.Diagnostics;
    using System.Linq.Expressions;
    using System.Reflection;

    /// <summary>
    /// Extension Methods for the Integer class.
    /// </summary>
    public static class IntegerExtension
    {
        #region METHODS

        /// <summary>
        /// Calculates the gcd (greatest common divisor) with the euclidian algorithm.
        /// </summary>
        /// <returns>The gcd of a and b.</returns>
        /// <param name="a">The alpha component.</param>
        /// <param name="b">The blue component.</param>
        /// <returns>The gcd of a and b</returns>
        public static Int32 EuclidianAlgorithm(this Int32 a, Int32 b)
        {
            Int32 gcd;
            a = Math.Abs(a);
            b = Math.Abs(b);

            while (b != 0)
            {
                gcd = a % b;
                a = b;
                b = gcd;
            }

            gcd = a;
            return gcd;
        }

        /// <summary>
        /// Extends the euclidian algorithm.
        /// It also calculates x,y.
        /// gcd(a,b) = a * x + b * y.
        /// </summary>
        /// <returns>The euclidian algorithm.</returns>
        /// <param name="a">The alpha component.</param>
        /// <param name="b">The blue component.</param>
        /// <param name="x">The x coordinate.</param>
        /// <param name="y">The y coordinate.</param>
        /// <returns>The gcd of a and b</returns>
        public static Int32 ExtendedEuclidianAlgorithm(
            this Int32 a,
            Int32 b,
            out Int32 x,
            out Int32 y)
        {
            Int32 q;
            Int32 r;
            Int32 xx;
            Int32 yy;
            Int32 gcd = 0;
            Int32 sign = 1;
            var xs = new Int32[2];
            var ys = new Int32[2];

            xs[0] = 1;
            xs[1] = 0;
            ys[0] = 0;
            ys[1] = 1;

            // till b != 0 a = b, b = a%b
            // calculate coefficients
            while (b != 0)
            {
                r = a % b;
                q = a / b;
                a = b;
                b = r;
                xx = xs[1];
                yy = ys[1];
                xs[1] = (q * xs[1]) + xs[0];
                ys[1] = (q * ys[1]) + ys[0];
                xs[0] = xx;
                ys[0] = yy;
                sign = -sign;
            }

            // calculate coefficients
            x = sign * xs[0];
            y = -sign * ys[0];

            gcd = a;

            return gcd;
        }

        /// <summary>
        /// Calculates the chinese rest term algorithm.
        /// Calculates a solution for the equation 
        /// result = x[0] mod moduli[0]
        /// result = x[1] mod moduli[1]
        /// .....
        /// result = x[n] mod moduli[n]
        /// It needs to be true that gcd(moduli) = 1
        /// </summary>
        /// <returns>The rest term.</returns>
        /// <param name="moduli">The moduli.</param>
        /// <param name="x">The parameters.</param>
        /// <returns>The solution for the equation posted above.</returns>
        public static Int32 ChineseRestTerm(this int[] moduli, int[] x)
        {
            if (moduli.Length != x.Length)
            {
                throw new IndexOutOfRangeException("The index for the moduli and the x do not agree");
            }

            var multipliers = new int[moduli.Length];
            var result = 0;
            var modulus = ChineseRestTermHelper(moduli, ref multipliers);
            for (var i = 0; i < moduli.Length; i++)
            {
                result = (result + (multipliers[i] * x[i])) % modulus;
            }

            return result;
        }

        #endregion

        #region HELPER METHODS

        private static int ChineseRestTermHelper(
            Int32[] moduli,
            ref Int32[] multipliers)
        {
            var modulus = 1;

            // calculate the modulus (the product of all moduli)
            for (var i = 0; i < moduli.Length; i++)
            {
                modulus *= moduli[i];
            }

            var m = 0;
            var inverse = 0;
            var gcd = 0;
            var y = 0;

            for (var i = 0; i < moduli.Length; i++)
            {
                m = modulus / moduli[i];

                gcd = m.ExtendedEuclidianAlgorithm(
                    moduli[i],
                    out inverse,
                    out y);
                if (gcd != 1)
                {
                    throw new InvalidOperationException("gcd(moduli) != 1"); // TODO find other solution (extend to integer rings)
                }
                    
                multipliers[i] = inverse * (m % modulus); 
            }

            return modulus;
        }

        #endregion

        #region DEBUG METHODS

        [Conditional("DEBUG")]
        private static void Checkvariable<T>(Expression<Func<T>> expr) where T : struct
        {
            // Grab name of calling method
            var methodName = new StackTrace().GetFrame(1).GetMethod().Name;

            Console.WriteLine(string.Format("Method: {0}", methodName));
            var body = (MemberExpression)expr.Body;
            Console.WriteLine("Name is: {0}", body.Member.Name);
            Console.WriteLine(
                "Value is: {0}",
                ((FieldInfo)body.Member).GetValue(((ConstantExpression)body.Expression).Value));
        }

        #endregion
    }
}
