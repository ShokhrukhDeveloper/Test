namespace Test.Api.DTO.Test;

public class Test
{
    public int TestId { get; set; }
    public int  CheckerId { get; set; }
    public string Name { get; set; }
    
    public string Description { get; set; }
    public virtual ICollection<Question> Questions{ get; set; }
}