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
        BindingSource bs = new BindingSource(); //data type of the binding source will be sales and bs will be the data source for the data grid view
        string filter; //global variable for the search function
        public Form1()
        {
            InitializeComponent();
            LoadCSV();
            bs.DataSource = sales; //the list of sales will have actual value from the csv file
            dgvSales.DataSource = bs; 
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void LoadCSV()
        {
            //display the data
            string filePath = @"c:\Users\demo\Task3_Shop_Data.csv";
            List<string> lines = new List<string>(); //create a list of lines to store the lines that is read from the csv file
            lines = File.ReadAllLines(filePath).ToList(); 
            foreach (string line in lines) //for each line in csv file there are strings
            {
                List<string> items = line.Split(',').ToList(); //split into a list of items
                Sales s = new Sales();
                s.TextBook = items[0];//each item in each different row
                s.Subject = items[1];
                s.Seller = items[2];
                s.Purchaser = items[3];
                s.purchasedPrice = float.Parse(items[4]); //convert to float
                s.SalePrice = items[5];
                s.Rating = items[6];
                sales.Add(s); //add this object(sale) to the list of sales
            }
        }
        //i tried my best on the selection sort but i can't figure it out so i just put my coding in just in case there can be some points i can gain from atleast trying
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
        private List<Sales> Search(string target, string filter) //first parameter is the target which means whatever you enter in the testbox and second is the filter from the comboBox
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
            filter = cbFilter.Text;  //whenever the user select a different item
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            
            List<Sales> r = Search(txtSearch.Text, filter); //first parameter is the text that user type and the second is the comboBox
            bs.DataSource = r; //new datasource 
            dgvSales.DataSource = bs; //tell the datagridview that binding source is the data source,the binding source will automatically refresh
            bs.ResetBindings(false); //false means no data type will be changed
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
