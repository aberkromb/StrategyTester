﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibsLoader;
using StatsReaderFromTxt;

namespace StrategyTester
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //TODO Кнопка для тестирования текущих наработок
        private void button1_Click(object sender, EventArgs e)
        {
            string path = @"C:\Users\Aberkromb\Documents\Visual Studio 2015\Projects\StrategyTester\SBER_160101_161001-1.txt";

            TxtReader reader = new TxtReader();
            var allstats = reader.LoadStats(path);

            var patterns = LoadStrategies.Load();

            var test = patterns[0].Logic(allstats);

            foreach (var t in test)
            {
                rtb_Main.Text = rtb_Main.Text + t + '\n';
            }
        }
    }
}
