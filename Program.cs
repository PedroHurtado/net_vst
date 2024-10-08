// See https://aka.ms/new-console-template for more information

using Aves;
using Paint;

var canvas = App.createCanvas();
var toolbar =App.createToolBar();
var dto = new DtoShape(new Point(0,0), new Point(0,0), "black");
var shape = toolbar.GetShape("circle", dto);
if(shape != null){
    canvas.add(shape);
}
    

var pinguino = new Pinguino(5);
var aguila = new Aguila(10,100);
Printer.PrintAve(aguila);
Printer.PrintAve(pinguino);
Printer.PrintAveVoladora(aguila);
Printer.PrintAveNoVoladora(pinguino);

Console.WriteLine("Extension Method");

var foo = new Foo("Pedro");
//foo.GetHashCode
Console.WriteLine(foo.name);
var foo1 = new Foo("Pedro");
Console.WriteLine(foo1 == foo);


var a = new int[] { 1, 2, 3, 4, 5, 6 };
var result = a.Filter(x => x % 2 == 0 && x.Between(4, 6)); //pares
foreach (var x in result)
{
    Console.WriteLine(x);
}

/*
    un extension method que al tipo int haba between
    2 4
    1. static class
    2. crear un metodo statico donde el primer parametro debe tener la palabra
    this  (this,start,end)    
*/

/*
   crear un delegado capaz de realizar las operaciones suma,resta,division,multiplicacion   
   agregar cada operacion a una lista y despues operar con los valors 2 y 2
   2+2=4
   2*2=4
   2/2=1
   2-2=0

   1. Creando una clase con las cuatro operaciones
   2. Crear instancias del delegado con expresion lambda 
    (a,b)=>a+b 
*/
Console.WriteLine("delegdos");
var operations = new List<Operation>(){
    Operations.Sum,   // (a,b)=>a+b
    (a,b)=>a*b,
    (a,b)=>a-b,
    (a,b)=>a/b
};
foreach (var operation in operations)
{
    Console.WriteLine(operation(2, 2));
}
/*
    Clousure->Crea una instancia con los parametros de la primera invocacion
    y devuelve otra funcion ->tiene acceso a los parametros
    Escribir este código js const sum = (a)=>(b)=>a+b en c# 
    utilizando Func<T> sin escribir clases
*/

Func<int, Func<int, int>> clousure = (a) => (b) => a + b;
/*
    const sum = (a)=>(b)=>a+b
    
    function sum(a){
        return function(b){
            debugger
            return a+b
        }
    }
*/



Console.WriteLine("Clousure");
var obj = clousure(5);
Console.WriteLine(obj(100)); //105
Console.WriteLine(obj(30)); //35
Console.WriteLine(obj(40)); //45


/*
   Crear una funcion que imprima por la consola la fecha actual
   function printDate(){
    console.log(Date.now())
   }
*/
var date = DateTime.Now;
Action<DateTime, Action<object?>> printDate = (a, b) => b(a);

printDate(date, Console.WriteLine);
printDate(DateTime.Now, Console.WriteLine);

//Crear una funcion filter a Link
public delegate int Operation(int a, int b);

public static class Operations
{
    public static int Sum(int a, int b)
    {
        return a + b;
    }
}
public static class ExtensionInteger
{
    public static bool Between(this int a, int b, int c)
    {
        return a >= b && a <= c;
    }
}

public static partial class Enumerable
{
    public static IEnumerable<TSource> Filter<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
    {
        foreach (var value in source)
        {
            if (predicate(value))
            {
                yield return value;
            }
        }
    }
}

/*public class Foo{
    public Foo(string name)
    {
        Name = name;
    }
    public String Name {get; init;}

    public class Bar {
    public string Name { get; set; }
 
    public override bool Equals(object? other) {
        return (other is Bar bar && bar.Name == Name);
    }
 
    public static bool operator ==(Bar b1, Bar b2) => b1.Equals(b2);
    public static bool operator !=(Bar b1, Bar b2) => !b1.Equals(b2);
 
    public override int GetHashCode() => Name.GetHashCode();
}
}*/

public readonly record struct Foo(string name);

/*
   crear una clase que implemente los metodos equals, GetHashCode y sobrecargar
   el operador == para comprobar que dos instancias de esa clase son iguales
*/