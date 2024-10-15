using System.Text.Json;


namespace App.Extensions;

public static class HttpExtensions
{
    public static void AddPaginationHeader(this HttpResponse response, int page,
                int pageSize, int total, int totalPages)
    {
        var paginationHeader = new PaginationHeader(page, pageSize, total, totalPages);

        var options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        response.Headers.Append("Pagination", JsonSerializer.Serialize(paginationHeader, options));
        response.Headers.Append("Access-Control-Expose-Headers", "Pagination");
    }
}
