using SubtitleRed.Shared;

namespace SubtitleRed.Domain;

public abstract class Entity
{
    public Guid Id { get; protected set; }

    public Result<Guid, Error> SetId(Guid id)
    {
        if (id == Guid.Empty || Id != Guid.Empty)
            return Result<Guid, Error>.Failure(Error.WithMessage("Given id was empty or id was already set"));
        
        Id = id;
        return Result<Guid, Error>.Success(id);
    }
}