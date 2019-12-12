using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AoC.Y2018.Days
{
    internal class Node
    {
        public int HeaderCount { get; } = 2;
        public int ChildCount { get; } = 0;
        public int MetaDataCount { get; } = 0;
        public List<int> RawNodeData { get; } = new List<int>();
        public List<int> MetaData { get; } = new List<int>();
        public List<Node> ChildNodes { get; } = new List<Node>();

        public Node(List<int> rawNodeData)
        {
            RawNodeData = rawNodeData;
            ChildCount = rawNodeData[0];
            MetaDataCount = rawNodeData[1];
        }

        public int Init()
        {
            var dataToProcess = RawNodeData.GetRange(2, RawNodeData.Count - 2);
            var processedItems = 2;
            var processedNodeData = 0;

            if (ChildCount > 0)
            {
                processedNodeData = CreateChildNodes(dataToProcess);
            }

            var metaDataRange = dataToProcess.GetRange(processedNodeData, MetaDataCount);
            MetaData.AddRange(metaDataRange);
            processedItems += processedNodeData + metaDataRange.Count;

            return processedItems;
        }

        /// <summary>
        /// Iterate through the childnodes as defined in the header
        /// </summary>
        /// <param name="dataToProcess"></param>
        /// <returns>The amount of processed items from the dataset</returns>
        private int CreateChildNodes(List<int> dataToProcess)
        {
            var processedItemsCount = 0;

            for (int i = 0; i < ChildCount; i++)
            {
                processedItemsCount += CreateChildNode(dataToProcess, processedItemsCount);
            }

            return processedItemsCount;
        }

        /// <summary>
        /// Creates the actual childnode, recursively calling the process
        /// </summary>
        /// <param name="dataToProcess"></param>
        /// <param name="startPoint"></param>
        /// <returns></returns>
        private int CreateChildNode(List<int> dataToProcess, int startPoint)
        {
            var childNode = new Node(dataToProcess.GetRange(startPoint, dataToProcess.Count - startPoint));
            var processedItemsCount = childNode.Init();
            ChildNodes.Add(childNode);
            return processedItemsCount;
        }

        public int GetMetaDataSum()
        {
            var sum = MetaData.Sum();

            foreach (var node in ChildNodes)
            {
                sum += node.GetMetaDataSum();
            }

            return sum;
        }

        public int GetRootNodeValue()
        {
            if (ChildNodes.Any())
            {
                var sum = 0;

                foreach (var item in MetaData)
                {
                    var element = ChildNodes.ElementAtOrDefault(item - 1);

                    if (element != null)
                    {
                        sum += element.GetRootNodeValue();
                    }
                }

                return sum;
            }
            else
            {
                return MetaData.Sum();
            }
        }
    }
}
