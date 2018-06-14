﻿//-----------------------------------------------------------------------
// <copyright file="Offset.cs" company="Akka.NET Project">
//     Copyright (C) 2009-2018 Lightbend Inc. <http://www.lightbend.com>
//     Copyright (C) 2013-2018 .NET Foundation <https://github.com/akkadotnet/akka.net>
// </copyright>
//-----------------------------------------------------------------------

using System;

namespace Akka.Persistence.Query
{
    public abstract class Offset
    {
        /// <summary>
        /// Used when retrieving all events.
        /// </summary>
        public static Offset NoOffset() => Query.NoOffset.Instance;

        /// <summary>
        /// Corresponds to an ordered sequence number for the events.Note that the corresponding
        /// offset of each event is provided in the <see cref="EventEnvelope"/>,
        /// which makes it possible to resume the stream at a later point from a given offset.
        /// The `offset` is exclusive, i.e.the event with the exact same sequence number will not be included
        /// in the returned stream. This means that you can use the offset that is returned in <see cref="EventEnvelope"/>
        /// as the `offset` parameter in a subsequent query.
        /// </summary>
        public static Offset Sequence(long value) => new Sequence(value);
    }

    /// <summary>
    /// Corresponds to an ordered sequence number for the events.Note that the corresponding
    /// offset of each event is provided in the <see cref="EventEnvelope"/>,
    /// which makes it possible to resume the stream at a later point from a given offset.
    /// The `offset` is exclusive, i.e.the event with the exact same sequence number will not be included
    /// in the returned stream. This means that you can use the offset that is returned in <see cref="EventEnvelope"/>
    /// as the `offset` parameter in a subsequent query.
    /// </summary>
    public sealed class Sequence : Offset, IComparable<Sequence>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Sequence"/> class.
        /// </summary>
        public Sequence(long value)
        {
            Value = value;
        }

        public long Value { get; }

        public int CompareTo(Sequence other) => Value.CompareTo(other.Value);

        private bool Equals(Sequence other) => Value == other.Value;

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj is Sequence && Equals((Sequence)obj);
        }

        public override int GetHashCode() => Value.GetHashCode();
    }

    /// <summary>
    /// Used when retrieving all events.
    /// </summary>
    public sealed class NoOffset : Offset
    {
        /// <summary>
        /// The singleton instance of <see cref="NoOffset"/>.
        /// </summary>
        public static NoOffset Instance { get; } = new NoOffset();
        private NoOffset() { }
    }
}
