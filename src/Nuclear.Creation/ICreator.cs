using System;

namespace Nuclear.Creation {

    /// <summary>
    /// Defines an atomic creation mechanism.
    /// </summary>
    /// <typeparam name="TOut">The type that will be created.</typeparam>
    public interface ICreator<TOut> {

        /// <summary>
        /// Creates an instance of <typeparamref name="TOut"/> and returns it via the out parameter <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The created instance of type <typeparamref name="TOut"/>.</param>
        void Create(out TOut obj);

        /// <summary>
        /// Tries to create an instance of <typeparamref name="TOut"/> and returns it via the out parameter <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The created instance of type <typeparamref name="TOut"/>.</param>
        /// <returns>True if the object was created.</returns>
        Boolean TryCreate(out TOut obj);

        /// <summary>
        /// Tries to create an instance of <typeparamref name="TOut"/> and returns it via the out parameter <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The created instance of type <typeparamref name="TOut"/>.</param>
        /// <param name="ex">The caught exception.</param>
        /// <returns>True if the object was created.</returns>
        Boolean TryCreate(out TOut obj, out Exception ex);

    }

    /// <summary>
    /// Defines an atomic creation mechanism.
    /// </summary>
    /// <typeparam name="TOut">The type that will be created.</typeparam>
    /// <typeparam name="TIn1">The type of the 1st input parameter.</typeparam>
    public interface ICreator<TOut, TIn1> {

        /// <summary>
        /// Creates an instance of <typeparamref name="TOut"/> and returns it via the out parameter <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The created instance of type <typeparamref name="TOut"/>.</param>
        /// <param name="in1">The 1st input parameter.</param>
        void Create(out TOut obj, TIn1 in1);

        /// <summary>
        /// Tries to create an instance of <typeparamref name="TOut"/> and returns it via the out parameter <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The created instance of type <typeparamref name="TOut"/>.</param>
        /// <param name="in1">The 1st input parameter.</param>
        /// <returns>True if the object was created.</returns>
        Boolean TryCreate(out TOut obj, TIn1 in1);

        /// <summary>
        /// Tries to create an instance of <typeparamref name="TOut"/> and returns it via the out parameter <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The created instance of type <typeparamref name="TOut"/>.</param>
        /// <param name="in1">The 1st input parameter.</param>
        /// <param name="ex">The caught exception.</param>
        /// <returns>True if the object was created.</returns>
        Boolean TryCreate(out TOut obj, TIn1 in1, out Exception ex);

    }

    /// <summary>
    /// Defines an atomic creation mechanism.
    /// </summary>
    /// <typeparam name="TOut">The type that will be created.</typeparam>
    /// <typeparam name="TIn1">The type of the 1st input parameter.</typeparam>
    /// <typeparam name="TIn2">The type of the 2nd input parameter.</typeparam>
    public interface ICreator<TOut, TIn1, TIn2> {

        /// <summary>
        /// Creates an instance of <typeparamref name="TOut"/> and returns it via the out parameter <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The created instance of type <typeparamref name="TOut"/>.</param>
        /// <param name="in1">The 1st input parameter.</param>
        /// <param name="in2">The 2nd input parameter.</param>
        void Create(out TOut obj, TIn1 in1, TIn2 in2);

        /// <summary>
        /// Tries to create an instance of <typeparamref name="TOut"/> and returns it via the out parameter <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The created instance of type <typeparamref name="TOut"/>.</param>
        /// <param name="in1">The 1st input parameter.</param>
        /// <param name="in2">The 2nd input parameter.</param>
        /// <returns>True if the object was created.</returns>
        Boolean TryCreate(out TOut obj, TIn1 in1, TIn2 in2);

        /// <summary>
        /// Tries to create an instance of <typeparamref name="TOut"/> and returns it via the out parameter <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The created instance of type <typeparamref name="TOut"/>.</param>
        /// <param name="in1">The 1st input parameter.</param>
        /// <param name="in2">The 2nd input parameter.</param>
        /// <param name="ex">The caught exception.</param>
        /// <returns>True if the object was created.</returns>
        Boolean TryCreate(out TOut obj, TIn1 in1, TIn2 in2, out Exception ex);

    }

