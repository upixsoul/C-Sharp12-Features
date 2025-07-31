
namespace C_Sharp12
{
    using Measurement = (string Unit, double Value);
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Hello, Welcome to DAGG C# 12 Catalog");
            Console.WriteLine("This catalog contains examples of C# 11 features");
            Console.WriteLine("These features are available in .NET Core 8.0+ since 2023");

            #region PrimaryConstructors
            Console.WriteLine("1.- Primary Constructors for Classes and Structs");
            Console.WriteLine("You can now declare constructor parameters directly in the type definition.");
            Console.WriteLine("public class Person(string name, int age)");
            #endregion

            #region CollectionExpressions
            Console.WriteLine();
            Console.WriteLine("2.- Collection Expressions");
            Console.WriteLine("A concise syntax for initializing arrays, lists, spans, and more.");
            //Basic Collection Initialization
            //not yet available
            //var numbers = [1, 2, 3, 4, 5]; // Creates a List<int>

            Console.WriteLine();
            #endregion

            #region DefaultParametersInLambdaExpressions
            Console.WriteLine();
            Console.WriteLine("3.- Default Parameters in Lambda Expressions");
            Console.WriteLine("Lambdas can now have default parameter values.");
            var greet = (string name, string greeting = "Hello") =>
            {
                Console.WriteLine($"{greeting}, {name}!");
            };

            greet("David"); // Outputs: Hello, David!
            #endregion

            #region RefReadonlyParameters
            Console.WriteLine();
            Console.WriteLine("4.- Ref Readonly Parameters");
            Console.WriteLine("Improves clarity for APIs that pass by reference but don’t modify the value.");
            var testValue = 10;
            Print(ref testValue);
            #endregion

            #region AliasAnyType
            Console.WriteLine();
            Console.WriteLine("5.- Alias Any Type");
            Console.WriteLine("You can alias tuples, arrays, pointers, and more—not just named types.");
            Measurement m = ("cm", 12.5);
            Console.WriteLine($"Measurement: {m.Value} {m.Unit}");
            #endregion

            #region ExperimentalAttribute
            Console.WriteLine();
            Console.WriteLine("6.- Experimental Attribute");
            Console.WriteLine("Marks APIs as experimental and triggers compiler warnings.");
            Console.WriteLine("[System.Diagnostics.CodeAnalysis.Experimental(\"EXP001\")]");
            Console.WriteLine("public void TryFeature() => Console.WriteLine(\"Experimental!\");");
            #endregion

            #region InlineArrays
            Console.WriteLine();
            Console.WriteLine("7.- Inline Arrays");
            Console.WriteLine("Define fixed-size buffers inside structs for performance-critical scenarios.");
            var buffer = new SmallBuffer();
            buffer[0] = 10;
            Console.WriteLine($"Inline Array Element: {buffer[0]}");
            #endregion

            #region Interceptors
            Console.WriteLine();
            Console.WriteLine("8.- Interceptors");
            Console.WriteLine("Allows compile-time substitution of method calls via source generators.");
            Console.WriteLine("Please run WebInterceptors project");
            #endregion
        }

        // 1.- Example of a class with a primary constructor
        public class Person(string name, int age)
        {
            public string Name { get; } = name;
            public int Age { get; } = age;
        }

        // 4.- Ref Readonly Parameters
        public static void Print(ref readonly int value)
        {
            //value = 7;//No se puede asignar a variable "value" o usarlo como el lado derecho de una asignación de referencia porque es una variable de solo lectura
            Console.WriteLine(value);
        }

        //6.- Experimental Attribute
        [System.Diagnostics.CodeAnalysis.Experimental("EXP001")]
        public void TryFeature() => Console.WriteLine("Experimental!");

        // 7.- Inline Arrays
        [System.Runtime.CompilerServices.InlineArray(3)]
        public struct SmallBuffer
        {
            private int _element0;
        }

    }

    
}
