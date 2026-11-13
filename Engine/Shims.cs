// Collection + MIDP shims for the port (PORTING.md §1/§4).
using System;
using System.Collections.Generic;

namespace MiamiNights
{
    // java.lang.Runnable
    public interface Runnable { void Run(); }

    // java.util.Vector (Java-style API, generic)
    public sealed class Vector<T>
    {
        private readonly List<T> items = new List<T>();
        public void addElement(T v) => items.Add(v);
        public int size() => items.Count;
        public T elementAt(int i) => items[i];
        public void setElementAt(T v, int i) => items[i] = v;
        public void removeElementAt(int i) => items.RemoveAt(i);
        public void removeAllElements() => items.Clear();
        public bool removeElement(T v) => items.Remove(v);
        public bool isEmpty() => items.Count == 0;
        public T firstElement() => items[0];
        public T lastElement() => items[items.Count - 1];
        public bool contains(T v) => items.Contains(v);
        public void insertElementAt(T v, int i) => items.Insert(i, v);
        public System.Collections.IEnumerator elements() => items.GetEnumerator();
    }

    // java.util.Hashtable (string keys/values as used by c.java)
    public sealed class Hashtable
    {
        private readonly Dictionary<string, string> map = new Dictionary<string, string>();
        public void put(string k, string v) { if (k != null) map[k] = v; }
        public string get(string k) => map.TryGetValue(k, out var v) ? v : null;
        public bool containsKey(string k) => map.ContainsKey(k);
        public string remove(string k) { map.TryGetValue(k, out var v); map.Remove(k); return v; }
        public int size() => map.Count;
        public void clear() => map.Clear();
    }

    // javax.microedition.lcdui.Command
    public sealed class Command
    {
        public string Label;
        public int CommandType;
        public int Priority;
        public Command(string label, int commandType, int priority)
        {
            Label = label; CommandType = commandType; Priority = priority;
        }
    }

    // javax.microedition.lcdui.CommandListener
    public interface CommandListener
    {
        void CommandAction(Command c, Displayable d);
    }

    // javax.microedition.io.ConnectionNotFoundException
    public sealed class ConnectionNotFoundException : Exception
    {
        public ConnectionNotFoundException() { }
        public ConnectionNotFoundException(string m) : base(m) { }
    }
}
