namespace src
{
    public struct ClassField
    {
        public ClassFieldAccessAttribute FieldAccessAttribute;
        public ClassFieldAttribute ClassFieldAttribute;
        public string FieldType;
        public string FieldName;

        public ClassField(ClassFieldAccessAttribute fieldAccessAttribute, ClassFieldAttribute classFieldAttribute, string fieldType, string fieldName)
        {
            FieldAccessAttribute = fieldAccessAttribute;
            ClassFieldAttribute = classFieldAttribute;
            FieldType = fieldType;
            FieldName = fieldName;
        }
    }
}