using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var m = new MyStruct();
            m.a = 22;
            using (m)
            {
                //m.a = 10;
            }

            Console.WriteLine(m.a);
        }
    }


    struct MyStruct : IDisposable
    {
        public int a;

        public void Dispose()
        {

            a = 5;
        }
    }
}
