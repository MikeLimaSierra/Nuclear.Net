using System;

namespace Nuclear.Creation.Internal {

    internal class CreatorFactory : ICreatorFactory {

        #region methods

        public ICreator<TOut> Create<TOut>(Func<TOut> func) => new InternalCreator<TOut>(func);

        public ICreator<TOut, TIn1> Create<TOut, TIn1>(Func<TIn1, TOut> func)
            => new InternalCreator<TOut, TIn1>(func);

        public ICreator<TOut, TIn1, TIn2> Create<TOut, TIn1, TIn2>(Func<TIn1, TIn2, TOut> func)
            => new InternalCreator<TOut, TIn1, TIn2>(func);

        public ICreator<TOut, TIn1, TIn2, TIn3> Create<TOut, TIn1, TIn2, TIn3>(Func<TIn1, TIn2, TIn3, TOut> func)
            => new InternalCreator<TOut, TIn1, TIn2, TIn3>(func);

        public ICreator<TOut, TIn1, TIn2, TIn3, TIn4> Create<TOut, TIn1, TIn2, TIn3, TIn4>(Func<TIn1, TIn2, TIn3, TIn4, TOut> func)
            => new InternalCreator<TOut, TIn1, TIn2, TIn3, TIn4>(func);

        public ICreator<TOut, TIn1, TIn2, TIn3, TIn4, TIn5> Create<TOut, TIn1, TIn2, TIn3, TIn4, TIn5>(Func<TIn1, TIn2, TIn3, TIn4, TIn5, TOut> func)
            => new InternalCreator<TOut, TIn1, TIn2, TIn3, TIn4, TIn5>(func);

        public ICreator<TOut, TIn1, TIn2, TIn3, TIn4, TIn5, TIn6> Create<TOut, TIn1, TIn2, TIn3, TIn4, TIn5, TIn6>(Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TOut> func)
            => new InternalCreator<TOut, TIn1, TIn2, TIn3, TIn4, TIn5, TIn6>(func);

        public ICreator<TOut, TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7> Create<TOut, TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7>(Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TOut> func)
            => new InternalCreator<TOut, TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7>(func);

        public ICreator<TOut, TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8> Create<TOut, TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8>(Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TOut> func)
            => new InternalCreator<TOut, TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8>(func);

        #endregion

    }

}
