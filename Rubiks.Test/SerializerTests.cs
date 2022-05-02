using NUnit.Framework;

namespace Rubiks.Test;

public class SerializerTests
{
    [Test]
    public void SerializesInitialState()
    {
        var cube = new Cube();
        var serializer = new Serializer();
        var state = serializer.Convert(cube);

        Assert.AreEqual("WWWWWWWWWOOOOOOOOOGGGGGGGGGRRRRRRRRRBBBBBBBBBYYYYYYYYY", state);
    }
}