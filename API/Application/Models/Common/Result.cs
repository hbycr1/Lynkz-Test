namespace Application.Models.Common;

public class Result
{
    public virtual bool IsValid { get => Errors?.Any() != true; }
    public IEnumerable<string>? Errors { get; set; } = Enumerable.Empty<string>();
}

public class Result<T> : Result
{
    public T? Model { get; set; }
}

