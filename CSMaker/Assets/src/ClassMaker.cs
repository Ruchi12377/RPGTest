using System;
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
                if ((field.ClassFieldAttribute == ClassFieldAttribute.Const ||
                     field.ClassFieldAttribute == ClassFieldAttribute.StaticReadOnly) &&
                    defaultValue.IsNullOrEmptyOrWhiteSpace())
                {
                    Debug.LogError("フィールドはconstまたはstatic readonly キーワードがついていますが、初期値が設定されていません。");
                }

                defaultValue = defaultValue.IsNullOrEmptyOrWhiteSpace() ? "" : $" = {defaultValue}";

                csBuilder.AppendLine(
                    $"{fieldAccessAttribute} {classFieldAttribute}{field.FieldTypeName} {field.FieldName}{defaultValue};");
            }

            //Method関連
            foreach (var method in target.Methods)
            {
                //using一覧に使用すると思われるusingを入れる
                if (method.MethodType != typeof(void))
                {
                    usingTable.Add(method.MethodType.Namespace);
                }

                var defineAttribute = method.MethodDefineAttribute._ToString();
                defineAttribute = defineAttribute.IsNullOrEmptyOrWhiteSpace() ? "" : defineAttribute + " ";

                //引数
                var methodParams = new StringBuilder();

                var fields = method.MethodField.OrderBy(x => x.DefaultValue.IsNullOrEmptyOrWhiteSpace() == false)
                    .ToList();
                for (var i = 0; i < fields.Count; i++)
                {
                    var field = fields[i];
                    
                    //using一覧に使用すると思われるusingを入れる
                    usingTable.Add(field.FieldType.Namespace);

                    var defaultValue = field.DefaultValue;
                    defaultValue = defaultValue.IsNullOrEmptyOrWhiteSpace() ? "" : $" = {defaultValue}";

                    var comma = fields.Count > 0 && i < fields.Count - 1 ? ", " : "";
                    methodParams.Append($"{field.FieldTypeName} {field.FieldName}{defaultValue}{comma}");
                }

                csBuilder.AppendLine(
                    $"{method.AccessAttribute._ToString()} {defineAttribute}{method.MethodTypeName} {method.MethodName}({methodParams})");
                csBuilder.AppendLine("{");
                csBuilder.AppendLine("");
                csBuilder.AppendLine("}");
            }

            //Using関連
            //フィールドとの被りもあるので、被りを消してから、最後にまとめて追加する
            usingTable.AddRange(target.UsingTable);
            usingTable = usingTable.Distinct().ToList();
            foreach (var u in usingTable.Where(u => u.IsNullOrEmptyOrWhiteSpace() == false))
            {
                nameSpaceBuilder.AppendLine($"using {u};");
            }

            //NameSpaceが一つでも存在するなら、
            //UsingとNameSpaceとの間の一行を開ける
            if (usingTable.Count > 0)
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

        public static void AddInheritanceInterface(this Class target, Type @interface)
        {
            target.InheritanceInterfaces.Add(@interface);
        }

        public static void AddClassField(this Class target, ClassField field)
        {
            target.Fields.Add(field);
        }

        public static void AddMethodField(this Class target, Method method)
        {
            target.Methods.Add(method);
        }

        //Getter Setter
        //継承
    }
}