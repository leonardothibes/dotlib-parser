namespace Dotlib.Parser
{
    public interface IParsable<T>
    {
        bool IsParsed();

        T GetParsed();
    }
}
