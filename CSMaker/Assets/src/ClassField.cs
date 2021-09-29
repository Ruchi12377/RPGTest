using System;

namespace src
{
    public struct ClassField
    {
        public AccessAttribute AccessAttribute;
        public ClassFieldAttribute ClassFieldAttribute;
        public string FieldTypeName;
        public Type FieldType;
        public string FieldName;
        public string DefaultValue;

        public ClassField(AccessAttribute accessAttribute, ClassFieldAttribute classFieldAttribute, string fieldTypeName, Type fieldType, string fieldName, string defaultValue)
        {
            AccessAttribute = accessAttribute;
            ClassFieldAttribute = classFieldAttribute;
            FieldTypeName = fieldTypeName;
            FieldType = fieldType;
            FieldName = fieldName;
            DefaultValue = defaultValue;
        }
    }
}