using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Demo.Interface;
using Demo.Model;
using log4net;

namespace DemoFrom
{
    public partial class Form1 : Form
    {
        private readonly ILog _log = LogManager.GetLogger(typeof(Form1));
        Timer timer = new Timer();
        ISwPackageWeight swExport = Program.context.GetProxyObject<ISwPackageWeight>();
        public Form1()
        {
            InitializeComponent();
            timer.Tick += Timer_Tick;
            timer.Interval = 1300;

        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                try
                {
                    swExport.Insert(new SwPackageWeight() { Guid = Guid.NewGuid().ToString().Replace("-", ""), CardId = "1234", TotalWeight = 200, CreateDate = DateTime.Now });
                    List<SwPackageWeight> swPackageWeights = swExport.GetSwPackageWeights();
                    if (dataGridView1.IsHandleCreated)
                    {
                        dataGridView1.BeginInvoke((EventHandler)delegate
                        {
                            dataGridView1.DataSource = swPackageWeights;
                            label1.Text = swPackageWeights.Count.ToString();
                        });

                    }
                }
                catch (Exception ex)
                {
                    _log.Error(ex);
                }

            });

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            dataGridView1.DataSource = swExport.GetSwPackageWeights();
            timer.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }
    }
}
