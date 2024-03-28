using Microsoft.EntityFrameworkCore;
using Test.Api.Brokers;
using Test.Api.DTO;
using Test.Api.DTO.CheckTest;
using Test.Api.Entities;
using Question = Test.Api.DTO.Test.Question;
using Result = Test.Api.Entities.Result;


namespace Test.Api.Services;

public partial class ExaminerService : IExaminerService
{
    private readonly IStorageBroker storageBroker;
   
    public ExaminerService(IStorageBroker storageBroker)
    {
        this.storageBroker = storageBroker;
    }
    public async ValueTask<DTO.CheckTest.TestStartDTO> StartTest(int userId, int testId, int? numberOfTest=null)
    {
        var test =  await  storageBroker.GetByIdTestAsync(testId);
       var resul= await storageBroker.CreateResult(new Result()
        {
            Score = 0,
            TestId = testId,
            UserId = userId,
            StartedAt = DateTime.Now
        });
       
       return new  ()
       {
            TimeAllowed = test.TimeAllowed,
            Description = test.Description,
            Name = test.Name,
            CheckerId = resul.Id,
            Questions   = test.Questions.Select(ToDTO).ToList()
       };
    }

    public async ValueTask<CheckedAnswerDTO> CheckTest(CheckTestDTO checkTestDto)
    {
        var result =  await  storageBroker.GetResultById(checkTestDto.CheckerId);
        var test = await storageBroker.GetByIdTestAsync(result.TestId);
        int correctAnswer = 0;
        List<Answer> answers = new List<Answer>();
        List<QuestionResult> questionResults = new List<QuestionResult>();
        foreach (var question in test.Questions)
        {
            var selectedOptionId = checkTestDto.Answers.FirstOrDefault(q => q.QuestionId == question.Id).OptionId;
            var userOption = question.Options.FirstOrDefault(option=>option.Id==selectedOptionId);
            var correctOption = question.Options.FirstOrDefault(e => e.Correct);
            if (userOption!=null)
            {

                    if (userOption.Correct)correctAnswer++;
                    answers.Add(new Answer()
                    {
                       TestId = test.Id,
                       ResultId = result.Id,
                       SelectedOpionId = userOption.Id,
                       QuestionId = userOption.Id,
                       CorrectOpionId = correctOption.Id,
                       Correct = userOption.Correct
                    });
                    questionResults.Add(new QuestionResult()
                    {
                        Id = question.Id,
                        Correct = userOption.Correct,
                        SelectedOpion = new OptionResult()
                        {
                          Id = userOption.Id,
                          Content = userOption.Content
                        },
                        CorrectOpionId = correctOption.Id,
                        CorrectOpion =  new OptionResult()
                        {
                            Content = correctOption.Content,
                            Id = correctOption.Id
                        }
                    });
                    
               
            }

            result.Score = (int)(((double) correctAnswer / (double)answers.Count())* 100);
            
            
            
            result.CompletedAt=DateTime.Now;
            storageBroker.GetAllAnswer().AddRange(answers);
            result =  await  storageBroker.UpdateResult(result);
            
            // await  storageBroker.SaveChangesAsync();
        }

        return new CheckedAnswerDTO()
        {
            Result = new DTO.CheckTest.Result()
            {
              CompletedAt  = result.CompletedAt,
              StartedAt = result.StartedAt,
              Score = result.Score,
              CorrectAnswer = correctAnswer,
              InCorrectAnswer = answers.Count()-correctAnswer
            },
            QuestionResults = questionResults
        };
    }
}