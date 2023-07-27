namespace Domain.Utils;

public class PagedList<T> : List<T>
{
    public int Page { get; private set; }
    public int TotalPages { get; private set; }

    public PagedList(IEnumerable<T> items, int count, int page, int itemsPerPage)
    {
        Page = page;
        TotalPages = (int)Math.Ceiling(count / (double)itemsPerPage);
        AddRange(items);
    }
}