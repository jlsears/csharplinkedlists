﻿using System;
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

        // READ: http://msdn.microsoft.com/en-us/library/6x16t2tx.aspx
        public string this[int i]
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
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

            while (node != null)
            {
                if (node.Value == existingValue)
                {
                    var capturePointer = node.Next;
                    node.Next = newNode;
                    newNode.Next = capturePointer;
                    return; // Not so much returning a thing as completing a modification
                }

                else
                {
                    var lastNode = LastNode();
                    lastNode.Next = newNode;
                    return;
                }

                node = node.Next; // Propelling the while loop onto each next node in line

            }
             throw new ArgumentException(); // Essentially, if existingValue is not found    
        }


        //public void AddAfterLastItem(string value)
        //{
        //    var newNode = new SinglyLinkedListNode(value);
        //    var lastNode = LastNode();
        //    lastNode.Next = newNode;
        //    return;
        //}


        public void AddFirst(string value)
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
            if (this.First() == null)
            {
                throw new ArgumentOutOfRangeException();
            } else
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
                return node.Value; //getting string for your node
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
            throw new NotImplementedException();
        }

        public bool IsSorted()
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public void Sort()
        {
            throw new NotImplementedException();
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
