namespace SubtitleRed.Domain.Lines;

public class Line : Entity
{
    public Line()
    {
        
    }
    
    public Line(string speaker, string text, Guid sectionId)
    {
        Speaker = speaker;
        Text = text;
        SectionId = sectionId;
    }

    public string Speaker { get; init; }

    public string Text { get; init; }

    public Guid SectionId { get; init; }
}