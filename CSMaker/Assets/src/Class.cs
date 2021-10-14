using System;
using System.Collections.Generic;

namespace src
{
    [Serializable]
    public struct Class
    {
        public List<string> UsingTable;
        public string NameSpace;
        public CSIAccessAttribute AccessAttribute;
        public ClassDefineAttribute DefineAttribute;
        public string ClassName;
        public Type InheritanceClass;
        public List<Type> InheritanceInterfaces;
        public List<ClassField> Fields;
        public List<Method> Methods;

        public Class(List<string> usingTable, string nameSpace, CSIAccessAttribute accessAttribute, ClassDefineAttribute defineAttribute, string className, Type inheritanceClass, List<Type> inheritanceInterfaces, List<ClassField> fields, List<Method> methods)
        {
            UsingTable = usingTable;
            NameSpace = nameSpace;
            AccessAttribute = accessAttribute;
            DefineAttribute = defineAttribute;
            ClassName = className;
            InheritanceClass = inheritanceClass;
            InheritanceInterfaces = inheritanceInterfaces;
            Fields = fields;
            Methods = methods;
        }
        
        public Class(string nameSpace, CSIAccessAttribute accessAttribute, ClassDefineAttribute defineAttribute, string className, Type inheritanceClass = null)
        {
            UsingTable = new List<string>();
            NameSpace = nameSpace;
            AccessAttribute = accessAttribute;
            DefineAttribute = defineAttribute;
            ClassName = className;
            InheritanceClass = inheritanceClass;
            InheritanceInterfaces = new List<Type>();
            Fields = new List<ClassField>();
            Methods = new List<Method>();
        }
    }
}