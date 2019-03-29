using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hlp_lab_7_delegates_and_events
{
    using DirectedGraph;

    delegate void HandleStatus<T>(object sender, T item);

    class Traversal<T> where T : IСontainer<Node>, new()
    {
        private Graph graph;

        private T strategy;

        private HashSet<Node> visited;

        private HashSet<Node> beginning;

        private HashSet<Node> completed;

        public HandleStatus<Node> NewVertex;

        public HandleStatus<Node> VertexInProgress;

        public HandleStatus<Node> CompletedVertex;

        public Traversal(Graph graph)
        {
            this.graph = graph;            
            this.strategy = new T();
            this.visited = new HashSet<Node>();
            this.beginning = new HashSet<Node>();
            this.completed = new HashSet<Node>();
        }

        public void Run()
        {
            Node cursor;

            if (0 == graph.Roots.Count())
            {
                cursor = graph.Nodes.First();
                strategy.Add(cursor);
                raiseNewEvent(cursor);
            }
            else
            {
                foreach (Node root in graph.Roots)
                {
                    strategy.Add(root);
                    raiseNewEvent(root);
                }
            }

            while (0 != strategy.Count()) 
            {
                cursor = strategy.Remove();
                raiseProgressEvent(cursor);  
                foreach (Edge item in cursor.OutboundEdges)
                {
                    if (!visited.Contains(item.To))
                    {
                        strategy.Add(item.To);
                        raiseNewEvent(item.To);
                    }
                }
                raiseCompletedEvent(cursor);
            }

            clear();
        }

        private void riseEvent(HashSet<Node> memory, HandleStatus<Node> callback, Node node)
        {
            if (!memory.Contains(node))
            {
                callback(this, node);
                memory.Add(node);
            }
        }

        private void raiseCompletedEvent(Node node)
        {
            riseEvent(completed, CompletedVertex, node);
        }

        private void raiseNewEvent(Node node)
        {
            riseEvent(beginning, NewVertex, node);
        }

        private void raiseProgressEvent(Node node)
        {
            riseEvent(visited, VertexInProgress, node);
        }

        private void clear()
        {
            visited.Clear();
            beginning.Clear();
            completed.Clear();
            strategy.Clear();
        }
    }
}
