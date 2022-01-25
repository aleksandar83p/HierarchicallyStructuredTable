using System;
using System.Collections.Generic;
using System.Linq;

namespace HierarchicallyStructuredTable
{
    class Program
    {
        static List<Node> _Nodes = new List<Node>();

        static void Main(string[] args)
        {
            Run();
        }

        static void Run()
        {
            Console.WriteLine("Starting table");            
            _Nodes.Add(new Node { Id = 1, Name = "a", Parent = null });
            _Nodes.Add(new Node { Id = 2, Name = "b", Parent = 1 });
            _Nodes.Add(new Node { Id = 3, Name = "c", Parent = 1 });
            _Nodes.Add(new Node { Id = 4, Name = "d", Parent = 2 });
            _Nodes.Add(new Node { Id = 5, Name = "e", Parent = 3 });
            _Nodes.Add(new Node { Id = 6, Name = "f", Parent = 3 });
            _Nodes.Add(new Node { Id = 7, Name = "g", Parent = 2 });
            _Nodes.Add(new Node { Id = 8, Name = "i", Parent = 4 });
            _Nodes.Add(new Node { Id = 9, Name = "j", Parent = 8 });

            Console.WriteLine("Name -- ID -- Parent");

            foreach (var item in _Nodes)
            {
                Console.WriteLine(item.ToString());
            }

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Result table");
            Console.WriteLine("Name -- LFT --- RGT");
            CreateResultNodes();
            foreach (var item in _Nodes)
            {

                Console.WriteLine(item.GetLeftAndRight());
            }
        }

        static IEnumerable<Node> GetChildNodes(Node node)
        {
            return _Nodes.Where(x => x.Parent == node.Id);
        }

        static IEnumerable<Node> GetFirstNodes()
        {
            return _Nodes.Where(x => x.Parent == null);
        }

        static void ProcessNode(Node node, NodeDataHolder nodeDataHolder)
        {
            node.Left = nodeDataHolder.IncrementAndGet();
            foreach (var childNode in GetChildNodes(node))
            {
                ProcessNode(childNode, nodeDataHolder);
            }
            node.Right = nodeDataHolder.IncrementAndGet();
        }

        static void CreateResultNodes()
        {
            foreach (var parentNode in GetFirstNodes())
            {
                var nodeDataHolder = new NodeDataHolder();
                ProcessNode(parentNode, nodeDataHolder);
            }
        }
    }
}
