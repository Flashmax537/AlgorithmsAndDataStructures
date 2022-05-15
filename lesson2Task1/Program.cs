namespace lesson2Task1
{
    class Program
    {
        static void Main()
        {
            var node = new DoublyLinkedList(); // Создал новый двусвязный список
            node.AddNode(1); // Добавил ноду со значением 1
            node.AddNode(2); // Добавил ноду со значением 2
            node.AddNode(4); // Добавил ноду со значением 4

            var f2 = node.FindNode(2); // Нашел ноду со значением 2
            node.AddNodeAfter(f2, 3); // Добавил ноду со значением 3, после ноды со значением 2

            var countNode = node.GetCount(); // Количество элементов в списке = 4
            var f1 = node.FindNode(1); // Нашел ноду со значением 1

            node.RemoveNode(f1); // Удалил указаный элемент
            countNode = node.GetCount(); // Количество элементов в списке = 3

            node.RemoveNode(3); // Удалил элемент по порядковому номеру
            countNode = node.GetCount(); // Количество элементов в списке = 2
        }
    }

    public class Node
    {
        public int Value { get; set; }
        public Node NextNode { get; set; }
        public Node PrevNode { get; set; }
    }

    public interface ILinkedList
    {
        /// <summary>
        /// возвращает количество элементов в списке
        /// </summary>
        /// <returns></returns>
        int GetCount();

        /// <summary>
        /// добавляет новый элемент списка
        /// </summary>
        /// <param name="value"></param>
        void AddNode(int value);

        /// <summary>
        /// добавляет новый элемент списка после определённого элемента
        /// </summary>
        /// <param name="node"></param>
        /// <param name="value"></param>
        void AddNodeAfter(Node node, int value);

        /// <summary>
        /// удаляет элемент по порядковому номеру
        /// </summary>
        /// <param name="index"></param>
        void RemoveNode(int index);

        /// <summary>
        /// удаляет указанный элемент
        /// </summary>
        /// <param name="node"></param>
        void RemoveNode(Node node);

        /// <summary>
        /// ищет элемент по его значению
        /// </summary>
        /// <param name="searchValue"></param>
        /// <returns></returns>
        Node FindNode(int searchValue);
    }

    public class DoublyLinkedList : ILinkedList
    {
        private Node head; // головной/первый элемент
        private Node tail; // последний/хвостовой элемент

        public void AddNode(int value)
        {
            Node node = new Node();
            node.Value = value;

            if (head == null)
                head = node;
            else
            {
                tail.NextNode = node;
                node.PrevNode = tail;
            }
            tail = node;
        }

        public void AddNodeAfter(Node node, int value)
        {
            Node current = head;
            while (true)
            {
                if (current == node)
                {
                    current.NextNode = new Node()
                    {
                        Value = value,
                        PrevNode = current,
                        NextNode = current.NextNode
                    };
                    current = current.NextNode;
                    current.NextNode.PrevNode = current;
                }
                if (current == tail) break;
                current = current.NextNode;
            }
        }

        public Node FindNode(int searchValue)
        {
            Node current = head;
            while (true)
            {
                if (current.Value == searchValue)
                {
                    return current;
                }
                if (current == tail) break;
                current = current.NextNode;
            }
            return null;
        }

        public int GetCount()
        {
            int count = 0;
            Node current = head;
            while (true)
            {
                count++;
                if (current == tail) break;
                current = current.NextNode;
            }
            return count;
        }

        public void RemoveNode(int index)
        {
            int count = 0;
            Node current = head;
            while (true)
            {
                count++;
                if (count == index)
                {
                    RemoveNode(current);
                    break;
                }
                if (current == tail) break;
                current = current.NextNode;
            }
        }

        public void RemoveNode(Node node)
        {
            if (node == head)
            {
                head = node.NextNode;
                head.PrevNode = null;
            }
            else if (node == tail)
            {
                tail = node.PrevNode;
                tail.NextNode = null;
            }
            else
            {
                Node next = node.NextNode;
                Node prev = node.PrevNode;
                next.PrevNode = prev;
                prev.NextNode = next;
            }
        }
    }
}