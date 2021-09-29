using System.Text;

namespace src
{
    public static class ClassMaker
    {
        //C lass
        //S truct
        //I nterface
        //クラスを生成する関数
        public static string Generate(this Class target)
        {
            //ここから本番のコード
            //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
            
            var csBuilder = new StringBuilder();

            //Using関連
            foreach (var u in target.UsingTable)
            {
                if (u.IsNullOrEmptyOrWhiteSpace() == false)
                {
                    csBuilder.AppendLine($"using {u};");
                }
            }
            //UsingとNameSpaceとの間の一行
            csBuilder.AppendLine("");

            //NameSpace関連
            var hasNameSpace = target.NameSpace.IsNullOrEmptyOrWhiteSpace() == false;
            if (hasNameSpace)
            {
                csBuilder.AppendLine($"namespace {target.NameSpace}");
                csBuilder.AppendLine("{");
            }

            //Class定義関連
            var accessAttributeStr = target.AccessAttribute switch
            {
                CSIAccessAttribute.Public => "public",
                CSIAccessAttribute.Private => "private",
                CSIAccessAttribute.Internal => "internal",
                _ => ""
            };
            
            var defineAttributeStr = target.DefineAttribute switch
            {
                ClassDefineAttribute.None => "",
                ClassDefineAttribute.Abstract => "abstract",
                ClassDefineAttribute.Sealed => "sealed",
                ClassDefineAttribute.Static => "static",
                _ => ""
            };
            defineAttributeStr = defineAttributeStr.IsNullOrEmptyOrWhiteSpace() ? "" : defineAttributeStr + " ";

            csBuilder.AppendLine($"{accessAttributeStr} {defineAttributeStr}class {target.ClassName}");
            csBuilder.AppendLine("{");
            
            //Field関連
            foreach (var field in target.Fields)
            {
                var fieldAccessAttribute = field.FieldAccessAttribute switch
                {
                    ClassFieldAccessAttribute.Public => "public",
                    ClassFieldAccessAttribute.Protected => "protected",
                    ClassFieldAccessAttribute.Private => "private",
                    ClassFieldAccessAttribute.Internal => "internal",
                    ClassFieldAccessAttribute.ProtectedInternal => "protected internal",
                    ClassFieldAccessAttribute.PrivateProtected => "private protected",
                    _ => ""
                };
                
                var classFieldAttribute = field.ClassFieldAttribute switch
                {
                    ClassFieldAttribute.None => "",
                    ClassFieldAttribute.Static => "static",
                    ClassFieldAttribute.Const => "const",
                    ClassFieldAttribute.Readonly => "readonly",
                    ClassFieldAttribute.StaticReadOnly => "static readonly",
                    _ => ""
                };
                
                classFieldAttribute = classFieldAttribute.IsNullOrEmptyOrWhiteSpace() ? "" : classFieldAttribute + " ";

                csBuilder.AppendLine(
                    $"{fieldAccessAttribute} {classFieldAttribute}{field.FieldType} {field.FieldName};");
            }

            //最後に中括弧をつける
            csBuilder.AppendLine("}");

            //NameSpaceを追加する場合
            if (hasNameSpace)
            {
                csBuilder.AppendLine("}");
            }

            //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
            return csBuilder.ToString();
        }

        public static void AddClassField(this Class target, ClassField field)
        {
            target.Fields.Add(field);
        }

        //Getter Setter
        //継承
    }
}