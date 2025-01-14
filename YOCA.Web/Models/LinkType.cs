namespace YOCA.Web.Models
{
    public class LinkTarget
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
    }

    public class LinkTargets
    {
        public Dictionary<int, LinkTarget> DefaultLinkTargets = new();
        public LinkTargets()
        {
            DefaultLinkTargets.Add(0, new LinkTarget { Id = 0, Name = "Default", Code = "" });
            DefaultLinkTargets.Add(1, new LinkTarget { Id = 1, Name = "New Window", Code = "_blank" });
        }
    }
}
