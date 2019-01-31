using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Lesson_2_Inheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            //Lesson.InheritanceExample();
            //Lesson.ObjectVariablesExample();
            //Lesson.VirtualMethodExample();

            Practice.A_L2_P1_1();
            //Lesson.ConstructroExamples2();
            //Lesson.VirtualMethodExample();



            Console.ReadLine();
        }

        public class  Song22
        {
            public  string Name { get; set; }

            public string Like() => "liked";

            public override bool Equals(object obj)
            {
                return true;
            }

            protected bool Equals(Song22 other)
            {
                return string.Equals(Name, other.Name);
            }

            public override int GetHashCode()
            {
                return (Name != null ? Name.GetHashCode() : 0);
            }
        }
    }
}
