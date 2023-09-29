// Copyright (c) Sundry OSS. All Rights Reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace Sundry.ProblemOr;

/// <summary>
/// A discriminated union of problems or a value.
/// </summary>
public record struct ProblemOr<TValue> : IProblemOr
{

    private readonly TValue? _value = default;
    private readonly List<Problem>? _problems = null;

    /// <summary>
    /// Gets the value.
    /// </summary>
    /// <value>
    /// The value.
    /// </value>
    public readonly TValue Value => _value!;

    private ProblemOr(Problem problem)
    {
        _problems = new List<Problem> { problem };
        HasProblem = true;
    }

    private ProblemOr(List<Problem> problems)
    {
        _problems = problems;
        HasProblem = true;
    }

    private ProblemOr(TValue value)
    {
        _value = value;
        HasProblem = false;
    }

    /// <summary>
    /// Gets a value indicating whether the state has problem.
    /// </summary>
    /// <value>
    /// A value indicating whether the state is problem.
    /// </value>
    public bool HasProblem { get; }

    /// <summary>
    /// Gets the list of problems. If the state is not problem, the list will contain a single problem representing the state.
    /// </summary>
    /// <value>
    /// The list of problems. If the state is not problem, the list will contain a single problem representing the state.
    /// </value>
    public readonly List<Problem> Problems => HasProblem ? _problems! : new List<Problem> { NoProblems };

    /// <summary>
    /// Gets the list of problems. If the state is not problem, the list will be empty.
    /// </summary>
    /// <value>
    /// The list of problems. If the state is not problem, the list will be empty.
    /// </value>
    public readonly List<Problem> ProblemsOrEmptyList => HasProblem ? _problems! : new ();

    /// <summary>
    /// Gets the first problem.
    /// </summary>
    /// <value>
    /// The first problem.
    /// </value>
    public Problem FirstProblem
    {
        get
        {
            if (!HasProblem)
            {
                return NoFirstProblem;
            }

            return _problems![0];
        }
    }

    /// <summary>
    /// Creates a <see cref="ProblemOr{TValue}"/> from a value.
    /// </summary>
    /// <param name="value">The value to create the <see cref="ProblemOr{TValue}"/> from.</param>
    /// <returns>A new instance of <see cref="ProblemOr{TValue}"/> with the provided value.</returns>
    public static implicit operator ProblemOr<TValue>(TValue value) => new ProblemOr<TValue>(value);

    /// <summary>
    /// Creates a <see cref="ProblemOr{TValue}"/> from an problem.
    /// </summary>
    /// <param name="problem">The problem to create the <see cref="ProblemOr{TValue}"/> from.</param>
    /// <returns>A new instance of <see cref="ProblemOr{TValue}"/> with the provided problem.</returns>
    public static implicit operator ProblemOr<TValue>(Problem problem) => new ProblemOr<TValue>(problem);

    /// <summary>
    /// Creates a <see cref="ProblemOr{TValue}"/> from a list of problems.
    /// </summary>
    /// <param name="problems">The list of problems to create the <see cref="ProblemOr{TValue}"/> from.</param>
    /// <returns>A new instance of <see cref="ProblemOr{TValue}"/> with the provided list of problems.</returns>
    public static implicit operator ProblemOr<TValue>(List<Problem> problems) => new ProblemOr<TValue>(problems);

    /// <summary>
    /// Creates an <see cref="ProblemOr{TValue}"/> from a array of problems.
    /// </summary>
    /// <param name="problems">The list of problems to create the <see cref="ProblemOr{TValue}"/> from.</param>
    /// <returns>A new instance of <see cref="ProblemOr{TValue}"/> with the provided list of problems.</returns>
    public static implicit operator ProblemOr<TValue>(Problem[] problems) => new (problems.ToList());

    /// <summary>
    /// Creates a <see cref="ProblemOr{TValue}"/> from a list of problems.
    /// </summary>
    /// <param name="problems">The list of problems to create the <see cref="ProblemOr{TValue}"/> from.</param>
    /// <returns>A new instance of <see cref="ProblemOr{TValue}"/> with the provided list of problems.</returns>
    public static ProblemOr<TValue> From(List<Problem> problems) => problems;

    /// <summary>
    /// Executes the appropriate action based on the state of the <see cref="ProblemOr{TValue}"/>.
    /// If the state is an Problem, the provided action <paramref name="onProblem"/> is executed.
    /// If the state is a value, the provided action <paramref name="onValue"/> is executed.
    /// </summary>
    /// <param name="onValue">The action to execute if the state is a value.</param>
    /// <param name="onProblem">The action to execute if the state is an Problem.</param>
    public void Switch(Action<TValue> onValue, Action<List<Problem>> onProblem)
    {
        if (HasProblem)
        {
            onProblem(Problems);
            return;
        }

        onValue(Value);
    }

    /// <summary>
    /// Asynchronously executes the appropriate action based on the state of the <see cref="ProblemOr{TValue}"/>.
    /// If the state is an Problem, the provided action <paramref name="onProblem"/> is executed asynchronously.
    /// If the state is a value, the provided action <paramref name="onValue"/> is executed asynchronously.
    /// </summary>
    /// <param name="onValue">The asynchronous action to execute if the state is a value.</param>
    /// <param name="onProblem">The asynchronous action to execute if the state is an Problem.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task SwitchAsync(Func<TValue, Task> onValue, Func<List<Problem>, Task> onProblem)
    {
        if (HasProblem)
        {
            await onProblem(Problems).ConfigureAwait(false);
            return;
        }

        await onValue(Value).ConfigureAwait(false);
    }

