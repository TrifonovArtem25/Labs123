using System;
using System.Diagnostics;
using System.Net.Quic;
using System.Text.Json;
using System.Xml.Serialization;
using System.Linq;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;
using Lab3;

class Program
{
    static void Main(string[] args)
    {
        Song a = new Song("Red Hot Chili Peppers", "Snow");

        PlayList playlist = new PlayList();

        //XmlSerializer xmlPLaylistSerializer = new XmlSerializer(typeof(PlayList));
        //var jsonPlaylist = JsonSerializer.Serialize<PlayList>(playlist);

        bool active = true;
        Console.WriteLine("Usage:");
        Console.WriteLine("'1' to find a song");
        Console.WriteLine("'2' to overview full playlist");
        Console.WriteLine("'3' to add new song");
        Console.WriteLine("'4' to delete song");

        Console.WriteLine("'5' to save playlist in JSON-file");
        Console.WriteLine("'6' to upload playlist from JSON-file");
        Console.WriteLine("'7' to save playlist in XML-file");
        Console.WriteLine("'8' to upload playlist from XML-file");
        Console.WriteLine("'9' to save playlist to SQL DataBase");
        Console.WriteLine("'10' to get PlayList from SQL DataBase");
        Console.WriteLine("'11' to delete PlayList from SQL DataBase");
        Console.WriteLine("'0' to exit");
        Console.Write("Command:  ");
        while (active)
        {
            String command = Console.ReadLine();
            switch (command)
            {
                case "5":    //toJSON
                    playlist.ToJSON();
                    Console.WriteLine("JSON-file created");
                    Console.Write("Command:  ");
                    break;
                case "6":    //FromJSON
                    playlist = playlist.FromJSON();
                    Console.WriteLine("Playlist has been updated from JSON-file");
                    Console.Write("Command:  ");
                    break;
                case "7":      //toXML
                    playlist.ToXML();
                    Console.WriteLine("XML-file created");
                    Console.Write("Command:  ");
                    break;
                case "8":      //FromXML
                    playlist=playlist.FromXML();
                    Console.WriteLine("Playlist has been updated from XML-file");
                    Console.Write("Command:  ");
                    break;

                case "9":
                    String CreatePLinDBQuery = CreatePlayListName();

                    Console.WriteLine(playlist.ToSQL(CreatePLinDBQuery));

                    //using (var db = new BloggingContext())
                    //{
                    //    if (db.Song.Where(b => b.PlayListName == CreatePLinDBQuery).Count() != 0)
                    //    {
                    //        Console.WriteLine("PlayList already exists");
                    //        Console.Write("Command:  ");
                    //        break;
                    //    }
                    //    db.AddRange(playlist.playlist.Select(c => new Song()
                    //    {
                    //        Author = c.Author,
                    //        Title = c.Title,
                    //        PlayListName = CreatePLinDBQuery
                    //    }));
                    //    db.SaveChanges();
                    //    Console.WriteLine("Playlist has been saved to SQL-DataBase");
                    //    Console.Write("Command:  ");
                    //    break;
                    //}
                    Console.Write("Command:  ");
                    break;

                case "10":
                    string GetPLfromDBQuery = ReadPlayListName();

                    Console.WriteLine(playlist.FromSQL(GetPLfromDBQuery));

                    //using (var db = new BloggingContext())
                    //{
                    //    IQueryable<Song> query = (db.Song.Where(b => b.PlayListName == GetPLfromDBQuery));
                    //    if (query.Count() == 0)
                    //    {
                    //        Console.WriteLine("No playlist found");
                    //        Console.Write("Command:  ");
                    //        break;
                    //    }
                    //    playlist.playlist=query.ToList();

                    //    Console.WriteLine("Playlist has been loaded from SQL-DataBase");
                    //}
                    Console.Write("Command:  ");
                    break;
                case "11":
                    string DeletePLfromDBQuery = ReadPlayListName();
                    using (var db = new BloggingContext())
                    {
                        IQueryable<Song> query = (db.Song.Where(b => b.PlayListName == DeletePLfromDBQuery));
                        if (query.Count() == 0)
                        {
                            Console.WriteLine("No playlist found");
                            Console.Write("Command:  ");
                            break;
                        }
                        db.Song.RemoveRange(query);
                        Console.WriteLine("Playlist has been deleted from SQL-DataBase");
                        db.SaveChanges();
                    }
                    Console.Write("Command:  ");
                    break;
                case "0":
                    active = false;
                    break;

                case "1": // search
                    Console.Write("Type in your request: ");
                    String[] searchRequest = Console.ReadLine().Split(" ");
                    foreach (var song in playlist.Search(searchRequest))
                    {
                        Console.WriteLine(song);
                    }
                    Console.Write("Command:  ");
                    break;
                case "2":  //show
                    Console.WriteLine("///////////////////////////////////////////////");
                    foreach (var song in playlist.Songs)
                    {
                        Console.WriteLine(song);
                    }
                    Console.WriteLine("///////////////////////////////////////////////");
                    Console.Write("Command:  ");
                    break;
                case "3":   //add
                    String a_add = ReadAuthor();
                    String t_add = ReadTitle();

                    if (playlist.AddSong(new Song(a_add, t_add)))
                    {
                        Console.WriteLine("Song was registred succsessfully");
                    }
                    else
                    {
                        Console.WriteLine("Song has already been added to playlist");
                    }

                    Console.Write("Command:  ");
                    break;
                case "4":    //delete
                    String a_delete = ReadAuthor();
                    String t_delete = ReadTitle();
                    String[] DeleteRequest = { a_delete, t_delete };
                    var songs = playlist.Search(DeleteRequest);
                    switch (songs.Count())
                    {
                        case 0:
                            Console.WriteLine("No song found");
                            break;
                        case > 1:
                            Console.WriteLine("More than 1 song found. Please, specify your request");
                            break;
                        default:
                            playlist.DeleteSong(songs.ElementAt(0));
                            Console.WriteLine("Song was deleted succsessfully");
                            break;
                    }
                    Console.Write("Command:  ");
                    break;
                default:
                    Console.WriteLine("Unidentified command. Please try again.");
                    Console.Write("Command:  ");
                    break;
            }
        }
        Console.WriteLine("<Shuting down...>");
        Console.WriteLine("Thank you");
    }
    public static String ReadAuthor()
    {
        Console.WriteLine("Type in author's name");
        String result = Console.ReadLine();
        while (result.Length == 0)
        {
            Console.WriteLine("Please, ensure you typed in the author's name");
            result = Console.ReadLine();
        }
        return result;
    }
    public static String ReadTitle()
    {
        Console.WriteLine("Type in title name");
        String result = Console.ReadLine();
        while (result.Length == 0)
        {
            Console.WriteLine("Please, ensure you typed in the title name");
            result = Console.ReadLine();
        }
        return result;
    }
    public static String ReadPlayListName()
    {
        Console.WriteLine("Type in the title of playlist");
        String result = Console.ReadLine();
        while (result.Length == 0)
        {
            Console.WriteLine("Please, ensure you typed in the title of playlist");
            result = Console.ReadLine();
        }
        return result;
    }
    public static String CreatePlayListName()
    {
        Console.WriteLine("Type in the title of playlist");
        String result = Console.ReadLine();
        while (result.Length == 0)
        {
            Console.WriteLine("Please, ensure you typed in the title of playlist");
            result = Console.ReadLine();
        }
        return result;
    }
}