using System;

namespace Nuclear.Properties.ClampedProperties {

    /// <summary>
    /// Implementation of <see cref="ClampedProperty{TValue}"/> using <see cref="Tuple{T1}"/> for value.
    /// </summary>
    /// <typeparam name="T1">Tuple type parameter.</typeparam>
    public class ClampedTuple<T1> : ClampedProperty<Tuple<T1>>, IClampedTuple<T1> {

        #region ctors

        /// <summary>
        /// Creates a new instance of <see cref="ClampedTuple{T1}"/>.
        /// </summary>
        /// <param name="value">The initial value.</param>
        /// <param name="minimum">The lower border of the range.</param>
        /// <param name="maximum">The upper border of the range.</param>
        public ClampedTuple(Tuple<T1> value, Tuple<T1> minimum, Tuple<T1> maximum)
            : base(value, minimum, maximum) { }

        #endregion

    }

    /// <summary>
    /// Implementation of <see cref="ClampedProperty{TValue}"/> using <see cref="Tuple{T1, T2}"/> for value.
    /// </summary>
    /// <typeparam name="T1">Tuple type parameter.</typeparam>
    /// <typeparam name="T2">Tuple type parameter.</typeparam>
    public class ClampedTuple<T1, T2> : ClampedProperty<Tuple<T1, T2>>, IClampedTuple<T1, T2> {

        #region ctors

        /// <summary>
        /// Creates a new instance of <see cref="ClampedTuple{T1}"/>.
        /// </summary>
        /// <param name="value">The initial value.</param>
        /// <param name="minimum">The lower border of the range.</param>
        /// <param name="maximum">The upper border of the range.</param>
        public ClampedTuple(Tuple<T1, T2> value, Tuple<T1, T2> minimum, Tuple<T1, T2> maximum)
            : base(value, minimum, maximum) { }

        #endregion

    }

    /// <summary>
    /// Implementation of <see cref="ClampedProperty{TValue}"/> using <see cref="Tuple{T1, T2, T3}"/> for value.
    /// </summary>
    /// <typeparam name="T1">Tuple type parameter.</typeparam>
    /// <typeparam name="T2">Tuple type parameter.</typeparam>
    /// <typeparam name="T3">Tuple type parameter.</typeparam>
    public class ClampedTuple<T1, T2, T3> : ClampedProperty<Tuple<T1, T2, T3>>, IClampedTuple<T1, T2, T3> {

        #region ctors

        /// <summary>
        /// Creates a new instance of <see cref="ClampedTuple{T1, T2, T3}"/>.
        /// </summary>
        /// <param name="value">The initial value.</param>
        /// <param name="minimum">The lower border of the range.</param>
        /// <param name="maximum">The upper border of the range.</param>
        public ClampedTuple(Tuple<T1, T2, T3> value, Tuple<T1, T2, T3> minimum, Tuple<T1, T2, T3> maximum)
            : base(value, minimum, maximum) { }

        #endregion

    }

    /// <summary>
    /// Implementation of <see cref="ClampedProperty{TValue}"/> using <see cref="Tuple{T1, T2, T3, T4}"/> for value.
    /// </summary>
    /// <typeparam name="T1">Tuple type parameter.</typeparam>
    /// <typeparam name="T2">Tuple type parameter.</typeparam>
    /// <typeparam name="T3">Tuple type parameter.</typeparam>
    /// <typeparam name="T4">Tuple type parameter.</typeparam>
    public class ClampedTuple<T1, T2, T3, T4> : ClampedProperty<Tuple<T1, T2, T3, T4>>, IClampedTuple<T1, T2, T3, T4> {

        #region ctors

        /// <summary>
        /// Creates a new instance of <see cref="ClampedTuple{T1, T2, T3, T4}"/>.
        /// </summary>
        /// <param name="value">The initial value.</param>
        /// <param name="minimum">The lower border of the range.</param>
        /// <param name="maximum">The upper border of the range.</param>
        public ClampedTuple(Tuple<T1, T2, T3, T4> value, Tuple<T1, T2, T3, T4> minimum, Tuple<T1, T2, T3, T4> maximum)
            : base(value, minimum, maximum) { }

        #endregion

    }

    /// <summary>
    /// Implementation of <see cref="ClampedProperty{TValue}"/> using <see cref="Tuple{T1, T2, T3, T4, T5}"/> for value.
    /// </summary>
    /// <typeparam name="T1">Tuple type parameter.</typeparam>
    /// <typeparam name="T2">Tuple type parameter.</typeparam>
    /// <typeparam name="T3">Tuple type parameter.</typeparam>
    /// <typeparam name="T4">Tuple type parameter.</typeparam>
    /// <typeparam name="T5">Tuple type parameter.</typeparam>
    public class ClampedTuple<T1, T2, T3, T4, T5> : ClampedProperty<Tuple<T1, T2, T3, T4, T5>>, IClampedTuple<T1, T2, T3, T4, T5> {

        #region ctors

