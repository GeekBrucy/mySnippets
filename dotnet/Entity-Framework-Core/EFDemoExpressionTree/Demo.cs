using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Reflection.Metadata;
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
    Console.WriteLine(expThumbUpNotZero.ToString("Factory methods", "C#"));
  }

  private void DynamicallyConstructExpressionTreeBasic()
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

  private void FlexibleConstructExpressionTree()
  {
    Console.WriteLine("Choose operator: 1. Greater Than. 2. Less than");
    string s = Console.ReadLine();

    ParameterExpression paramExprA = Expression.Parameter(typeof(Article), "a");
    ConstantExpression constExpr5 = Expression.Constant((long)0, typeof(long));
    MemberExpression memExprThumbUp = Expression.MakeMemberAccess(paramExprA, typeof(Article).GetProperty("ThumbUp"));
    BinaryExpression binExpCompare;
    if (s == "1")
    {
      binExpCompare = Expression.GreaterThan(memExprThumbUp, constExpr5);
    }
    else
    {
      binExpCompare = Expression.LessThan(memExprThumbUp, constExpr5);
    }
    Expression<Func<Article, bool>> exprRoot = Expression.Lambda<Func<Article, bool>>(binExpCompare, paramExprA);

    foreach (var a in _ctx.Articles.Where(exprRoot))
    {
      Console.WriteLine(a);
    }
  }

  private IEnumerable<Article> DynamicallyConstructExpressionTree(string propertyName, object value)
  {
    Type valueType = typeof(Article).GetProperty(propertyName).PropertyType;
    Expression<Func<Article, bool>> lambda;

    var param = Expression.Parameter(typeof(Article), "e");

    var constant = Expression.Constant(Convert.ChangeType(value, valueType));

    var memberAccess = Expression.MakeMemberAccess(param, typeof(Article).GetProperty(propertyName));

    Expression expressionBody;
    if (valueType.IsPrimitive)
    {
      expressionBody = Expression.Equal(
        memberAccess,
        constant
      );
    }
    else
    {
      expressionBody = Expression.MakeBinary(
        ExpressionType.Equal,
        memberAccess,
        constant,
        false,
        typeof(string).GetMethod("op_Equality")
      );
    }
    lambda = Expression.Lambda<Func<Article, bool>>(expressionBody, param);
    return _ctx.Articles.Where(lambda).ToList();
  }

  private IEnumerable<object[]> SimpleDynamicSelect<T>(params string[] propertyNames) where T : class
  {
    ParameterExpression exprParam = Expression.Parameter(typeof(Article));
    List<Expression> exprList = new List<Expression>();
    foreach (var propName in propertyNames)
    {
      Expression propExpr = Expression.Convert(
        Expression.MakeMemberAccess(exprParam, typeof(T).GetProperty(propName)),
        typeof(object)
      );
      exprList.Add(propExpr);
    }

    var newArrExpr = Expression.NewArrayInit(typeof(object), exprList.ToArray());
    var selectExpression = Expression.Lambda<Func<T, object[]>>(newArrExpr, exprParam);

    return _ctx.Set<T>().Select(selectExpression).ToList();
  }

  private IEnumerable<Article> UseIQueryableReplaceExpressionTree(string title, long? thumbUp, string content, short orderType)
  {
    IQueryable<Article> articles = _ctx.Articles;
    if (string.IsNullOrEmpty(title) != false)
    {
      articles.Where(a => a.Title == title);
    }

    if (thumbUp != null)
    {
      articles.Where(a => a.ThumbUp == thumbUp);
    }

    if (string.IsNullOrEmpty(content) != false)
    {
      articles.Where(a => a.Content == content);
    }

    switch (orderType)
    {
      case 1:
        articles.OrderBy(a => a.Title);
        break;
      case 2:
        articles.OrderByDescending(a => a.Title);
        break;
    }

    return articles.ToList();
  }

  /// <summary>
  /// Demo System.Linq.Dynamic.Core
  /// This can build dynamic query
  /// </summary>
  /// <returns></returns>
  public IEnumerable<Article> LinqDynamicCore()
  {
    return _ctx.Articles.Where("Title = 'Test'").Select("ThumbUp").ToDynamicList<Article>();
  }

  public override void Run()
  {
    // ViewExpressionTree();
    // DynamicallyConstructExpressionTreeBasic();
    // FlexibleConstructExpressionTree();
    // var res = DynamicallyConstructExpressionTree("ThumbUp", 0);
    // Console.WriteLine(res.Count());

    var res = SimpleDynamicSelect<Article>("Title", "ThumbUp", "Content");
    Console.WriteLine(res.Count());
  }
}
