using NUnit.Framework;

namespace Rubiks.Test;

public class DeserializerTests
{
    [Test]
    public void DeserializesInitialState()
    {
        const string initialState = "WWWWWWWWWOOOOOOOOOGGGGGGGGGRRRRRRRRRBBBBBBBBBYYYYYYYYY";
        var deserializer = new Deserializer();
        var cube = deserializer.Convert(initialState);

        Assert.AreEqual(new Cube(), cube);
    }
}