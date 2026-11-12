namespace YOCA.Fluent.Tools;

public static class UrlValidation
{
    /// <summary>
    /// Allows same-site relative paths (/...) or http(s) absolute URLs. Rejects javascript:, data:, etc.
    /// </summary>
    public static bool IsAllowedLinkUrl(string? url)
    {
        if (string.IsNullOrWhiteSpace(url))
        {
            return false;
        }

        url = url.Trim();

        if (url.StartsWith('/') && !url.StartsWith("//", StringComparison.Ordinal))
        {
            return !url.Any(char.IsControl);
        }

        if (!Uri.TryCreate(url, UriKind.Absolute, out var absolute))
        {
            return false;
        }

        return string.Equals(absolute.Scheme, Uri.UriSchemeHttps, StringComparison.OrdinalIgnoreCase)
            || string.Equals(absolute.Scheme, Uri.UriSchemeHttp, StringComparison.OrdinalIgnoreCase);
    }
}
