using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// ReSharper disable once InconsistentNaming
public struct SimpleLL
{
    private static readonly Dictionary<string, Action<List<object>>> DefaultCommands = new Dictionary<string, Action<List<object>>>()
    {
        {"log", obj => Debug.Log(obj[0])}
    };
    
    public void Execute(string code)
    {
        var lines = code.Split('\n');
        for (var i = 0; i < lines.Length; i++)
        {
            var line = lines[i];
            var blocks = line.Split(' ').ToList();
            for (var j = 0; j < blocks.Count; j++)
            {
                var e = blocks[i];
                if (string.IsNullOrEmpty(e) || string.IsNullOrWhiteSpace(e))
                {
                    blocks.RemoveAt(i);
                    continue;
                }

                if (e == "set")
                {
                    
                }
            }
        }
    }
}
