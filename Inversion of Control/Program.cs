using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Practices.ObjectBuilder2;
using Microsoft.Practices.Unity;

namespace InversionOfControl
{
    //------------------------------------------------------------------
    public class Desk
    {
        //------------------------------------------------------------------
        public Desk (int id, string name)
        {
            Console.WriteLine ("{0}: {1}", id, name);
        }


    }

    //------------------------------------------------------------------
    public static class Level
    {
        public static string PropertyName<T>(this object obj, Expression<Func<T>> p)
        {
            return (p.Body as MemberExpression).Member.Name;
        }
    }


    //------------------------------------------------------------------
    public class MyProgram
    {

        private static void Main ()
        {
            var container = new UnityContainer ();


//            var constructor = new InjectionConstructor (new InjectionParameter (typeof (int)), new InjectionParameter (typeof (string)));
//            container.RegisterType (typeof (Desk), constructor);
            //            container.RegisterType<Desk> (new InjectionConstructor (10, "sis"));


            var activityParameter = new ParameterOverride ("id", 15);
            var gameParameter = new ParameterOverride ("name", "torsisojs");
            var clone = container.Resolve<Desk> (activityParameter, gameParameter);


        }



        //------------------------------------------------------------------
    }
}