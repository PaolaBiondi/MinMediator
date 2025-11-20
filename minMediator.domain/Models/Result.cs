namespace minMediator.domain;

public class Result<T>
{
    public T? Value { get; set; }

    public IReadOnlyCollection<Exception> Errors => _errors.AsReadOnly();

    private List<Exception> _errors = new List<Exception>();

    protected Result(T? value, Exception err )
    {
        IList<Exception> ex = new List<Exception>();
        if (err is not null)
            ex.Add(err);

        this.Value = value;
        _errors.AddRange(ex);
    }

    public static Result<T> Success(T value)
    {
        return new Result<T>(value, null!);
    }

    public static Result<T> Failure(Exception err)
    {
        return new Result<T>(default, err);
    }
}