using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hlp_lab_7_delegates_and_events.DirectedGraph
{
    public abstract class Node
    {
        public Graph Graph { get; internal set; }

        public List<Edge> InboundEdges
        {
            get
            {
                return Graph.Edges.Where(e => e.To == this).ToList();
            }
        }

        public List<Edge> OutboundEdges
        {
            get
            {
                return Graph.Edges.Where(e => e.From == this).ToList();
            }
        }
    }

    public class Node<T> : Node
    {
        public T Payload { get; private set; }

        public Node(T payload)
        {
            this.Payload = payload;
        }

        public override string ToString()
        {
            return this.Payload.ToString();
        }
    }
}
