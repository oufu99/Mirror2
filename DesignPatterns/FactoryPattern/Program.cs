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

            //简单工厂




            //工厂



            //抽象工厂


        }
    }


    public class Operation
    {
        public virtual decimal GetResult()
        {
            throw new Exception("子类没有实现");

        }
    }


    public class OperationFactory
    {
        public static Operation createOperate(string operate)//静态方法
        {
            Operation oper = null;
            switch (operate)      //分支判断，在增加新的运算类的时候这里需要修改，违背了开放封闭原则
            {
                case "+":
                    oper = new OperationAdd();
                    break;
                case "-":
                    oper = new OperationSub();
                    break;
                case "*":
                    oper = new OperationMul();
                    break;
                case "/":
                    oper = new OperationDiv();
                    break;
            }
            return oper;
        }
    }

}
