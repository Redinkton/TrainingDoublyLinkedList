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
                Node temp = _first;
                for(int j = 0;  j < i; j++)
                {
                    temp = temp.Next;
                }
                return temp.Value;
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
            Node temp = _first;
            temp = _first;
            if(_first != null)
            {
                for(int j = 0; j < index; j++)
                {
                    temp = temp.Next;
                }
                temp.Value = value;                
            }
            else
            {
                throw new NullReferenceException();
            }
        }
        
        public void RemoveAt(int index)
        {
            Node previousElement = _first;
            Node nextElement = _first;

            if (index == 0)
            {
                _first = _first.Next;
            }
            else if (_first != null & _last != null)
            {
                //looking for the previous element
                for (int i = 0; i < index - 1; i++)
                {
                    previousElement = previousElement.Next;
                }

                //looking for the next element
                for (int i = 0; i < index + 1; i++)
                {
                    nextElement = nextElement.Next;
                }

                if (nextElement != null)
                {
                    previousElement.Next = nextElement;
                    nextElement.Prev = previousElement;
                }
                else
                {
                    previousElement.Next = null;
                }
            }
            else
            { 
                throw new NullReferenceException(); 
            }
            _count--;
        }

        public void RemoveAllThisInstances(int value)
        {
            int a = _count;
            Node node = _first;
            int modifiedIndex = 0;
            for (int i = 0; i < a; i++)
            {
                if (node.Value == value)
                {
                    RemoveAt(i-modifiedIndex);
                    modifiedIndex++;
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
