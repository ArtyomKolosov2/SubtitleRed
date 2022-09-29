using SubtitleRed.Shared;
using SubtitleRed.Shared.Extensions;

namespace SubtitleRed.Domain.Lines;

public class Line : Entity
{
    private int _lineOrder;
    
    public string Speaker { get; init; }

    public string Text { get; init; }

    public Guid SectionId { get; set; }

    public int LineOrder
    {
        get => _lineOrder;
        set => SetLineOrder(value).OnError(result => throw new ArgumentException(result.Error!.Message));
    }

    public Result<int, Error> SetLineOrder(int newOrder) => newOrder switch
    {
        <= 0 => Result<int, Error>.Failure(Error.WithMessage("Given order is less or equal to zero.")),
        _ when LineOrder is 0 => Result<int, Error>.Success(newOrder).Do(x => _lineOrder = newOrder),
        _ => Result<int, Error>.Failure(Error.WithMessage("Unexpected error during section order set."))
    };
}