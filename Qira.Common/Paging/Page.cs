namespace Qira.Common.Paging;

/// <summary>
/// Page of data items.
/// </summary>
/// <typeparam name="T">Data item type.</typeparam>
public class Page<T>
{
    /// <summary>
    /// Items.
    /// </summary>
    public ICollection<T> Items { get; set; }

    /// <summary>
    /// Page number.
    /// </summary>
    public int CurrentPage { get; set; }

    /// <summary>
    /// Page size.
    /// </summary>
    public int PageSize { get; set; }

    /// <summary>
    /// Total items count.
    /// </summary>
    public int TotalCount { get; set; }

    /// <summary>
    /// Total pages.
    /// </summary>
    public int TotalPages { get; set; }

    /// <summary>
    /// Gas previous.
    /// </summary>
    public bool HasPrevious => CurrentPage > 1;

    /// <summary>
    /// Has next.
    /// </summary>
    public bool HasNext => CurrentPage < TotalPages;
}