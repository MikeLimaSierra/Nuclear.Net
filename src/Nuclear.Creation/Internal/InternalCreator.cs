using System;

using Nuclear.Exceptions;

namespace Nuclear.Creation.Internal {

    internal class InternalCreator<TOut> : ICreator<TOut> {

        private readonly Func<TOut> _func;

        internal InternalCreator(Func<TOut> func) {
            Throw.If.Object.IsNull(func, nameof(func));

            _func = func;
        }

        public void Create(out TOut obj) => obj = _func();

        public Boolean TryCreate(out TOut obj) {
            obj = default;

            Try.Do(() => _func(), out obj, out Exception _);

            return obj != null;
        }

        public Boolean TryCreate(out TOut obj, out Exception ex) {
            obj = default;

            Try.Do(() => _func(), out obj, out ex);

            return obj != null;
        }

    }

    internal class InternalCreator<TOut, TIn1> : ICreator<TOut, TIn1> {

        private readonly Func<TIn1, TOut> _func;

        internal InternalCreator(Func<TIn1, TOut> func) {
            Throw.If.Object.IsNull(func, nameof(func));

            _func = func;
        }

        public void Create(out TOut obj, TIn1 in1) => obj = _func(in1);

        public Boolean TryCreate(out TOut obj, TIn1 in1) {
            obj = default;

            Try.Do(() => _func(in1), out obj, out Exception _);

            return obj != null;
        }

        public Boolean TryCreate(out TOut obj, TIn1 in1, out Exception ex) {
            obj = default;

            Try.Do(() => _func(in1), out obj, out ex);

            return obj != null;
        }

    }

    internal class InternalCreator<TOut, TIn1, TIn2> : ICreator<TOut, TIn1, TIn2> {

        private readonly Func<TIn1, TIn2, TOut> _func;

        internal InternalCreator(Func<TIn1, TIn2, TOut> func) {
            Throw.If.Object.IsNull(func, nameof(func));

            _func = func;
        }

        public void Create(out TOut obj, TIn1 in1, TIn2 in2) => obj = _func(in1, in2);

        public Boolean TryCreate(out TOut obj, TIn1 in1, TIn2 in2) {
            obj = default;

            Try.Do(() => _func(in1, in2), out obj, out Exception _);

            return obj != null;
        }

        public Boolean TryCreate(out TOut obj, TIn1 in1, TIn2 in2, out Exception ex) {
            obj = default;

            Try.Do(() => _func(in1, in2), out obj, out ex);

            return obj != null;
        }

    }

    internal class InternalCreator<TOut, TIn1, TIn2, TIn3> : ICreator<TOut, TIn1, TIn2, TIn3> {

        private readonly Func<TIn1, TIn2, TIn3, TOut> _func;

        internal InternalCreator(Func<TIn1, TIn2, TIn3, TOut> func) {
            Throw.If.Object.IsNull(func, nameof(func));

            _func = func;
        }

        public void Create(out TOut obj, TIn1 in1, TIn2 in2, TIn3 in3) => obj = _func(in1, in2, in3);

        public Boolean TryCreate(out TOut obj, TIn1 in1, TIn2 in2, TIn3 in3) {
            obj = default;

            Try.Do(() => _func(in1, in2, in3), out obj, out Exception _);

            return obj != null;
        }

        public Boolean TryCreate(out TOut obj, TIn1 in1, TIn2 in2, TIn3 in3, out Exception ex) {
            obj = default;

            Try.Do(() => _func(in1, in2, in3), out obj, out ex);

            return obj != null;
        }

    }

    internal class InternalCreator<TOut, TIn1, TIn2, TIn3, TIn4> : ICreator<TOut, TIn1, TIn2, TIn3, TIn4> {

        private readonly Func<TIn1, TIn2, TIn3, TIn4, TOut> _func;

        internal InternalCreator(Func<TIn1, TIn2, TIn3, TIn4, TOut> func) {
            Throw.If.Object.IsNull(func, nameof(func));

            _func = func;
        }

        public void Create(out TOut obj, TIn1 in1, TIn2 in2, TIn3 in3, TIn4 in4) => obj = _func(in1, in2, in3, in4);

        public Boolean TryCreate(out TOut obj, TIn1 in1, TIn2 in2, TIn3 in3, TIn4 in4) {
            obj = default;

            Try.Do(() => _func(in1, in2, in3, in4), out obj, out Exception _);

            return obj != null;
        }

        public Boolean TryCreate(out TOut obj, TIn1 in1, TIn2 in2, TIn3 in3, TIn4 in4, out Exception ex) {
            obj = default;

            Try.Do(() => _func(in1, in2, in3, in4), out obj, out ex);

            return obj != null;
        }

    }

    internal class InternalCreator<TOut, TIn1, TIn2, TIn3, TIn4, TIn5> : ICreator<TOut, TIn1, TIn2, TIn3, TIn4, TIn5> {

