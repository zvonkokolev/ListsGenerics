using System;
using System.Collections;
using System.Collections.Generic;
namespace Lists.ListLogic
{
	/// <summary>
	/// Die Liste verwaltet beliebige Elemente und implementiert
	/// das IList-Interface und damit auch ICollection und IEnumerable
	/// </summary>
	public class MyList<T> : IList<T>, IComparable
	{
		//fields
		private Node<T> _head;

		#region IList Members

		/// <summary>
		/// Ein neues Objekt wird in die Liste am Ende
		/// eingefügt. Etwaige Typinkompatiblitäten beim Vergleich werden
		/// nicht behandelt und lösen eine Exception aus.
		/// </summary>
		/// <param name="value">Einzufügender Datensatz</param>
		/// <returns>Index des Werts in der Liste</returns>

		/// <summary>
		/// Die Liste wird geleert. Die Elemente werden einfach ausgekettet.
		/// Der GC räumt dann schon auf.
		/// </summary>
		public void Clear()
		{
			_head = null;
		}

		/// <summary>
		/// Gibt es den gesuchten DataObject zumindest ein mal?
		/// </summary>
		/// <param name="value">gesuchter DataObject</param>
		/// <returns></returns>


		/// <summary>
		/// Der DataObject wird gesucht und dessen Index wird zurückgegeben.
		/// </summary>
		/// <param name="value">gesuchter DataObject</param>
		/// <returns>Index oder -1, falls der DataObject nicht in der Liste ist</returns>


		/// <summary>
		/// DataObject an bestimmter Position in Liste einfügen.
		/// Es ist auch erlaubt, einen DataObject hinter dem letzten Element
		/// (index == count) einzufügen.
		/// </summary>
		/// <param name="index">Einfügeposition</param>
		/// <param name="value">Einzufügender DataObject</param>


		/// <summary>
		/// Wird nicht verwendet ==> Immer false
		/// </summary>
		public bool IsFixedSize
		{
			get { return false; }
		}

		/// <summary>
		/// Wird nicht verwendet ==> Immer false
		/// </summary>
		public bool IsReadOnly
		{
			get { return false; }
		}

		/// <summary>
		/// Ein DataObject wird aus der Liste entfernt, wenn es ihn 
		/// zumindest ein mal gibt.
		/// </summary>
		/// <param name="value">zu entfernender DataObject</param>


		/// <summary>
		/// Der DataObject an der Position Index wird entfernt.
		/// Gibt es die Position nicht, geschieht nichts.
		/// </summary>
		/// <param name="index"></param>
		public void RemoveAt(int index)
		{
			int count = 0;
			Node<T> temp = _head;
			Node<T> prev = null;
			while (temp != null)
			{
				if (count == index)
				{
					if (temp == _head)
					{
						_head = temp.Next;
					}
					else
					{
						prev.Next = prev.Next.Next;
					}
					break;
				}
				prev = temp;
				temp = temp.Next;
				count++;
			}
		}

		/// <summary>
		/// Indexer zum Einfügen und Lesen von Werten an
		/// gesuchten Positionen.
		/// </summary>
		/// <param name="index"></param>
		/// <returns></returns>

		public object this[int index]
		{
			get
			{
				if (index < 0 || index >= Count)
					throw new IndexOutOfRangeException(nameof(index));

				int count = 0;
				Node<T> temp = _head;

				while (count != index)
				{
					temp = temp.Next;
					count++;
				}
				return temp.DataObject;
			}
			set
			{
				if (index < 0 || index > Count)
					throw new IndexOutOfRangeException(nameof(index));

				Node<T> run = _head;
				int counter = 0;

				while (counter != index)
				{
					run = run.Next;
					counter++;
				}
				run.DataObject = (T)value;
			}
		}
		#endregion

		#region ICollection Members

		/// <summary>
		/// Werte in ein bereits angelegtes Array kopieren.
		/// Ist das übergebene Array zu klein, oder stimmt der
		/// Startindex nicht, geschieht nichts.
		/// </summary>
		/// <param name="array">Zielarray, existiert bereits</param>
		/// <param name="index">Startindex</param>


		/// <summary>
		/// Die Anzahl von Elementen in der Liste wird immer 
		/// explizit gezählt und ist nicht redundant gespeichert.
		/// </summary>
		public int Count
		{
			get
			{
				Node<T> temp = _head;
				int count = 0;
				while (temp != null)
				{
					count++;
					temp = temp.Next;
				}
				return count;
			}
		}

