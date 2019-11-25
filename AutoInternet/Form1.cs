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
            var url = "http://10.44.254.1:8081/?userip=10.44.61.29&usermac=e468a395fb22";
            var setting = new CefSettings();
            setting.CefCommandLineArgs.Add("disable-gpu", "1"); // 禁用gpu
            Cef.Initialize(setting, true, false);
            browser = new ChromiumWebBrowser(url);
            this.Controls.Add(browser);
            browser.Dock = DockStyle.Fill;
            obj = new BoundObject(browser, CheckFrameInit, Login);
            browser.RegisterJsObject("boundObj", obj);
            browser.FrameLoadEnd += new EventHandler<FrameLoadEndEventArgs>(FrameEndFunc);
            d1 = DateTime.Now;
        }

        private void FrameEndFunc(object sender, FrameLoadEndEventArgs e)
        {
            CheckFrameInit();
        }

        public void CheckFrameInit()
        {
            var js = @" 
             var isExit=document.getElementById('username')==undefined;
             boundObj.handlerJs(isExit)";
            browser.GetMainFrame().Browser.MainFrame.ExecuteJavaScriptAsync(js);
        }

        private void Login()
        {
            var js = @" 
             document.getElementById('username').value = 'oujialin';
             document.getElementById('password').value='cc1234';
             document.getElementsByTagName('button')[0].click();";
            browser.GetMainFrame().Browser.MainFrame.ExecuteJavaScriptAsync(js);

            //打开批处理路径
            Process.Start(@"D:\MyConfig\MyLoveOpenAllSoft.bat");
            this.Close();
            this.Dispose();
        }


        public string FormatterJs(List<string> list)
        {
            string text = string.Empty;
            foreach (var item in list)
            {
                text += item;
            }
            return text;
        }

    }

    //这用在js回调C#方法的时候使用
    public class BoundObject
    {
        public static bool IsDo = false;
        public static int TotalFunc = 0;
        Action CheckFunc;
        Action LoginFunc;
        public ChromiumWebBrowser browser;
        public string OutputPath { get; set; }

        public BoundObject(ChromiumWebBrowser _browser, Action _checkFunc, Action _loginFunc)
        {
            browser = _browser;
            CheckFunc = _checkFunc;
            LoginFunc = _loginFunc;
        }


        public void HandlerJs(bool elementCount)
        {
            //弄一个获取页面上的元素,如果获取到就开始做事,不然就不管他
            if (elementCount)
            {
                if (TotalFunc >= 10)
                {
                    return;
                }
                Thread.Sleep(500);
                TotalFunc++;
                CheckFunc.Invoke();
            }
            else
            {
                LoginFunc.Invoke();
            }
        }
    }
}
