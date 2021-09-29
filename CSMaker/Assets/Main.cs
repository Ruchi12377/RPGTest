using System.IO;
using src;
using UnityEngine;

public class Main : MonoBehaviour
{
    private async void Start()
    {
        var target = new ClassMaker.Class(new[] { "System.Collections.Generic" }, "Sample", ClassMaker.CSIAccessAttribute.Public,
            ClassMaker.ClassDefineAttribute.None, "SampleClass",
            new[]
            {
                new ClassMaker.ClassField(ClassMaker.ClassFieldAccessAttribute.Public,
                    ClassMaker.ClassFieldAttribute.Static, "List<int>", "aaa")
            });
        var data = target.Generate();

        var path = Application.dataPath + "/Test.cs";
        path = Path.GetFullPath(path);

        //書き込み
        await FileIO.Write(path, data);
    }
}
    