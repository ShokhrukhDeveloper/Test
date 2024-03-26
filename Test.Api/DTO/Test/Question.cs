namespace Test.Api.DTO.Test;

public class Question
{
    public int Id { get; set; }
    public int TestId { get; set; }
    public string Content { get; set; }
    public virtual ICollection<Option> Options { get; set; }
}