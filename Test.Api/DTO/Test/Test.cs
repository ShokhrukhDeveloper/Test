namespace Test.Api.DTO.Test;

public class Test
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public virtual ICollection<Question> Questions{ get; set; }
}