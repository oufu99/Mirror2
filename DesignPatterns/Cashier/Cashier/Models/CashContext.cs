using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Cashier.Models
{
    public class CashContext
    {

        private ICashComputer cash;
        public CashContext(string switchValue)
        {
            //通过反射创建出具体对象
            var reflectArr = switchValue.Split(new string[] { "@@" }, StringSplitOptions.RemoveEmptyEntries);
            // 正常收费@_@Cashier@@Cashier.Models.NormalComputer@@1
            //如果无参构造函数,传入了参数会怎么样
            var space = reflectArr[0];
            var modelName = reflectArr[1];
            var ctorParm = reflectArr[2];
            //会默认从bin文件夹中查找
            var pars = new List<object>();
            if (!string.IsNullOrEmpty(ctorParm) && ctorParm != "parmNull")
            {
                var parmsArr = ctorParm.Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);


                foreach (var item in parmsArr)
                {
                    //根据&&解析成具体的类型
                    var typeArr = item.Split(new string[] { "&&" }, StringSplitOptions.RemoveEmptyEntries);
                    var typeValue = typeArr[0];
                    var typeName = typeArr[1];
                    var para = ConvertTypeByName(typeName, typeValue);
                    pars.Add(para);
                }
            }
            Assembly ass = Assembly.GetExecutingAssembly();
            //普通的
            //Assembly ass = Assembly.LoadFrom(AppDomain.CurrentDomain.BaseDirectory + space + ".exe");
            var instance = ass.CreateInstance(modelName, true, System.Reflection.BindingFlags.Default, null, pars.ToArray(), null, null);
            //判断此type是否是ICashComputer的子类 不是就直接报错
            cash = (ICashComputer)instance;
        }
        public decimal Computer(decimal money)
        {
            return cash.Computer(money);
        }

        private object ConvertTypeByName(string typeName, string value)
        {
            switch (typeName)
            {
                case "decimal":
                    return decimal.Parse(value);
                case "string":
                    return value;
                case "int":
                    return int.Parse(value);
                case "DateTime":
                    return DateTime.Parse(value);
                default:
                    return value;
            }



        }
    }
}
