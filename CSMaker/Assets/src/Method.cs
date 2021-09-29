using System;
using System.Collections.Generic;

namespace src
{
    public struct Method
    {
        public AccessAttribute AccessAttribute;
        public MethodDefineAttribute MethodDefineAttribute;
        public string MethodTypeName;
        public Type MethodType;
        public string MethodName;
        public IEnumerable<MethodField> MethodField;


        public Method(AccessAttribute accessAttribute, MethodDefineAttribute methodDefineAttribute, string methodTypeName, Type methodType, string methodName, IEnumerable<MethodField> methodField)
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