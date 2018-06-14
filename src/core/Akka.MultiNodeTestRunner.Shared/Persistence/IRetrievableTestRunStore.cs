﻿//-----------------------------------------------------------------------
// <copyright file="IRetrievableTestRunStore.cs" company="Akka.NET Project">
//     Copyright (C) 2009-2018 Lightbend Inc. <http://www.lightbend.com>
//     Copyright (C) 2013-2018 .NET Foundation <https://github.com/akkadotnet/akka.net>
// </copyright>
//-----------------------------------------------------------------------

using Akka.MultiNodeTestRunner.Shared.Reporting;

namespace Akka.MultiNodeTestRunner.Shared.Persistence
{
    /// <summary>
    /// Persistent store for retrieving <see cref="TestRunTree" /> instances
    /// from disk.
    /// </summary>
    public interface IRetrievableTestRunStore :IPersistentTestRunStore
    {
        bool TestRunExists(string filePath);

        TestRunTree FetchTestRun(string filePath);
    }
}
