using System.Collections;
using SubtitleRed.Shared;

namespace SubtitleRed.Domain.Locales;

public class LocalizedTextCollection : ILocalizedTextCollection
{
    public void Add(LocalizedText item) => AddLocalizedText(item);

    public void Clear() => _list.Clear();

    public bool Contains(LocalizedText item) => _list.Contains(item);

    public void CopyTo(LocalizedText[] array, int arrayIndex) => _list.CopyTo(array, arrayIndex);

    public bool Remove(LocalizedText item) => RemoveLocalizedText(item).IsSuccess;
    
    public int Count => _list.Count;
    
    public bool IsReadOnly => false;

    private readonly List<LocalizedText> _list;

    public LocalizedTextCollection(IEnumerable<LocalizedText> sections)
    {
        _list = new List<LocalizedText>(sections);
    }

    public LocalizedTextCollection()
    {
        _list = new List<LocalizedText>();
    }

    public IEnumerator<LocalizedText> GetEnumerator() => _list.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public Result<LocalizedText, Error> AddLocalizedText(LocalizedText section)
    {
        _list.Add(section);
        return Result<LocalizedText, Error>.Success(section);
    }
    
    public Result<LocalizedText, Error> RemoveLocalizedText(LocalizedText section)
    {
        _list.Remove(section);
        return Result<LocalizedText, Error>.Success(section);
    }

    public Result<LocalizedText, Error> GetTextByLocale(Locale locale)
    {
        var text = _list.SingleOrDefault(x => x.LocaleId == locale.Id);
        return text is not null
            ? Result<LocalizedText, Error>.Success(text)
            : Result<LocalizedText, Error>.Failure(Error.WithMessage("Text by locale not found."));
    }
}