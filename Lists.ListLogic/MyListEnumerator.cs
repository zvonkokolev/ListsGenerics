using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Lists.ListLogic
{
	public class MyListEnumerator<T> : IEnumerator<T>
	{
		//fields
		private Node<T> _pos;
		private Node<T> _node;

		//constructor
		public MyListEnumerator(Node<T> node)
		{
			_node = node;
			Reset();
		}

		object IEnumerator.Current
		{
			get
			{
				return Current;
			}
		}

		//properties

		public T Current
		{
			get
			{
				if (_pos == null)
				{
					throw new InvalidOperationException();
				}
				else
				{
					return _pos.DataObject;
				}
			}
		}

		public void Dispose()
		{
			//throw new NotImplementedException();
		}

		public bool MoveNext()
		{
			_pos = _node;
			if(_pos != null)
			{
				_node = _node.Next;
			}
			return _pos != null;
		}

		public void Reset()
		{
			_pos = null;
		}
	}
}
