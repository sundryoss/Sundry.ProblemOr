namespace Sundry.ProblemOr.Demo.Abstractions;

public interface IDemo
{
    ProblemOr<Success> Success();
    ProblemOr<Success> Problem();
}

public class Demo: IDemo
{
    /// <inheritdoc/>
    public ProblemOr<Success> Success() => ProblemOrResult.Success;

     /// <inheritdoc/>
    public ProblemOr<Success> Problem() => Sundry.ProblemOr.Problem.Failure();
 
}