////////////////////////////////////////////////////////////////////////////////
//                                                                            //
//                                   graph.cs                                 //
//                                  Graph Class                               //
//             Created by: Jarett (Jay) Mirecki, February 28, 2019            //
//              Modified by: Jarett (Jay) Mirecki, March 1, 2019              //
//                                                                            //
////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;

namespace GSWS {
    public class Graph<TKey, TValue> {
        private IDictionary<TKey, Element> adjList;
        private struct Element { public TValue Item; public TKey[] Neighbors;
                                 public Element(TValue i, TKey[] n) {
                                     Item = i;
                                     Neighbors = n; } }
        public Graph() {
            adjList = new Dictionary<TKey, Element>();
        }
        public void Add(TKey key, TValue value) {
            Element cur = new Element(value, null);
            adjList.Add(key, cur);
        }
        public void Add(TKey key, TValue value, TKey[] neighbors) {
            Element cur = new Element(value, neighbors);
            adjList.Add(key, cur);
        }
        public bool Find(TKey key, out TValue value) {
            Element elem;
            if (adjList.TryGetValue(key, out elem)) {
                value = elem.Item;
                return true;
            } else {
                value = default(TValue);
                return false;
            }
        }
        public bool Neighbors(TKey key, out TKey[] neighbors) {
            Element elem;
            if (adjList.TryGetValue(key, out elem)) {
                neighbors = elem.Neighbors;
                return true;
            } else {
                neighbors = default(TKey[]);
                return false;
            }
        }
    }
}