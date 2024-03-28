namespace Test.Api.Services;

public partial class TestService
{
    Entities.Test ToEntity(DTO.NewTestDTO testDto)
        => new()
        {
            Name = testDto.TestName,
            Description = testDto.Description,
            Questions = testDto.Questions.Select(ToEntity).ToList()
        };

    Entities.Question ToEntity(DTO.NewQuestionDTO questionDto)
        => new()
        {
            Content = questionDto.Content,
            TimeAllowed = questionDto.TimeAllowed,
            Image = "",
            Options = questionDto.Varinats.Select(ToEntity).ToList()
        };

    Entities.Option ToEntity(DTO.NewVariantDTO variantDto)
        => new()
        {
            Content = variantDto.Content,
            Correct = variantDto.Correct
        };

}