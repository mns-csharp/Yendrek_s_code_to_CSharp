using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using ZedGraph;

namespace Yendrek_s_code_to_CSharp.GUI
{
    public partial class Form1 : Form
    {
        private PointPairList ppList = new PointPairList();
        Thread t;
        double energy = 0;
        public Form1()
        {
            InitializeComponent();

            zedGraphControl1.GraphPane.AddCurve("", ppList, Color.Red, SymbolType.None);

            t = new Thread(new ThreadStart(RunSimulatio));
        }

        long X = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            t.Start();
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            textBox1.Text += energy.ToString() + "\r\n";
            textBox1.SelectionStart = textBox1.Text.Length;
            textBox1.ScrollToCaret();

            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();
        }

        void RunSimulatio()
        {
            Program.polymer_chain_vec = Program.InitializePolymerChain();
            double previousEnergy = Program.GetTotalPolymerEnergy();
            List<double> energies = new List<double>();
            energies.Add(previousEnergy);

            for (int j = 0; j < 100; j++)
            {
                for (int i = 0; i < 100; i++)
                {
                    Console.WriteLine(Program.polymer_chain_vec.Count + ", ");

                    Program.RunSimulation();

                    energy = Program.GetTotalPolymerEnergy();
                    ppList.Add(X++, energy);                    
                }
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            t.Abort();
        }
    }
}
