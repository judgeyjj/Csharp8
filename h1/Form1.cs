using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;

namespace WindowsFormsApp13
{
    public partial class Form1 : Form
    {
        private delegate void MyDelegate();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Task task_baidu = new Task(() => { Search_baidu("https://www.baidu.com/baidu?wd=" + textBox1.Text); }) ;
            Task task_bing = new Task(() => { Search_bing("https://cn.bing.com/search?form=MOZTSB&pc=MOZI&q=" + textBox1.Text); });
            task_baidu.Start();
            task_bing.Start();
        }
        private void Search_baidu(string url)           // baidu
        {
            WebClient webClient = new WebClient();
            byte[] recvdata = webClient.DownloadData(url);       // 指定url下载数据到byte数组中
            string response = Encoding.UTF8.GetString(recvdata); // 获取UTF-8类型编码
            this.BeginInvoke(new MyDelegate(() => { textBox_baidu.Text = response.Substring(0, 100); }));   // 将转换后的数据填入textBox
        }
        private void Search_bing(string url)           // bing
        {
            WebClient webClient = new WebClient();
            byte[] recvdata = webClient.DownloadData(url);
            string response = Encoding.UTF8.GetString(recvdata);
            this.BeginInvoke(new MyDelegate(() => { textBox_bing.Text = response.Substring(0, 100); }));
        }
    }
}
