////////////////////////////////////////////////////////////////////////////////
//                                                                            //
//                                   graph.cs                                 //
//                                  Graph Class                               //
//             Created by: Jarett (Jay) Mirecki, February 28, 2019            //
//              Modified by: Jarett (Jay) Mirecki, March 02, 2019             //
//                                                                            //
////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;

namespace JMSuite.Collections {
    // using Pair = KeyValuePair<TKey, Element>;
    public class Graph<TKey, TValue> {
        private IDictionary<TKey, Element> adjList;
        private struct Element { public TValue Item; 
                                 public Edges Edges; 
                                 bool Visited;
                                 TKey Parent;
                                 public Element(TValue i, Edges e ) {
                                     Item = i;
                                     Edges = e;
                                     Visited = false;
                                     Parent = default(TKey); }
                                 public void MarkUnvisited() {
                                     Visited = false;
                                     Parent = default(TKey); }
                                 public void MarkVisited(TKey parent) {
                                     Visited = true;
                                     Parent = parent; }
                                 public bool GetVisited() {
                                     return Visited; } }
        private struct Edges { public TKey[] Neighbors; public int[] Weights;
                               public Edges(TKey[] ns, int[] ws) {
                                   Neighbors = ns;
                                   Weights = ws; } }
        public Graph() {
            adjList = new Dictionary<TKey, Element>();
        }
        public void Add(TKey key, TValue value) {
            Add(key, value, null, null);
        }
        public void Add(TKey key, TValue value, TKey[] neighbors) {
            Add(key, value, neighbors, null);
        }
        public void Add(TKey key, TValue value, 
                        TKey[] neighbors, int[] weights) {
            if (weights == null && neighbors != null)
                weights = Enumerable.Repeat(1, neighbors.Length).ToArray();
            Edges curEdge = new Edges(neighbors, weights);
            Element curElem = new Element(value, curEdge);
            if (adjList.ContainsKey(key))
                adjList[key] = curElem;
            else
                adjList.Add(key, curElem);
        }
        public bool TryFind(TKey key, out TValue value) {
            Element elem;
            if (adjList.TryGetValue(key, out elem)) {
                value = elem.Item;
                return true;
            } else {
                value = default(TValue);
                return false;
            }
        }
        public TValue Find(TKey key) {
            TValue value;
            TryFind(key, out value);
            return value;
        }
        public bool Exists(TKey key) {
            TValue value;
            return TryFind(key, out value);
        }
        public bool TryEdges(TKey key, out TKey[] neighbors, out int[] edges) {
            Element elem;
            if (adjList.TryGetValue(key, out elem)) {
                neighbors = elem.Edges.Neighbors;
                edges = elem.Edges.Weights;
                return true;
            } else {
                neighbors = default(TKey[]);
                edges = default(int[]);
                return false;
            }
        }
        public bool TryNeighbors(TKey key, out TKey[] neighbors) {
            int[] edges;
            neighbors = default(TKey[]);
            return TryEdges(key, out neighbors, out edges);
        }
        public TKey[] Neighbors(TKey key) {
            TKey[] neighbors;
            TryNeighbors(key, out neighbors);
            return neighbors;
        }
        public bool TryDistanceTo(TKey start, TKey end, out int distance) {
            distance = default(int);
            PriorityQueue<int, TKey> queue = new PriorityQueue<int, TKey>();
            if(!Exists(start) || !Exists(end)) return false;

            MarkAllNodesUnvisited();
            MarkVisited(start, default(TKey), true);
            queue.Add(0, start);

            for (int j = 0; j < 10; j++) {
                // Console.WriteLine("here");
                if (queue.Count == 0)
                    break;
                int curDist = queue.FirstKey();
                TKey cur = queue.FirstValue();
                if (cur.Equals(end)) {
                    distance = curDist;
                    return true;
                }
                queue.Pop();

                TKey[] neighbors;
                int[] weights;
                TryEdges(cur, out neighbors, out weights);
                for (int i = 0; i < neighbors.Length; i++) {
                    // Console.WriteLine("Current, Neighbor, Weight: " + cur.ToString() + neighbors[i].ToString() + weights[i].ToString());
                    if (!GetVisited(neighbors[i])) {
                        MarkVisited(neighbors[i], cur, true);
                        queue.Add(curDist + weights[i], neighbors[i]);
                        // Console.WriteLine(queue.ToString());
                    }
                }
            }

            return true;
        }

        public int DistanceTo(TKey start, TKey end) {
            int distance;
            TryDistanceTo(start, end, out distance);
            return distance;
        }
        private void MarkAllNodesUnvisited() {
            foreach (TKey key in adjList.Keys.ToList()) {
                MarkVisited(key, default(TKey), false);
            }
        }
        private void MarkVisited(TKey key, TKey parent, bool visited) {
            Element elem;
            adjList.TryGetValue(key, out elem);
            if (visited)
                elem.MarkVisited(parent);
            else
                elem.MarkUnvisited();
            adjList[key] = elem;
        }
        private bool GetVisited(TKey key) {
            Element elem;
            adjList.TryGetValue(key, out elem);
            return elem.GetVisited();
        }
    }
}