namespace SubtitleRed.Domain.Lines;

public class Line : Entity
{
    public string Speaker { get; init; }

    public string Text { get; init; }

    public Guid SectionId { get; init; }
    
    public int LineOrder { get; init; }
}