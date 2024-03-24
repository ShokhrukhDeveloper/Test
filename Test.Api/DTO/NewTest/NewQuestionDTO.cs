namespace Test.Api.DTO;

public class NewQuestionDTO
{
    public string Content { get; set; }
    public List<NewVariantDTO> Varinats { get; set; }
    
}