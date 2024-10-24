namespace Wbx.Sample.Application.Features;

public class EditResult<T>
{
    public T Id { get; set; }
    public bool IsSuccess { get; set; } = false;
}
