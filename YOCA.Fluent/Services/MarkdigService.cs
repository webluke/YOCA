using Markdig;
using Markdig.Prism;

namespace YOCA.Fluent.Services;

public class MarkdigService : IMarkdownService
{
    private readonly MarkdownPipeline _pipeline;

    public MarkdigService()
    {
        _pipeline = new MarkdownPipelineBuilder()
            .UseAdvancedExtensions()
            .UsePrism()
            .UseBootstrap() 
            .UseEmojiAndSmiley() 
            .UseSoftlineBreakAsHardlineBreak() 
            .Build();
    }

    public string Parse(string markdown)
    {
        if (string.IsNullOrEmpty(markdown))
        {
            return string.Empty;
        }

        // Use the pre-built pipeline to convert Markdown to HTML.
        return Markdown.ToHtml(markdown, _pipeline);
    }
}