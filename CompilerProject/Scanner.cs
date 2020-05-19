using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompilerProject
{
	public partial class Scanner1 : UserControl
	{
		public string[] rsrvdwrds = { "read", "write", "repeat", "until", "if", "elseif", "else", "then", "return", "endl", "while", "program", "main" };
		public string[] dtatyps = { "int", "float", "string" };

		public void CheckKeyword(string word, Color color, int startIndex)
		{
			if (this.richTextBox1.Text.Contains(word))
			{
				int index = -1;
				int selectStart = this.richTextBox1.SelectionStart;

				while ((index = this.richTextBox1.Text.IndexOf(word, (index + 1))) != -1)
				{
					this.richTextBox1.Select((index + startIndex), word.Length);
					this.richTextBox1.SelectionColor = color;
					this.richTextBox1.Select(selectStart, 0);
					this.richTextBox1.SelectionColor = Color.Black;
				}
			}
		}

		public Scanner1()
		{
			InitializeComponent();
			button1.BringToFront();
			listBox1.Visible = false;

		}


		public void richTextBox1_TextChanged(object sender, EventArgs e)
		{

		}

		private void button1_Click(object sender, EventArgs e)
		{


			ScannerCompiler sc = new ScannerCompiler(richTextBox1.Text);
			richTextBox1.Clear();
			sc.scan();
			int ind = 0;
			for (int i = 0; i < sc.tokens.Count; i++)

			{
				richTextBox1.AppendText(sc.tokens[i].input);

				richTextBox1.AppendText("    ");

				richTextBox1.AppendText(sc.tokens[i].type.ToString());

				richTextBox1.AppendText("\n");


			}
			List<int> removalList = new List<int>();
			for (int i = 0; i < sc.tokens.Count; i++) if (sc.tokens[i].type == Type.ERROR) listBox1.Items.Add("Error in Line " + (ind + 1).ToString() + ", using " + sc.tokens[i].input); else if (sc.tokens[i].type == Type.NEWLINE || sc.tokens[i].type == Type.COMMENT) { ind++; removalList.Add(i); };
			for (int i = 0; i < removalList.Count; i++)
			{
				sc.tokens.RemoveAt(removalList[i] - i);
			}


			Parser ps = new Parser();
			ps.parsing(sc.tokens);
		
			treeView1.Nodes.Add(ps.root);



			button2.BringToFront();
		}

		private void pictureBox1_Click(object sender, EventArgs e)
		{
			

			textsize txt = new textsize(richTextBox1, treeView1);

			txt.Show();
		}

		private void Scanner1_Load(object sender, EventArgs e)
		{

		}
		public void Setfont(int fnt)
		{
			richTextBox1.Font = new Font("Century Gothic", fnt);
		}

		private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

		}

		private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
		{



		}

		private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

		}

		private void treeView1_AfterSelect_1(object sender, TreeViewEventArgs e)
		{

		}

		private void treeView1_AfterSelect_2(object sender, TreeViewEventArgs e)
		{

		}

		private void button2_Click(object sender, EventArgs e)
		{
			treeView1.Nodes.Clear();
			treeView1.Refresh();
			richTextBox1.Clear();
			button1.BringToFront();
		}
	}
}