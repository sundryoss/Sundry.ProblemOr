// Copyright (c) Sundry OSS. All Rights Reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace Sundry.ProblemOr;

/// <summary>
/// A discriminated union for Success.
/// </summary>
public readonly record struct Success;
/// <summary>
/// A discriminated union for Created.
/// </summary>
public readonly record struct Created;
/// <summary>
/// A discriminated union for Deleted.
/// </summary>
public readonly record struct Deleted;
/// <summary>
/// A discriminated union for Updated.
/// </summary>
public readonly record struct Updated;

/// <summary>
/// Represents a collection of discriminated union types for common result scenarios.
/// </summary>
public static class ProblemOrResult
{
    /// <summary>
    /// Gets the Success.
    /// </summary>
    /// <value>The Success.</value>
    public static Success Success => default;

    /// <summary>
    /// Gets the Created.
    /// </summary>
    /// <value>The Created.</value>
    public static Created Created => default;

    /// <summary>
    /// Gets the Deleted.
    /// </summary>
    /// <value>The Deleted.</value>
    public static Deleted Deleted => default;

    /// <summary>
    /// Gets the Updated.
    /// </summary>
    /// <value>The Updated.</value>
    public static Updated Updated => default;
}
