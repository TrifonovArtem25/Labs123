using System.Diagnostics;
class Program
{
    static void Main(string[] args)
    {
        PlayList playlist = new PlayList();
        Song snow = new Song("Red Hot Chili Peppers", "Snow");
        // if ("abcdef".Contains("Cde", StringComparison.InvariantCultureIgnoreCase))
        // {
        //     Console.WriteLine("hh");
        // }
        playlist.AddSong(new Song("Red Hot Chili Peppers", "Snow"));

        playlist.AddSong(new Song("Green Day", "American Idiot"));
        playlist.AddSong(new Song("Oasis", "WonderWall"));
        playlist.AddSong(new Song("Linkin Park", "Somewhere I Belong"));
        bool active = true;
        Console.WriteLine("Usage:");
        Console.WriteLine("'search' to find a song");
        Console.WriteLine("'show' to overview full playlist");
        Console.WriteLine("'add' to add new song");
        Console.WriteLine("'delete' to delete song");
        Console.WriteLine("'quit' to exit");
        Console.Write("Command:  ");
        while (active)
        {
            String command = Console.ReadLine();
            switch (command)
            {
                case "quit":
                    active = false;
                    break;

                case "search":
                    Console.Write("Type in your request: ");
                    String[] searchRequest = Console.ReadLine().Split(" ");
                    foreach (var song in playlist.Search(searchRequest))
                    {
                        Console.WriteLine(song);
                    }
                    Console.Write("Command:  ");
                    break;

                case "add":
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
                case "show":
                    foreach (var song in playlist.Songs)
                    {
                        Console.WriteLine(song);
                    }
                    Console.Write("Command:  ");
                    break;
                case "delete":

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
}

