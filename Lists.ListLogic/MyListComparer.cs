using System;
using System.Collections;
using System.Collections.Generic;

namespace Lists.ListLogic
{
	class MyListComparer<T> : IComparer
	{
		public int Compare(T left, T right)
		{
			if (left == null || right == null)
				throw new ArgumentException("Argument ist kein Objekt");
			MyList<T> leftOne = left as MyList<T>;
			MyList<T> rightOne = right as MyList<T>;
			return leftOne.CompareTo(rightOne);
		}

		public int Compare(object left, object right)
		{
			if (left == null || right == null)
				throw new ArgumentException("Argument ist kein Objekt");
			MyList<T> leftOne = left as MyList<T>;
			MyList<T> rightOne = right as MyList<T>;
			return leftOne.CompareTo(rightOne);
		}
	}
}
