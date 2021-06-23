using System;

using Nuclear.Creation;

namespace Nuclear.SemVer.Factories {

    /// <summary>
    /// Defines a factory to create semantic versioning objects.
    /// </summary>
    public interface ISemVerFactory : ICreator<ISemVer, String> { }
}
