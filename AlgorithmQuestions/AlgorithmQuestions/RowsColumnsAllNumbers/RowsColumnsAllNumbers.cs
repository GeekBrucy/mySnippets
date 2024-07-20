using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlgorithmQuestions;

public class RowsColumnsAllNumbers : BaseSolution<int[][], bool>
{
  protected override string Question => @"
      Check if every row and column Contains All Numbers

      An n * n matrix is valid if every row and every column contains all the integers from 1 to n (inclusive)

      Given an n* n integer matrix matrix, return true if the matrix is valid. Otherwise return false.

      Example 1:

      Input: matrix = [
        [1, 2, 3],
        [3, 1, 2],
        [2, 3, 1]
      ]

      Output: true

      Explanation: In this case, n = 3, and every row and column contains the numbers 1, 2, and 3.

      Hence, we return true.

      Example 2:

      Input: matrix = [
        [1,1,1],
        [1,2,3],
        [1,2,3]
      ]

      Output: false

      Explanation: In this case, n = 3, but the first row and the first column do not contain the numbers 2 or 3.
      Hence, we return false.
    ";

  public override bool Solve(int[][] matrix)
  {
    bool isOriginalValid = CheckValid(matrix);
    int[][] pivotArr = PivotArray(matrix);
    bool isPivotValid = CheckValid(pivotArr);
    return isOriginalValid && isPivotValid;
  }
  private int[][] PivotArray(int[][] matrix)
  {
    int matrixLen = matrix.Length;
    int[][] pivotedArray = new int[matrixLen][];
    for (int r = 0; r < matrixLen; r++)
    {
      for (int c = 0; c < matrix[r].Length; c++)
      {
        if (pivotedArray[c] == null)
        {
          pivotedArray[c] = new int[matrix[r].Length];
        }

        pivotedArray[c][r] = matrix[r][c];
      }
    }

    return pivotedArray;
  }
  public bool CheckValid(int[][] matrix)
  {
    int n = matrix.Length;

    IEnumerable<int> requiredRange = Enumerable.Range(1, n);

    foreach (int[] row in matrix)
    {
      Dictionary<int, int> expected = new Dictionary<int, int>();
      foreach (var r in requiredRange)
      {
        expected[r] = 1;
      }
      foreach (int column in row)
      {
        if (expected.ContainsKey(column) == false)
        {
          return false;
        }
        expected[column]--;
      }
      foreach (var v in expected.Values)
      {
        if (v != 0)
        {
          return false;
        }
      }
    }

    return true;
  }
}
