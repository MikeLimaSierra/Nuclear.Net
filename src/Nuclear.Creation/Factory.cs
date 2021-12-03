namespace Nuclear.Creation {

    /// <summary>
    /// Provides static access to instances of <see cref="IFactory"/>.
    /// </summary>
    public static class Factory {

        #region properties

        /// <summary>
        /// Gets a new instance of type <see cref="IFactory"/>.
        /// </summary>
        public static IFactory New => new Internal.Factory();

        /// <summary>
        /// Gets a cached instance of type <see cref="IFactory"/>.
        /// </summary>
        public static IFactory Instance { get; } = new Internal.Factory();

        #endregion

        #region ctors

        static Factory() { }

        #endregion

    }

}
