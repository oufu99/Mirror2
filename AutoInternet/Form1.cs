using CefSharp;
using CefSharp.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoInternet
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitBrowser();
        }

        List<string> fileNameList = new List<string>();
        DateTime d1 = DateTime.Now;

        BoundObject obj;
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public ChromiumWebBrowser browser;

        public void InitBrowser()
        {
            var url = "https://www.baidu.com/s?tn=site5566&ch=1&word=%CD%F8%C9%CF%B3%E5%C0%CB+%D3%A2%CE%C4";
            var setting = new CefSettings();
            setting.CefCommandLineArgs.Add("disable-gpu", "1"); // 禁用gpu
            Cef.Initialize(setting, true, false);
            browser = new ChromiumWebBrowser(url);
            this.Controls.Add(browser);
            browser.Dock = DockStyle.Fill;
            obj = new BoundObject(browser);
            browser.RegisterJsObject("bound", obj);
            browser.FrameLoadEnd += new EventHandler<FrameLoadEndEventArgs>(FrameEndFunc);
            d1 = DateTime.Now;
        }

        private void FrameEndFunc(object sender, FrameLoadEndEventArgs e)
        {
            MessageBox.Show("加载完毕");
            ExecuteJs();
        }

        private void ExecuteJs()
        {
            //后面把这个弄到加载完毕执行的时候就可以了
            var js = FormaterJS();
            browser.GetMainFrame().Browser.MainFrame.ExecuteJavaScriptAsync(js);
        }

        public string FormaterJS()
        {
            string text = "$('#kw').val('Hello World!')";
            return text;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ExecuteJs();
        }
    }

    //这用在js回调C#方法的时候使用
    public class BoundObject
    {
        public ChromiumWebBrowser browser;
        public string OutputPath { get; set; }

        public BoundObject(ChromiumWebBrowser _browser)
        {
            browser = _browser;

        }
        public void HandlerJs()
        {

        }
    }
}