    /// <summary>
    /// Defines an atomic creation mechanism.
    /// </summary>
    /// <typeparam name="TOut">The type that will be created.</typeparam>
    /// <typeparam name="TIn1">The type of the 1st input parameter.</typeparam>
    /// <typeparam name="TIn2">The type of the 2nd input parameter.</typeparam>
    /// <typeparam name="TIn3">The type of the 3rd input parameter.</typeparam>
    public interface ICreator<TOut, TIn1, TIn2, TIn3> {

        /// <summary>
        /// Creates an instance of <typeparamref name="TOut"/> and returns it via the out parameter <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The created instance of type <typeparamref name="TOut"/>.</param>
        /// <param name="in1">The 1st input parameter.</param>
        /// <param name="in2">The 2nd input parameter.</param>
        /// <param name="in3">The 3rd input parameter.</param>
        void Create(out TOut obj, TIn1 in1, TIn2 in2, TIn3 in3);

        /// <summary>
        /// Tries to create an instance of <typeparamref name="TOut"/> and returns it via the out parameter <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The created instance of type <typeparamref name="TOut"/>.</param>
        /// <param name="in1">The 1st input parameter.</param>
        /// <param name="in2">The 2nd input parameter.</param>
        /// <param name="in3">The 3rd input parameter.</param>
        /// <returns>True if the object was created.</returns>
        Boolean TryCreate(out TOut obj, TIn1 in1, TIn2 in2, TIn3 in3);

        /// <summary>
        /// Tries to create an instance of <typeparamref name="TOut"/> and returns it via the out parameter <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The created instance of type <typeparamref name="TOut"/>.</param>
        /// <param name="in1">The 1st input parameter.</param>
        /// <param name="in2">The 2nd input parameter.</param>
        /// <param name="in3">The 3rd input parameter.</param>
        /// <param name="ex">The caught exception.</param>
        /// <returns>True if the object was created.</returns>
        Boolean TryCreate(out TOut obj, TIn1 in1, TIn2 in2, TIn3 in3, out Exception ex);

    }

    /// <summary>
    /// Defines an atomic creation mechanism.
    /// </summary>
    /// <typeparam name="TOut">The type that will be created.</typeparam>
    /// <typeparam name="TIn1">The type of the 1st input parameter.</typeparam>
    /// <typeparam name="TIn2">The type of the 2nd input parameter.</typeparam>
    /// <typeparam name="TIn3">The type of the 3rd input parameter.</typeparam>
    /// <typeparam name="TIn4">The type of the 4th input parameter.</typeparam>
    public interface ICreator<TOut, TIn1, TIn2, TIn3, TIn4> {

        /// <summary>
        /// Creates an instance of <typeparamref name="TOut"/> and returns it via the out parameter <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The created instance of type <typeparamref name="TOut"/>.</param>
        /// <param name="in1">The 1st input parameter.</param>
        /// <param name="in2">The 2nd input parameter.</param>
        /// <param name="in3">The 3rd input parameter.</param>
        /// <param name="in4">The 4th input parameter.</param>
        void Create(out TOut obj, TIn1 in1, TIn2 in2, TIn3 in3, TIn4 in4);

        /// <summary>
        /// Tries to create an instance of <typeparamref name="TOut"/> and returns it via the out parameter <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The created instance of type <typeparamref name="TOut"/>.</param>
        /// <param name="in1">The 1st input parameter.</param>
        /// <param name="in2">The 2nd input parameter.</param>
        /// <param name="in3">The 3rd input parameter.</param>
        /// <param name="in4">The 4th input parameter.</param>
        /// <returns>True if the object was created.</returns>
        Boolean TryCreate(out TOut obj, TIn1 in1, TIn2 in2, TIn3 in3, TIn4 in4);

