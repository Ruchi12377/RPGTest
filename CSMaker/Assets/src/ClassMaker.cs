using System.Collections.Generic;
using System.Linq;
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
            var nameSpaceBuilder = new StringBuilder();
            var csBuilder = new StringBuilder();

            var usingTable = new List<string>();
            //NameSpace関連
            var hasNameSpace = target.NameSpace.IsNullOrEmptyOrWhiteSpace() == false;
            if (hasNameSpace)
            {
                csBuilder.AppendLine($"namespace {target.NameSpace}");
                csBuilder.AppendLine("{");
            }

            //Class定義関連
            var accessAttributeStr = target.AccessAttribute._ToString();

            var defineAttributeStr = target.DefineAttribute._ToString();
            defineAttributeStr = defineAttributeStr.IsNullOrEmptyOrWhiteSpace() ? "" : defineAttributeStr + " ";

            csBuilder.AppendLine($"{accessAttributeStr} {defineAttributeStr}class {target.ClassName}");
            csBuilder.AppendLine("{");
            
            //Field関連
            foreach (var field in target.Fields)
            {
                //using一覧に使用すると思われるusingを入れる
                usingTable.Add(field.FieldType.Namespace);
                
                var fieldAccessAttribute = field.AccessAttribute._ToString();

                var classFieldAttribute = field.ClassFieldAttribute._ToString();

                classFieldAttribute = classFieldAttribute.IsNullOrEmptyOrWhiteSpace() ? "" : classFieldAttribute + " ";

                var defaultValue = field.DefaultValue;
                if ((field.ClassFieldAttribute == ClassFieldAttribute.Const || field.ClassFieldAttribute == ClassFieldAttribute.StaticReadOnly) && defaultValue.IsNullOrEmptyOrWhiteSpace())
                {
                    Debug.LogError("フィールドはconstまたはstatic readonly キーワードがついていますが、初期値が設定されていません。");
                }

                defaultValue = defaultValue.IsNullOrEmptyOrWhiteSpace() ? "" : $" = {defaultValue}";
                
                csBuilder.AppendLine(
                    $"{fieldAccessAttribute} {classFieldAttribute}{field.FieldTypeName} {field.FieldName}{defaultValue};");
            }

            //Method関連
            
            
            //Using関連
            //フィールドとの被りもあるので、被りを消してから、最後にまとめて追加する
            usingTable.AddRange(target.UsingTable);
            foreach (var u in usingTable.Distinct())
            {
                if (u.IsNullOrEmptyOrWhiteSpace() == false)
                {
                    nameSpaceBuilder.AppendLine($"using {u};");
                }
            }
            //UsingとNameSpaceとの間の一行
            if (target.UsingTable.Any())
            {
                nameSpaceBuilder.AppendLine("");
            }

            //最後に中括弧をつける
            csBuilder.AppendLine("}");

            //NameSpaceを追加する場合
            if (hasNameSpace)
            {
                csBuilder.AppendLine("}");
            }

            return nameSpaceBuilder + csBuilder.ToString();
        }

        public static void AddClassField(this Class target, ClassField field)
        {
            target.Fields.Add(field);
        }

        //Getter Setter
        //継承
    }
}