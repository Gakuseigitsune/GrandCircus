using System;
using Xunit;
using Lab4_3_PrimeCalc;

namespace Lab4_3_Tester
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(1, 2)]
        [InlineData(2, 3)]
        [InlineData(3, 5)]
        [InlineData(4, 7)]

        public void TestGroupA(int n, int act)
        {
            int test;

            test = PrimeNumber.GetPrime(n);
            Assert.Equal(act, test);
        }

        [Theory]
        [InlineData(5, 11)]
        [InlineData(6, 13)]
        [InlineData(7, 17)]
        [InlineData(10, 29)]

        public void TestGroupB(int n, int act)
        {
            int test;

            test = PrimeNumber.GetPrime(n);
            Assert.Equal(act, test);
        }



        [Theory]
        [InlineData(16, 53)]
        [InlineData(17, 59)]
        [InlineData(18, 61)]
        [InlineData(19, 67)]

        public void TestGroupC(int n, int act)
        {
            int test;

            test = PrimeNumber.GetPrime(n);
            Assert.Equal(act, test);
        }


        [Theory]
        [InlineData(27, 103)]
        [InlineData(58, 271)]
        [InlineData(71, 353)]
        [InlineData(105, 571)]

        public void TestGroupD(int n, int act)
        {
            int test;

            test = PrimeNumber.GetPrime(n);
            Assert.Equal(act, test);
        }

    }
}
