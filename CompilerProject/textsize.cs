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
	 partial class textsize : Form
	{
		private RichTextBox x;
		private TreeView y;
		
		public textsize(RichTextBox xosom, TreeView treeView1)
		{
			x = xosom;
			y = treeView1;
			InitializeComponent();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void label4_Click(object sender, EventArgs e)
		{

			x.Font = new Font("Century Gothic", 8);
			y.Font = new Font("Century Gothic", 8);

		}

		private void label3_Click(object sender, EventArgs e)
		{
			x.Font = new Font("Century Gothic", 10);
			y.Font = new Font("Century Gothic", 10);
		}

		private void label5_Click(object sender, EventArgs e)
		{
			x.Font = new Font("Century Gothic", 12);
			y.Font = new Font("Century Gothic", 12);
		}

		private void label2_Click(object sender, EventArgs e)
		{
			x.Font = new Font("Century Gothic", 14);
			y.Font = new Font("Century Gothic", 14);
		}

		private void button1_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
