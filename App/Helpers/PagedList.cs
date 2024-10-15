namespace App.Helpers;

public class PagedResponse<T>
{
    public PagedResponse(IEnumerable<T> data, int total, int page, int pageSize)
    {
        Page = page;
        TotalPages = (int)Math.Ceiling(total / (double)pageSize);
        PageSize = pageSize;
        Total = total;
        Data = data;
    }

    public IEnumerable<T> Data { get; set; }
    public int Page { get; set; }
    public int PageSize { get; set; }
    public int Total { get; set; }
    public int TotalPages { get; set; }

    public static async Task<PagedResponse<T>> CreateAsync(IQueryable<T> source, int pageNumber,
        int pageSize)
    {
        var count = await source.CountAsync();
        var items = await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
        return new PagedResponse<T>(items, count, pageNumber, pageSize);
    }
}