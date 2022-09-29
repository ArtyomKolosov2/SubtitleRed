using SubtitleRed.Shared;
using SubtitleRed.Shared.Extensions;

namespace SubtitleRed.Domain;

public abstract class Entity
{
    private Guid _id;

    public Guid Id
    {
        get => _id;
        set => SetIdWithResult(value).OnError(result => throw new ArgumentException(result.Error!.Message));
    }

    public Result<Guid, Error> SetIdWithResult(Guid newId)
    {
        if (newId == Guid.Empty || _id != Guid.Empty)
            return Result<Guid, Error>.Failure(Error.WithMessage("Given id was empty or id was already set"));

        _id = newId;
        return Result<Guid, Error>.Success(newId);
    }
}