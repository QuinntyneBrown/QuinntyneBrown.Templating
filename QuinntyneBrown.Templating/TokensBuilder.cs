namespace QuinntyneBrown.Templating;

public class TokensBuilder
{
    private Dictionary<string, object> _value { get; set; } = new();

    public TokensBuilder()
    {
        _value = new();
    }
    public TokensBuilder With(string propertyName, Token token)
    {
        var tokens = token == null ? new Token("").ToTokens(propertyName) : token.ToTokens(propertyName);
        _value = new Dictionary<string, object>(_value.Concat(tokens));
        return this;
    }

    public Dictionary<string, object> Build() => _value;
}
