namespace Nuclear.Creation {

    /// <summary>
    /// Provides static access to instances of <see cref="IConverter"/>.
    /// </summary>
    public static class Converter {

        #region properties

        /// <summary>
        /// Gets a new instance of type <see cref="IConverter"/>.
        /// </summary>
        public static IConverter New => new Internal.Converter();

        /// <summary>
        /// Gets a cached instance of type <see cref="IConverter"/>.
        /// </summary>
        public static IConverter Instance { get; } = new Internal.Converter();

        #endregion

        #region ctors

        static Converter() { }

        #endregion

    }

}
