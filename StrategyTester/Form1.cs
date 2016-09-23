using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StatsReaderFromTxt;

namespace StrategyTester
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string path = @"C:\Users\Aberkromb\Documents\Visual Studio 2015\Projects\StrategyTester\SPFB.RTS_160101_160918.txt";

            TxtReader reader = new TxtReader();
            reader.LoadStats(path);
        }
    }
}
