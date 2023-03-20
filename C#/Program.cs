
//Console.Write("Escribe tu nombre: ");
//string nombre = Console.ReadLine();
//Console.WriteLine("Hola "+ nombre);
using System.Runtime.CompilerServices;
using System.Xml.Linq;

int entero = 1000 / 2;
long enteroGrande = 48732947389247L;
float flotante = 10.254878F;
double doublee = 213.454059893023498D;
bool falso = false;
char caracter = 'a';
const string Constante = "solo lectura";
Console.WriteLine("Constante: {0}", Constante); //format
var inferido = 66;
var date = DateTime.Now;
Console.WriteLine(date);


/* conversion implicita es posible de menores a mayores (en tamaño): char < int < long < float < double */
double myDouble = entero; // Automatic casting: int to double

/* conversion explicita de mayores a menores: */
int myInt = (int)myDouble; // Manual casting: double to int
int otroInt = Convert.ToInt32(myDouble); // convert double to int
double otroDoble = Convert.ToDouble(myInt); // convert int to double
string myStr = Convert.ToString(myInt); // convert int to string
string falsoStr = Convert.ToString(falso); // convert bool to string

//transformar cadena a numero si es posible:
int numSalida = 0;
string numString = "8080";
bool resultadoTry = int.TryParse(numString, out numSalida);
Console.WriteLine($"TryParse:{resultadoTry}, numSalida: {numSalida}");


int? nullable = null; // ? para q pueda ser int o null
string? nullStr = null;


//operadores C# == JS
//condicion ? "true" : "false";


//MATH
double mayor = Math.Max(myInt, otroInt);
double menor = Math.Min(myInt, otroInt);
double raiz = Math.Sqrt(myInt);
double absoluto = Math.Abs(-5);
double redondeado = Math.Round(5.44);
double paArriba = Math.Ceiling(5.55);
double paAbajo = Math.Floor(6.23);


