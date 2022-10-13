using Microsoft.Extensions.Options;
using System.Reflection;

namespace QuinntyneBrown.Templating;


public class TemplateLocator : ITemplateLocator
{
    private readonly TemplateLocatorOptions _options;
    public TemplateLocator(IOptions<TemplateLocatorOptions> optionsAccessor)
    {
        _options = optionsAccessor.Value;
    }

    public string[] Get(string name)
    {
        foreach (Assembly _assembly in AppDomain.CurrentDomain.GetAssemblies().Where(x => x.GetName().FullName.Contains(_options.Namespace)).Distinct())
        {
            var resourceName = _assembly.GetManifestResourceNames().GetResourceName(name);

            if (!string.IsNullOrEmpty(resourceName))
            {
                return GetResource(_assembly, resourceName);
            }
        }

        throw new Exception("");
    }

    public string[] GetResource(Assembly assembly, string name)
    {
        var lines = new List<string>();

        using (var stream = assembly.GetManifestResourceStream(name))
        {
            using (var streamReader = new StreamReader(stream))
            {
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    lines.Add(line);
                }
            }
            return lines.ToArray();
        }
    }
}
