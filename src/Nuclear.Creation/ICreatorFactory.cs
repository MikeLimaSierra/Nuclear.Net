using System;

namespace Nuclear.Creation {

    /// <summary>
    /// Defines a factory for creator instances.
    /// </summary>
    public interface ICreatorFactory {

        #region methods

        /// <summary>
        /// Creates a new instance if <see cref="ICreator{TOut}"/>.
        /// </summary>
        /// <typeparam name="TOut"></typeparam>
        /// <param name="func"></param>
        /// <returns></returns>
        ICreator<TOut> Create<TOut>(Func<TOut> func);

        /// <summary>
        /// Creates a new instance if <see cref="ICreator{TOut, TIn1}"/>.
        /// </summary>
        /// <typeparam name="TOut">The type that will be created.</typeparam>
        /// <typeparam name="TIn1">The type of the 1st input parameter.</typeparam>
        /// <param name="func">The function that is invoked for internal creation.</param>
        /// <returns>The new creator instance.</returns>
        ICreator<TOut, TIn1> Create<TOut, TIn1>(Func<TIn1, TOut> func);

        /// <summary>
        /// Creates a new instance if <see cref="ICreator{TOut, TIn1, TIn2}"/>.
        /// </summary>
        /// <typeparam name="TOut">The type that will be created.</typeparam>
        /// <typeparam name="TIn1">The type of the 1st input parameter.</typeparam>
        /// <typeparam name="TIn2">The type of the 2nd input parameter.</typeparam>
        /// <param name="func">The function that is invoked for internal creation.</param>
        /// <returns>The new creator instance.</returns>
        ICreator<TOut, TIn1, TIn2> Create<TOut, TIn1, TIn2>(Func<TIn1, TIn2, TOut> func);

        /// <summary>
        /// Creates a new instance if <see cref="ICreator{TOut, TIn1, TIn2, TIn3}"/>.
        /// </summary>
        /// <typeparam name="TOut">The type that will be created.</typeparam>
        /// <typeparam name="TIn1">The type of the 1st input parameter.</typeparam>
        /// <typeparam name="TIn2">The type of the 2nd input parameter.</typeparam>
        /// <typeparam name="TIn3">The type of the 3rd input parameter.</typeparam>
        /// <param name="func">The function that is invoked for internal creation.</param>
        /// <returns>The new creator instance.</returns>
        ICreator<TOut, TIn1, TIn2, TIn3> Create<TOut, TIn1, TIn2, TIn3>(Func<TIn1, TIn2, TIn3, TOut> func);

        /// <summary>
        /// Creates a new instance if <see cref="ICreator{TOut, TIn1, TIn2, TIn3, TIn4}"/>.
        /// </summary>
        /// <typeparam name="TOut">The type that will be created.</typeparam>
        /// <typeparam name="TIn1">The type of the 1st input parameter.</typeparam>
        /// <typeparam name="TIn2">The type of the 2nd input parameter.</typeparam>
        /// <typeparam name="TIn3">The type of the 3rd input parameter.</typeparam>
        /// <typeparam name="TIn4">The type of the 4th input parameter.</typeparam>
        /// <param name="func">The function that is invoked for internal creation.</param>
        /// <returns>The new creator instance.</returns>
        ICreator<TOut, TIn1, TIn2, TIn3, TIn4> Create<TOut, TIn1, TIn2, TIn3, TIn4>(Func<TIn1, TIn2, TIn3, TIn4, TOut> func);

