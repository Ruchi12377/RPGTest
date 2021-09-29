namespace src
{
    public static class EnumEx
    {
        public static string _ToString(this AccessAttribute accessAttribute)
        {
            return accessAttribute switch
            {
                AccessAttribute.Public => "public",
                AccessAttribute.Protected => "protected",
                AccessAttribute.Private => "private",
                AccessAttribute.Internal => "internal",
                AccessAttribute.ProtectedInternal => "protected internal",
                AccessAttribute.PrivateProtected => "private protected",
                _ => ""
            };
        }

        public static string _ToString(this ClassFieldAttribute classFieldAttribute)
        {
            return classFieldAttribute switch
            {
                ClassFieldAttribute.None => "",
                ClassFieldAttribute.Static => "static",
                ClassFieldAttribute.Const => "const",
                ClassFieldAttribute.Readonly => "readonly",
                ClassFieldAttribute.StaticReadOnly => "static readonly",
                _ => ""
            };
        }

        public static string _ToString(this CSIAccessAttribute csiAccessAttribute)
        {
            return csiAccessAttribute switch
            {
                CSIAccessAttribute.Public => "public",
                CSIAccessAttribute.Private => "private",
                CSIAccessAttribute.Internal => "internal",
                _ => ""
            };
        }

        public static string _ToString(this ClassDefineAttribute classDefineAttribute)
        {
            return classDefineAttribute switch
            {
                ClassDefineAttribute.None => "",
                ClassDefineAttribute.Abstract => "abstract",
                ClassDefineAttribute.Sealed => "sealed",
                ClassDefineAttribute.Static => "static",
                _ => ""
            };
        }
        
        public static string _ToString(this MethodDefineAttribute methodDefineAttribute)
        {
            return methodDefineAttribute switch
            {
                MethodDefineAttribute.None => "",
                MethodDefineAttribute.Abstract => "abstract",
                MethodDefineAttribute.Override => "override",
                MethodDefineAttribute.Static => "static",
                _ => ""
            };
        }
    }
}