namespace Nuclear.Creation {

    internal class InternalFactory : IFactory {

        public ICreatorFactory Creator => new CreatorFactory();

    }

}