        /// <summary>
        /// Tries to create an instance of <typeparamref name="TOut"/> and returns it via the out parameter <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The created instance of type <typeparamref name="TOut"/>.</param>
        /// <param name="in1">The 1st input parameter.</param>
        /// <param name="in2">The 2nd input parameter.</param>
        /// <param name="in3">The 3rd input parameter.</param>
        /// <param name="in4">The 4th input parameter.</param>
        /// <param name="ex">The caught exception.</param>
        /// <returns>True if the object was created.</returns>
        Boolean TryCreate(out TOut obj, TIn1 in1, TIn2 in2, TIn3 in3, TIn4 in4, out Exception ex);

    }

    /// <summary>
    /// Defines an atomic creation mechanism.
    /// </summary>
    /// <typeparam name="TOut">The type that will be created.</typeparam>
    /// <typeparam name="TIn1">The type of the 1st input parameter.</typeparam>
    /// <typeparam name="TIn2">The type of the 2nd input parameter.</typeparam>
    /// <typeparam name="TIn3">The type of the 3rd input parameter.</typeparam>
    /// <typeparam name="TIn4">The type of the 4th input parameter.</typeparam>
    /// <typeparam name="TIn5">The type of the 5th input parameter.</typeparam>
    public interface ICreator<TOut, TIn1, TIn2, TIn3, TIn4, TIn5> {

        /// <summary>
        /// Creates an instance of <typeparamref name="TOut"/> and returns it via the out parameter <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The created instance of type <typeparamref name="TOut"/>.</param>
        /// <param name="in1">The 1st input parameter.</param>
        /// <param name="in2">The 2nd input parameter.</param>
        /// <param name="in3">The 3rd input parameter.</param>
        /// <param name="in4">The 4th input parameter.</param>
        /// <param name="in5">The 5th input parameter.</param>
        void Create(out TOut obj, TIn1 in1, TIn2 in2, TIn3 in3, TIn4 in4, TIn5 in5);

        /// <summary>
        /// Tries to create an instance of <typeparamref name="TOut"/> and returns it via the out parameter <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The created instance of type <typeparamref name="TOut"/>.</param>
        /// <param name="in1">The 1st input parameter.</param>
        /// <param name="in2">The 2nd input parameter.</param>
        /// <param name="in3">The 3rd input parameter.</param>
        /// <param name="in4">The 4th input parameter.</param>
        /// <param name="in5">The 5th input parameter.</param>
        /// <returns>True if the object was created.</returns>
        Boolean TryCreate(out TOut obj, TIn1 in1, TIn2 in2, TIn3 in3, TIn4 in4, TIn5 in5);

        /// <summary>
        /// Tries to create an instance of <typeparamref name="TOut"/> and returns it via the out parameter <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The created instance of type <typeparamref name="TOut"/>.</param>
        /// <param name="in1">The 1st input parameter.</param>
        /// <param name="in2">The 2nd input parameter.</param>
        /// <param name="in3">The 3rd input parameter.</param>
        /// <param name="in4">The 4th input parameter.</param>
        /// <param name="in5">The 5th input parameter.</param>
        /// <param name="ex">The caught exception.</param>
        /// <returns>True if the object was created.</returns>
        Boolean TryCreate(out TOut obj, TIn1 in1, TIn2 in2, TIn3 in3, TIn4 in4, TIn5 in5, out Exception ex);

    }

    /// <summary>
    /// Defines an atomic creation mechanism.
    /// </summary>
    /// <typeparam name="TOut">The type that will be created.</typeparam>
    /// <typeparam name="TIn1">The type of the 1st input parameter.</typeparam>
    /// <typeparam name="TIn2">The type of the 2nd input parameter.</typeparam>
    /// <typeparam name="TIn3">The type of the 3rd input parameter.</typeparam>
    /// <typeparam name="TIn4">The type of the 4th input parameter.</typeparam>
    /// <typeparam name="TIn5">The type of the 5th input parameter.</typeparam>
    /// <typeparam name="TIn6">The type of the 6th input parameter.</typeparam>
    public interface ICreator<TOut, TIn1, TIn2, TIn3, TIn4, TIn5, TIn6> {

