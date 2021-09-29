using System.Collections.Generic;
using System.IO;
using src;
using UnityEngine;

public class Main : MonoBehaviour
{
    private async void Start()
    {
        var target = new Class(new List<string>(), "Sample", CSIAccessAttribute.Public,
            ClassDefineAttribute.None, "SampleClass", new List<ClassField>());

        target.AddClassField(new ClassField(AccessAttribute.Public,
            ClassFieldAttribute.Const, "string", typeof(string), "aaa", "\"Sample\""));
        var data = target.Generate();

        var path = Application.dataPath + "/Test.cs";
        path = Path.GetFullPath(path);

        //書き込み
        await FileIO.Write(path, data);
    }
}
    