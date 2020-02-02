using Cashier.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cashier
{
    public partial class Form1 : Form
    {
        List<CasherResult> resultList = new List<CasherResult>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.button1.TabIndex = 0;
            this.txtPrice.Text = "100";

            //初始化下拉框  用反射来解耦
            List<CasherData> list = InitDdlDataSource();
            
            ddlFunc.DisplayMember = "Name";
            ddlFunc.ValueMember = "FuncName";
            this.ddlFunc.DataSource = list;

            //不显示出dataGridView1的最后一行空白   
            dataGridView1.AllowUserToAddRows = false;
        }
        /// <summary>
        /// 初始化数据源 用try使用 如果报错抛错直接不初始化
        /// </summary>
        /// <returns></returns>
        public List<CasherData> InitDdlDataSource()
        {
            try
            {
                var list = new List<CasherData>();
                var ddlList = GetDdlReflectData();
                foreach (var item in ddlList)
                {
                    var arr = item.Split(new string[] { "@_@" }, StringSplitOptions.RemoveEmptyEntries);
                    list.Add(new CasherData() { Name = arr[0], FuncName = arr[1] });
                }
                return list;
            }
            catch (Exception)
            {

                throw new Exception("反射数据初始化失败,请联系管理员");
            }
        }
        /// <summary>
        /// 获取配置的信息返回List列表 后面可以从xml文件中读取
        /// </summary>
        /// <returns></returns>
        public List<string> GetDdlReflectData()
        {
            var list = new List<string>();
            //参数以&&分割,以|结尾 无论有没有都这样  如果是无参构造 parms参数填parmNull
            list.Add("正常收费@_@Cashier@@Cashier.Models.NormalComputer@@1&&decimal|");
            list.Add("打九折@_@Cashier@@Cashier.Models.NormalComputer@@0.9&&decimal|");
            list.Add("满100减50@_@Cashier@@Cashier.Models.RebateComputer@@100&&decimal|50&&decimal");
            return list;
        }
        private void RefreshDataTable()
        {
            //dataGridView刷新页面需要重新绑定一下
            this.dataGridView1.DataSource = null;
            this.dataGridView1.DataSource = resultList;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtPrice.Text))
            {
                return;
            }
            var money = decimal.Parse(this.txtPrice.Text);

            var switchValue = this.ddlFunc.SelectedValue.ToString();
            var ddlName = this.ddlFunc.Text;
            var context = new CashContext(switchValue);
            //刷新结算数据
            var resultMoney = context.Computer(money);
            resultList.Add(new CasherResult() { Name = ddlName, TotolMoney = resultMoney });
            RefreshDataTable();
        }

    }

    public class CasherData
    {
        public string Name { get; set; }
        public string FuncName { get; set; }
    }

    public class CasherResult
    {
        [DisplayName("活动名称")]
        public string Name { get; set; }
        [DisplayName("总价")]
        public decimal TotolMoney { get; set; }
    }
}
