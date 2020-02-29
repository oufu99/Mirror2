using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocatorMode
{
    public interface IStudent
    {
        void Say();
    }

    public class Student : IStudent
    {
        private IBoyStudent[] Boys;
        public Student(IBoyStudent[] _boys)
        {
            Boys = _boys;
        }
        public void Say()
        {
            Console.WriteLine("我是Student");
        }
    }

    public interface IBoyStudent
    {
        void Study();
    }

    public class BoyStudent : IBoyStudent
    {
        public void Study()
        {
            Console.WriteLine("男学生开始学习");
        }
    }


    public class BoyStudent1 : IBoyStudent
    {
        public void Study()
        {
            Console.WriteLine("男学生1开始学习");
        }
    }
}
