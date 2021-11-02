namespace Nuclear.Creation.Internal {

    internal class InternalFactory : IFactory {

        public ICreatorFactory Creator => new CreatorFactory();

    }

}