    /// <summary>
    /// Executes the appropriate action based on the state of the <see cref="ProblemOr{TValue}"/>.
    /// If the state is an Problem, the provided action <paramref name="onFirstProblem"/> is executed using the first Problem as input.
    /// If the state is a value, the provided action <paramref name="onValue"/> is executed.
    /// </summary>
    /// <param name="onValue">The action to execute if the state is a value.</param>
    /// <param name="onFirstProblem">The action to execute with the first Problem if the state is an Problem.</param>
    public void SwitchFirst(Action<TValue> onValue, Action<Problem> onFirstProblem)
    {
        if (HasProblem)
        {
            onFirstProblem(FirstProblem);
            return;
        }

        onValue(Value);
    }

    /// <summary>
    /// Asynchronously executes the appropriate action based on the state of the <see cref="ProblemOr{TValue}"/>.
    /// If the state is an Problem, the provided action <paramref name="onFirstProblem"/> is executed asynchronously using the first Problem as input.
    /// If the state is a value, the provided action <paramref name="onValue"/> is executed asynchronously.
    /// </summary>
    /// <param name="onValue">The asynchronous action to execute if the state is a value.</param>
    /// <param name="onFirstProblem">The asynchronous action to execute with the first Problem if the state is an Problem.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task SwitchFirstAsync(Func<TValue, Task> onValue, Func<Problem, Task> onFirstProblem)
    {
        if (HasProblem)
        {
            await onFirstProblem(FirstProblem).ConfigureAwait(false);
            return;
        }

        await onValue(Value).ConfigureAwait(false);
    }

    /// <summary>
    /// Executes the appropriate function based on the state of the <see cref="ProblemOr{TValue}"/>.
    /// If the state is a value, the provided function <paramref name="onValue"/> is executed and its result is returned.
    /// If the state is an Problem, the provided function <paramref name="onProblem"/> is executed and its result is returned.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <param name="onValue">The function to execute if the state is a value.</param>
    /// <param name="onProblem">The function to execute if the state is an Problem.</param>
    /// <returns>The result of the executed function.</returns>
    public TResult Match<TResult>(Func<TValue, TResult> onValue, Func<List<Problem>, TResult> onProblem)
    {
        if (HasProblem)
        {
            return onProblem(Problems);
        }

        return onValue(Value);
    }

    /// <summary>
    /// Asynchronously executes the appropriate function based on the state of the <see cref="ProblemOr{TValue}"/>.
    /// If the state is a value, the provided function <paramref name="onValue"/> is executed asynchronously and its result is returned.
    /// If the state is an Problem, the provided function <paramref name="onProblem"/> is executed asynchronously and its result is returned.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <param name="onValue">The asynchronous function to execute if the state is a value.</param>
    /// <param name="onProblem">The asynchronous function to execute if the state is an Problem.</param>
    /// <returns>A task representing the asynchronous operation that yields the result of the executed function.</returns>
    public async Task<TResult> MatchAsync<TResult>(Func<TValue, Task<TResult>> onValue, Func<List<Problem>, Task<TResult>> onProblem)
    {
        if (HasProblem)
        {
            return await onProblem(Problems).ConfigureAwait(false);
        }

        return await onValue(Value).ConfigureAwait(false);
    }

    /// <summary>
    /// Executes the appropriate function based on the state of the <see cref="ProblemOr{TValue}"/>.
    /// If the state is a value, the provided function <paramref name="onValue"/> is executed and its result is returned.
    /// If the state is an Problem, the provided function <paramref name="onFirstProblem"/> is executed using the first Problem, and its result is returned.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <param name="onValue">The function to execute if the state is a value.</param>
    /// <param name="onFirstProblem">The function to execute with the first Problem if the state is an Problem.</param>
    /// <returns>The result of the executed function.</returns>
    public TResult MatchFirst<TResult>(Func<TValue, TResult> onValue, Func<Problem, TResult> onFirstProblem)
    {
        if (HasProblem)
        {
            return onFirstProblem(FirstProblem);
        }

        return onValue(Value);
    }

    /// <summary>
    /// Asynchronously executes the appropriate function based on the state of the <see cref="ProblemOr{TValue}"/>.
    /// If the state is a value, the provided function <paramref name="onValue"/> is executed asynchronously and its result is returned.
    /// If the state is an Problem, the provided function <paramref name="onFirstProblem"/> is executed asynchronously using the first Problem, and its result is returned.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <param name="onValue">The asynchronous function to execute if the state is a value.</param>
    /// <param name="onFirstProblem">The asynchronous function to execute with the first Problem if the state is an Problem.</param>
    /// <returns>A task representing the asynchronous operation that yields the result of the executed function.</returns>
    public async Task<TResult> MatchFirstAsync<TResult>(Func<TValue, Task<TResult>> onValue, Func<Problem, Task<TResult>> onFirstProblem)
    {
        if (HasProblem)
        {
            return await onFirstProblem(FirstProblem).ConfigureAwait(false);
        }

        return await onValue(Value).ConfigureAwait(false);
    }

    private static readonly Problem NoFirstProblem = Problem.Unexpected(
        code: "ProblemOr.NoFirstProblem",
        description: "First problem cannot be retrieved from a successful ProblemOr.");

    private static readonly Problem NoProblems = Problem.Unexpected(
        code: "ProblemOr.NoProblems",
        description: "problem list cannot be retrieved from a successful ProblemOr.");
}
