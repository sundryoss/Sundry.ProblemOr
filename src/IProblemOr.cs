// Copyright (c) Sundry OSS. All Rights Reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace Sundry.ProblemOr;

/// <summary>
/// Represents a type that can hold either a list of problems or a value.
/// </summary>
public interface IProblemOr
{
    /// <summary>
    /// Gets the list of problems.
    /// </summary>
    /// <value>
    /// The list of problems.
    /// </value>
    List<Problem>? Problems { get; }

    /// <summary>
    /// Gets a value indicating whether the state is problem.
    /// </summary>
    /// <value>
    /// A value indicating whether the state is problem.
    /// </value>
    bool HasProblem { get; }
}
