public class Song
{
    public Song(string author, string title)
    {
        Author = author;
        Title = title;
    }
    public String Author { get; private set; }
    public String Title { get; private set; }

    public override String ToString()
    {
        return Author + " - " + Title;
    }
    public bool Equals(Song another)
    {
        return this.Author.Equals(another.Author, StringComparison.InvariantCultureIgnoreCase) &
               this.Title.Equals(another.Title, StringComparison.InvariantCultureIgnoreCase);
    }
}