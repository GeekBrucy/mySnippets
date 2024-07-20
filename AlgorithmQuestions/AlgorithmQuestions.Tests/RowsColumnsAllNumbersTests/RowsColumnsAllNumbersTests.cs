using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace AlgorithmQuestions.Tests.RowsColumnsAllNumbersTests;

public class RowsColumnsAllNumbersTests
{
    private readonly BaseSolution<int[][], bool> sln;
    public RowsColumnsAllNumbersTests()
    {
        sln = new RowsColumnsAllNumbers();
    }

    [Theory]
    [ClassData(typeof(RowsColumnsAllNumbersTestDataGenerator))]
    public void RowsColumnsAllNumbers_Solve_ShouldReturnBool(int[][] input, bool expected)
    {
        bool result = sln.Solve(input);

        result.Should().Be(expected);
    }
}
