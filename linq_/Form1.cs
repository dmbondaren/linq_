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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace linq_
{
    public partial class Form1 : Form
    {
        private List<Product> products = new List<Product>();
        private string filePath = "C:\\Users\\bonda\\OneDrive\\Документы\\lab10acd\\linq_\\products.txt";

        public Form1()
        {
            InitializeComponent();
            InitializeComboBox();
        }

        private void InitializeComboBox()
        {
            comboBox1.Items.AddRange(new string[] { "Electronics", "Appliances", "Books", "Clothing" });
            comboBox2.Items.AddRange(new string[] { "Filter by Category", "Search by Name" });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var product = new Product
            {
                Name = textBox1.Text,
                Category = comboBox1.SelectedItem?.ToString(),
                Price = decimal.Parse(textBox3.Text),
                Quantity = int.Parse(textBox4.Text)
            };

            products.Add(product);
            UpdateListBox();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var writer = new StreamWriter(filePath))
            {
                foreach (var product in products)
                {
                    writer.WriteLine($"{product.Name},{product.Category},{product.Price},{product.Quantity}");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (File.Exists(filePath))
            {
                products.Clear();
                var lines = File.ReadAllLines(filePath);
                foreach (var line in lines)
                {
                    var parts = line.Split(',');
                    var product = new Product
                    {
                        Name = parts[0],
                        Category = parts[1],
                        Price = decimal.Parse(parts[2]),
                        Quantity = int.Parse(parts[3])
                    };
                    products.Add(product);
                }
                UpdateListBox();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            List<Product> filteredProducts;
            if (comboBox2.SelectedItem?.ToString() == "Filter by Category")
            {
                filteredProducts = products.Where(p => p.Category.Equals(textBox6.Text, StringComparison.OrdinalIgnoreCase)).ToList();
            }
            else
            {
                filteredProducts = products.Where(p => p.Name.IndexOf(textBox6.Text, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
            }
            UpdateListBox(filteredProducts);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var sortedProducts = products.OrderBy(p => p.Price).ToList();
            UpdateListBox(sortedProducts);
        }

        private void UpdateListBox(List<Product> productsToShow = null)
        {
            listBox1.Items.Clear();
            var items = productsToShow ?? products;
            foreach (var product in items)
            {
                listBox1.Items.Add(product);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void textBox3_TextChanged(object sender, EventArgs e) { }
        private void textBox4_TextChanged(object sender, EventArgs e) { }
        private void textBox6_TextChanged(object sender, EventArgs e) { }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e) { }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) { }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e) { }
    }
}