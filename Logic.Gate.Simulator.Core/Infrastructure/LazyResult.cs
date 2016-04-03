using System;
using System.Linq.Expressions;

namespace Logic.Gate.Simulator.Core
{

    public class LazyResult
    {
        private Expression<Func<Result>> resultExpression;

        public Result Result => resultExpression.Compile().Invoke();

        private LazyResult(Expression<Func<Result>> getter)
        {
            resultExpression = getter;
        }

        public static LazyResult For(Expression<Func<Result>> getter)
        {
            return new LazyResult(getter);
        }

        private LazyResult BinaryExpressionConverter(
            Expression<Func<Result>> left,
            Expression<Func<Result>> right,
            Func<Expression, Expression, BinaryExpression> converter)
        {
            BinaryExpression expression = converter(left.Body, right.Body);

            return new LazyResult(Expression.Lambda<Func<Result>>(expression));
        }

        public LazyResult And(LazyResult other)
        {
            return BinaryExpressionConverter(resultExpression, other.resultExpression, BinaryExpression.AndAlso);
        }

        public LazyResult Or(LazyResult other)
        {
            return BinaryExpressionConverter(resultExpression, other.resultExpression, BinaryExpression.OrElse);
        }

        public LazyResult Not
        {
            get
            {
                var notExpression = Expression.Not(resultExpression.Body);
                resultExpression = Expression.Lambda<Func<Result>>(notExpression);
                return this;
            }
        }
    }
}