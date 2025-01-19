using System.Text.RegularExpressions;

namespace YOCA.DataAccess.Tools;

public static class Slugs
{
    public static string NewSlug(string title, int length = 150)
    {
        title = Regex.Replace(title, @"[^a-zA-Z0-9\s_\-]", "");
        string slug = title.ToLower().Replace(' ', '-');
        slug.Substring(0, length);
        return slug;
    }

    public static string NewIdSlug(string title, string id, int length = 150)
    {
        title = Regex.Replace(title, @"[^a-zA-Z0-9\s_\-]", "");
        string slug = title.ToLower().Replace(' ', '-');
        slug.Substring(0, length);
        slug = slug + "-" + id;
        return slug;
    }
}