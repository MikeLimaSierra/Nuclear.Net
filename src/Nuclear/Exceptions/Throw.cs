namespace Nuclear.Exceptions {

    /// <summary>
    /// Supplies conditional throw implementation.
    /// </summary>
    public static class Throw {

        #region properties

        /// <summary>
        /// Gets conditional throw functionality.
        /// </summary>
        public static IConditionalThrow If { get; private set; } = new ConditionalThrow();

        /// <summary>
        /// Gets conditional throw functionality with inverted results.
        /// </summary>
        public static IConditionalThrow IfNot { get; private set; } = new ConditionalThrow(invert: true);

        #endregion

    }
}
