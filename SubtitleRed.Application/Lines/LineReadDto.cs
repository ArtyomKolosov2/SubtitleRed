namespace SubtitleRed.Application.Lines;

public class LineReadDto
{
    public Guid Id { get; set; }
    
    public string? Speaker { get; set; }

    public string? Text { get; set; }

    public Guid SectionId { get; set; }
    
    public int LineOrder { get; set; }
}