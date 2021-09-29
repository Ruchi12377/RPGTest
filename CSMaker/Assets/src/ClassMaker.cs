using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

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
        
        public struct Class
        {
            public IEnumerable<string> UsingTable;
            public string NameSpace;
            public CSIAccessAttribute AccessAttribute;
            public ClassDefineAttribute DefineAttribute;
            public string ClassName;
            public IEnumerable<ClassField> Fields;

            public Class(IEnumerable<string> usingTable, string nameSpace, CSIAccessAttribute accessAttribute, ClassDefineAttribute defineAttribute, string className, IEnumerable<ClassField> fields)
            {
                UsingTable = usingTable;
                NameSpace = nameSpace;
                AccessAttribute = accessAttribute;
                DefineAttribute = defineAttribute;
                ClassName = className;
                Fields = fields;
            }
        }
        
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

        public enum ClassFieldAccessAttribute
        {
            Public,
            Protected,
            Private,
            Internal,

            ProtectedInternal,
            PrivateProtected,
        }
        
        public enum ClassFieldAttribute
        {
            None,
            Static,
            Const,
            Readonly,
            StaticReadOnly
        }
        
        public enum StructFieldAccessAttribute
        {
            Public,
            Private,
            Internal,
        }
        
        //Getter Setter
        //継承
        
        //C lass
        //S truct
        //I nterface
        // ReSharper disable once InconsistentNaming
        //クラスのアクセス範囲を設定する
        public enum CSIAccessAttribute
        {
            Public,
            Private,
            Internal,
        };

        //クラスの宣言を設定する
        public enum ClassDefineAttribute
        {
            None,
            Abstract,
            Sealed,
            Static
        };
    }
}