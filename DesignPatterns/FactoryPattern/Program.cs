using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern
{
    class Program
    {
        static void Main(string[] args)
        {

            //简单工厂   每次修改都要传入新的符号,新增太麻烦,违背了对修改封闭,对扩展开放的原则
            //var op = OperationFactory.CreateOperate("-");
            //op.GetResult();

            //工厂
            //IFactory factory = new DellFactory();
            //var model = factory.GetInstance();
            //model.GetResult();


            //factory = new ASUSFactory();
            //model = factory.GetInstance();
            //model.GetResult();
            //抽象工厂
            IFactory factory = new DellFactory();
            var model = factory.GetAddInstance();
            model.GetResult();
            model.GetResult2();

            model = factory.GetSubInstance();
            model.GetResult();
            model.GetResult2();
            Console.ReadLine();
        }
    }
    #region 抽象工厂

    public interface IFactory
    {
        IOperation GetAddInstance();
        IOperation GetSubInstance();
        //产品族 xx计算法之类

    }


    public class DellFactory : IFactory
    {
        public IOperation GetAddInstance()
        {
            return new OperationAdd();
        }

        public IOperation GetSubInstance()
        {
            return new OperationSub();
        }
    }



    public interface IOperation
    {
        int GetResult();
        int GetResult2();
    }

    public class OperationAdd : IOperation
    {
        public int GetResult()
        {
            Console.WriteLine("我是加法");
            return 1;
        }
        public int GetResult2()
        {
            Console.WriteLine("我是加法2代");
            return 1;
        }
    }

    public class OperationSub : IOperation
    {
        public int GetResult()
        {
            Console.WriteLine("我是减法");
            return 1;
        }
        public int GetResult2()
        {
            Console.WriteLine("我是减法2代");
            return 1;
        }
    }
    public class OperationMul : IOperation
    {
        public int GetResult()
        {
            Console.WriteLine("我是乘法");
            return 1;
        }
        public int GetResult2()
        {
            Console.WriteLine("我是乘法2代");
            return 1;
        }
    }
    #endregion


    #region 普通工厂

    //public interface IFactory
    //{
    //    Operation GetInstance();

    //    //产品族 xx计算法之类

    //}


    //public class AddFactory : IFactory
    //{
    //    public Operation GetInstance()
    //    {
    //        return new OperationAdd();
    //    }
    //}
    //public class SubFactory : IFactory
    //{
    //    public Operation GetInstance()
    //    {
    //        return new OperationSub();
    //    }
    //}



    //public class Operation
    //{
    //    public virtual int GetResult()
    //    {
    //        throw new Exception("子类没有实现");

    //    }
    //}

    //public class OperationAdd : Operation
    //{
    //    public override int GetResult()
    //    {
    //        Console.WriteLine("我是加法");
    //        return 1;
    //    }
    //}

    //public class OperationSub : Operation
    //{
    //    public override int GetResult()
    //    {
    //        Console.WriteLine("我是减法");
    //        return 1;
    //    }
    //}
    //public class OperationMul : Operation
    //{
    //    public override int GetResult()
    //    {
    //        Console.WriteLine("我是乘法");
    //        return 1;
    //    }
    //}
    //public class OperationDiv : Operation
    //{
    //    public override int GetResult()
    //    {
    //        Console.WriteLine("我是除法");
    //        return 1;
    //    }
    //}
    #endregion


    #region 简单工厂
    ///// <summary>
    ///// 简单工厂
    ///// </summary>
    //public class OperationFactory
    //{
    //    public static Operation CreateOperate(string operate)//静态方法
    //    {
    //        Operation oper = null;
    //        switch (operate)      //分支判断，在增加新的运算类的时候这里需要修改，违背了开放封闭原则
    //        {
    //            case "+":
    //                oper = new OperationAdd();
    //                break;
    //            case "-":
    //                oper = new OperationSub();
    //                break;
    //            case "*":
    //                oper = new OperationMul();
    //                break;
    //            case "/":
    //                oper = new OperationDiv();
    //                break;
    //        }
    //        return oper;
    //    }
    //}


    //public class Operation
    //{
    //    public virtual int GetResult()
    //    {
    //        throw new Exception("子类没有实现");

    //    }
    //}

    //public class OperationAdd : Operation
    //{
    //    public override int GetResult()
    //    {
    //        Console.WriteLine("我是加法");
    //        return 1;
    //    }
    //}

    //public class OperationSub : Operation
    //{
    //    public override int GetResult()
    //    {
    //        Console.WriteLine("我是减法");
    //        return 1;
    //    }
    //}
    //public class OperationMul : Operation
    //{
    //    public override int GetResult()
    //    {
    //        Console.WriteLine("我是乘法");
    //        return 1;
    //    }
    //}
    //public class OperationDiv : Operation
    //{
    //    public override int GetResult()
    //    {
    //        Console.WriteLine("我是除法");
    //        return 1;
    //    }
    //} 

    #endregion

}
