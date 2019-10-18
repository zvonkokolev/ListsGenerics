
using Lists.Entity;
using Lists.ListLogic;
using System;
using System.Collections;


namespace MainProgram
{
	public class Program
	{
		public static void Main(string[] args)
		{
			Person[] persons =
			{
					 new Person { LastName = "Huber", FirstName = "Herman", Age = 27},
					 new Person { LastName = "Adam", FirstName = "Paul", Age = 35},
					 new Person { LastName = "Mustermann", FirstName = "Max", Age = 42},
					 new Person { LastName = "Bertold", FirstName = "Brecht", Age = 19}
			};
			Console.WriteLine("Liste unsortiert");
			PrintOut(persons);

			MySort.Sort(persons);
			Console.WriteLine();
			Console.WriteLine("Liste sortiert nach VORNAME aufsteigend!!!");
			PrintOut(persons);

			MySort.Sort(persons, new PersonAgeComparer());
			Console.WriteLine();
			Console.WriteLine("Liste sortiert nach ALTER absteigend!!!");
			PrintOut(persons);
		}
		public static void PrintOut(Person[] people)
		{
			Console.WriteLine("----------------------------------------------------");
			foreach (var item in people)
			{
				Console.WriteLine($"{item.FirstName} {item.LastName} {item.Age}");
			}
		}
	}
}
