using System.IO;
using System.Text.Json;
using System.Xml.Serialization;

namespace WpfLibrary1
{
    public class PlayList
    {
        public List<Song> playlist;

        //[Key]
        //public int Id { get; set; }
        //public string Name { get; set; }
        //public DateTime CreationDate { get; set; }
        //public int NumberOfSongs { get; set; }
        public PlayList()
        {
            playlist = new List<Song>();
        }
        public bool AddSong(Song songToAdd)
        {
            if (SongInPlaylist(songToAdd))
            {
                return false;
            }

            playlist.Add(songToAdd);
            return true;
        }

        private bool SongInPlaylist(Song song)
        {
            foreach (var s in playlist)
            {
                if (song.Equals(s))
                {
                    return true;
                }
            }

            return false;
        }

        //public bool DeleteSong(Song songsToDelete)
        //{
        //    foreach (var song in playlist)
        //    {
        //        if (songsToDelete.Equals(song))
        //        {
        //            playlist.Remove(song);
        //            return true;
        //        }
        //    }

        //    return false;
        //}
        public bool DeleteSong(Song songToDelete)
        {
            if (SongInPlaylist(songToDelete))
            {
                playlist.Remove(songToDelete);
                return true;
            }
            return false;
        }
        public IEnumerable<Song> Search(string[] request)
        {
            List<Song> result = new List<Song>();

            foreach (var song in playlist)
            {
                for (int i = 0; i < request.Length; i++)
                {
                    if (song.Author.Contains(request[i], StringComparison.InvariantCultureIgnoreCase)
                        || song.Title.Contains(request[i], StringComparison.InvariantCultureIgnoreCase))
                    {
                        result.Add(song);
                        break;
                    }
                }
            }

            return result;
        }
        public void ToJSON()
        {
            var jsonPlaylist = JsonSerializer.Serialize<PlayList>(this);
            jsonPlaylist = JsonSerializer.Serialize<PlayList>(this);
            File.WriteAllText("playlist.json", jsonPlaylist);
        }
        public void ToXML()
        {
            XmlSerializer xmlPLaylistSerializer = new XmlSerializer(typeof(PlayList));
            using (FileStream create = new FileStream("playlist.xml", FileMode.OpenOrCreate))
            {
                xmlPLaylistSerializer.Serialize(create, this);
            }
        }
        public PlayList FromJSON()
        {
            return JsonSerializer.Deserialize<PlayList>(File.ReadAllText("playlist.json"));
        }
        public PlayList FromXML()
        {
            XmlSerializer xmlPLaylistSerializer = new XmlSerializer(typeof(PlayList));

            using (FileStream read = new FileStream("playlist.xml", FileMode.Open))
            {
                return (PlayList)xmlPLaylistSerializer.Deserialize(read);
            }
        }
        public string ToSQL(String name)
        {
            using (var db = new BloggingContext())
            {
                if (db.Song.Where(b => b.PlayListName == name).Count() != 0)
                {
                    return "PlayList already exists";
                }
                db.AddRange(this.playlist.Select(c => new Song()
                {
                    Author = c.Author,
                    Title = c.Title,
                    PlayListName = name
                }));
                db.SaveChanges();
                return "Playlist has been saved to SQL-DataBase";
            }
        }
        public string FromSQL(string name)
        {
            using (var db = new BloggingContext())
            {
                IQueryable<Song> query = (db.Song.Where(b => b.PlayListName == name));
                if (query.Count() == 0)
                {
                    return "No playlist found";
                }
                this.playlist = query.ToList();
                return "Playlist has been loaded from SQL-DataBase";
            }
        }
        public List<Song> Songs
        {
            get { return playlist; }
            set { playlist = value; }
        }
    }

}
