using System.Diagnostics;
using NUnit.Framework;
using MathNet.Numerics.LinearAlgebra;

namespace MathNet.Numerics.UnitTests
{
    public class PigletTests
    {
        [Test]
        public void CubicTangentsTest()
        {
            int n = 3;
            var A = Matrix<double>.Build.Dense(n - 1, n - 1);
            var b = Vector<double>.Build.Dense(n - 1);

            A[0, 0] = 2;
            A[0, 1] = 0.5;
            A[1, 0] = 0.5;
            A[1, 1] = 2;

            b[0] = 3;
            b[1] = -6;

            // Note: We use the LU-based `Solve` method here
            // to reduce our dependency on other MathNet.Numerics
            // code. We know that we can LU factorization here
            // because our matrix A is square.

            var x = A.LU().Solve(b);

            TestContext.WriteLine("x: {0}", x);
        }
    }

}
