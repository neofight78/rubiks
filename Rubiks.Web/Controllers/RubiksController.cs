using Microsoft.AspNetCore.Mvc;

namespace Rubiks.Web.Controllers;

[Route("[controller]/[action]")]
[ApiController]
public class RubiksController : ControllerBase
{
    private readonly IConverter<string, ICube> _deserializer;
    private readonly IConverter<ICube, string> _serializer;

    public RubiksController(IConverter<string, ICube> deserializer, IConverter<ICube, string> serializer)
    {
        _deserializer = deserializer;
        _serializer = serializer;
    }

    [HttpGet]
    public string Rotate(string state, Face face, Direction direction)
    {
        var cube = _deserializer.Convert(state);
        cube.Rotate(new Rotation(face, direction));
        return _serializer.Convert(cube);
    }
}