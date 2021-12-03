namespace Nuclear.Creation {

    /// <summary>
    /// Provides static access to instances of <see cref="IParser"/>.
    /// </summary>
    public static class Parser {

        #region properties

        /// <summary>
        /// Gets a new instance of type <see cref="IFactory"/>.
        /// </summary>
        public static IParser New => new Internal.Parser();

        /// <summary>
        /// Gets a cached instance of type <see cref="IParser"/>.
        /// </summary>
        public static IParser Instance { get; } = new Internal.Parser();

        #endregion

        #region ctors

        static Parser() { }

        #endregion

    }

}
