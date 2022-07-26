namespace QuinntyneBrown.Templating
{
    public interface ITemplateRenderer
    {
        string[] Render(string templateName, Dictionary<string, object> tokens);
    }
}