        private readonly Func<TIn1, TIn2, TIn3, TIn4, TIn5, TOut> _func;

        internal InternalCreator(Func<TIn1, TIn2, TIn3, TIn4, TIn5, TOut> func) {
            Throw.If.Object.IsNull(func, nameof(func));

            _func = func;
        }

        public void Create(out TOut obj, TIn1 in1, TIn2 in2, TIn3 in3, TIn4 in4, TIn5 in5) => obj = _func(in1, in2, in3, in4, in5);

        public Boolean TryCreate(out TOut obj, TIn1 in1, TIn2 in2, TIn3 in3, TIn4 in4, TIn5 in5) {
            obj = default;

            Try.Do(() => _func(in1, in2, in3, in4, in5), out obj, out Exception _);

            return obj != null;
        }

        public Boolean TryCreate(out TOut obj, TIn1 in1, TIn2 in2, TIn3 in3, TIn4 in4, TIn5 in5, out Exception ex) {
            obj = default;

            Try.Do(() => _func(in1, in2, in3, in4, in5), out obj, out ex);

            return obj != null;
        }

    }

    internal class InternalCreator<TOut, TIn1, TIn2, TIn3, TIn4, TIn5, TIn6> : ICreator<TOut, TIn1, TIn2, TIn3, TIn4, TIn5, TIn6> {

        private readonly Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TOut> _func;

        internal InternalCreator(Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TOut> func) {
            Throw.If.Object.IsNull(func, nameof(func));

            _func = func;
        }

        public void Create(out TOut obj, TIn1 in1, TIn2 in2, TIn3 in3, TIn4 in4, TIn5 in5, TIn6 in6) => obj = _func(in1, in2, in3, in4, in5, in6);

        public Boolean TryCreate(out TOut obj, TIn1 in1, TIn2 in2, TIn3 in3, TIn4 in4, TIn5 in5, TIn6 in6) {
            obj = default;

            Try.Do(() => _func(in1, in2, in3, in4, in5, in6), out obj, out Exception _);

            return obj != null;
        }

        public Boolean TryCreate(out TOut obj, TIn1 in1, TIn2 in2, TIn3 in3, TIn4 in4, TIn5 in5, TIn6 in6, out Exception ex) {
            obj = default;

            Try.Do(() => _func(in1, in2, in3, in4, in5, in6), out obj, out ex);

            return obj != null;
        }

    }

    internal class InternalCreator<TOut, TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7> : ICreator<TOut, TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7> {

        private readonly Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TOut> _func;

        internal InternalCreator(Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TOut> func) {
            Throw.If.Object.IsNull(func, nameof(func));

            _func = func;
        }

        public void Create(out TOut obj, TIn1 in1, TIn2 in2, TIn3 in3, TIn4 in4, TIn5 in5, TIn6 in6, TIn7 in7) => obj = _func(in1, in2, in3, in4, in5, in6, in7);

        public Boolean TryCreate(out TOut obj, TIn1 in1, TIn2 in2, TIn3 in3, TIn4 in4, TIn5 in5, TIn6 in6, TIn7 in7) {
            obj = default;

            Try.Do(() => _func(in1, in2, in3, in4, in5, in6, in7), out obj, out Exception _);

            return obj != null;
        }

        public Boolean TryCreate(out TOut obj, TIn1 in1, TIn2 in2, TIn3 in3, TIn4 in4, TIn5 in5, TIn6 in6, TIn7 in7, out Exception ex) {
            obj = default;

            Try.Do(() => _func(in1, in2, in3, in4, in5, in6, in7), out obj, out ex);

            return obj != null;
        }

    }

    internal class InternalCreator<TOut, TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8> : ICreator<TOut, TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8> {

        private readonly Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TOut> _func;

        internal InternalCreator(Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TOut> func) {
            Throw.If.Object.IsNull(func, nameof(func));

            _func = func;
        }

        public void Create(out TOut obj, TIn1 in1, TIn2 in2, TIn3 in3, TIn4 in4, TIn5 in5, TIn6 in6, TIn7 in7, TIn8 in8) => obj = _func(in1, in2, in3, in4, in5, in6, in7, in8);

        public Boolean TryCreate(out TOut obj, TIn1 in1, TIn2 in2, TIn3 in3, TIn4 in4, TIn5 in5, TIn6 in6, TIn7 in7, TIn8 in8) {
            obj = default;

            Try.Do(() => _func(in1, in2, in3, in4, in5, in6, in7, in8), out obj, out Exception _);

            return obj != null;
        }

        public Boolean TryCreate(out TOut obj, TIn1 in1, TIn2 in2, TIn3 in3, TIn4 in4, TIn5 in5, TIn6 in6, TIn7 in7, TIn8 in8, out Exception ex) {
            obj = default;

            Try.Do(() => _func(in1, in2, in3, in4, in5, in6, in7, in8), out obj, out ex);

            return obj != null;
        }

    }

}
