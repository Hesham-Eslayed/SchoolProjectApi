namespace SchoolProject.Core.Wrappers;

public class PaginatedResult<T>
{
    public PaginatedResult(List<T> data)
    {
        Data = data;
    }


    internal PaginatedResult(List<T>? data = default, int count = 0, int page = 1, int pageSize = 10, List<string>? messages = null)
    {
        Data = data;
        CurrentPage = page;
        Succeeded = true;
        PageSize = pageSize;
        TotalPages = (int)Math.Ceiling(count / (double)pageSize);
        TotalCount = count;
    }

    public List<T>? Data { get; set; }

    public int CurrentPage { get; set; }

    public int TotalPages { get; set; }

    public int TotalCount { get; set; }

    public object? Meta { get; set; }

    public int PageSize { get; set; }

    public bool HasPreviousPage => CurrentPage > 1;

    public bool HasNextPage => CurrentPage < TotalPages;

    public List<string> Messages { get; set; } = [];

    public bool Succeeded { get; set; }
}