		/// <summary>
		/// Multithreading wird nicht verwendet
		/// </summary>
		public bool IsSynchronized
		{
			get { return false; }
		}

		/// <summary>
		/// Multithreading wird nicht verwendet
		/// </summary>
		public T SyncRoot
		{
			get { return default; }
		}

		T IList<T>.this[int index]
		{
			get
			{
				if (index < 0 || index >= Count)
					throw new IndexOutOfRangeException(nameof(index));

				int count = 0;
				Node<T> temp = _head;

				while (count != index)
				{
					temp = temp.Next;
					count++;
				}
				return temp.DataObject;
			}
			set
			{
				if (index < 0 || index > Count)
					throw new IndexOutOfRangeException(nameof(index));

				Node<T> run = _head;
				int counter = 0;

				while (counter != index)
				{
					run = run.Next;
					counter++;
				}
				run.DataObject = value;
			}
		}

		#endregion

		/// <summary>
		/// Liefert alle Elemente in Form eines Arrays zurück
		/// </summary>
		/// <returns>Array in der richtigen Größe</returns>
		public object[] ToArray()
		{
			Node<T> temp = _head;
			object[] array = new object[Count];
			int counter = 0;
			while (temp != null)
			{
				array[counter] = temp.DataObject;
				counter++;
				temp = temp.Next;
			}
			return array;
		}

		public int IndexOf(T value)
		{
			int index = 0;
			Node<T> temp = _head;
			while (temp != null)
			{
				if (temp.DataObject.Equals(value))
				{
					break;
				}
				temp = temp.Next;
				index++;
			}
			if (temp == null)
			{
				index = -1;
			}
			return index;
		}

		public void Insert(int index, T value)
		{
			Node<T> newNode = new Node<T>(value);
			Node<T> temp = _head;
			Node<T> prev = null;
			int count = 0;
			if (index == Count)
			{  //insert after last element
				Add(value);
			}
			else
			{
				while (temp != null)
				{
					if (count == index)
					{
						if (temp == _head)
						{  //insert at begin
							newNode.Next = temp;
							_head = newNode;
						}
						else
						{
							prev.Next = newNode;
							newNode.Next = temp;
						}
						break;
					}
					count++;
					prev = temp;
					temp = temp.Next;
				}
			}
		}
		public void Add(T value)
		{
			Node<T> newNode = new Node<T>(value);
			//int index = 1;
			if (_head == null)
			{
				//index = 0;
				_head = newNode;
			}
			else
			{
				Node<T> temp = _head;
				while (temp.Next != null)
				{
					temp = temp.Next;
					//index++;
				}
				temp.Next = newNode;
			}
			//return index;
		}

		public bool Contains(T value)
		{
			Node<T> temp = _head;
			bool isIn = false;
			while (temp != null)
			{
				if (temp.DataObject.Equals(value))
				{
					isIn = true;
					break;
				}
				temp = temp.Next;
			}
			return isIn;
		}

		public void CopyTo(T[] array, int index)
		{
			if (array == null || index < 0 || index >= Count || Count - index > array.Length)
			{
				//throw new ArgumentNullException(nameof(array));
			}
			else
			{
				Node<T> temp = _head;
				for (int i = 0; i < index; i++)
				{
					temp = temp.Next;
				}
				int count = 0;
				while (temp != null)
				{
					array.SetValue(temp.DataObject, count);
					temp = temp.Next;
					if (temp != null)
					{
						count++;
					}
				}
			}
		}

		public bool Remove(T value)
		{
			bool check = false;
			int index = IndexOf(value);
			if (index > -1 && index < Count)
			{
				RemoveAt(index);
				check = true;
			}
			return check;
		}

		public IEnumerator<T> GetEnumerator()
		{
			return new MyListEnumerator<T>(_head);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator() ;
		}

		public int CompareTo(T obj)
		{
			if (obj == null)
			{
				throw new ArgumentException("Argument ist nicht MyList objekt");
			}
			MyList<T> other = obj as MyList<T>;
			MyListComparer<T> myListComparer = new MyListComparer<T>();
			return myListComparer.Compare(this, other);
		}

		public int CompareTo(object obj)
		{
			if (obj == null)
			{
				throw new ArgumentException("Argument ist nicht MyList objekt");
			}
			MyList<T> other = obj as MyList<T>;
			MyListComparer<T> myListComparer = new MyListComparer<T>();
			return myListComparer.Compare(this, other);
		}
	}
}
