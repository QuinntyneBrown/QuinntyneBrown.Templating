namespace QuinntyneBrown.Templating;

internal class TemplateRenderer : ITemplateRenderer
{
    private readonly ITemplateProcessor _templateProcessor;
    private readonly ITemplateLocator _templateLocator;

    public TemplateRenderer(ITemplateLocator templateLocator, ITemplateProcessor templateProcessor)
    {
        _templateLocator = templateLocator ?? throw new ArgumentNullException(nameof(templateLocator));
        _templateProcessor = templateProcessor ?? throw new ArgumentNullException(nameof(templateProcessor));
    }

    public string[] Render(string templateName, Dictionary<string, object> tokens)
    {
        var template = _templateLocator.Get(templateName);
        return _templateProcessor.Process(template, tokens);
    }
}
