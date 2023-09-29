// Copyright (c) Sundry OSS. All Rights Reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace Sundry.ProblemOr;

    /// <summary>
    /// problem types.
    /// </summary>
    public enum ProblemType
    {
        /// <summary>
        /// Represents an unexpected problem.
        /// </summary>
        Unexpected,

        /// <summary>
        /// Represents a validation problem.
        /// </summary>
        Validation,

        /// <summary>
        /// Represents a conflict problem.
        /// </summary>
        Conflict,

        /// <summary>
        /// Represents a not found problem.
        /// </summary>
        NotFound,

        /// <summary>
        /// Represents a not authorized problem.
        /// </summary>
        NotAuthorized,

        /// <summary>
        /// Represents a failure problem.
        /// </summary>
        Failure,
    }
