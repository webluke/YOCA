using NanoidDotNet;

namespace YOCA.DataAccess.Tools;

public class Ids
{
    public static string NewId()
    {
        string id = Nanoid.Generate(size: 10);
        return id;
    }
}