        /// <summary>
        /// Creates a new instance if <see cref="ICreator{TOut, TIn1, TIn2, TIn3, TIn4, TIn5}"/>.
        /// </summary>
        /// <typeparam name="TOut">The type that will be created.</typeparam>
        /// <typeparam name="TIn1">The type of the 1st input parameter.</typeparam>
        /// <typeparam name="TIn2">The type of the 2nd input parameter.</typeparam>
        /// <typeparam name="TIn3">The type of the 3rd input parameter.</typeparam>
        /// <typeparam name="TIn4">The type of the 4th input parameter.</typeparam>
        /// <typeparam name="TIn5">The type of the 5th input parameter.</typeparam>
        /// <param name="func">The function that is invoked for internal creation.</param>
        /// <returns>The new creator instance.</returns>
        ICreator<TOut, TIn1, TIn2, TIn3, TIn4, TIn5> Create<TOut, TIn1, TIn2, TIn3, TIn4, TIn5>(Func<TIn1, TIn2, TIn3, TIn4, TIn5, TOut> func);

        /// <summary>
        /// Creates a new instance if <see cref="ICreator{TOut, TIn1, TIn2, TIn3, TIn4, TIn5, TIn6}"/>.
        /// </summary>
        /// <typeparam name="TOut">The type that will be created.</typeparam>
        /// <typeparam name="TIn1">The type of the 1st input parameter.</typeparam>
        /// <typeparam name="TIn2">The type of the 2nd input parameter.</typeparam>
        /// <typeparam name="TIn3">The type of the 3rd input parameter.</typeparam>
        /// <typeparam name="TIn4">The type of the 4th input parameter.</typeparam>
        /// <typeparam name="TIn5">The type of the 5th input parameter.</typeparam>
        /// <typeparam name="TIn6">The type of the 6th input parameter.</typeparam>
        /// <param name="func">The function that is invoked for internal creation.</param>
        /// <returns>The new creator instance.</returns>
        ICreator<TOut, TIn1, TIn2, TIn3, TIn4, TIn5, TIn6> Create<TOut, TIn1, TIn2, TIn3, TIn4, TIn5, TIn6>(Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TOut> func);

        /// <summary>
        /// Creates a new instance if <see cref="ICreator{TOut, TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7}"/>.
        /// </summary>
        /// <typeparam name="TOut">The type that will be created.</typeparam>
        /// <typeparam name="TIn1">The type of the 1st input parameter.</typeparam>
        /// <typeparam name="TIn2">The type of the 2nd input parameter.</typeparam>
        /// <typeparam name="TIn3">The type of the 3rd input parameter.</typeparam>
        /// <typeparam name="TIn4">The type of the 4th input parameter.</typeparam>
        /// <typeparam name="TIn5">The type of the 5th input parameter.</typeparam>
        /// <typeparam name="TIn6">The type of the 6th input parameter.</typeparam>
        /// <typeparam name="TIn7">The type of the 7th input parameter.</typeparam>
        /// <param name="func">The function that is invoked for internal creation.</param>
        /// <returns>The new creator instance.</returns>
        ICreator<TOut, TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7> Create<TOut, TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7>(Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TOut> func);

        /// <summary>
        /// Creates a new instance if <see cref="ICreator{TOut, TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8}"/>.
        /// </summary>
        /// <typeparam name="TOut">The type that will be created.</typeparam>
        /// <typeparam name="TIn1">The type of the 1st input parameter.</typeparam>
        /// <typeparam name="TIn2">The type of the 2nd input parameter.</typeparam>
        /// <typeparam name="TIn3">The type of the 3rd input parameter.</typeparam>
        /// <typeparam name="TIn4">The type of the 4th input parameter.</typeparam>
        /// <typeparam name="TIn5">The type of the 5th input parameter.</typeparam>
        /// <typeparam name="TIn6">The type of the 6th input parameter.</typeparam>
        /// <typeparam name="TIn7">The type of the 7th input parameter.</typeparam>
        /// <typeparam name="TIn8">The type of the 8th input parameter.</typeparam>
        /// <param name="func">The function that is invoked for internal creation.</param>
        /// <returns>The new creator instance.</returns>
        ICreator<TOut, TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8> Create<TOut, TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8>(Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TOut> func);

        #endregion

    }

}
