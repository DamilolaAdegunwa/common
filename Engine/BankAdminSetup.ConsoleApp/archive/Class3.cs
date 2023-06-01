//using System;
//using System.Collections.Generic;
//using System.Diagnostics.CodeAnalysis;
//using System.Text;
//namespace NS1
//{
//    public class GenericArray<T> where T : IEnumerable<string>
//    {
//        public void Summarize(T input) { }
//    }
//    public interface ITest<T> { }

//    internal class Test1 : ITest<int> { }
//    internal sealed class Test2 : ITest<int> { }

//    internal class C<T>
//    {
//        public void F(ITest<T> x)
//        {
//            if (x is Test1 z) { }
//            if (x is Test2 y) { }
//        }
//    }
//}
//namespace CodeSnippet.ConsoleApp
//{
//    class Class3
//    {
//        void somemethod()
//        {
//            YForm form = new YForm();
//            //if (form is YWindowForm<MyDBObject> yw)
//            if (form is YWindowFormBase yw)
//            {
//                yw.XFormBeforeSave += (x) =>
//                {
//                    //I need to attach to this event
//                    //Do some work here
//                };
//            };
//        }
//        public static void Main()
//        {
//            new Class3().somemethod();
//            _ = "";
//        }

//    }
//    public class YForm : YWindowForm<MyDBObject> { }
//    public class YWindowForm<T> : YWindowFormBase where T : DBBaseObject
//    {
//        public event Action<T> XFormBeforeSave;
//    }
//    public class YWindowFormBase<T>
//    {
//        public Action<object> XFormBeforeSave { get; set; }
//    }
//    public class YWindowFormBase
//    {
//    }
//    public class MyDBObject : DBBaseObject { }

//    public class DBBaseObject
//    {
//    }
//}
//namespace test
//{

//    public class BetterInputSelect<TItem> : InputBase<TItem>
//    {

//        //public int x =  new csharp9().GoodEnough(null);
//        /// <summary>
//        /// ///////////////////////////////
//        /// </summary>
//        [Parameter]
//        public IEnumerable<TItem> Data { get; set; } = new List<TItem>();

//        protected override void BuildRenderTree(RenderTreeBuilder builder)
//        {
//            builder.OpenElement(0, "select");
//            builder.AddMultipleAttributes(1, AdditionalAttributes);
//            builder.AddAttribute(2, "class", CssClass);
//            builder.AddAttribute(3, "value", BindConverter.FormatValue(CurrentValueAsString));
//            builder.AddAttribute(4, "onchange", EventCallback.Factory.CreateBinder<string>(
//              this, value => CurrentValueAsString = value, CurrentValueAsString!, null));

//            foreach (var item in this.Data)
//            {
//                builder.OpenElement(5, "option");
//                builder.AddAttribute(6, "value", item!.ToString());
//                builder.AddContent(7, this.FindDisplayName(item));
//                builder.CloseElement();
//            }

//            builder.CloseElement();
//        }

//        protected override bool TryParseValueFromString(string? value, out TItem result, out string validationErrorMessage)
//        {
//            // Check for enums first.
//            if (typeof(TItem).IsEnum && BindConverter.TryConvertTo(value, CultureInfo.CurrentCulture, out TItem? parsedValue))
//            {
//                result = parsedValue!;
//                validationErrorMessage = null!;
//                return true;
//            }

//            // Other types here
//            // ...

//            result = default!;
//            validationErrorMessage = $"The {FieldIdentifier.FieldName} field is not valid.";
//            return false;
//        }

//        private string FindDisplayName(TItem value)
//        {
//            return value switch
//            {
//                //null => string.Empty,
//                null => throw new Exception("fuck! what is this?!"),
//                Enum @enum => @enum.GetHashCode().ToString(),
//                _ => value.ToString() ?? string.Empty
//            };
//        }
//    }
//}