        /// <summary>
        /// Creates a new instance of <see cref="ClampedTuple{T1, T2, T3, T4, T5}"/>.
        /// </summary>
        /// <param name="value">The initial value.</param>
        /// <param name="minimum">The lower border of the range.</param>
        /// <param name="maximum">The upper border of the range.</param>
        public ClampedTuple(Tuple<T1, T2, T3, T4, T5> value, Tuple<T1, T2, T3, T4, T5> minimum, Tuple<T1, T2, T3, T4, T5> maximum)
            : base(value, minimum, maximum) { }

        #endregion

    }

    /// <summary>
    /// Implementation of <see cref="ClampedProperty{TValue}"/> using <see cref="Tuple{T1, T2, T3, T4, T5, T6}"/> for value.
    /// </summary>
    /// <typeparam name="T1">Tuple type parameter.</typeparam>
    /// <typeparam name="T2">Tuple type parameter.</typeparam>
    /// <typeparam name="T3">Tuple type parameter.</typeparam>
    /// <typeparam name="T4">Tuple type parameter.</typeparam>
    /// <typeparam name="T5">Tuple type parameter.</typeparam>
    /// <typeparam name="T6">Tuple type parameter.</typeparam>
    public class ClampedTuple<T1, T2, T3, T4, T5, T6> : ClampedProperty<Tuple<T1, T2, T3, T4, T5, T6>>, IClampedTuple<T1, T2, T3, T4, T5, T6> {

        #region ctors

        /// <summary>
        /// Creates a new instance of <see cref="ClampedTuple{T1, T2, T3, T4, T5, T6}"/>.
        /// </summary>
        /// <param name="value">The initial value.</param>
        /// <param name="minimum">The lower border of the range.</param>
        /// <param name="maximum">The upper border of the range.</param>
        public ClampedTuple(Tuple<T1, T2, T3, T4, T5, T6> value, Tuple<T1, T2, T3, T4, T5, T6> minimum, Tuple<T1, T2, T3, T4, T5, T6> maximum)
            : base(value, minimum, maximum) { }

        #endregion

    }

    /// <summary>
    /// Implementation of <see cref="ClampedProperty{TValue}"/> using <see cref="Tuple{T1, T2, T3, T4, T5, T6, T7}"/> for value.
    /// </summary>
    /// <typeparam name="T1">Tuple type parameter.</typeparam>
    /// <typeparam name="T2">Tuple type parameter.</typeparam>
    /// <typeparam name="T3">Tuple type parameter.</typeparam>
    /// <typeparam name="T4">Tuple type parameter.</typeparam>
    /// <typeparam name="T5">Tuple type parameter.</typeparam>
    /// <typeparam name="T6">Tuple type parameter.</typeparam>
    /// <typeparam name="T7">Tuple type parameter.</typeparam>
    public class ClampedTuple<T1, T2, T3, T4, T5, T6, T7> : ClampedProperty<Tuple<T1, T2, T3, T4, T5, T6, T7>>, IClampedTuple<T1, T2, T3, T4, T5, T6, T7> {

        #region ctors

        /// <summary>
        /// Creates a new instance of <see cref="ClampedTuple{T1, T2, T3, T4, T5, T6, T7}"/>.
        /// </summary>
        /// <param name="value">The initial value.</param>
        /// <param name="minimum">The lower border of the range.</param>
        /// <param name="maximum">The upper border of the range.</param>
        public ClampedTuple(Tuple<T1, T2, T3, T4, T5, T6, T7> value, Tuple<T1, T2, T3, T4, T5, T6, T7> minimum, Tuple<T1, T2, T3, T4, T5, T6, T7> maximum)
            : base(value, minimum, maximum) { }

        #endregion

    }

    /// <summary>
    /// Implementation of <see cref="ClampedProperty{TValue}"/> using <see cref="Tuple{T1, T2, T3, T4, T5, T6, T7, TRest}"/> for value.
    /// </summary>
    /// <typeparam name="T1">Tuple type parameter.</typeparam>
    /// <typeparam name="T2">Tuple type parameter.</typeparam>
    /// <typeparam name="T3">Tuple type parameter.</typeparam>
    /// <typeparam name="T4">Tuple type parameter.</typeparam>
    /// <typeparam name="T5">Tuple type parameter.</typeparam>
    /// <typeparam name="T6">Tuple type parameter.</typeparam>
    /// <typeparam name="T7">Tuple type parameter.</typeparam>
    /// <typeparam name="TRest">Tuple type parameter.</typeparam>
    public class ClampedTuple<T1, T2, T3, T4, T5, T6, T7, TRest> : ClampedProperty<Tuple<T1, T2, T3, T4, T5, T6, T7, TRest>>, IClampedTuple<T1, T2, T3, T4, T5, T6, T7, TRest> {

        #region ctors

        /// <summary>
        /// Creates a new instance of <see cref="ClampedTuple{T1, T2, T3, T4, T5, T6, T7, TRest}"/>.
        /// </summary>
        /// <param name="value">The initial value.</param>
        /// <param name="minimum">The lower border of the range.</param>
        /// <param name="maximum">The upper border of the range.</param>
        public ClampedTuple(Tuple<T1, T2, T3, T4, T5, T6, T7, TRest> value, Tuple<T1, T2, T3, T4, T5, T6, T7, TRest> minimum, Tuple<T1, T2, T3, T4, T5, T6, T7, TRest> maximum)
            : base(value, minimum, maximum) { }

        #endregion

    }

}
