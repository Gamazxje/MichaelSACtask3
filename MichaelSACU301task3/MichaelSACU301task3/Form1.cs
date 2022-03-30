using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MichaelSACU301task3
{
    
    public partial class Form1 : Form
    {
        List<Sales> sales = new List<Sales>();
        BindingSource bs = new BindingSource();
        string filter;
        public Form1()
        {
            InitializeComponent();
            LoadCSV();
            bs.DataSource = sales;
            dgvSales.DataSource = bs;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void LoadCSV()
        {
            //display the data
            string filePath = @"c:\Users\demo\Task3_Shop_Data.csv";
            List<string> lines = new List<string>();
            lines = File.ReadAllLines(filePath).ToList();
            foreach (string line in lines)
            {
                List<string> items = line.Split(',').ToList();
                Sales s = new Sales();
                s.TextBook = items[0];
                s.Subject = items[1];
                s.Seller = items[2];
                s.Purchaser = items[3];
                s.purchasedPrice = float.Parse(items[4]);
                s.SalePrice = items[5];
                s.Rating = items[6];
                sales.Add(s);
            }
        }
        ////i tried my best on the selection sort but i can't figure it out so i just put my coding in just in case there can be some points i can gain from atleast trying
        //private List<int> SelectionSort(List<int> Rating)
        //{
        //  for (int i = 0; i < Rating.Count  -1; i++)
        //   {
        //       int temp = Rating[i];
        //       int min_index = 0;
        //      int min_value = 9999;
        //       for (int j = i; j < Rating.Count; j++)
        //      {
        //          if (Rating[j] < min_value)
        //          {
        //              min_index = j;
        //              min_value = Rating[j];
        //          }
        //     }
        //      Rating[i] = min_value;
        //      Rating[min_index] = temp;
        //   }
        //    return Rating;
        //  }
        private List<Sales> Search(string target, string filter)
        {
            //search function for Rating,Subject,TextBook
            List<Sales> results = new List<Sales>();
            foreach(Sales s in sales)
            {
                if(filter == "Rating")
                {
                    if(s.Rating.ToLower() == target.ToLower()) results.Add(s);
                }
                if (filter =="Subject")
                {
                    if (s.Subject.ToLower().Contains(target.ToLower())) results.Add(s);
                }
                if(filter == "TextBook")
                {
                    if (s.TextBook.ToLower().Contains(target.ToLower()))results.Add(s);
                }
            }
            return results;
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            filter = cbFilter.Text;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            //search box
            List<Sales> r = Search(txtSearch.Text, filter);
            bs.DataSource = r;
            dgvSales.DataSource = bs;
            bs.ResetBindings(false);
        }
        
        //private void btnSort_Click(object sender, EventArgs e)
        //{
          //sales = SelectionSort(sales);
            //bs.DataSource = sales;
            //dgvSales.DataSource = bs;
          //  bs.ResetBindings(false);
        //}
        //i tried my best on the selection sort but i can't figure it out so i just put my coding in just in case there can be some points i can gain from atleast trying
        //i also have to delete the selection sort button on my design or else everything will crash :)   
    }
}
