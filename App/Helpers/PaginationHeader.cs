namespace App.Helpers;

public class PaginationHeader
{
    public PaginationHeader(int page, int pageSize, int total, int totalPages)
    {
        Page = page;
        PageSize = pageSize;
        Total = total;
        TotalPages = totalPages;
    }

    public int Page { get; set; }
    public int PageSize { get; set; }
    public int Total { get; set; }
    public int TotalPages { get; set; }
}
