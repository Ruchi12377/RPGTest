using System.Collections.Generic;

namespace src
{
    public struct Class
    {
        public IEnumerable<string> UsingTable;
        public string NameSpace;
        public CSIAccessAttribute AccessAttribute;
        public ClassDefineAttribute DefineAttribute;
        public string ClassName;
        public List<ClassField> Fields;

        public Class(IEnumerable<string> usingTable, string nameSpace, CSIAccessAttribute accessAttribute, ClassDefineAttribute defineAttribute, string className, List<ClassField> fields)
        {
            UsingTable = usingTable;
            NameSpace = nameSpace;
            AccessAttribute = accessAttribute;
            DefineAttribute = defineAttribute;
            ClassName = className;
            Fields = fields;
        }
    }
}