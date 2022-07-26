using System.Collections.Generic;

namespace QuinntyneBrown.Templating
{
    public interface ITemplateProcessor
    {
        string[] Process(string[] template, IDictionary<string, object> tokens, string[] ignoreTokens = null);
        string Process(string template, IDictionary<string, object> tokens);
    }
}