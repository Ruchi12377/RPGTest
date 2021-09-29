using System;

namespace src
{
    public struct MethodField
    {
        public string FieldTypeName;
        public Type FieldType;
        public string FieldName;
        public string DefaultValue;

        public MethodField(string fieldTypeName, Type fieldType, string fieldName, string defaultValue)
        {
            FieldTypeName = fieldTypeName;
            FieldType = fieldType;
            FieldName = fieldName;
            DefaultValue = defaultValue;
        }
    }
}