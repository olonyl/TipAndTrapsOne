namespace CompilerInferredGenericMethodtypes.DemoSupportCode.Generics
{
    interface ICookable { }
    abstract class Fruit { }

    class Orange : Fruit
    {

    }
    class Pear : Fruit, ICookable
    {
        private Pear()
        {

        }
    }

    class Apple : Fruit, ICookable { }


    class ConstrainedByCombinations<T> where T : Fruit, ICookable, new()
    {
    }
}
