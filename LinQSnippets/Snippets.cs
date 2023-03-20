using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinQSnippets {
	public class Snippets {
		static public void BasicLinQ() {
			string[] cars = {
				"VW Golf",
				"VW California",
				"Audi A3",
				"Audi A5",
				"Fiat Punto",
				"Seat Ibiza",
				"Seat León"
			};


			//SELECT * of cars
			var carList = from car in cars
						  select car;


			// SELECT WHERE car is Audi
			var audiList = from car in cars
						   where car.Contains("Audi")
						   select car;
		}


		static public void LinQNumbers() {
			List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

			// Cada numero multiplicado por 3
			// Todos los numeros menos el 9
			// Ordenar de forma ascendente
			var processedNumberList = numbers
				.Select(num => num * 3)
				.Where(num => num != 9)
				.OrderBy(num => num);
		}


		static public void SearchExamples() {
			List<string> textList = new List<string> {
				"a","bx","c","d","e","cj","f","c"
			};

			// primer elemento:
			var fisrt = textList.First();

			// primer elemento que sea "c"
			var firstC = textList
				.First(text => text.Equals("c"));

			// primer elemento que contenga la "j"
			var firstWithJ = textList
				.First(x => x.Contains("j"));

			// primer elemento con "z" o default
			var firstWithZOrDefault = textList
				.FirstOrDefault(x => x.Contains("z"));

			// ultimo elemento con "z" o default
			var lastWithZOrDefault = textList
				.LastOrDefault(x => x.Contains("z"));

			// valores unicos
			var uniqueTexts = textList
				.Single();
			var uniqueTextsOrDefault = textList
				.SingleOrDefault();


			int[] evenNumbers = { 0, 2, 4, 6, 8 };
			int[] otherEvenNumbers = { 0, 2, 6 };

			// obtener los que no se repiten ( 4 y 8 )
			var uniqueEvenNumbers = evenNumbers
				.Except(otherEvenNumbers);

		}



		static public void MultipleSelect() {

			string[] opinions = {
				"Opinion 1, text 1",
				"Opinion 2, text 2",
				"Opinion 3, text 3"
			};

			// SELECT MANY
			var opinionSelection = opinions
				.SelectMany(opinion => opinion.Split(","));


			var enterprises = new[] {
				new Enterprise() {
					Id= 1,
					Name = "Enterprise 1",
					Employees = new[] {
						new Employee {
							Id = 1,
							Name = "Martin",
							Email = "asdsa@example.com",
							Salary = 3000
						},
						new Employee {
							Id = 2,
							Name = "Carlos",
							Email = "asdsads@example.com",
							Salary = 3000
						},
						new Employee {
							Id = 3,
							Name = "Maria",
							Email = "asa@example.com",
							Salary = 4000
						}
					}
				},
				new Enterprise() {
					Id= 2,
					Name = "Enterprise 2",
					Employees = new[] {
						new Employee {
							Id = 4,
							Name = "Pepe",
							Email = "asddssa@example.com",
							Salary = 2000
						},
						new Employee {
							Id = 5,
							Name = "Carla",
							Email = "asdsdsads@example.com",
							Salary = 3000
						},
						new Employee {
							Id = 6,
							Name = "Mariano",
							Email = "aa@example.com",
							Salary = 4000
						}
					}
				}
			};

			//obtener todos los empleados de todas las empresas:
			var employeesList = enterprises
				.SelectMany(e => e.Employees);

			//saber si hay alguna enterprice en la lista:
			bool hasEnterprises = enterprises.Any();

			//saber si hay alguna con empleados
			bool hasEmployees = enterprises.Any(
					enterprise => enterprise.Employees.Any()
				);

			//saber si todas tienen empleados con salario >= a 1000
			bool hasEmployeeWithSalaryMoreThanOrEqualTo1000 = enterprises.Any(enterprise => enterprise.Employees.Any(employee => employee.Salary >= 1000));
		}



		static public void linQCollection() {
			var firstList = new List<string>() { "a", "b", "c" };
			var secondList = new List<string>() { "a", "c", "d" };


			//INNER JOIN (interseccion)
			var commonResult =
				from element in firstList
				join secondElement in secondList
				on element equals secondElement
				select new { element, secondElement };

			//lo mismo de arriba:
			var commonResult2 = firstList.Join(
					secondList,
					element => element,
					secondElement => secondElement,
					(element, secondElement) => new {
						element,
						secondElement
					}
				);


			//OUTER JOIN - LEFT  (list1 - list2)
			var leftOuterJoin =
				from element in firstList
				join secondElement in secondList
				on element equals secondElement
				into temporalList
				from temporalElement in temporalList.DefaultIfEmpty()
				where element != temporalElement
				select new { Element = element };

			var leftOuterJoin2 =
				from element in firstList
				from secondElement in secondList.Where(s => s == element).DefaultIfEmpty()
				select new { Element = element, secondElement = secondElement };

			//OUTER JOIN - RIGHT  (list2 - list1)
			var rightOuterJoin =
				from secondElement in secondList
				join element in firstList
				on secondElement equals element
				into temporalList
				from temporalElement in temporalList.DefaultIfEmpty()
				where secondElement != temporalElement
				select new { Element = secondElement };


			//UNION (list1 xor list2)
			var unionList = leftOuterJoin.Union(rightOuterJoin);
		}


		static public void SkipTakeLinQ() {
			var myList = new[] {
				1,2,3,4,5,6,7,8,9,10
			};

			//SKIP primeros 2 valores:
			var skipFirstTwoValues = myList
				.Skip(2); // {3,4,etc...}

			//SKIP ultimos 2 valores:
			var skipLastTwoValues = myList
				.SkipLast(2); // {etc...,7,8}

			//SKIP WHILE
			var skipWhileLessThan4 = myList.
				SkipWhile(n => n < 4); // {4,5,etc...}


			//TAKE (contrario a skip)
			var skipTakeTwoFirstValues = myList
				.Take(2); // {1,2}

			var skipTakeTwoLastValues = myList
				.TakeLast(2); // {9,10}

			var skipTakeWhileMoreThan4 = myList
				.TakeWhile(n => n > 4); // {5,6,etc...}

		}




		//PAGING with Skip & Take
		static public IEnumerable<T> GetPage<T>(IEnumerable<T> collection, int pageNumber, int resultsPerPage) {
			int startIndex = (pageNumber - 1) * resultsPerPage;
			return collection.Skip(startIndex).Take(resultsPerPage);

		}



		//VARIABLES (con uso de let, variables locales del query)
		//devolver los numeros cuyos cuadrados enten por encima de la media de la lista
		public static void LinQVariables() {
			int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
			var aboveAverage =
				from number in numbers
				let average = numbers.Average()
				let nSquare = Math.Pow(number, 2)
				where nSquare > average
				select number;

			foreach(int number in aboveAverage) {
				Console.WriteLine("Query: Number: {0}, Square: {1} ", number, Math.Pow(number, 2));
			}
		}



		// ZIP (operacion cualquiera entre 2 listas)
		public static void ZipLinQ() {
			int[] numbers = { 1, 2, 3, 4, 5 };
			string[] stringNumbers = { "one", "two", "three", "four", "five" };

			IEnumerable<string> zipNumbers = numbers.Zip(stringNumbers, (number, word) => number + "+" + word); // {"1=one","2=two", etc...}
		}



		//Repeat & Range
		public static void RepeatRangeLinQ() {
			//coleccion de valores del 1 al 1000
			var first1000 = Enumerable.Range(1, 1000);
			var aboveAverage =
				from number in first1000
				select number;

			var repeatFiveX = Enumerable.Repeat("X", 5); // {"X","X","X","X","X"}
		}


		static public void StudentsLinQ() {
			var classRoom = new[] {
				new Student {
					Name = "Martin",
					Id = 1,
					Grade = 90,
					Certified = true
				},
				new Student {
					Name = "Juan",
					Id = 2,
					Grade = 50,
					Certified = false
				},
				new Student {
					Name = "Maria",
					Id = 3,
					Grade = 96,
					Certified = true
				}
			};

			var certifiedStudentsNames =
				from student in classRoom
				where student.Certified
				select student.Name;

			var notCertifiedStudentsNames =
				from student in classRoom
				where student.Certified == false
				select student.Name;

			var approvedStudentsNames =
				from student in classRoom
				where student.Grade >= 50 && student.Certified
				select student.Name;

			//group
			var certifiedQuery = classRoom.GroupBy(x => x.Certified && x.Grade >= 50);
			//quedan 2 grupos, primero los no certificados y segundo los certificados que cumplen la condicion
		}


		//ALL (todos los valores deben cumplir la condicion)
		static public void AllLinQ() {
			var numbers = new List<int> {
				1,2,3,4,5
			};

			bool allAreSmallerThan10 = numbers.All(x => x < 10);
			bool allAreBiggerThan2 = numbers.All(x => x > 2);

			var emptyList = new List<int>();
			bool allNumbersAreGreaterThan0 = numbers.All(x => x >= 0); // true
			bool allNumbersAreGreaterThan0F = emptyList.All(x => x >= 0); // false
		}


		//AGGREGATE (secuencia de funciones, salida de un operacion es la entrada de la siguiente operacion)
		public static void AggregateQueries() {
			int[] numbers = { 1, 2, 3, 4, 6, 7, 8, 9, 10 };
			//sumar todos los numberos
			int sum = numbers.Aggregate((prevSum, currValue) => prevSum + currValue); // 55
			string[] words = { "hello", "my", "name", "is", "pepe" };
			string greeting = words.Aggregate((a, b) => a + b);
			//es como reduce
		}



		//DISTINCT (valores unicos)
		public static void DistinctValues() {
			int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
			IEnumerable<int> distinctValues = numbers.Distinct();
		}


		//GROUP BY
		public static void GroupByExample() {
			List<int> numbers = new List<int>() {
				1,2,3,4,5,6,7,8,9
			};

			//obtener solo valores pares y generar 2 grupos:
			var grouped = numbers.GroupBy(x => x % 2 == 0);
			// primero queda el grupo que no cumple y despues el que cumple
			foreach(var group in grouped) {
				Console.WriteLine("Grupo {0}", group.Key);
				foreach(var value in group) {
					Console.WriteLine(value); // {...odd} {...even}
				}
			}
		}




		static public void relationsLinQ() {
			List<Post> posts = new List<Post>() {
				new Post {
					Id = 1,
					Title = "My first post",
					Content = "My first content",
					Created = DateTime.Now,
					Comments = new List<Comment>{
						new Comment {
							Id = 1,
							Created = DateTime.Now,
							Title = "My first comment",
							Content = "My content"
						},
						new Comment {
							Id = 2,
							Created = DateTime.Now,
							Title = "My second comment",
							Content = "My other content"
						}
					}
				},
				new Post {
					Id = 2,
					Title = "My first post",
					Content = "My first content",
					Created = DateTime.Now,
					Comments = new List<Comment>{
						new Comment {
							Id = 3,
							Created = DateTime.Now,
							Title = "My first comment",
							Content = "My content"
						},
						new Comment {
							Id = 4,
							Created = DateTime.Now,
							Title = "My second comment",
							Content = "My other content"
						}
					}
				}
			};


			var commentsContent = posts
				.SelectMany(post =>
				post.Comments, (post, comment) => new {
					PostId = post.Id,
					CommentContent = comment.Content
				});


		}

	}
}