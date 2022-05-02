namespace Rubiks;

public interface IConverter<in TIn, out TOut>
{
    TOut Convert(TIn state);
}