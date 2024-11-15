using System;

namespace API.Helpers;

public class PaginationParams
{
    private const int MaxPageSize = 50;

    public int pageNumber { get; set; } = 1;

    private int _pageSize = 10;

    public int PageSize     //If a MaxPageSize isnt chose it'll use _pageSive instead
    {
        get => _pageSize;
        set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
    }

    
}
