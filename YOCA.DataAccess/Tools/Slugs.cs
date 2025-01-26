using System.Text.RegularExpressions;

namespace YOCA.DataAccess.Tools;

public static class Slugs
{
    public static string NewSlug(string title, int length = 150)
    {
        title = Regex.Replace(title, @"[^a-zA-Z0-9\s_\-]", "");
        string slug = title.ToLower().Replace(' ', '-');
        if (slug.Length >= length)
        {
            slug.Substring(0, length-1);
        } else {
            slug.Substring(0, slug.Length-1);
        }
        return slug;
    }

    public static string NewIdSlug(string title, string id, int length = 150)
    {
        title = Regex.Replace(title, @"[^a-zA-Z0-9\s_\-]", "");
        string slug = title.ToLower().Replace(' ', '-');
        if (slug.Length >= length)
        {
            slug.Substring(0, length - 1);
        }
        else
        {
            slug.Substring(0, slug.Length - 1);
        }
        slug = slug + "-" + id;
        return slug;
    }
}