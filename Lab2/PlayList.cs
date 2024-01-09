public class PlayList
{
    private List<Song> playlist;
    public PlayList()
    {
        this.playlist = new List<Song>();
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

    public bool DeleteSong(Song songsToDelete)
    {
        foreach (var song in playlist)
        {
            if (songsToDelete.Equals(song))
            {
                playlist.Remove(song);
                return true;
            }
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
    public IEnumerable<Song> Songs
    {
        get { return playlist; }
    }
}