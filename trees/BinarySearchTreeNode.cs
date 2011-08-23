namespace omarkhd.DataStructures
{
	public class BinarySearchTreeNode<T>
	{
		public BinarySearchTreeNode<T> Parent;
		public BinarySearchTreeNode<T> RightChild;
		public BinarySearchTreeNode<T> LeftChild;
		public T Item;

		public BinarySearchTreeNode(T item)
		{
			this.Item = item;
		}

		public BinarySearchTreeNode<T> Maximum
		{
			get
			{
				BinarySearchTreeNode<T> basenode = this;
				while(basenode.RightChild != null)
					basenode = basenode.RightChild;
				return basenode;
			}
		}

		public BinarySearchTreeNode<T> Minimum
		{
			get
			{
				BinarySearchTreeNode<T> basenode = this;
				while(basenode.LeftChild != null)
					basenode = basenode.LeftChild;
				return basenode;
			}
		}

		public BinarySearchTreeNode<T> Successor
		{
			get
			{
				if(this.RightChild == null)
				{
					BinarySearchTreeNode<T> basenode;
					for
					(
						basenode = this;
						basenode.Parent != null && basenode.Parent.LeftChild != basenode;
						basenode = basenode.Parent
					);

					return basenode.Parent;
				}

				else
					return this.RightChild.Minimum;
			}
		}

		public BinarySearchTreeNode<T> Predecessor
		{
			get
			{
				if(this.LeftChild == null)
				{
					BinarySearchTreeNode<T> basenode = null;
					for
					(
						basenode = this;
						basenode.Parent != null && basenode.Parent.RightChild != basenode;
						basenode = basenode.Parent
					);

					return basenode.Parent;
				}

				else
					return this.LeftChild.Maximum;
			}
		}

		public void Clear()
		{
			this.Parent = null;
			this.RightChild = null;
			this.LeftChild = null;
			this.Item = default(T);
		}
	}
}