        /// <summary>
        /// Creates an instance of <typeparamref name="TOut"/> and returns it via the out parameter <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The created instance of type <typeparamref name="TOut"/>.</param>
        /// <param name="in1">The 1st input parameter.</param>
        /// <param name="in2">The 2nd input parameter.</param>
        /// <param name="in3">The 3rd input parameter.</param>
        /// <param name="in4">The 4th input parameter.</param>
        /// <param name="in5">The 5th input parameter.</param>
        /// <param name="in6">The 6th input parameter.</param>
        void Create(out TOut obj, TIn1 in1, TIn2 in2, TIn3 in3, TIn4 in4, TIn5 in5, TIn6 in6);

        /// <summary>
        /// Tries to create an instance of <typeparamref name="TOut"/> and returns it via the out parameter <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The created instance of type <typeparamref name="TOut"/>.</param>
        /// <param name="in1">The 1st input parameter.</param>
        /// <param name="in2">The 2nd input parameter.</param>
        /// <param name="in3">The 3rd input parameter.</param>
        /// <param name="in4">The 4th input parameter.</param>
        /// <param name="in5">The 5th input parameter.</param>
        /// <param name="in6">The 6th input parameter.</param>
        /// <returns>True if the object was created.</returns>
        Boolean TryCreate(out TOut obj, TIn1 in1, TIn2 in2, TIn3 in3, TIn4 in4, TIn5 in5, TIn6 in6);

        /// <summary>
        /// Tries to create an instance of <typeparamref name="TOut"/> and returns it via the out parameter <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The created instance of type <typeparamref name="TOut"/>.</param>
        /// <param name="in1">The 1st input parameter.</param>
        /// <param name="in2">The 2nd input parameter.</param>
        /// <param name="in3">The 3rd input parameter.</param>
        /// <param name="in4">The 4th input parameter.</param>
        /// <param name="in5">The 5th input parameter.</param>
        /// <param name="in6">The 6th input parameter.</param>
        /// <param name="ex">The caught exception.</param>
        /// <returns>True if the object was created.</returns>
        Boolean TryCreate(out TOut obj, TIn1 in1, TIn2 in2, TIn3 in3, TIn4 in4, TIn5 in5, TIn6 in6, out Exception ex);

    }

    /// <summary>
    /// Defines an atomic creation mechanism.
    /// </summary>
    /// <typeparam name="TOut">The type that will be created.</typeparam>
    /// <typeparam name="TIn1">The type of the 1st input parameter.</typeparam>
    /// <typeparam name="TIn2">The type of the 2nd input parameter.</typeparam>
    /// <typeparam name="TIn3">The type of the 3rd input parameter.</typeparam>
    /// <typeparam name="TIn4">The type of the 4th input parameter.</typeparam>
    /// <typeparam name="TIn5">The type of the 5th input parameter.</typeparam>
    /// <typeparam name="TIn6">The type of the 6th input parameter.</typeparam>
    /// <typeparam name="TIn7">The type of the 7th input parameter.</typeparam>
    public interface ICreator<TOut, TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7> {

        /// <summary>
        /// Creates an instance of <typeparamref name="TOut"/> and returns it via the out parameter <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The created instance of type <typeparamref name="TOut"/>.</param>
        /// <param name="in1">The 1st input parameter.</param>
        /// <param name="in2">The 2nd input parameter.</param>
        /// <param name="in3">The 3rd input parameter.</param>
        /// <param name="in4">The 4th input parameter.</param>
        /// <param name="in5">The 5th input parameter.</param>
        /// <param name="in6">The 6th input parameter.</param>
        /// <param name="in7">The 7th input parameter.</param>
        void Create(out TOut obj, TIn1 in1, TIn2 in2, TIn3 in3, TIn4 in4, TIn5 in5, TIn6 in6, TIn7 in7);

        /// <summary>
        /// Tries to create an instance of <typeparamref name="TOut"/> and returns it via the out parameter <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The created instance of type <typeparamref name="TOut"/>.</param>
        /// <param name="in1">The 1st input parameter.</param>
        /// <param name="in2">The 2nd input parameter.</param>
        /// <param name="in3">The 3rd input parameter.</param>
        /// <param name="in4">The 4th input parameter.</param>
        /// <param name="in5">The 5th input parameter.</param>
        /// <param name="in6">The 6th input parameter.</param>
        /// <param name="in7">The 7th input parameter.</param>
        /// <returns>True if the object was created.</returns>
        Boolean TryCreate(out TOut obj, TIn1 in1, TIn2 in2, TIn3 in3, TIn4 in4, TIn5 in5, TIn6 in6, TIn7 in7);

