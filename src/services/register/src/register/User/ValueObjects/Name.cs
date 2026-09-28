
namespace User.ValueObjects;

public record Name
{
    public string Value { get; }
    private Name(string value)
    {
        Value = value;
    }

    public static Name Of(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        { }
        return new Name(value);
    }
}
