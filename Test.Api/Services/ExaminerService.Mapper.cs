using Test.Api.Entities;

namespace Test.Api.Services;

public partial class ExaminerService
{
    private DTO.Test.Question ToDTO(Question question)
        => new DTO.Test.Question()
        {
            Content = question.Content,
            Id = question.Id,
            TestId = question.TestId,
            Options = question.Options!.Select(ToDTO).ToList()
        };

    private DTO.Test.Option ToDTO(Option option)
        => new DTO.Test.Option()
        {
            Content = option.Content,
            Id = option.Id,
            QuestionId = option.QuestionId
        };
}