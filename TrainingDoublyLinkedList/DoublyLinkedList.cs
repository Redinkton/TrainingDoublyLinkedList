namespace TrainingDoublyLinkedList
{
    public class DoublyLinkedList
    {
        private Node _first;
        private Node _last;

        private int _count;
        public int Count => _count;

        public int this[int i]
        {
            get
            {
                if (_first != null & i < _count)
                {
                    Node temp = _first;
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
            _first = null;
            _last = null;
            _count = 0;
        }

        public DoublyLinkedList(int[] i)
        {
            Node temp = _first;
            for (int j = 0; j < i.Length; j++)
            {
                Add(i[j]);
            }
        }

        public void Add(int value)
        {
            Node node = new Node(value);

            if(_first == null)
            {
                _first = node;
            }
            else
            {
                _last.Next = node;
                node.Prev = _last;
            }
            _last = node;
            _count++;
        }

        public void AddAtIndex(int index, int value)
        {
            Node newElement = new Node(value);
            Node previousElement = _first;
            Node nextElement;
            if (_first != null)
            {
                for(int j = 0; j < index-1; j++)
                {
                    previousElement = previousElement.Next;
                }
                // it looks ugly
                nextElement = previousElement.Next;
                nextElement = nextElement.Next;
                nextElement.Prev = newElement;
                previousElement.Next = newElement;
                newElement.Prev = previousElement;
                newElement.Next = nextElement;
            }
            else
            {
                throw new NullReferenceException();
            }
        }
        
        public void RemoveAt(int index)
        {
            Node removeToElement = _first;

            if (_first != null & _last != null)
            {
                // looking for the element to be removed
                for (int i = 0; i < index ; i++)
                {
                    removeToElement = removeToElement.Next;
                }
                ChangeReferences(removeToElement.Prev, removeToElement.Next);
            }
            else
            { 
                throw new NullReferenceException(); 
            }
        }

        private void ChangeReferences(Node previousElement, Node nextElement)
        {
            if (previousElement == null)
            {
                _first = _first.Next;
                _first.Prev = null;
            }
            else if (nextElement == null)
            {
                _last = _last.Prev;
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
            int myCount = _count;
            Node node = _first;
            for (int i = 0; i < myCount; i++)
            {
                if (node.Value == value)
                {
                    ChangeReferences(node.Prev, node.Next);
                }
                node = node.Next;
            }
        }

        public void Clear()
        {
            _count = 0;
            _first = null;
            _last = null;
        }
    }
}
