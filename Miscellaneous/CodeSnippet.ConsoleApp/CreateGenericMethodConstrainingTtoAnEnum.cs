using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace CodeSnippet.ConsoleApp
{
    public class CreateGenericMethodConstrainingTtoAnEnum
    {
        public static T GetEnumFromString<T>(string value, T defaultValue) where T : Enum
        {
            if (string.IsNullOrEmpty(value)) return defaultValue;
            foreach (T item in Enum.GetValues(typeof(T)))
            {
                if (item.ToString().ToLower().Equals(value.Trim().ToLower())) return item;
            }
            return defaultValue;
        }
        public static class EnumUtils
        {
            public static T ParseEnum<T>(string value, T defaultValue) where T : struct, IConvertible
            {
                if (!typeof(T).IsEnum) throw new ArgumentException("T must be an enumerated type");
                if (string.IsNullOrEmpty(value)) return defaultValue;

                foreach (T item in Enum.GetValues(typeof(T)))
                {
                    if (item.ToString().ToLower().Equals(value.Trim().ToLower())) return item;
                }
                return defaultValue;
            }
        }
        public T GetEnumFromString<T>(string value) where T : struct, IConvertible, IComparable, IFormattable
        {
            if (!typeof(T).IsEnum)
            {
                throw new ArgumentException("T must be an enumerated type");
            }

            //...
            return default;
        }
        public static Dictionary<int, string> EnumNamedValues<T>() where T : System.Enum
        {
            var result = new Dictionary<int, string>();
            var values = Enum.GetValues(typeof(T));

            foreach (int item in values)
                result.Add(item, Enum.GetName(typeof(T), item));
            return result;
        }
        #region MSIL Code Alert!!
        //        // license: http://www.apache.org/licenses/LICENSE-2.0.html
        //.assembly MyThing { }
        //.class public abstract sealed MyThing.Thing
        //       extends[mscorlib]System.Object
        //{
        //  .method public static !!T GetEnumFromString<valuetype .ctor ([mscorlib] System.Enum) T>(string strValue,
        //                                                                                          !!T defaultValue) cil managed
        //        {
        //    .maxstack  2
        //    .locals init ([0] !!T temp,
        //                  [1] !!T return_value,
        //                  [2] class [mscorlib]
        //        System.Collections.IEnumerator enumerator,
        //                  [3] class [mscorlib]
        //        System.IDisposable disposer)
        //    // if(string.IsNullOrEmpty(strValue)) return defaultValue;
        //    ldarg strValue
        //    call bool[mscorlib] System.String::IsNullOrEmpty(string)
        //    brfalse.s HASVALUE
        //    br RETURNDEF         // return default it empty

        //    // foreach (T item in Enum.GetValues(typeof(T)))
        //        HASVALUE:
        //    // Enum.GetValues.GetEnumerator()
        //    ldtoken !!T
        //    call class [mscorlib]
        //        System.Type[mscorlib] System.Type::GetTypeFromHandle(valuetype[mscorlib] System.RuntimeTypeHandle)
        //    call class [mscorlib] System.Array[mscorlib] System.Enum::GetValues(class [mscorlib] System.Type)
        //    callvirt instance class [mscorlib]
        //        System.Collections.IEnumerator[mscorlib] System.Array::GetEnumerator()
        //    stloc enumerator
        //    .try
        //    {
        //        CONDITION:
        //            ldloc enumerator
        //        callvirt instance bool[mscorlib] System.Collections.IEnumerator::MoveNext()
        //        brfalse.s LEAVE


        //      STATEMENTS:
        //            // T item = (T)Enumerator.Current
        //            ldloc enumerator
        //        callvirt instance object[mscorlib] System.Collections.IEnumerator::get_Current()
        //        unbox.any!!T
        //       stloc temp
        //        ldloca.s temp
        //        constrained. !!T

        //        // if (item.ToString().ToLower().Equals(value.Trim().ToLower())) return item;
        //        callvirt instance string[mscorlib] System.Object::ToString()
        //        callvirt instance string[mscorlib] System.String::ToLower()
        //        ldarg strValue
        //        callvirt instance string[mscorlib] System.String::Trim()
        //        callvirt instance string[mscorlib] System.String::ToLower()
        //        callvirt instance bool[mscorlib] System.String::Equals(string)
        //        brfalse.s CONDITION
        //        ldloc temp
        //        stloc return_value
        //        leave.s RETURNVAL


        //      LEAVE:
        //            leave.s RETURNDEF
        //    }
        //    finally
        //    {
        //        // ArrayList's Enumerator may or may not inherit from IDisposable
        //        ldloc enumerator
        //        isinst[mscorlib] System.IDisposable
        //        stloc.s disposer
        //        ldloc.s disposer
        //        ldnull
        //        ceq
        //        brtrue.s LEAVEFINALLY
        //        ldloc.s disposer
        //        callvirt instance void[mscorlib] System.IDisposable::Dispose()
        //      LEAVEFINALLY:
        //        endfinally
        //    }

        //    RETURNDEF:
        //    ldarg defaultValue
        //    stloc return_value


        //  RETURNVAL:
        //    ldloc return_value
        //    ret
        //}
        //} 
        #endregion
        T GetEnumFromString2<T>(string valueString, T defaultValue) where T : Enum
        {
            return default;
        }
        public abstract class EnumClassUtils<TClass> where TClass : class
        {

            public static TEnum Parse<TEnum>(string value)
            where TEnum : struct, TClass
            {
                return (TEnum)Enum.Parse(typeof(TEnum), value);
            }

        }

        public class EnumUtils2 : EnumClassUtils<Enum>
        {
        }

    }

    public static class XmlEnumExtension
    {
        public static string ReadXmlEnumAttribute(this Enum value)
        {
            if (value == null) throw new ArgumentNullException("value");
            var attribs = (XmlEnumAttribute[])value.GetType().GetField(value.ToString()).GetCustomAttributes(typeof(XmlEnumAttribute), true);
            return attribs.Length > 0 ? attribs[0].Name : value.ToString();
        }

        public static T ParseXmlEnumAttribute<T>(this string str)
        {
            foreach (T item in Enum.GetValues(typeof(T)))
            {
                var attribs = (XmlEnumAttribute[])item.GetType().GetField(item.ToString()).GetCustomAttributes(typeof(XmlEnumAttribute), true);
                if (attribs.Length > 0 && attribs[0].Name.Equals(str)) return item;
            }
            return (T)Enum.Parse(typeof(T), str, true);
        }
    }
    public enum MyEnum
    {
        [XmlEnum("First Value")]
        One,
        [XmlEnum("Second Value")]
        Two,
        Three
    }
    public class TestEnum
    {
        public static void MainTest()
        {
            // Parsing from XmlEnum attribute
            var str = "Second Value";
            var me = str.ParseXmlEnumAttribute<MyEnum>();
            System.Console.WriteLine(me.ReadXmlEnumAttribute());
            // Parsing without XmlEnum
            str = "Three";
            me = str.ParseXmlEnumAttribute<MyEnum>();
            System.Console.WriteLine(me.ReadXmlEnumAttribute());
            me = MyEnum.One;
            System.Console.WriteLine(me.ReadXmlEnumAttribute());
        }
    }
}
