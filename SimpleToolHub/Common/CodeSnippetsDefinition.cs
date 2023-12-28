namespace SimpleToolHub.Common
{
    public class CodeSnippetsDefinition
    {
        public CodeSnippet[] CodeSnippets { get; set; }

    }

    public class CodeSnippet
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string CodeFile { get; set; }
        public string MDFile { get; set; }
        public string Keywords { get; set; }
        public string Icon { get; set; }
        public string PublicationDate { get; set; }

    }
}
