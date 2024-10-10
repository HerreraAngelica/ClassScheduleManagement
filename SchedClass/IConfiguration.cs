namespace BusinessLayer
{
    public interface IConfiguration
    {
        object GetSection(string v);
    }
}