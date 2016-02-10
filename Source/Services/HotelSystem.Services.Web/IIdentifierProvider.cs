namespace HotelSystem.Services.Web
{
    public interface IIdentifierProvider
    {
        int DecodeId(string urlId);

        string EncodeId(int id);
    }
}
