
namespace User.ValueObjects;

public record Email
{
    public string Value { get; }
    private Email(string value)
    {
        Value = value;
    }

    public static Email Of(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        { }
        return new Email(value);
    }
}