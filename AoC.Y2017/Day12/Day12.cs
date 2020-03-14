using AoC.Helpers.Days;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC.Y2017.Days
{
    public class Day12 : BaseDay
    {
        public Day12() : base(2017, 12)
        {
        }

        public Day12(IEnumerable<string> inputLines) : base(2017, 12, inputLines)
        {
        }

        protected override IConvertible PartOne()
        {
            var networks = MapNetworks(inputLines);
            var zeroNetwork = networks.Single(network => network.Any(node => node.Id == 0));
            return zeroNetwork.Count;
        }

        protected override IConvertible PartTwo()
        {
            var networks = MapNetworks(inputLines);
            return networks.Count;
        }

        private static List<List<Node>> MapNetworks(IEnumerable<string> lines)
        {
            var unconnectedNodes = ParseInput(lines);
            var nodes = CreateConnectedNodes(unconnectedNodes);
            return CreateNetworks(nodes);
        }

        private static List<List<Node>> CreateNetworks(List<Node> nodes)
        {
            var networks = new List<List<Node>>();

            foreach (var node in nodes)
            {
                if (networks.Any(network => network.Contains(node)))
                {
                    continue;
                }

                var network = new List<Node>();

                var nodeQueue = new Queue<Node>();
                nodeQueue.Enqueue(node);

                while (nodeQueue.Any())
                {
                    var currentNode = nodeQueue.Dequeue();

                    if (network.Contains(currentNode)) { continue; }

                    network.Add(currentNode);

                    foreach (var connectedNode in currentNode.ConnectedNodes)
                    {
                        nodeQueue.Enqueue(connectedNode);
                    }
                }

                networks.Add(network);
            }

            return networks;
        }

        private static List<Node> CreateConnectedNodes(List<(int node, List<int> connections)> unconnectedNodes)
        {
            var nodes = new List<Node>();

            foreach (var (unconnectedNode, connections) in unconnectedNodes)
            {
                var node = nodes.SingleOrDefault(n => n.Id == unconnectedNode);

                if (node == null)
                {
                    node = new Node(unconnectedNode);
                    nodes.Add(node);
                }

                foreach (var connection in connections)
                {
                    var connectionNode = nodes.SingleOrDefault(n => n.Id == connection);

                    if (connectionNode == null)
                    {
                        connectionNode = new Node(connection);
                        nodes.Add(connectionNode);
                    }

                    node.CreateConnection(connectionNode);
                    connectionNode.CreateConnection(node);
                }
            }

            return nodes;
        }

        private static List<(int node, List<int> connections)> ParseInput(IEnumerable<string> inputLines)
        {
            var nodes = new List<(int, List<int>)>();

            foreach (var l in inputLines)
            {
                var items = l.Replace(",", "").Split(' ');
                nodes.Add((int.Parse(items[0]), items.Skip(2).Select(i => int.Parse(i)).ToList()));
            }

            return nodes;
        }
    }
}