//STRINGS
int longitud = falsoStr.Length;
myStr = myStr.ToLower();
myStr = myStr.ToUpper();
myStr = string.Concat(falsoStr, myStr);
char a = falsoStr[1];
int posicion = falsoStr.IndexOf("l");
string ultimasLetras = falsoStr.Substring(posicion); //segundo arg sería posicion max
string reemplazoFacha = falsoStr.Replace("lso", "cha");
string sinEspaciosEnPrincipioYFinal = reemplazoFacha.Trim();
string interpolacion = $"string 1: {falsoStr}, string2: {myStr}";
string multilinea = @"primer linea
    segunda linea
        y puedo usar comillas ""asi""";
Console.WriteLine(multilinea);
string txt = "We are the so-called \"Vikings\" from the \n north."; //clausulas de escape y new line


//COLECCIONES
//1D 2D 3D
//estructura de 3 dimensiones:
Coordenadas myCoords = new Coordenadas(2, 5, 12);
Console.WriteLine("x:" + myCoords.X);
Console.WriteLine("y:" + myCoords.Y);
Console.WriteLine("z:" + myCoords.Z);

Coordenadas CoordsModificadas = myCoords with { X = 10 };
Console.WriteLine(CoordsModificadas);
//struct estructura para guardar datos
//las instrucciones tienen que estar arriba
Cliente carlitos = new Cliente("carlitos", "4324325", "belgrano 2", "carl@gmail.com", true);


//Arrays
string[] names = { "carlos", "maria" };
List<int> numeritos = new List<int> { 4, 6, 2, 7, 8 };

// Create an array of four elements, and add values later
string[] cars = new string[4];
// Create an array of four elements and add values right away 
string[] cars2 = new string[4] { "Volvo", "BMW", "Ford", "Mazda" };
// Create an array of four elements without specifying the size 
string[] cars3 = new string[] { "Volvo", "BMW", "Ford", "Mazda" };
// Create an array of four elements, omitting the new keyword, and without specifying the size
string[] cars4 = { "Volvo", "BMW", "Ford", "Mazda" };

// 2D Array:
int[,] numbers = { { 1, 4, 2 }, { 3, 6, 8 } };
//acceder:
Console.WriteLine(numbers[0, 2]);  // Outputs 2
numbers[1, 0] = 9; // { { 1, 4, 2 }, { 9, 6, 8 } }
//we have to use GetLength() instead of Length to specify how many times the loop should run:
//RECORRER ARRAY 2D (con el foreach itera tambien)
//for(int i = 0; i < numbers.GetLength(0); i++) {
//    for(int j = 0; j < numbers.GetLength(1); j++) {
//        Console.WriteLine(numbers[i, j]);
//    }
//}


//RECORRER ARRAY
//foreach(string name in names) {
//    Console.WriteLine(name);
//}



//METODOS ARRAY
Array.Sort(cars4);
//Other useful array methods, such as Min, Max, and Sum, can be found in the System.Linq namespace:
int maximo = numeritos.Max();
int minimo = numeritos.Min();
int sumatoria = numeritos.Sum();


//LINQ
int[] myArray = { 24, 73, 573, 8, 2, 647, 83, 23, 522, 54 };
var consulta = from element in myArray
               where ((element % 2) == 0)
               select element;
Console.WriteLine("consulta: ");
foreach(var item in consulta) {
    Console.WriteLine(item + " es par");
}


//FUNCIONES
int cuadrado(int n) {
    return n * n;
}

void saludar(string nombre = "defaultValue") {
    Console.WriteLine($"Hola {nombre}");
}


//FUNCIONES ANONIMAS /LAMBDA: (n) => {n*2};
int[] arrNum = { 1, 2, 3, 4 };
var arrNumAlCuadrado = arrNum.Select((n) => n * n);
Console.WriteLine(string.Join(",", arrNumAlCuadrado));


//TIPOS ANONIMOS
var coche = new { Marca = "Fiat", Anio = 2021 };

//CLASS
Moto motito = new Moto();
Moto.Arrancar();
motito.Encender();
motito.Encender(str: "nada"); //arg como key:value (opcional, no importaria el orden de args)

Puerta miPuerta = new Puerta();
miPuerta.Abrir();
miPuerta.MostrarEstado();

Persona rober = new Persona();
rober.Respirar();
Pez nemo = new Pez();
nemo.Respirar();

class Moto {
    public static void Arrancar() {
        Console.WriteLine("Arrancar");
    }
    public void Encender() {
        Console.WriteLine("Encender");
    }
    //sobrecarga de metodos
    public void Encender(string str) {
        Console.WriteLine($"Encender y {str}");
    }
}


class Puerta {
    bool abierta;

    public Puerta() {
        abierta = false;
    }
    //sobrecarga constructor
    public Puerta(bool abierta) {
        this.abierta = abierta;
    }

    public void Cerrar() {
        abierta = false;
    }
    public void Abrir() {
        abierta = true;
    }
    public void MostrarEstado() {
        Console.WriteLine(abierta);
    }
}

class SerVivo {
    //nada
    public void Respirar() {
        Console.WriteLine("Respirar");
    }
}

class Pez : SerVivo {
    //Polimorfismo:
    public void Respirar() {
        Console.WriteLine("Glu Glu");
    }
}

class Persona : SerVivo {
    private int _edad;

    public int Edad { get => _edad; set => _edad = value; }


}


//INTERFACE



public struct Coordenadas {
    public Coordenadas(double x, double
y, double z) {
        X = x;

        Y = y;

        Z = z;
    }
    public double X { get; set; }//si tiene solo get es de solo lectura
    public double Y { get; }
    public double Z { get; }

    public override string ToString() => $"{X},{Y},{Z}"; //forma en la que aparece el objeto cuando se lo ref
}


//public ref <name>  // objeto de referencia
//public readonly <name> // solo lectura
public struct Cliente {
    public Cliente(string nombreCompleto, string telefono, string direccion, string email, bool esNuevo) {
        NombreCompleto = nombreCompleto;
        Telefono = telefono;
        Direccion = direccion;
        Email = email;
        EsNuevo = esNuevo;
    }
    public string NombreCompleto { get; }
    public string Telefono { get; }
    public string Direccion { get; }
    public string Email { get; }
    public bool EsNuevo { get; }

    public override string ToString() => $"{NombreCompleto},{Telefono},{Direccion},{Email},{EsNuevo}";


}
