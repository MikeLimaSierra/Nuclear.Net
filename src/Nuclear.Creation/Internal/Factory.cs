namespace Nuclear.Creation.Internal {

    internal class Factory : IFactory {

        public ICreatorFactory Creator => new CreatorFactory();

    }

}
