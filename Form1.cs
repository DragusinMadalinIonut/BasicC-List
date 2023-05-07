using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        DataTable notes = new DataTable();
        bool editing = false;
        public Form1()
        {
            InitializeComponent();
            label1.Click += new EventHandler(label1_Click);
            label2.Click += new EventHandler(label2_Click);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            notes.Columns.Add("Title");
            notes.Columns.Add("Note");

            previousNotes.DataSource = notes;
            previousNotes.Columns[1].Visible = false;
            previousNotes.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void loadBTN_Click(object sender, EventArgs e)
        {
            titleBox.Text = notes.Rows[previousNotes.CurrentCell.RowIndex].ItemArray[0].ToString();
            notesBox.Text = notes.Rows[previousNotes.CurrentCell.RowIndex].ItemArray[1].ToString();
            editing = true;
        }

        private void deleteBTN_Click(object sender, EventArgs e)
        {
            try
            {
                notes.Rows[previousNotes.CurrentCell.RowIndex].Delete();
                notes.AcceptChanges();
            }
            catch (Exception ex) { Console.WriteLine("Nu este o notita valida"); }

        }

        private void newBTN_Click(object sender, EventArgs e)
        {
            titleBox.Text = "";
            notesBox.Text = "";
            editing = false;
        }

        private void saveBTN_Click(object sender, EventArgs e)
        {
            if (editing)
            {
                notes.Rows[previousNotes.CurrentCell.RowIndex]["Title"] = titleBox.Text;
                notes.Rows[previousNotes.CurrentCell.RowIndex]["Note"] = notesBox.Text;
            }
            else
            {
                notes.Rows.Add(new object[] { titleBox.Text, notesBox.Text });
            }

            notes.AcceptChanges();
            previousNotes.DataSource = notes;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // Do something when the label is clicked
        }

        private void label2_Click(object sender, EventArgs e)
        {
            // Do something when the label is clicked
        }
    }
}
