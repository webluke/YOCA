using Ganss.Xss;
using Markdig;
using Markdig.Prism;

namespace YOCA.Fluent.Services;

public class MarkdigService : IMarkdownService
{
    private readonly MarkdownPipeline _pipeline;
    private readonly HtmlSanitizer _sanitizer;

    public MarkdigService()
    {
        _pipeline = new MarkdownPipelineBuilder()
            .UseAdvancedExtensions()
            .UsePrism()
            .UseBootstrap()
            .UseEmojiAndSmiley()
            .UseSoftlineBreakAsHardlineBreak()
            .Build();

        _sanitizer = CreateSanitizer();
    }

    public string Parse(string? markdown)
    {
        if (string.IsNullOrEmpty(markdown))
        {
            return string.Empty;
        }

        var html = Markdown.ToHtml(markdown, _pipeline);
        return _sanitizer.Sanitize(html);
    }

    private static HtmlSanitizer CreateSanitizer()
    {
        var sanitizer = new HtmlSanitizer();

        sanitizer.AllowedTags.Clear();
        foreach (var tag in new[]
        {
            "p", "br", "hr",
            "h1", "h2", "h3", "h4", "h5", "h6",
            "ul", "ol", "li",
            "strong", "em", "b", "i", "u", "s", "del", "ins", "mark", "sub", "sup",
            "blockquote", "pre", "code", "kbd", "samp",
            "a", "img",
            "table", "thead", "tbody", "tfoot", "tr", "th", "td",
            "div", "span", "figure", "figcaption",
            "dl", "dt", "dd",
            "abbr", "cite", "q"
        })
        {
            sanitizer.AllowedTags.Add(tag);
        }

        sanitizer.AllowedAttributes.Clear();
        foreach (var attr in new[]
        {
            "href", "src", "alt", "title", "class", "id",
            "width", "height", "colspan", "rowspan", "scope",
            "start", "reversed", "type"
        })
        {
            sanitizer.AllowedAttributes.Add(attr);
        }

        sanitizer.AllowedSchemes.Clear();
        sanitizer.AllowedSchemes.Add("http");
        sanitizer.AllowedSchemes.Add("https");
        sanitizer.AllowedSchemes.Add("mailto");

        sanitizer.AllowedCssProperties.Clear();

        return sanitizer;
    }
}
