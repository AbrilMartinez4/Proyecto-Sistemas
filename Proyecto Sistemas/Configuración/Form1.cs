using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;

namespace Configuración
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        #region Constructor
        string Primer_op = "dddd";     
        public Form1()
        {
            InitializeComponent();     
            this.Size = new System.Drawing.Size(584, 185);          
        }
        #endregion

        #region Automatico
        private void btnAutomatico_Click(object sender, EventArgs e)
        {
            btnAutomatico.BackColor = Color.FromArgb(255, 49, 52);
            btnAutomatico.ForeColor = Color.White;

            btnManual.BackColor = Color.Silver;
            btnManual.ForeColor = Color.FromArgb(64, 64, 64);

            pbAjustes.BackColor = Color.White;

            this.Size = new System.Drawing.Size(584, 555);
            this.CenterToScreen();

            Componentes(true, true, true, true, true, true, true, true, true,
                true, true, false, false, true, true, true, false, true);

            tbVisor.Enabled = false;
            tbTracera.Enabled = false;
            tbPorcentaje.Enabled = false;
            tbH.Enabled = false;

            label8.Text = "Solo lectura.";
        }
        #endregion

        #region Manual
        private void btnManual_Click(object sender, EventArgs e)
        {
            btnManual.BackColor = Color.FromArgb(255, 49, 52);
            btnManual.ForeColor = Color.White;

            btnAutomatico.BackColor = Color.Silver;
            btnAutomatico.ForeColor = Color.FromArgb(64, 64, 64);

            pbAjustes.BackColor = Color.White;

            this.Size = new System.Drawing.Size(584, 555);
            this.CenterToScreen();

            Componentes(false, false, false, false, false, false, false, false, false,
                false, false, false, false, false, false, false, true, false);

            label9.Text = "     Modo: Manual\n Sensores inactivos.";
        }
        #endregion

        #region Metodo
        public void Componentes(bool a, bool b, bool c, bool d, bool e, bool f, bool g, bool i, bool j
            , bool k, bool l, bool n, bool o, bool p, bool q, bool r, bool s, bool t)
        {
            label1.Visible = a;
            label2.Visible = b;
            label3.Visible = c;
            label4.Visible = d;
            label5.Visible = e;
            label6.Visible = f;
            label7.Visible = g;

            tbVisor.Visible = i;
            tbTracera.Visible = j;
            tbPorcentaje.Visible = k;
            tbH.Visible = l;

            btnGuardar.Visible = n;
            btnRestablecer.Visible = o;

            pictureBox2.Visible = p;
            pictureBox3.Visible = q;
            pictureBox4.Visible = r;

            label9.Visible = s;
            label8.Visible = t;

        }
        #endregion

        #region Ajustes
        private void pbAjustes_Click(object sender, EventArgs e)
        {
            pbAjustes.BackColor = Color.FromArgb(255, 49, 52);

            this.Size = new System.Drawing.Size(584, 555);
            this.CenterToScreen();

            Componentes(true, true, true, true, true, true, true, true, true,
                true, true, true, true, true, true, true, false,false);

            tbVisor.Enabled = true;
            tbTracera.Enabled = true;
            tbPorcentaje.Enabled = true;
            tbH.Enabled = true;

            
        }

        #endregion

        #region Form y puertos
        private void Form1_Load(object sender, EventArgs e)
        {
            serialPort1.PortName = "COM11";
            serialPort1.Open();
            timer1.Interval = 100;
            timer1.Start();

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (serialPort1.IsOpen) serialPort1.Close();
        }
        #endregion

        #region Timer
        private void timer1_Tick(object sender, EventArgs e)
        {
            Primer_op = ((tbPorcentaje.Value == 10) ? ":" : tbPorcentaje.Value.ToString()) + ((tbH.Value == 10) ? ":" : tbH.Value.ToString()) +((tbTracera.Value==10)? ":": tbTracera.Value.ToString()) + ((tbVisor.Value==10)? ":": tbVisor.Value.ToString());
            serialPort1.Write(Primer_op);
        }
        #endregion

        #region Tooltips
        private void tbVisor_Scroll(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(tbVisor,tbVisor.Value.ToString());
        }

        private void tbTracera_Scroll(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(tbTracera, tbTracera.Value.ToString());
        }

        private void tbPorcentaje_Scroll(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(tbPorcentaje, tbPorcentaje.Value.ToString());
        }

        private void tbH_Scroll(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(tbH, tbH.Value.ToString());
        }
        #endregion


    }
}
