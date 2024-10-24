namespace Wbx.Sample.Domain.Models;

public class Result   
{
   public bool IsSuccess { get; set; }
}

public class EditResult<T>: Result
{
    public T Id { get; set; }
}