namespace QuinntyneBrown.Templating
{
    public static class StringListExtensions
    {
        public static string GetResourceName(this string[] collection, string name)
            => collection.SingleOrDefault(x => x.EndsWith(name)) == null ?
                collection.SingleOrDefault(x => x.EndsWith($".{name}.txt"))
                : collection.SingleOrDefault(x => x.EndsWith(name));
    }
}