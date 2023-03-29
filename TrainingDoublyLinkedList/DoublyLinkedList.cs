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
                _first = newElement;
            }
            else if (nextElement == null)
            {
                _last = newElement;
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
            Node removeToElement = _first;

            if (_first != null & _last != null)
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
            Node node = _first;

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
            _first = null;
            _last = null;
        }
    }
}
