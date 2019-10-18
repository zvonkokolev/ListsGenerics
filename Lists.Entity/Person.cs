using System;
using System.Collections;

namespace Lists.Entity
{
	public class Person : IComparable
	{
		public string LastName { get; set; }
		public string FirstName { get; set; }
		public int Age { get; set; }
		public Person()
		{

		}
		public Person(string ln, string fn, int age)
		{
			LastName = ln;
			FirstName = fn;
			Age = age;
		}
		public override string ToString()
		{
			return $"{FirstName} {LastName} {Age}";
		}

		public int CompareTo(object obj)
		{
			if(obj == null)
			{
				throw new Exception("Objekt ist kein Person");
			}
			Person otherPerson = obj as Person;
			return this.FirstName.CompareTo(otherPerson.FirstName);
		}
	}
}
