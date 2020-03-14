using System;
using System.Collections.Generic;
using System.Text;

namespace AoC.Y2017.Days
{
    internal class Node
    {
        public int Id { get; set; }
        public List<Node> ConnectedNodes { get; set; }

        public Node(int id)
        {
            Id = id;
            ConnectedNodes = new List<Node>();
        }

        public void CreateConnection(Node connection)
        {
            if (!ConnectedNodes.Contains(connection))
            {
                ConnectedNodes.Add(connection);
            }
        }
    }
}
