// Copyright (c) Sundry OSS. All Rights Reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace Sundry.ProblemOr;

/// <summary>
/// Represents an problem.
/// </summary>
public readonly record struct Problem
{
    /// <summary>
    /// Gets the unique problem code.
    /// </summary>
    /// <value>
    /// The unique problem code.
    /// </value>
    public string Code { get; }

    /// <summary>
    /// Gets the problem description.
    /// </summary>
    /// <value>
    /// The problem description.
    /// </value>
    public string Description { get; }

    /// <summary>
    /// Gets the problem type.
    /// </summary>
    /// <value>
    /// The problem type.
    /// </value>
    public ProblemType Type { get; }

    /// <summary>
    /// Gets the numeric value of the type.
    /// </summary>
    /// <value>
    /// The numeric value of the type.
    /// </value>
    public int NumericType { get; }

    private Problem(string code, string description, ProblemType type)
    {
        Code = code;
        Description = description;
        Type = type;
        NumericType = (int)type;
    }

    /// <summary>
    /// Creates an <see cref="Problem"/> of type <see cref="ProblemType.Failure"/> from a code and description.
    /// </summary>
    /// <param name="code">The unique problem code.</param>
    /// <param name="description">The problem description.</param>
    /// <returns>Returns a new instance of the <see cref="Problem"/>.</returns>
    public static Problem Failure(
        string code = "General.Failure",
        string description = "A failure has occurred.") =>
        new (code, description, ProblemType.Failure);

    /// <summary>
    /// Creates an <see cref="Problem"/> of type <see cref="ProblemType.Unexpected"/> from a code and description.
    /// </summary>
    /// <param name="code">The unique problem code.</param>
    /// <param name="description">The problem description.</param>
    /// <returns>Returns a new instance of the <see cref="Problem"/>.</returns>
    public static Problem Unexpected(
        string code = "General.Unexpected",
        string description = "An unexpected problem has occurred.") =>
        new (code, description, ProblemType.Unexpected);

    /// <summary>
    /// Creates an <see cref="Problem"/> of type <see cref="ProblemType.Validation"/> from a code and description.
    /// </summary>
    /// <param name="code">The unique problem code.</param>
    /// <param name="description">The problem description.</param>
    /// <returns>Returns a new instance of the <see cref="Problem"/>.</returns>
    public static Problem Validation(
        string code = "General.Validation",
        string description = "A validation problem has occurred.") =>
        new (code, description, ProblemType.Validation);

    /// <summary>
    /// Creates an <see cref="Problem"/> of type <see cref="ProblemType.Conflict"/> from a code and description.
    /// </summary>
    /// <param name="code">The unique problem code.</param>
    /// <param name="description">The problem description.</param>
    /// <returns>Returns a new instance of the <see cref="Problem"/>.</returns>
    public static Problem Conflict(
        string code = "General.Conflict",
        string description = "A conflict problem has occurred.") =>
        new (code, description, ProblemType.Conflict);

    /// <summary>
    /// Creates an <see cref="Problem"/> of type <see cref="ProblemType.NotFound"/> from a code and description.
    /// </summary>
    /// <param name="code">The unique problem code.</param>
    /// <param name="description">The problem description.</param>
    /// <returns>Returns a new instance of the <see cref="Problem"/>.</returns>
    public static Problem NotFound(
        string code = "General.NotFound",
        string description = "A 'Not Found' problem has occurred.") =>
        new (code, description, ProblemType.NotFound);

    /// <summary>
    /// Creates an <see cref="Problem"/> with the given numeric <paramref name="type"/>,
    /// <paramref name="code"/>, and <paramref name="description"/>.
    /// </summary>
    /// <param name="code">The unique problem code.</param>
    /// <param name="description">The problem description.</param>
    /// <param name="type">An integer value which represents the type of problem that occurred.</param>
    /// <returns>Returns a new instance of the <see cref="Problem"/>.</returns>
    public static Problem Custom(
        string code,
        string description,
        int type) =>
        new (code, description, (ProblemType)type);

    /// <summary>
    /// Creates an <see cref="Problem"/> with the given numeric <paramref name="type"/>,
    /// <paramref name="code"/>, and <paramref name="description"/>.
    /// </summary>
    /// <param name="code">The unique problem code.</param>
    /// <param name="description">The problem description.</param>
    /// <param name="type">ProblemType which represents the type of problem that occurred.</param>
    /// <returns>Returns a new instance of the <see cref="Problem"/>.</returns>
    public static Problem Custom(
         string code,
         string description,
         ProblemType type) =>
         new (code, description, type);

}
