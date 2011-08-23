using System;

namespace omarkhd.DataStructures
{
	public class BinarySearchTree<T> where T : IComparable<T>
	{
		private BinarySearchTreeNode<T> Root;
		public int Length { get; private set; }
		public bool Empty { get { return this.Length == 0; } }

		public BinarySearchTree()
		{
			this.Clear();
		}

		public void Insert(T item)
		{
			if(this.Root == null)
				this.Root = new BinarySearchTreeNode<T>(item);
			
			else
			{
				BinarySearchTreeNode<T> basenode = this.Root;
				BinarySearchTreeNode<T> parent = null;
				int? cmp = null;

				while(basenode != null)
				{
					parent = basenode;
					if((cmp = item.CompareTo(basenode.Item)) >= 0)
						basenode = basenode.RightChild;
					else
						basenode = basenode.LeftChild;
				}

				BinarySearchTreeNode<T> node = new BinarySearchTreeNode<T>(item);
				node.Parent = parent;
				if(cmp >= 0)
					parent.RightChild = node;
				else
					parent.LeftChild = node;
				Console.Out.WriteLine("inserting below {0}", parent.Item);
			}

			this.Length += 1;
		}

		private BinarySearchTreeNode<T> GetNode(T item) // this return the first node found
		{
			BinarySearchTreeNode<T> basenode;
			int cmp;
			for
			(
				basenode = this.Root;
				basenode != null && (cmp = item.CompareTo(basenode.Item)) != 0;
				basenode = (cmp > 0 ? basenode.RightChild : basenode.LeftChild)
			);

			return basenode;
		}

		public T Search(T item)
		{
			return this.GetNode(item).Item;
		}

		public bool Contains(T item)
		{
			return this.GetNode(item) != null;
		}

		public bool Remove(T item)
		{
			BinarySearchTreeNode<T> node;
			if((node = this.GetNode(item)) == null)
				return false;

			this.RemoveNode(node);
			return true;
		}

		private void RemoveNode(BinarySearchTreeNode<T> node)
		{
			if(node.RightChild == null && node.LeftChild == null)
			{
				if(node.Parent.RightChild == node)
					node.Parent.RightChild = null;
				else
					node.Parent.LeftChild = null;
			}

			else if(node.RightChild != null && node.LeftChild != null)
			{
				BinarySearchTreeNode<T> successor = node.Successor;
				T auxiliar = node.Item;
				node.Item = successor.Item;
				successor.Item = auxiliar;
				this.RemoveNode(successor);
			}

			else //then it has only one child
			{
				BinarySearchTreeNode<T> child = (node.RightChild == null ? node.LeftChild : node.RightChild);
				if(node.Parent.RightChild == node)
					node.Parent.RightChild = child;
				else
					node.Parent.LeftChild = child;
				child.Parent = node.Parent;
			}
		}

		public void Clear()
		{
			this.Root = null;
			this.Length = 0;
		}

		public IList<T> TraverseToList(TraversalType type)
		{
			LinkedList<T> list = new LinkedList<T>(); //change this to a user defined type of list
			if(this.Empty) // if the tree is empty, return an empty list
				return list;

			switch(type)
			{
				case TraversalType.Inorder:
					this.ToInorder(this.Root, list);
					break;

				case TraversalType.Postorder:
					this.ToPostorder(this.Root, list);
					break;

				case TraversalType.Preorder:
					this.ToPreorder(this.Root, list);
					break;

				case TraversalType.BreadthFirst:
					this.ToBreadthFirst(this.Root, list);
					break;
			}

			return list;
		}

		private void ToInorder(BinarySearchTreeNode<T> node, IList<T> list)
		{
			if(node.LeftChild != null)
				this.ToInorder(node.LeftChild, list);
			list.Add(node.Item);
			if(node.RightChild != null)
				this.ToInorder(node.RightChild, list);
		}

		private void ToPreorder(BinarySearchTreeNode<T> node, IList<T> list)
		{
			list.Add(node.Item);
			if(node.LeftChild != null)
				this.ToPreorder(node.LeftChild, list);
			if(node.RightChild != null)
				this.ToPreorder(node.RightChild, list);
		}

		private void ToPostorder(BinarySearchTreeNode<T> node, IList<T> list)
		{
			if(node.LeftChild != null)
				this.ToPostorder(node.LeftChild, list);
			if(node.RightChild != null)
				this.ToPostorder(node.RightChild, list);
			list.Add(node.Item);
		}

		private void ToBreadthFirst(BinarySearchTreeNode<T> node, IList<T> list)
		{
			IQueue<BinarySearchTreeNode<T>> queue = new Queue<BinarySearchTreeNode<T>>();
			queue.Enqueue(node);
			BinarySearchTreeNode<T> current;

			while(!queue.Empty)
			{
				current = queue.Dequeue();
				list.Add(current.Item);
				if(current.LeftChild != null)
					queue.Enqueue(current.LeftChild);
				if(current.RightChild != null)
					queue.Enqueue(current.RightChild);
			}
		}
	}

	public enum TraversalType
	{
		Inorder,
		Postorder,
		Preorder,
		BreadthFirst
	}
}
