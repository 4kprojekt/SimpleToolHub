namespace SimpleToolHub.Common
{
   
    public class ToolsDefinition
    {
        public Tool[] tools { get; set; }
    }

    public class Tool
    {
        public string name { get; set; }
        public string description { get; set; }
        public string url { get; set; }
        public string icon { get; set; }
    }

}
