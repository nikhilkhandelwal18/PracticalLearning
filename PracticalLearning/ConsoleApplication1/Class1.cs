using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    #region MyRegion
    class Class1
    {
        static void Main(string[] args)
        {
            Bar.DoSomething();
            Console.WriteLine();
            Bar.DoSomething();
            //Foo.Baz();

            Console.ReadLine();
        }
    }
    public abstract class Foo
    {
        static Foo()
        {
            Console.Write("4");
        }

        protected internal static void Baz()
        {
            // I don't do anything but am called in inherited classes' 
            // constructors to call the Foo constructor
            Console.Write("Baz");
        }
    }

    public class Bar : Foo
    {
        static Bar()
        {
            Foo.Baz();
            Console.Write("2");
        }

        public static void DoSomething()
        {
            Console.Write("DoSomething");
            /*...*/
        }
    }

    #endregion


    class Class2
    {

        static void Main(string[] args)
        {
            C c = new ConsoleApplication1.C();
            c.Method1();

            A a = new ConsoleApplication1.C();
            a.Method1();


            Console.ReadLine();
        }
    }

    public abstract class A
    {
        //public virtual void Method1()
        public virtual void Method1()
        {
            Console.WriteLine("Class A Method1");
        }

    }

    public class B : A
    {
        public override void Method1()
        {

            Console.WriteLine("Class B Method1");
        }
    }

    public class C : B
    {
        public override void Method1()
        {
            base.Method1();

            Console.WriteLine("Class C Method1");
        }
    }

}
