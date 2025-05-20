using Microsoft.EntityFrameworkCore;

namespace SchoolProject.Core.Wrappers;

public static class QueryableExtensions
{
    public static async Task<PaginatedResult<T>> ToPaginatedListAsync<T>(this IQueryable<T> source, int pageNumber, int pageSize)
        where T : class
    {
        pageNumber = pageNumber <= 0 ? 1 : pageNumber;
        pageSize = pageSize <= 0 ? 10 : pageSize;
        int count = await source.AsNoTracking().CountAsync();
        if (count == 0)
            return new PaginatedResult<T>([], count, pageNumber, pageSize);

        pageNumber = pageNumber <= 0 ? 1 : pageNumber;
        var items = await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

        return new PaginatedResult<T>(items, count, pageNumber, pageSize);

    }
}