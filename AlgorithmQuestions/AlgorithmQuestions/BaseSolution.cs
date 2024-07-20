using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlgorithmQuestions;

public abstract class BaseSolution<ParamType, ReturnType>
{
  protected abstract string Question { get; }
  public abstract ReturnType Solve(ParamType param);
}
