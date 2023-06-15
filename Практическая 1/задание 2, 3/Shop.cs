using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practica1_2_Poleev
{
    class Shop
    {
        private Dictionary<Product, int> products;
        private string name;
        public Shop (string _name)
        {
            products = new Dictionary<Product, int>();
            name = _name;
        }
        public decimal Profit
        {
            get;
            set;
        }
        public string Name
        {
            get { return name; }
            set { value = name; }
        }
        public void CreateProduct (string name, decimal price, int count)
        {
           
            products.Add(new Product(name, price), count);
        }
        public void WriteAllProducts (ListBox listbox)
        {
            listbox.Items.Clear();
            foreach (var product in products)
            {
                listbox.Items.Add(product.Key.GetInfo() + $"; Количество: {product.Value}");
            }
        }
        public void Sell (Product product, int count)
        {
            if (products.ContainsKey(product))
            {
                if (products[product] == 0)
                {
                    MessageBox.Show("Нет в наличии!");
                }
                else
                {
                    products[product] -= count;
                }
            } else
            {
                MessageBox.Show("Товар не найден!");
            }
        }
        public void Sell (string ProductName, int count)
        {
            Product ToSell = FindByName(ProductName);
            if (ToSell != null)
            {
                if (products[ToSell] >= count)
                {
                    Profit += ToSell.Price * count;
                    this.Sell(ToSell, count);
                }
                else
                    MessageBox.Show("Столько товара нет в наличии");
            } else
            {
                MessageBox.Show("Товар не найден!");
            }
        }
        public Product FindByName (string name)
        {
            foreach (var product in products.Keys)
            {
                if (product.Name == name)
                {
                    return product;
                }
            }
            return null;
        }

    }
}
