namespace TrainingDoublyLinkedList
{
    public class DoublyLinkedList
    {
        public Node First { get; set; }
        public Node Last { get; set; }

        private int _count;
        public int Count => _count;

        private int this[int i]
        {
            get
            {
                if (First != null & i < _count)
                {
                    Node temp = First;
                    for (int j = 0; j < i; j++)
                    {
                        temp = temp.Next;
                    }
                    return temp.Value;
                }
                else
                {
                    throw new NullReferenceException();
                }
            }
        }

        public DoublyLinkedList()
        {
            First = null;
            Last = null;
            _count = 0;
        }

        public DoublyLinkedList(int[] i)
        {
            Node temp = First;
            for (int j = 0; j < i.Length; j++)
            {
                Add(i[j]);
            }
        }

        public void Add(int value)
        {
            Node node = new Node(value);

            if(First == null)
            {
                First = node;
            }
            else
            {
                Last.Next = node;
                node.Prev = Last;
            }
            Last = node;
            _count++;
        }

        public void AddAtIndex(int index, int value)
        {
            Node newElement = new Node(value);
            Node previousElement = First;

            if (index == 0)
            {
                AddReferences(newElement, previousElement.Prev, previousElement.Next);
            }
            else if (index < _count)
            {
                for (int j = 0; j < index ; j++)
                {
                    previousElement = previousElement.Next;
                }
                AddReferences(newElement, previousElement.Prev, previousElement.Next);
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        private void AddReferences(Node newElement ,Node previousElement, Node nextElement)
        {
            if (previousElement == null)
            {
                newElement.Next = nextElement;
                First = newElement;
            }
            else if (nextElement == null)
            {
                Last = newElement;
                newElement.Prev = previousElement;
                previousElement.Next = newElement;
                
            }
            else if (previousElement != null & nextElement != null)
            {
                newElement.Next = nextElement;
                newElement.Prev = previousElement;
                previousElement.Next = newElement;
                nextElement.Prev = newElement;
            }
        }
        
        public void RemoveAt(int index)
        {
            Node removeToElement = First;

            if (First != null && Last != null)
            {
                // looking for the element to be removed
                for (int i = 0; i < index ; i++)
                {
                    removeToElement = removeToElement.Next;
                }
                RemoveReferences(removeToElement.Prev, removeToElement.Next);
            }
            else
            { 
                throw new NullReferenceException(); 
            }
        }

        private void RemoveReferences(Node previousElement, Node nextElement)
        {
            if (previousElement == null)
            {
                First = First.Next;
                First.Prev = null;
            }
            else if (nextElement == null)
            {
                previousElement.Next = null;
                Last = Last.Prev;
            }
            else if (nextElement != null & previousElement != null)
            {
                previousElement.Next = nextElement;
                nextElement.Prev = previousElement;
            }
            _count--;
        }

        public void RemoveAllThisInstances(int value)
        {
            Node node = First;

            while (node != null)
            {
                if (node.Value == value)
                {
                    RemoveReferences(node.Prev, node.Next);
                }
                node = node.Next;
            }
        }

        public void Clear()
        {
            _count = 0;
            First = null;
            Last = null;
        }
    }
}
