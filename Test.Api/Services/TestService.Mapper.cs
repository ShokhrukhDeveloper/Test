using Test.Api.DTO.Test;
using Option = Test.Api.Entities.Option;
using Question = Test.Api.Entities.Question;

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
            Image = "",
            Options = questionDto.Varinats.Select(ToEntity).ToList()
        };

    Entities.Option ToEntity(DTO.NewVariantDTO variantDto)
        => new()
        {
            Content = variantDto.Content,
            Correct = variantDto.Correct
        };

    TestDetails ToTestDetails(Entities.Test test)
        => new()
        {
            TestId = test.Id,
            Name = test.Name,
            Description = test.Description
        };

    DTO.Test.Test ToDTO(Entities.Test test)
    {
        if (test.Questions != null)
            return new()
            {
                TestId = test.Id,
                Name = test.Name,
                Description = test.Description,
                Questions = test.Questions.Select(ToDTO).ToList()
            };
        return new DTO.Test.Test();
    }

    private DTO.Test.Question ToDTO(Question question)
    {
        if (question.Options != null)
            return new DTO.Test.Question()
            {
                Id = question.Id,
                TestId = question.TestId,
                Content = question.Content,
                Options = question.Options.Select(ToDTO).ToList()
            };
        return new DTO.Test.Question();
    }

    private DTO.Test.Option ToDTO(Option option)
        => new DTO.Test.Option()
        {
            Id = option.Id,
            QuestionId = option.QuestionId,
            Content = option.Content
        };
}