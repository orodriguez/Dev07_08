using FluentResults;

namespace Okane.Tests;

public static class ResultExtensions {
    public static async Task<T> AssertSuccess<T>(this Task<Result<T>> task)
    {
        var result = await task;
        Assert.True(result.IsSuccess);
        return result.Value;
    }
}