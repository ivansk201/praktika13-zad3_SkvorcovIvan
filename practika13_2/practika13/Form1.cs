using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace practika13
{
    public partial class Form1 : Form
    {
        private DataGridViewColumn dataGridViewColumn1 = null;
        private DataGridViewColumn dataGridViewColumn2 = null;
        private DataGridViewColumn dataGridViewColumn3 = null;
        private DataGridViewColumn dataGridViewColumn4 = null;
        private DataGridViewColumn dataGridViewColumn5 = null;
        //Инициализация таблицы
        private void initDataGridView()
        {
            dataGridView1.DataSource = null;
            dataGridView1.Columns.Add(getDataGridViewColumn1());
            dataGridView1.Columns.Add(getDataGridViewColumn2());
            dataGridView1.Columns.Add(getDataGridViewColumn3());
            dataGridView1.Columns.Add(getDataGridViewColumn4());
            dataGridView1.Columns.Add(getDataGridViewColumn5());
            dataGridView1.AutoResizeColumns();
        }
        //Динамическое создание первой колонки в таблице
        private DataGridViewColumn getDataGridViewColumn1()
        {
            if (dataGridViewColumn1 == null)
            {                   
                dataGridViewColumn1 = new DataGridViewTextBoxColumn();
                dataGridViewColumn1.Name ="" ;
                dataGridViewColumn1.HeaderText = "Модель" ;
                dataGridViewColumn1.ValueType = typeof(string);
                dataGridViewColumn1.Width = dataGridView1.Width / 3;
            }
            return dataGridViewColumn1;
        }
        //Динамическое создание второй колонки в таблице
        private DataGridViewColumn getDataGridViewColumn2()
        {
            if (dataGridViewColumn2 == null)
            {
                dataGridViewColumn2 = new DataGridViewTextBoxColumn();
                dataGridViewColumn2.Name = "";
                dataGridViewColumn2.HeaderText = "Производитель" ;
                dataGridViewColumn2.ValueType = typeof(string);
                dataGridViewColumn2.Width = dataGridView1.Width / 3;
            }
            return dataGridViewColumn2;
        }
        //Динамическое создание третей колонки в таблице
        private DataGridViewColumn getDataGridViewColumn3()
        {
            if (dataGridViewColumn3 == null)
            {          
                dataGridViewColumn3 = new DataGridViewTextBoxColumn();
                dataGridViewColumn3.Name = ""; ;
                dataGridViewColumn3.HeaderText = "Тип экрана";
                dataGridViewColumn3.ValueType = typeof(string);
                dataGridViewColumn3.Width = dataGridView1.Width / 3;
            }
            return dataGridViewColumn3;
        }
        private DataGridViewColumn getDataGridViewColumn4()
        {
            if (dataGridViewColumn4 == null)
            {
                dataGridViewColumn4 = new DataGridViewTextBoxColumn();
                dataGridViewColumn4.Name = ""; ;
                dataGridViewColumn4.HeaderText = "Операционная система";
                dataGridViewColumn4.ValueType = typeof(string);
                dataGridViewColumn4.Width = dataGridView1.Width / 3;
            }
            return dataGridViewColumn4;
        }
        private DataGridViewColumn getDataGridViewColumn5()
        {
            if (dataGridViewColumn5 == null)
            {
                dataGridViewColumn5 = new DataGridViewTextBoxColumn();
                dataGridViewColumn5.Name = ""; ;
                dataGridViewColumn5.HeaderText = "Размер батаерии";
                dataGridViewColumn5.ValueType = typeof(string);
                dataGridViewColumn5.Width = dataGridView1.Width / 3;
            }
            return dataGridViewColumn5;
        }
        public Form1()
            {
            InitializeComponent();
            initDataGridView();
            }

       
        private HashSet<MobilePhone> MobileList = new HashSet<MobilePhone>();
        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void addMobile(string model, string proizvoditel, string tipekrana, string os, int battery)
        {
            MobilePhone s = new MobilePhone(model, proizvoditel, tipekrana,  os, battery);
            MobileList.Add(s);
            textBox1.Text = "" ;
            textBox2.Text ="";
            textBox3.Text = "" ;
            textBox4.Text = "";
            textBox5.Text = "";
            
            showListInGrid();
        }
        //Удаление студента с колекции

        public void deleteMobile(int index)
        {
            if (index >= 0 && index < MobileList.Count)
            {
                MobilePhone mobile = MobileList.ElementAt(index);
                MobileList.Remove(mobile);
                showListInGrid();
            }
        }
        //Отображение колекции в таблице
        private void showListInGrid()
        {
            dataGridView1.Rows.Clear();
            foreach (MobilePhone s in MobileList)
            {
                DataGridViewRow row = new DataGridViewRow();
                DataGridViewTextBoxCell cell1 = new
                DataGridViewTextBoxCell();
                DataGridViewTextBoxCell cell2 = new
                DataGridViewTextBoxCell();
                DataGridViewTextBoxCell cell3 = new
                DataGridViewTextBoxCell();
                DataGridViewTextBoxCell cell4 = new
                DataGridViewTextBoxCell();
                DataGridViewTextBoxCell cell5 = new
                DataGridViewTextBoxCell();
                cell1.ValueType = typeof(string);
                cell1.Value = s.getModel();
                cell2.ValueType = typeof(string);
                cell2.Value = s.getProizvoditel();
                cell3.ValueType = typeof(string);
                cell3.Value = s.getTipekrana();
                cell4.ValueType = typeof(string);
                cell4.Value = s.getOs();
                cell5.ValueType = typeof(string);
                cell5.Value = s.getBattery();
                row.Cells.Add(cell1);
                row.Cells.Add(cell2);
                row.Cells.Add(cell3);
                row.Cells.Add(cell4);
                row.Cells.Add(cell5);
                dataGridView1.Rows.Add(row);
            }
        }
        //Обработчик нажатия на кнопку добавления
        
       
       
        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                addMobile(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, Convert.ToInt32(textBox5.Text));
            }
            catch
            {
                MessageBox.Show("Не все поля были заполнены", "Ошибка");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void удалитьToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            int index = dataGridView1.SelectedCells[0].RowIndex;
            DialogResult dr = MessageBox.Show("Удалить мобильный телефон?", "", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                try
                {
                    deleteMobile(index);
                }
                catch (Exception)
                {

                }
            }
        }

        private void сортироватьАЯToolStripMenuItem_Click(object sender, EventArgs e)
        {

           dataGridView1.Columns[1].SortMode = DataGridViewColumnSortMode.Automatic;

        }
    }
}
