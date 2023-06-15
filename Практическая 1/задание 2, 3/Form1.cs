using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Practica1_2_Poleev
{
    public partial class Form1 : Form
    {
        List<Shop> ListShops = new List<Shop>();
        Shop CurrentShop;

        int index;
        public Form1()
        {
            InitializeComponent();
            ListShops.Add(new Shop("Магнит"));
            ListShops.Add(new Shop("Монетка"));
            ListShops.Add(new Shop("Красное&Белое"));
        }
        public bool Check(string input)
        {
            char spase = ' ';
            foreach (char c in input)
            {
                if (c == spase)
                {
                    continue;
                }
                if (c >= 'A' && c <= 'z' || c >= 'А' && c <= 'я')
                    return true;
                else
                    break;
            }
            return false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string product = textBox1.Text;
            int countProduct = Convert.ToInt32(numericUpDown1.Value);
            if (Check(product))
            {
                CurrentShop.Sell(product, countProduct);
                listBox1.Items.Clear();
                CurrentShop.WriteAllProducts(listBox1);
                label3.Text = CurrentShop.Profit.ToString();
            }
            else
                MessageBox.Show("Введите буквы");
        }


        private void button2_Click(object sender, EventArgs e)
        {
            string product = textBox2.Text;
            if (Check(product))
            {
                if (CurrentShop.FindByName(textBox2.Text) == null)
                    CurrentShop.CreateProduct(product, Convert.ToInt32(numericUpDown2.Value), Convert.ToInt32(numericUpDown3.Value));
                else
                    MessageBox.Show("Такой товар уже есть");
            }
            listBox1.Items.Clear();
            CurrentShop.WriteAllProducts(listBox1);
        }

        private void Refresh(int index)
        {
            switch (index)
            { 
                case 0:
                    CurrentShop = ListShops[index];
/*                    CurrentShop.CreateProduct("Кола", 85, 200);
                    CurrentShop.CreateProduct("Сок \"Добрый\"", 100, 50);
                    CurrentShop.CreateProduct("Шоколад \"Snikers\"", 60, 150);
                    CurrentShop.CreateProduct("Макароны ", 50, 250);*/
                    listBox1.Items.Clear();
                    CurrentShop.WriteAllProducts(listBox1);
                    label3.Text = $"{CurrentShop.Profit}";
                    break;
                case 1:
                    CurrentShop = ListShops[index];
 /*                   CurrentShop.CreateProduct("Кола", 100, 200);
                    CurrentShop.CreateProduct("Сок \"Привет\"", 50, 150);
                    CurrentShop.CreateProduct("Шоколад", 60, 150);
                    CurrentShop.CreateProduct("Чипсы", 150, 250);*/
                    listBox1.Items.Clear();
                    CurrentShop.WriteAllProducts(listBox1);
                    label3.Text = $"{CurrentShop.Profit}";
                    break;
                case 2:
                    CurrentShop = ListShops[index];
        /*            CurrentShop.CreateProduct("Кола", 10, 200);
                    CurrentShop.CreateProduct("Сок \"Сады придония\"", 50, 150);
                    CurrentShop.CreateProduct("Шоколад", 60, 150);
                    CurrentShop.CreateProduct("Булочка", 150, 250);*/
                    listBox1.Items.Clear();
                    CurrentShop.WriteAllProducts(listBox1);
                    label3.Text = $"{CurrentShop.Profit}";
                    break;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            index = comboBox2.SelectedIndex;
            listBox1.Items.Clear();
            Refresh(index);
        }


        PlayList Playlist = new PlayList();

        private void Addbutton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt";
            openFileDialog.Title = "Выберите файл с аудиозаписью";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filename = openFileDialog.FileName;
                try
                {
                    string[] lines = File.ReadAllLines(openFileDialog.FileName);

                    if (lines.Length == 2)
                    {
                        string author = lines[0];
                        string title = lines[1];
                        string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(filename); ;

                        Playlist.AddSong(author, title, filename);
                        UpdatePlaylistBox();

                        MessageBox.Show("Аудиозапись добавлена в плейлист.");
                    }
                    else
                    {
                        MessageBox.Show("Некорректный формат файла.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при чтении файла: " + ex.Message);
                }
            }
        }

        public void Update()
        {
            try
            {
                Songlabel.Text = Playlist.CurrentSong().Title + " - " + Playlist.CurrentSong().Author;
            }
            catch (InvalidOperationException ex)
            {
                Songlabel.Text = "";
                MessageBox.Show(ex.Message);
            }
        }
        private void UpdatePlaylistBox()
        {
            PlaylistBox.Items.Clear();
            foreach (Song song in Playlist.GetSongs())
            {
                PlaylistBox.Items.Add(song.Title + " - " + song.Author);
            }
        }

        private void Delitebutton_Click(object sender, EventArgs e)
        {
            int selectedIndex = PlaylistBox.SelectedIndex;
            if (selectedIndex >= 0)
            {
                try
                {
                    if (PlaylistBox.Items.Count == 1)
                    {
                        Songlabel.Visible = false;
                    }
                    Playlist.RemoveSong(selectedIndex);
                    UpdatePlaylistBox();
                    MessageBox.Show("Аудиозапись удалена из плейлиста.");
                }
                catch (InvalidOperationException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите аудиозапись для удаления.");
            }
        }

        private void Clearbutton_Click(object sender, EventArgs e)
        {
            try
            {
                Playlist.ClearPlaylist();
                UpdatePlaylistBox();
                Songlabel.Visible = false;
            }
            catch (InvalidOperationException ex)
            {
                Songlabel.Text = "";
                MessageBox.Show(ex.Message);
            }
        }

        private void Backbutton_Click(object sender, EventArgs e)
        {
            try
            {
                Songlabel.Visible = true;
                Playlist.BackSong();
                Update();
            }
            catch (InvalidOperationException ex)
            {
                Songlabel.Text = "";
                MessageBox.Show(ex.Message);
            }
        }

        private void Nextbutton_Click(object sender, EventArgs e)
        {
            try
            {
                Songlabel.Visible = true;
                Playlist.NextSong();
                Update();
            }
            catch (InvalidOperationException ex)
            {
                Songlabel.Text = "";
                MessageBox.Show(ex.Message);
            }
        }

        private void Stopbutton_Click(object sender, EventArgs e)
        {
            try
            {
                Songlabel.Visible = true;
                Playlist.StopSong(PlaylistBox, Songlabel);
            }
            catch (InvalidOperationException ex)
            {
                Songlabel.Text = "";
                MessageBox.Show(ex.Message);
            }
        }

        private void Startbutton_Click(object sender, EventArgs e)
        {
            try
            {
                Songlabel.Visible = true;
                Playlist.PlaySong(PlaylistBox, Songlabel);
            }
            catch(InvalidOperationException ex)
            {
                Songlabel.Text = "";
                MessageBox.Show(ex.Message);
            }
        }

        private void FerstSongbutton_Click(object sender, EventArgs e)
        {
            try
            {
                Songlabel.Visible = true;
                Playlist.GoToStart();
                Update();
            }
            catch (InvalidOperationException ex)
            {
                Songlabel.Text = "";
                MessageBox.Show(ex.Message);
            }
        }
    }
}
