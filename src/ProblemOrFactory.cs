// Copyright (c) Sundry OSS. All Rights Reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace Sundry.ProblemOr;

/// <summary>
/// Provides utility methods for creating instances of <see ref="ProblemOr{T}"/>.
/// </summary>
public static class ProblemOr
{
    /// <summary>
    /// Creates an <see ref="ProblemOr{TValue}"/> instance from a value.
    /// </summary>
    /// <typeparam name="TValue">The type of the value.</typeparam>
    /// <param name="value">The value from which to create an ProblemOr instance.</param>
    /// <returns>An <see ref="ProblemOr{TValue}"/> instance containing the specified value.</returns>
    public static ProblemOr<TValue> From<TValue>(TValue value) => value;
}

/// <summary>
/// Provides factory methods for creating instances of <see cref="ProblemOr{TValue}"/>.
/// </summary>
public static class ProblemOrFactory
{
    /// <summary>
    /// Creates a new instance of <see cref="ProblemOr{TValue}"/> with a value.
    /// </summary>
    /// <typeparam name="TValue">The type of the value.</typeparam>
    /// <param name="value">The value to wrap.</param>
    /// <returns>An instance of <see cref="ProblemOr{TValue}"/> containing the provided value.</returns>
    public static ProblemOr<TValue> From<TValue>(TValue value) => value;
}
