using SubtitleRed.Domain.Lines;
using SubtitleRed.Shared;
using SubtitleRed.Shared.Extensions;

namespace SubtitleRed.Domain.Sections;

public class Section : Entity
{
    private int _sectionOrder;
    
    public LineCollection Lines { get; init; }

    public string Name { get; init; }

    public Guid SceneId { get; set; }

    public int SectionOrder
    {
        get => _sectionOrder;
        set => SetSectionOrder(value).OnError(result => throw new ArgumentException(result.Error!.Message));
    }

    public Result<int, Error> SetSectionOrder(int newOrder) => newOrder switch
    {
        <= 0 => Result<int, Error>.Failure(Error.WithMessage("Given order is less or equal to zero.")),
        _ when SectionOrder is 0 => Result<int, Error>.Success(newOrder).Do(x => _sectionOrder = newOrder),
        _ => Result<int, Error>.Failure(Error.WithMessage("Unexpected error during section order set."))
    };
}