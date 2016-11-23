using SQLite.Net.Interop;

namespace YKWP
{
    public interface IConfig
    {
        string DirectoryDB { get; }
        ISQLitePlatform Plataforma { get; }
    }
}
