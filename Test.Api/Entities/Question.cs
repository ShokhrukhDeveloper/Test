namespace Test.Api.Entities;

public class Question
{
    public int Id { get; set; }
    public int TestId { get; set; }
    public Test? Test { get; set; }
    public string Content { get; set; }
    public string? Image { get; set; }
    public virtual ICollection<Option>? Options { get; set; }
} 