using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
namespace Thread
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            var res1= CallLongRunningMethod1();
            var  res1Awaiter = res1.GetAwaiter();
                res1Awaiter.OnCompleted(()=> {
                   label2.Text= res1Awaiter.GetResult().ToString();
                   watch.Stop();
                   label1.Text = watch.Elapsed.Seconds.ToString();
                });
            //var res2 = await CallLongRunningMethod2();
            label2.Text = ComplextMath(2, 3).ToString();
           
            
        }


        public Task<int> CallLongRunningMethod1()
        {
            return Task.Run(() =>
                {
                     return LongRunningMethod1();
                });
        }
        public int CallLongRunningMethod2()
        {
            return LongRunningMethod2();
        }

        public int ComplextMath(int i,int j)
        {
            return i + j;
        }
        private int LongRunningMethod1()
        {
            for(int i=0;i<=999;i++)
                for(int j=0;j<=999;j++)
                    for(int k=0;k<=2200;k++)
                    {
                        var l = 1 + 1;
                    }
           return 2;
        }
        private int LongRunningMethod2()
        {
            System.Threading.Thread.Sleep(5000);
            return 3;
        }

        /// <summary>
        /// comments1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            int i1 = 2 * 2;
            Task.Run(() =>
            {
                return LongRunningMethod1();
            });
            Task t = new Task(() =>
            {
                for (int i = 0; i <= 999; i++)
                    for (int j = 0; j <= 999; j++)
                        for (int k = 0; k <= 2200; k++)
                        {
                            var l = 1 + 1;
                        }
            }
            );
            t.Start();

            int i2 = 2 * 2;
        }
    }
}
