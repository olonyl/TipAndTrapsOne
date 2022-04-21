namespace CompilerInferredGenericMethodtypes.DemoSupportCode.Generics
{

    internal interface IPrintable { }

    internal class PrintableFoo : IPrintable { }
    internal class ConstrainedByInterface<T> where T : IPrintable
    {

    }
}
