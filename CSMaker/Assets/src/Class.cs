using System;
using System.Collections.Generic;

namespace src
{
    [Serializable]
    public struct Class
    {
        public IEnumerable<string> UsingTable;
        public string NameSpace;
        public CSIAccessAttribute AccessAttribute;
        public ClassDefineAttribute DefineAttribute;
        public string ClassName;
        public List<ClassField> Fields;
        public List<Method> Methods;

        public Class(IEnumerable<string> usingTable, string nameSpace, CSIAccessAttribute accessAttribute, ClassDefineAttribute defineAttribute, string className, List<ClassField> fields, List<Method> methods)
        {
            UsingTable = usingTable;
            NameSpace = nameSpace;
            AccessAttribute = accessAttribute;
            DefineAttribute = defineAttribute;
            ClassName = className;
            Fields = fields;
            Methods = methods;
        }
    }
}