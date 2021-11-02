namespace Nuclear.Creation {

    /// <summary>
    /// Defines a most basic factory structure used for extensibility.
    /// </summary>
    public interface IFactory {

        #region properties

        /// <summary>
        /// Gets a new factory instance for creator objects.
        /// </summary>
        ICreatorFactory Creator { get; }

        #endregion

    }

}