        /// <summary>
        /// Tries to create an instance of <typeparamref name="TOut"/> and returns it via the out parameter <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The created instance of type <typeparamref name="TOut"/>.</param>
        /// <param name="in1">The 1st input parameter.</param>
        /// <param name="in2">The 2nd input parameter.</param>
        /// <param name="in3">The 3rd input parameter.</param>
        /// <param name="in4">The 4th input parameter.</param>
        /// <param name="in5">The 5th input parameter.</param>
        /// <param name="in6">The 6th input parameter.</param>
        /// <param name="in7">The 7th input parameter.</param>
        /// <param name="ex">The caught exception.</param>
        /// <returns>True if the object was created.</returns>
        Boolean TryCreate(out TOut obj, TIn1 in1, TIn2 in2, TIn3 in3, TIn4 in4, TIn5 in5, TIn6 in6, TIn7 in7, out Exception ex);

    }

    /// <summary>
    /// Defines an atomic creation mechanism.
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
    public interface ICreator<TOut, TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8> {

        /// <summary>
        /// Creates an instance of <typeparamref name="TOut"/> and returns it via the out parameter <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The created instance of type <typeparamref name="TOut"/>.</param>
        /// <param name="in1">The 1st input parameter.</param>
        /// <param name="in2">The 2nd input parameter.</param>
        /// <param name="in3">The 3rd input parameter.</param>
        /// <param name="in4">The 4th input parameter.</param>
        /// <param name="in5">The 5th input parameter.</param>
        /// <param name="in6">The 6th input parameter.</param>
        /// <param name="in7">The 7th input parameter.</param>
        /// <param name="in8">The 8th input parameter.</param>
        void Create(out TOut obj, TIn1 in1, TIn2 in2, TIn3 in3, TIn4 in4, TIn5 in5, TIn6 in6, TIn7 in7, TIn8 in8);

        /// <summary>
        /// Tries to create an instance of <typeparamref name="TOut"/> and returns it via the out parameter <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The created instance of type <typeparamref name="TOut"/>.</param>
        /// <param name="in1">The 1st input parameter.</param>
        /// <param name="in2">The 2nd input parameter.</param>
        /// <param name="in3">The 3rd input parameter.</param>
        /// <param name="in4">The 4th input parameter.</param>
        /// <param name="in5">The 5th input parameter.</param>
        /// <param name="in6">The 6th input parameter.</param>
        /// <param name="in7">The 7th input parameter.</param>
        /// <param name="in8">The 8th input parameter.</param>
        /// <returns>True if the object was created.</returns>
        Boolean TryCreate(out TOut obj, TIn1 in1, TIn2 in2, TIn3 in3, TIn4 in4, TIn5 in5, TIn6 in6, TIn7 in7, TIn8 in8);

        /// <summary>
        /// Tries to create an instance of <typeparamref name="TOut"/> and returns it via the out parameter <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The created instance of type <typeparamref name="TOut"/>.</param>
        /// <param name="in1">The 1st input parameter.</param>
        /// <param name="in2">The 2nd input parameter.</param>
        /// <param name="in3">The 3rd input parameter.</param>
        /// <param name="in4">The 4th input parameter.</param>
        /// <param name="in5">The 5th input parameter.</param>
        /// <param name="in6">The 6th input parameter.</param>
        /// <param name="in7">The 7th input parameter.</param>
        /// <param name="in8">The 8th input parameter.</param>
        /// <param name="ex">The caught exception.</param>
        /// <returns>True if the object was created.</returns>
        Boolean TryCreate(out TOut obj, TIn1 in1, TIn2 in2, TIn3 in3, TIn4 in4, TIn5 in5, TIn6 in6, TIn7 in7, TIn8 in8, out Exception ex);

    }

}
