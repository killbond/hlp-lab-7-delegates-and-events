using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hlp_lab_7_delegates_and_events
{
    using DirectedGraph;
    class Program
    {
        static void Main(string[] args)
        {
            List<Node> nodes = new List<Node>();
            nodes.Add(new Node<string>("Node-0"));
            nodes.Add(new Node<string>("Node-1"));
            nodes.Add(new Node<string>("Node-2"));
            nodes.Add(new Node<string>("Node-3"));
            nodes.Add(new Node<string>("Node-4"));
            nodes.Add(new Node<string>("Node-5"));
            nodes.Add(new Node<string>("Node-6"));
            nodes.Add(new Node<string>("Node-7"));
            nodes.Add(new Node<string>("Node-8"));
            nodes.Add(new Node<string>("Node-9"));
            nodes.Add(new Node<string>("Node-10"));
            nodes.Add(new Node<string>("Node-11"));
            nodes.Add(new Node<string>("Node-12"));
            nodes.Add(new Node<string>("Node-13"));

            List<Edge> edges = new List<Edge>();
            edges.Add(new Edge(nodes[0], nodes[1]));
            edges.Add(new Edge(nodes[0], nodes[2]));
            edges.Add(new Edge(nodes[0], nodes[3]));
            edges.Add(new Edge(nodes[0], nodes[5]));
            edges.Add(new Edge(nodes[0], nodes[6]));
            edges.Add(new Edge(nodes[2], nodes[3]));
            edges.Add(new Edge(nodes[3], nodes[5]));
            edges.Add(new Edge(nodes[3], nodes[4]));
            edges.Add(new Edge(nodes[4], nodes[9]));
            edges.Add(new Edge(nodes[6], nodes[9]));
            edges.Add(new Edge(nodes[6], nodes[4]));
            edges.Add(new Edge(nodes[7], nodes[6]));
            edges.Add(new Edge(nodes[8], nodes[7]));
            edges.Add(new Edge(nodes[9], nodes[10]));
            edges.Add(new Edge(nodes[9], nodes[11]));
            edges.Add(new Edge(nodes[9], nodes[12]));
            edges.Add(new Edge(nodes[11], nodes[12]));

            Graph graph = new Graph(edges, nodes);

            List<Node> vertices = new List<Node>();


            var tInDepth = new Traversal<Stack<Node>>(graph);

            HandleStatus<Node> newVertex = delegate(object sender, Node vertex) 
            {
                Console.Out.WriteLine("New vertex handler raised at node {0}", vertex);
            };

            HandleStatus<Node> vertexInProgress = delegate(object sender, Node vertex)
            {
                Console.Out.WriteLine("Vertex in progress handler raised at node {0}", vertex);
            };

            HandleStatus<Node> completedVertex = delegate(object sender, Node vertex)
            {
                Console.Out.WriteLine("Completed vertex handler raised at node {0}", vertex);
            };

            tInDepth.NewVertex += newVertex;
            tInDepth.VertexInProgress += vertexInProgress;
            tInDepth.CompletedVertex += completedVertex;

            Console.Out.WriteLine("Beginning traversal in depth for graph:");
            tInDepth.Run();

            var tInBreadth = new Traversal<Queue<Node>>(graph);

            tInBreadth.NewVertex += newVertex;
            tInBreadth.VertexInProgress += vertexInProgress;
            tInBreadth.CompletedVertex += completedVertex;

            Console.Out.WriteLine("\nBeginning traversal in breadth for graph:");
            tInBreadth.Run();
            
            Console.In.Read();
        }
    }
}
