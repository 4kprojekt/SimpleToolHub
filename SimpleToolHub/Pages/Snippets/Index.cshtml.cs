using Markdig;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SimpleToolHub.Common;

namespace SimpleToolHub.Pages.Snippets
{
    public class IndexModel : PageModel
    {
        public required string SnippetName { get; set; }
        public required string SnippetDescription { get; set; }
        public required string SnippetCode { get; set; }
        public required string PublicationDate { get; set; }
        //meta tags
        public required string Description { get; set; }
        public required string Keywords { get; set; }
                   
        public required string Icon { get; set; }
        public void OnGet(string snippetname)
        {

            SnippetName = snippetname;
            //read the json file and get the snippet. using system.text.json
            var json = System.IO.File.ReadAllText(@"Common/CodeSnippetsDefinition.json");

            var snippets = System.Text.Json.JsonSerializer.Deserialize<CodeSnippetsDefinition>(json);
            //find the snippet
            var snippet = snippets.CodeSnippets.FirstOrDefault(s => s.Name == snippetname);
            if (snippet != null)
            {
                //load code file
                SnippetCode = System.IO.File.ReadAllText(snippet.CodeFile);
                //load md file
                SnippetDescription = Markdown.Parse(System.IO.File.ReadAllText(snippet.MDFile)).ToHtml();
                 PublicationDate  = snippet.PublicationDate;
                Description = snippet.Description;
                Keywords = snippet.Keywords;

                Icon = snippet.Icon;
                //if icon empty, use the default icon
                if (string.IsNullOrEmpty(Icon))
                {
                    Icon = "/icons/Snippet.jpg";
                }

            }
            else
            {
                //if not found, redirect to the 404 page
                Response.Redirect("/404");
            }
        }
    }
}

