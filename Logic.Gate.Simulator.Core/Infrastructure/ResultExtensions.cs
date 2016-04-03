using System;
using System.Threading.Tasks;

namespace Logic.Gate.Simulator.Core
{
    public static class ResultExtensions
    {
        #region Success

        public static Result OnSuccess(this Result result, Func<Result> func)
        {
            if (result.Failure)
            {
                return result;
            }
            return func();
        }

        public static Result<TValue> OnSuccess<TValue>(this Result result, Func<Result<TValue>> func)
        {
            if (result.Failure)
            {
                return Result.FailWith<TValue>(result.State, result.ErrorMessage);
            }
            return func();
        }

        public static Result OnSuccess(this Result result, Action<Result> action)
        {
            if (result.Failure)
            {
                return result;
            }
            action(result);

            return Result.Ok();
        }

        public static Result OnSuccess(this Result result, Action action)
        {
            if (result.Failure)
            {
                return result;
            }
            action();

            return Result.Ok();
        }

        public static Result<TValue> OnSuccess<TValue>(this Result<TValue> result, Action<TValue> action)
        {
            if (result.Failure)
            {
                return result;
            }
            action(result.Value);

            return result;
        }

        public static Result<TNext> OnSuccess<TValue, TNext>(this Result<TValue> result, Func<TValue, Result<TNext>> func)
        {
            if (result.Failure)
            {
                return Result.FailWith<TNext>(result.State, result.ErrorMessage);
            }
            return func(result.Value);
        }

        public static Result OnSuccess<TValue>(this Result<TValue> result, Func<TValue, Result> func)
        {
            if (result.Failure)
            {
                return result;
            }
            return func(result.Value);
        }

        #endregion

        #region Assert

        public static Result<TValue> ThrowIfNull<TValue>(this Result<TValue> result)
        {
            if (result.Success)
            {
                Argument.Require.NotNull(() => result.Value);
            }
            return result;
        }

        #endregion

        #region Failure

        public static Result OnFailure(this Result result, Action<Result> action)
        {
            if (result.Failure)
            {
                action(result);
            }
            return result;
        }

        public static Result<TValue> OnFailure<TValue>(this Result<TValue> result, Action<Result<TValue>> action)
        {
            if (result.Failure)
            {
                action(result);
            }
            return result;
        }

        public static Result<TValue> OnFailure<TValue>(this Result<TValue> result, Func<Result<TValue>> func)
        {
            if (result.Failure)
            {
               return func();
            }
            return result;
        }

        #endregion

        #region Misc

        public static Result<TValue> AsResult<TValue>(this Result result)
        {
            return new Result<TValue>(default(TValue),result.State, result.ErrorMessage);
        }
        public static Result<TValue> AddErrorMessage<TValue>(this Result<TValue> result, Result other)
        {
            return Result.FailWith(result.Value, result.State, $"{result.ErrorMessage}. {other.ErrorMessage}");
        }

        public static Result<TNewValue> ChangeValue<TValue,TNewValue>(this Result<TValue> result, TNewValue newValue)
        {
            return new Result<TNewValue>(newValue, result.State, result.ErrorMessage);
        }

        public static Result AddErrorMessage(this Result result, Result other)
        {
            return Result.FailWith(result.State, $"{result.ErrorMessage}. {other.ErrorMessage}");
        }

        public static Result<TNext> OnBoth<TValue,TNext>(this Result<TValue> result, Func<Result<TValue>, Result<TNext>> func)
        {
            return func(result.Value);
        }

        public static Result<TConverted> Cast<TConverted>(this Result result)
        {
            return new Result<TConverted>(default(TConverted), result.State, result.ErrorMessage);
        }

        #endregion
        
    }
}
