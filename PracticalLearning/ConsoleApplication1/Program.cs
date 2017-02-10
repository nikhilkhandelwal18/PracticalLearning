using ConsoleApplication1.Polymorphism;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        private static readonly log4net.ILog log =
log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        static String location;
        static DateTime time;
        static void Main(string[] args)
        {
            #region MyRegion
            //int a = 29;
            //a--;
            //a -= ++a;
            //Console.WriteLine("The value of a is: {0}", a);
            //Console.ReadLine();


            //int a = 29;
            //a--;
            //++a;
            //a -= a;
            //Console.WriteLine("The value of a is: {0}", a);
            //Console.ReadLine();

            #endregion

            #region RegexPatternCheck
            //string NumberPattern = "(?<MASTER>[^!]*)!(?<TYPE>[^!]*)!(?<NUMBER>[^!]*)!(?<DATE>[^!]*)!(?<USER>[^!]*)!(?<SIZE>[0-9^!]*)!(?<SERVERID>[^!]*)!(?<CREATIONBRIGADE>[^!]*)!(?<REQUESTID>[^!]*)!?(?<PREFIX>[^!]*)";
            //string _packet = "MASTER!BNIN!GHGH000554!26/05/2016!BOS!1!ECHVAS1!GH!BOS20160526134602Fire";
            //Match ma = Regex.Match(_packet, NumberPattern);

            //if (ma.Success)
            //{
            //    Console.WriteLine("Success");
            //}


            #endregion



            #region RemoveInLoop
            //DataSet ds = new DataSet();
            //DataTable dt = new DataTable();
            //dt.Columns.Add("Col1");
            //for (int i = 1; i <= 10; i++)
            //{
            //    dt.Rows.Add(i);
            //}
            //ds.Tables.Add(dt);
            //ds.AcceptChanges();


            //List<int> lst1 = new List<int> { 1, 2, 3 };
            //List<int> lst2 = new List<int> { 3, 4, 5, 6 };
            //List<int> lst3 = new List<int> { 6,7,8 };
            //List<List<int>> lstOfList = new List<List<int>>
            //{
            //    lst1,lst2,lst3
            //};

            //int countList = 0;

            //foreach (DataRow row in ds.Tables[0].Rows)
            //{
            //    bool flag = false;

            //    //foreach (var lst in lstOfList)
            //    //{
            //    //    if (lst.Contains(Convert.ToInt32(row["Col1"].ToString())))
            //    //    {
            //    //        flag = true;
            //    //        continue;
            //    //    }
            //    //}
            //    //if(!flag)
            //    //{
            //    //    Console.WriteLine("lst" + countList.ToString() + string.Empty + row["Col1"].ToString());
            //    //}



            //    foreach (var lst in lstOfList)
            //    {
            //        if (lst.Contains(Convert.ToInt32(row["Col1"].ToString())))
            //        {
            //            flag = true;
            //            break;
            //        }


            //    }
            //    if (!flag)
            //    {
            //        Console.WriteLine("lst" + countList.ToString() + string.Empty + row["Col1"].ToString());
            //    }
            //}



            #endregion



            #region TraceProperty
            //MyProperty myProp = new MyProperty();
            //// Get the type and PropertyInfo.
            //Type t = Type.GetType(myProp.ToString());
            //PropertyInfo pi = t.GetProperty("Caption");

            //// Get the public GetIndexParameters method.
            //ParameterInfo[] parms = pi.GetIndexParameters();
            //Console.WriteLine("\r\n" + t.FullName + "." + pi.Name
            //    + " has " + parms.GetLength(0) + " parameters.");

            //// Display a property that has parameters. The default 
            //// name of an indexer is "Item".
            //pi = t.GetProperty("Item");
            //parms = pi.GetIndexParameters();
            //Console.WriteLine(t.FullName + "." + pi.Name + " has " +
            //    parms.GetLength(0) + " parameters.");
            //foreach (ParameterInfo p in parms)
            //{
            //    Console.WriteLine("   Parameter: " + p.Name);
            //}

            ////return 0;

            #endregion


            #region Thread-lock
            //Thread[] threads = new Thread[10];
            //Account acc = new Account(1000);
            //for (int i = 0; i < 10; i++)
            //{
            //    Thread t = new Thread(new ThreadStart(acc.DoTransactions));
            //    threads[i] = t;
            //}
            //for (int i = 0; i < 10; i++)
            //{
            //    threads[i].Start();
            //}
            #endregion



            #region TimeOut
            //TestThread.CheckTimeLimit();
            #endregion


            #region log4Net-Test

            //for (int i = -1; i < 0; i--)
            //{
            //    log.Info("Application is working: " + i.ToString());
            //}

            #endregion



            #region GoogleProblem
            //IEnumerable<IEnumerable<int>> result =    Problem1.GetPermutations(Enumerable.Range(1, 3), 3);

            //string[] array = { "apple", "peach", "orange" };
            //int[] array = { 1, 2, 3 };
            //GroupPermutations.Perm(array, 0);

            //string result=  Problem1Java.CheckDate(19,19,03);
            ////  string result = Problem1Java.CheckDate(2,30,3);
            //  Console.WriteLine(result);
            #endregion

            #region Using
            //using (var stream = new StreamReader(""))// i = 10)
            //{

            //}
            //using (var i = 10)
            //{
            //}
            #endregion

            #region Test

            #region 1
            //Console.WriteLine(location == null ? "location is null" : location);
            //Console.WriteLine(time == null ? "time is null" : time.ToString()); 
            #endregion

            #region 2          
            //if (time == null)
            //{
            //    /* do something */
            //}
            #endregion



            #region 3
            //AbstractClass a;
            //ConsumeAbstract cb = new ConsoleApplication1.ConsumeAbstract();
            #endregion

            #endregion



            #region Polymorphism
            //Polymorphism.A a;
            //Polymorphism.B b;

            //a = new Polymorphism.A();
            //b = new Polymorphism.B();
            //a.Foo();  // output --> "A::Foo()"
            //b.Foo();  // output --> "B::Foo()"

            //a = new Polymorphism.B();
            //a.Foo();  // output --> "A::Foo()"
            #endregion


            #region try catch finally
            try
            {
                throw new Exception("Original Exception");
            }
            catch
            {
                Console.WriteLine("Catch");
                throw new Exception("Catch Exception");
            }
            finally
            {
                throw new Exception("Finally Exception");
                //try
                //{
                //    throw new Exception("Finally Exception");
                //}
                //catch
                //{
                //    Console.WriteLine("Finally Catch");
                //}
            }
            #endregion


            Console.ReadLine();


        }
    }

    // A class that contains some properties.
    public class MyProperty
    {
        // Define a simple string property.
        private string caption = "A Default caption";
        public string Caption
        {
            get { return caption; }
            set
            {
                if (caption != value) { caption = value; }
            }
        }

        // A very limited indexer that gets or sets one of four 
        // strings.
        private string[] strings = { "abc", "def", "ghi", "jkl" };
        public string this[int Index]
        {
            get
            {
                return strings[Index];
            }
            set
            {
                strings[Index] = value;
            }
        }

        public MyProperty()
        {
            testItem = new Int32[] { 1, 2, 3, 4, 5 };
        }


        public Int32[] testItem { get; set; }
    }

    // using System.Threading;

    class Account
    {
        private Object thisLock = new Object();
        int balance;

        Random r = new Random();

        public Account(int initial)
        {
            balance = initial;
        }

        int Withdraw(int amount)
        {

            // This condition never is true unless the lock statement
            // is commented out.
            if (balance < 0)
            {
                throw new Exception("Negative Balance");
            }

            // Comment out the next line to see the effect of leaving out 
            // the lock keyword.
            lock (thisLock)
            {
                if (balance >= amount)
                {
                    Console.WriteLine("Balance before Withdrawal :  " + balance);
                    Console.WriteLine("Amount to Withdraw        : -" + amount);
                    balance = balance - amount;
                    Console.WriteLine("Balance after Withdrawal  :  " + balance);
                    return amount;
                }
                else
                {
                    return 0; // transaction rejected
                }
            }
        }

        public void DoTransactions()
        {
            for (int i = 0; i < 100; i++)
            {
                Withdraw(r.Next(1, 100));
            }
        }
    }

    class TestThread
    {
        public static void CheckTimeLimit()
        {
            var value = "xxxxx";
            //bool Completed = ExecuteWithTimeLimit(TimeSpan.FromMilliseconds(1000), () =>
            //{
            //    value = "sometihg";
            //});


            object Completed = ExecuteWithTimeLimit(TimeSpan.FromMilliseconds(1000), () =>
            {
                value = "sometihg" + "Added";
            });

            Console.WriteLine(Completed.ToString());
            Console.WriteLine(value);

        }


        public static object ExecuteWithTimeLimit(TimeSpan timeSpan, Action codeBlock)
        {
            try
            {
                //Task<int> task1 = Task<int>.Factory.StartNew(() => 1);
                //int i = task1.Result;


                Task task = Task.Factory.StartNew(() => codeBlock());
                //Task task = Task.Factory.StartNew(() => Thread.Sleep(500000));

                task.Wait(timeSpan);




                //return task.IsCompleted;

                return "return value";


            }
            catch (AggregateException ae)
            {
                throw ae.InnerExceptions[0];
            }
        }

    }

    abstract class AbstractClass
    {
        public AbstractClass()
        {
            Console.WriteLine("Abstract Constructor");
        }
    }

    class ConsumeAbstract : AbstractClass
    {
        public ConsumeAbstract() : base()
        {

        }
    }

    namespace Polymorphism
    {
        class A
        {
            public void Foo() { Console.WriteLine("A::Foo()"); }
        }

        class B : A
        {
            public new void Foo() { Console.WriteLine("B::Foo()"); }
        }

       
    }
  
}

namespace InternalTest
    {
        internal class test
        {

        }
    }