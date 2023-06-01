using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Web.helpers.json;
namespace CodeSnippet.ConsoleApp
{
    public struct Surprise { public readonly int a, b, c; }
    public struct Gizmo { public readonly Surprise surprise; }
    public struct Bobble { public readonly Gizmo gizmo; }
    public struct Thing { public readonly Bobble bobble; }
    public class Gift { public readonly Thing thing; }

    public class Class5
    {
        //public void Function(Gift gift)
        //{
        //    int contrived = gift.thing.bobble.gizmo.surprise.a +
        //                    gift.thing.bobble.gizmo.surprise.b +
        //                    gift.thing.bobble.gizmo.surprise.c;
        //}
        void Function(Gift gift)
        {
            {
                //(A)  was trying to use a pointer to access the memory location, couldn't get it to work!
                //unsafe
                //{
                //    Surprise* ps = &(gift.thing.bobble.gizmo.surprise);
                //}
            }
            //(B)
            {
                int contrived = gift.Sum();
            }
            {
                int contrived = gift.thing.bobble.gizmo.surprise.Sum();
            }
        }
    }
    public static class GiftExtension
    {
        public static int Sum(this Gift gift)
        {
            int contrived = gift.thing.bobble.gizmo.surprise.a +
                                gift.thing.bobble.gizmo.surprise.b +
                                gift.thing.bobble.gizmo.surprise.c;
            return contrived;
        }
        public static int Sum(this Surprise surprise)
        {
            int contrived = surprise.a +
                                surprise.b +
                                surprise.c;
            return contrived;
        }
    }
}
