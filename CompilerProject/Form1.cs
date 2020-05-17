using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompilerProject
{
	public partial class Form1 : Form
	{



		


		public Form1()
		{
			InitializeComponent();
			homeLay1.BringToFront();
			
		}

		private void pictureBox3_Click(object sender, EventArgs e)
		{
			msgbox msgbox1 = new msgbox();

			msgbox1.Show();
			
		}

		private void button1_Click(object sender, EventArgs e)
		{
			homeLay1.BringToFront();
			
		}

		private void button2_Click(object sender, EventArgs e)
		{
			scanner1.BringToFront();
			
		}

		private void home1_Load(object sender, EventArgs e)
		{
			
		}

		private void pictureBox1_Click(object sender, EventArgs e)
		{
			Scanner1 sc = new Scanner1();

			
		}

		private void homeLay1_Load(object sender, EventArgs e)
		{

		}

		private void scanner1_Load(object sender, EventArgs e)
		{

		}
	}
}
