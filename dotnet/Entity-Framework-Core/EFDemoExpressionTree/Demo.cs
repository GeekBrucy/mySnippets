using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using EFConfigs.Models;
using EFConfigs.Models.Shared;
using ExpressionTreeToString;

namespace EFDemoExpressionTree;

public class Demo : BaseDemo
{
  public Expression<Func<Article, bool>> expThumbUpNotZero = a => a.ThumbUp != 0;
  public Expression<Func<Article, Article, long>> expTotalThumbUp = (a1, a2) => a1.ThumbUp + a2.ThumbUp;
  public Func<Article, bool> funcThumbUpNotZero = a => a.ThumbUp != 0;
  public Func<Article, Article, long> funcTotalThumbUp = (a1, a2) => a1.ThumbUp + a2.ThumbUp;

  private void ExpressionUsage()
  {
    _ctx.Articles.Where(expThumbUpNotZero); // generate where clause
  }

  private void FuncUsage()
  {
    _ctx.Articles.Where(funcThumbUpNotZero); // get all articles then filter
  }

  private void ViewExpressionTree()
  {
    Console.WriteLine(expThumbUpNotZero.ToString("Object notation", "C#"));
  }

  private void DynamicallyConstructExpressionTree()
  {
    ParameterExpression paramExprA = Expression.Parameter(typeof(Article), "a");
    ConstantExpression constExpr5 = Expression.Constant((long)0, typeof(long));
    MemberExpression memExprThumbUp = Expression.MakeMemberAccess(paramExprA, typeof(Article).GetProperty("ThumbUp"));
    BinaryExpression binExpNotEqual = Expression.NotEqual(memExprThumbUp, constExpr5);
    Expression<Func<Article, bool>> exprRoot = Expression.Lambda<Func<Article, bool>>(binExpNotEqual, paramExprA);

    foreach (var a in _ctx.Articles.Where(exprRoot))
    {
      Console.WriteLine(a);
    }
  }

  public override void Run()
  {
    // ViewExpressionTree();
    DynamicallyConstructExpressionTree();
  }
}
