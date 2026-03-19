using Godot;
using System;
using System.Diagnostics;

namespace GodotLibs
{
    public class NodeHelper
    {
        public static T GetNodeByType<T>(Node parentNode) where T : Node
        {
            foreach(var node in parentNode.GetChildren())
                if (node is T typedNode)
                    return typedNode;
            throw new Exception($"Node of type {typeof(T).Name} not found in {parentNode.Name}.");
        }

        public static T GetNodeByType<T>(Node parentNode, string nodeName) where T : Node
        {
            foreach (var node in parentNode.GetChildren())
                if (node is T typedNode && node.Name == nodeName)
                    return typedNode;
            throw new Exception($"Node of type {typeof(T).Name} not found in {parentNode.Name}.");
        }
    }
}
