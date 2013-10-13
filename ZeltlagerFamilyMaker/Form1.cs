using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZeltlagerFamilyMaker.Models;

namespace ZeltlagerFamilyMaker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Execute_Click(object sender, EventArgs e)
        {
            var lines = textBox1.Lines;
            var infos = new string[lines.Length - 1, 5];

            for (int i = 0; i < lines.Length - 1; i++ )
            {
                var infoArray = lines[i].Split(';');

                for (int j = 0; j < 5; j++)
                {
                    infos[i, j] = infoArray[j].Trim();
                }
            }

            var s = Singleton.Instance;

            for (int i = 0; i < lines.Length - 1; i++ )
            {
                int? wishedMateId;
                if (infos[i, 4].Equals(""))
                {
                    wishedMateId = null;
                }
                else
                {
                    wishedMateId = int.Parse(infos[i, 4]);
                }

                var newChild = new Child(int.Parse(infos[i, 0]), infos[i, 1], infos[i, 2], true, DateTime.Parse(infos[i, 3]), wishedMateId);
                s.addChild(newChild);
            }

            s.createAllConnections();

            textBox1.Text = s.getFams();
        }
    }
}
