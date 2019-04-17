using Demo.Interface;
using Demo.Model;
using log4net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoFrom
{
    public partial class Form2 : Form
    {
        private readonly ILog _log = LogManager.GetLogger(typeof(Form2));
        System.Timers.Timer timer = new System.Timers.Timer();
        ISwExportFinish swExport = Program.context.GetProxyObject<ISwExportFinish>();
        public Form2()
        {
            InitializeComponent();
            timer.Elapsed += Timer_Tick;
            timer.Interval = 1500;
        }
        private void Timer_Tick(object sender, EventArgs e)
        {

            Task.Run(() =>
            {
                try
                {
                    swExport.Insert(new SwExportFinish() { Guid = Guid.NewGuid().ToString().Replace("-", ""), CardId = "1234", ActNumber = 10, FinishTime = DateTime.Now, GoalNumber = 10 });
                    List<SwExportFinish> swExportFinishes = swExport.GetSwExportFinishs();
                    if (dataGridView1.IsHandleCreated)
                    {
                        dataGridView1.BeginInvoke((EventHandler)delegate
                        {
                            dataGridView1.DataSource = swExportFinishes;

                        });
                    }
                }
                catch (Exception ex)
                {
                    _log.Error(ex);
                }
            });

        }
        private void Form2_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = swExport.GetSwExportFinishs();
            timer.Start();
        }
    }
}
