using System.Collections.Generic;
using System.IO;
using src;
using UnityEngine;

public class Main : MonoBehaviour
{
    private async void Start()
    {
        var target = new Class(new List<string>(), "Sample", CSIAccessAttribute.Public,
            ClassDefineAttribute.None, "SampleClass", new List<ClassField>(), new List<Method>());

        target.AddClassField(new ClassField(AccessAttribute.Public,
            ClassFieldAttribute.Const, "string", typeof(string), "aaa", "\"Sample\""));
        target.AddMethod(new Method(AccessAttribute.Public, MethodDefineAttribute.None, "void", typeof(Void),
            "Start", new List<MethodField>()
            {
                new MethodField("string", typeof(string), "test", "\"Default\""),
                new MethodField("string", typeof(string), "test2", ""),
                new MethodField("int", typeof(int), "test33", "0")
            }));
        var data = target.Generate();

        var path = Application.dataPath + "/Test.cs";
        path = Path.GetFullPath(path);

        //書き込み
        await FileIO.Write(path, data);
    }
}