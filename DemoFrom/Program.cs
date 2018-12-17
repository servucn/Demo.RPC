using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoFrom
{

    public static class Program
    {
        public static UcAsp.RPC.ApplicationContext context;
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            context = new UcAsp.RPC.ApplicationContext();
            context.Start(AppDomain.CurrentDomain.BaseDirectory + "Application.config", AppDomain.CurrentDomain.BaseDirectory);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
