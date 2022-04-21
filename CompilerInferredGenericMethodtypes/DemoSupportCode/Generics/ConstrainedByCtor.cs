namespace CompilerInferredGenericMethodtypes.DemoSupportCode.Generics
{
    class FooWithCtor { }
    class FooWithPrivateCtor
    {
        private FooWithPrivateCtor()
        {

        }
    }
    class FooWithParameterizedCtor
    {
        public FooWithParameterizedCtor(int a)
        {

        }
    }
    class ConstrainedByCtor<T> where T : new()
    {
        public T CreateANewT()
        {
            return new T();
        }
    }
}
