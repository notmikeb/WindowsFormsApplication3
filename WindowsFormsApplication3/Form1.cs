using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication3
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Contains column names.
        /// </summary>
        List<string> _names = new List<string>();

        /// <summary>
        /// Contains column data arrays.
        /// </summary>
        List<double[]> _dataArray = new List<double[]>();
        DataTable dt = null;

        public Form1()
        {
            InitializeComponent();

            // Example column.
            _names.Add("Cat");
            // Three numbers of cat data.
            _dataArray.Add(new double[]
            {
                1.0,
                2.2,
                3.4
            });

            // Another example column.
            _names.Add("Dog");
            // Add three numbers of dog data.
            _dataArray.Add(new double[]
            {
                3.3,
                5.0,
                7.0
            });
            // Render the DataGridView.
            dt = GetResultsTable();
            dataGridView1.DataSource = dt;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            TabPage newPage = new TabPage("New Page");
            tabControl1.TabPages.Add(newPage);

            Console.WriteLine("column data\n");

            foreach (DataColumn column in dt.Columns)
            {
                Console.WriteLine(column);
            }

            Console.WriteLine("table data\n");

            foreach (DataRow row in dt.Rows)
            {
                foreach (DataColumn column in dt.Columns)
                {
                    Console.WriteLine(row[column]);
                }
            }
        }

        /// <summary>
        /// This method builds a DataTable of the data.
        /// </summary>
        public DataTable GetResultsTable()
        {
            // Create the output table.
            DataTable d = new DataTable();

            // Loop through all process names.
            for (int i = 0; i < this._dataArray.Count; i++)
            {
                // The current process name.
                string name = this._names[i];

                // Add the program name to our columns.
                d.Columns.Add(name);

                // Add all of the memory numbers to an object list.
                List<object> objectNumbers = new List<object>();

                // Put every column's numbers in this List.
                foreach (double number in this._dataArray[i])
                {
                    objectNumbers.Add((object)number);
                }

                // Keep adding rows until we have enough.
                while (d.Rows.Count < objectNumbers.Count)
                {
                    d.Rows.Add();
                }

                // Add each item to the cells in the column.
                for (int a = 0; a < objectNumbers.Count; a++)
                {
                    d.Rows[a][i] = objectNumbers[a];
                }
            }
            return d;
        }

        static int n = 0;
        private void btnAdd_Click(object sender, EventArgs e)
        {

            TreeNode tn = new TreeNode();

            tn.Text = "daylong test " + n;
            tn.Tag = n;
            treeView1.Nodes.Add( tn );

            n++;

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag != null)
            {
                Console.WriteLine("tag data is " + e.Node.Tag);
            }
            else
            {
                Console.WriteLine("empty data");
            }
        }



    }
}
