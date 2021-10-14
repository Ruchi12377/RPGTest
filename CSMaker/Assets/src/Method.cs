using System;
using System.Collections.Generic;

namespace src
{
    [Serializable]
    public struct Method
    {
        public AccessAttribute AccessAttribute;
        public MethodDefineAttribute MethodDefineAttribute;
        public string MethodTypeName;
        public Type MethodType;
        public string MethodName;
        public List<MethodField> MethodField;


        public Method(AccessAttribute accessAttribute, MethodDefineAttribute methodDefineAttribute, string methodTypeName, Type methodType, string methodName, List<MethodField> methodField)
        {
            AccessAttribute = accessAttribute;
            MethodDefineAttribute = methodDefineAttribute;
            MethodTypeName = methodTypeName;
            MethodType = methodType;
            MethodName = methodName;
            MethodField = methodField;
        }
    }
}