////////////////////////////////////////////////////////////////////////////////
//                                                                            //
//                                   graph.cs                                 //
//                                  Graph Class                               //
//             Created by: Jarett (Jay) Mirecki, February 28, 2019            //
//              Modified by: Jarett (Jay) Mirecki, March 03, 2019             //
//                                                                            //
////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JMSuite.Collections {
    class PriorityQueue<TKey, TValue> {
        SortedDictionary<TKey, List<TValue>> queue;
        public int Count { get; private set; }

        public PriorityQueue() {
            queue = new SortedDictionary<TKey, List<TValue>>();
            Count = 0;
        }
        public void Add(TKey key, TValue value) {
            List<TValue> list = new List<TValue>();
            if (queue.ContainsKey(key)) {
                list = queue[key];
                list.Add(value);
                queue[key] = list;
            }
            else {
                list.Add(value);
                queue.Add(key, list);
            }
            // queue.Add(key, list);
            Count++;
        }
        public TValue FirstValue() {
            return queue[queue.Keys.ToList()[0]].First();
        }
        public TKey FirstKey() {
            return queue.Keys.ToList()[0];
        }
        public TValue Pop() {
            if (Count == 0) return default(TValue);
            TKey key = queue.Keys.ToList()[0];
            List<TValue> list = queue[key];
            TValue value = list.First();
            if (list.Count == 1)
                queue.Remove(key);
            else {
                list.RemoveAt(0);
                // queue.Add(key, list);
                queue[key] = list;
            }
            Count--;
            return value;
        }
        public override string ToString() {
            StringBuilder output = new StringBuilder("[");
            foreach(KeyValuePair<TKey, List<TValue>> pair in queue) {
                foreach (TValue value in pair.Value)
                    output.Append("(" + pair.Key.ToString() + ", " + value.ToString() + "), ");
            }
            output.Remove(output.Length - 2, 2);
            output.Append("]");
            return output.ToString();
        }
    }
}