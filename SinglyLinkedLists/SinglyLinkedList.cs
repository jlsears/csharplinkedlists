using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace SinglyLinkedLists
{
    public class SinglyLinkedList
    {
        private SinglyLinkedListNode first_node;
        public SinglyLinkedList()
        {
            // NOTE: This constructor isn't necessary, once you've implemented the constructor below.
        }

        // READ: http://msdn.microsoft.com/en-us/library/aa691335(v=vs.71).aspx
        public SinglyLinkedList(params object[] values)
        {
            for (int i = 0; i < values.Length; i++)
            {
                this.AddLast(values[i].ToString());
            }
            
        }


        private void IndexOf(SinglyLinkedListNode newNode)
        {
            throw new NotImplementedException();
        }



        // READ: http://msdn.microsoft.com/en-us/library/6x16t2tx.aspx
        public string this[int i]
        {
            get { return this.ElementAt(i); }
            set {
                var node = this.first_node;
                var newNode = new SinglyLinkedListNode(value);

                if (i == 0)
                {
                    var grabNext = node.Next;
                    first_node = newNode;
                    newNode.Next = grabNext;
                    return;
                } 

                var beforeIt = NodeAt(i - 1);

                if (NodeAt(i).IsLast())
                {
                    beforeIt.Next = newNode;
                    return;
                }

                var afterIt = beforeIt.Next.Next;

                beforeIt.Next = newNode;
                newNode.Next = afterIt;
            }
        }


        public override string ToString()
        {
            StringBuilder output = new StringBuilder();

            var node = this.first_node;

            var opening = "{";
            //var ending = "}";
            var space = " ";
            var quote = "\"";
            var comma = "," + space;

            output.Append(opening).Append(space);

            while (node != null && !node.IsLast())
            {
                output.Append(quote).Append(node.Value).Append(quote).Append(comma);
                node = node.Next;
            }

            if (node != null)
            {
                output.Append(quote).Append(node.Value).Append(quote).Append(space);
            }
            output.Append("}");
            return output.ToString();

        }


        public void AddAfter(string existingValue, string value)
        {
            var node = this.first_node;
            var newNode = new SinglyLinkedListNode(value);

            // To handle existingValue scenarios
            while (existingValue != null)
            {
                if (node.Value == existingValue)
                {
                    if (node.Next == null)
                    {
                        node.Next = newNode;
                        return;
                    }
                    var capturePointer = node.Next;
                    node.Next = newNode;
                    newNode.Next = capturePointer;
                    return; // Not so much returning a thing as completing a modification
                }

                // If there's an exisingValue but it can't be found in this list
                if (node.Next == null)
                {
                    throw new ArgumentException();
                }
                // Let us move the while loop along to the next node in line
                else
                {
                    node = node.Next; 
                }
            }

            // To handle scenarios where an exisingValue has not been provided
            while (node != null)
            {
                var lastNode = LastNode();
                lastNode.Next = newNode;
                return;
            }
            throw new ArgumentException(); // Essentially, if existingValue is not found

        }


        public void AddFirst(string value)
        {
            if (this.First() == null)
            {
                first_node = new SinglyLinkedListNode(value);
            } else
            {
                var workingList = new SinglyLinkedList();
                workingList.AddFirst(value);
                for (var i = 0; i < this.Count(); i++)
                {
                    workingList.AddLast(this.ElementAt(i));
                }

                first_node = new SinglyLinkedListNode(workingList.First());
                for (var j = 1; j < workingList.Count(); j++)
                {
                    this.AddLast(workingList.ElementAt(j));
                }
            }
        }


        public void AddLast(string value)
        {
            if (this.First() == null)
            {
                first_node = new SinglyLinkedListNode(value);
            } else
            {
                var node = this.first_node;
                while(!node.IsLast()) 
                {
                    node = node.Next;
                }
                node.Next = new SinglyLinkedListNode(value);
            }
        }

        // NOTE: There is more than one way to accomplish this.  One is O(n).  The other is O(1).
        public int Count()
        {
            //If the list is empty
            //this.Count() == 0
            if (this.First() == null)
            {
                return 0;
            } else
            {
                int length = 1;
                var node = this.first_node;
                // Complexity is O(n) i.e., length of list determines how long to calculate number
                while (node.Next != null)
                {
                    length++;
                    node = node.Next;
                }
                return length;
            }

            //Provide a second implementation
        }

        public string ElementAt(int index)
        {
            return NodeAt(index).Value;
        }

        private SinglyLinkedListNode NodeAt(int index)
        {
            if (this.First() == null)
            {
                throw new ArgumentOutOfRangeException();
            }
            else
            {

                var node = this.first_node;

                for (var i = 0; i <= index; i++)
                {
                    if (i == index) //meaning it's our first node
                    {
                        break;
                    }
                    node = node.Next;
                }
                return node;
            }
        }

        public string First()
        {
            if (this.first_node == null)
            {
                return null;
            } else
            {
                return this.first_node.Value;
            }

            //return this.first_node ? null : this.first_node.Value;
 
        }

        public int IndexOf(string value)
        {
            var counter = 0;

            if (this.First() == null)
            {
                return -1;
            }
            else
            {
                var node = this.first_node;

                while (node != null)
                {
                    if (node.Value == value)
                    {
                        return counter;
                    }
                    node = node.Next;
                    counter++;
                }
                return -1;
            }
        }

        public bool IsSorted()
        {
            var numbItems = this.Count();

            if (numbItems == 1)
            {
                return true;
            }

            for (int i = 0; i < numbItems - 1; i++)
            {
                if (this[i].CompareTo(this[i+1]) > 0)
                {
                    return false;
                }
            }
            return true;
        }

        // HINT 1: You can extract this functionality (finding the last item in the list) from a method you've already written!
        // HINT 2: I suggest writing a private helper method LastNode()
        // HINT 3: If you highlight code and right click, you can use the refactor menu to extract a method for you...

        public string Last()
        {

            return LastNode().Value;
        }


        private SinglyLinkedListNode LastNode()
        {
            var node = this.first_node;
            if (node == null)
            {
                return null;
            }
            else
            {
                while (!node.IsLast())
                {
                    node = node.Next;
                }
                return node;
            }
        }



        //Re-solve

        // Step 1: Do I need to loop???
        // Step 2: If yes, do I already have an example of how?? (Pretty paramount)
        // Step 3: How can I modify the previous examples?
        // Step 4: Write what I think works.
        // Step 5: Rebuild/Re-run tests
        // Step 6: Rinse and repeat


        public void Remove(string value)
        {
            var node = this.first_node;
            var newNode = new SinglyLinkedListNode(value);
            var priorNode = this.first_node;

            // To handle various node location scenarios
            while (value != null)
            {
                // Look, we've found our node
                if (node.Value == value)
                {
                    // If the node we seek is the first node
                    if (node == this.first_node)
                    {
                        var herePointer = node.Next;
                        first_node = herePointer;
                    }

                    // If the node we seek ends up being the last node
                    if (node.IsLast())
                    {
                        var workingList = new SinglyLinkedList();
                        var notYou = this.Count() - 1;
                        //workingList.AddFirst(value);
                        for (var i = 0; i < notYou; i++)
                        {
                            workingList.AddLast(this.ElementAt(i));
                        }

                        first_node = new SinglyLinkedListNode(workingList.First());
                        for (var j = 1; j < workingList.Count(); j++)
                        {
                            this.AddLast(workingList.ElementAt(j));
                            return;
                        }
                    }
                    // For all nodes in between
                    var capturePointer = node.Next;
                    priorNode.Next = capturePointer;
                    return; 
                }

                // If the value can't be found in this list
                if (node.Next == null)
                {
                    return;
                }
                // Let us move the while loop along to the next node in line
                else
                {                   
                    priorNode = node;
                    node = node.Next;
                }
            }

            throw new ArgumentException(); // Essentially, if value is not found
        }

        public void Sort()
        {
            var theCount = this.Count();

            if (this.Count() == 1)
            {
                return;
            }

            var i = 0;
            var j = i + 1;
            var swapped = false;
            
            while (!this.IsSorted())
            {
                swapped = false;

                while (j < theCount -1)
                {
                    var firstItem = NodeAt(i);
                    var priorItem = NodeAt(i-1);
                    var secondItem = NodeAt(j);
                    var upcomingItem = NodeAt(j+1);

                    if (firstItem.CompareTo(secondItem) > 0)
                    {
                        priorItem.Next = secondItem;
                        secondItem.Next = firstItem;
                        firstItem.Next = upcomingItem;

                        swapped = true;
                    }
                    if (i == 0)
                    {
                        first_node = secondItem;
                        secondItem.Next = firstItem;
                    }

                    else if (j == theCount - 1)
                    {
                        i = 0;

                    }
                    else if (this.IsSorted()) {

                        break;

                    } else
                    {
                        i++;
                    }

                    j = i + 1;
                }
                if (swapped == false)
                {
                    break;
                }
            }
            return;

        }

        public string[] ToArray()

        {
            var output = new List<string>();

            var node = this.first_node;

            while (node != null)
            {
                output.Add(node.Value);
                node = node.Next;
            }
            return output.ToArray();
        }

    }
}
