namespace AnimeList.Data;

internal class UnclassifiedContent : AContent
{
    //required for json deserialization
    public UnclassifiedContent() { }

    public override string Description()
    {
        throw new NotImplementedException();
    }
}
