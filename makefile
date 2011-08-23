LIST_DIR := lists
QUEUES_DIR := queues
STACKS_DIR := stacks
TREES_DIR := trees

omarkhd.DataStructures.dll:
	gmcs $(LIST_DIR)/IList.cs $(LIST_DIR)/ArrayList.cs $(LIST_DIR)/LinkedList.cs $(LIST_DIR)/LinkedListNode.cs $(QUEUES_DIR)/IQueue.cs $(QUEUES_DIR)/Queue.cs $(QUEUES_DIR)/CircularQueue.cs $(STACKS_DIR)/IStack.cs $(STACKS_DIR)/Stack.cs $(TREES_DIR)/BinarySearchTreeNode.cs $(TREES_DIR)/BinarySearchTree.cs -target:library -out:omarkhd.DataStructures.dll

clean:
	-rm omarkhd.DataStructures.dll
