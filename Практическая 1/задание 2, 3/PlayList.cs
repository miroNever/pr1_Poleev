using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Practica1_2_Poleev
{
    class PlayList
    {
        private List<Song> Playlist;
        private int currentIndex;

        public PlayList()
        {
            Playlist = new List<Song>();
            currentIndex = 0;
        }
        public Song CurrentSong()
        {
            if (Playlist.Count > 0)
                return Playlist[currentIndex];
            else
                throw new IndexOutOfRangeException("Невозможно получить текущую аудиозапись для пустого плейлиста!");
        }

        public void AddSong(Song song)
        {
            Playlist.Add(song);
        }
        public void AddSong(string author, string title, string filename)
        {
            Song song = new Song(author, title, filename);
            Playlist.Add(song);
        }
        public void NextSong()
        {
            if (Playlist.Count > 0)
            {
                currentIndex++;
                if (currentIndex >= Playlist.Count)
                    currentIndex = 0;
            }
            else
            {
                throw new InvalidOperationException("У вас нет треков в плейлисте");
            }
        }
        public void BackSong()
        {
            if (Playlist.Count > 0)
            {
                currentIndex--;
                if (currentIndex < 0)
                    currentIndex = Playlist.Count - 1;
            }
            else
            {
                throw new InvalidOperationException("У вас нет треков в плейлисте");
            }
        }
        public void GoToStart()
        {
            if (Playlist.Count > 0)
                currentIndex = 0;
            else
            {
                
                throw new InvalidOperationException("У вас нет треков в плейлисте");
            }
        }
        public void RemoveSong(int index)
        {
            if (index < 0 || index >= Playlist.Count)
                throw new ArgumentOutOfRangeException("index", "Неверный индекс аудиозаписи для удаления.");

            Playlist.RemoveAt(index);
            if (currentIndex >= Playlist.Count)
                currentIndex = Playlist.Count - 1;
        }

        public int RemoveSong(string title)
        {

            if (string.IsNullOrEmpty(title))
                throw new ArgumentException("Поле 'Название' не может быть пустым.");

            int removedCount = Playlist.RemoveAll(song => song.Title == title);
            if (currentIndex >= Playlist.Count)
                currentIndex = Playlist.Count - 1;
            return removedCount;
        }
        public void ClearPlaylist()
        {
            Playlist.Clear();
            currentIndex = 0;
        }
        public void PlaySong(ListBox listBox, Label label)
        {
            if (listBox.Items.Count != 0)
            {
                label.Text = listBox.Items[0].ToString();
            }
            else
            {
                throw new InvalidOperationException("У вас нет треков в плейлисте");
            }
        }
        public void StopSong(ListBox listBox, Label label)
        {
            if (listBox.Items.Count != 0)
            {
                label.Text = "";
            }
            else
            {
                throw new InvalidOperationException("У вас нет треков в плейлисте");
            }
        }
        public List<Song> GetSongs()
        {
            return Playlist;
        }
    }
}
