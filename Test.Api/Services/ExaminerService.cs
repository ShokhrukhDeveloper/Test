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

    public async ValueTask<Result<CheckedAnswerDTO>> CheckTest(CheckTestDTO checkTestDto)
    {
        var result =  await  storageBroker.GetResultById(checkTestDto.CheckerId);
        if (result == null)
        {
            return new(false)
            {
                ErrorMessage = "Test natijasini tekshirishda xatolik yuz siz uchun test yaratilmagan"
            };
        }
        var test = await storageBroker.GetByIdTestAsync(result.TestId);
        int correctAnswer = 0;
        List<QuestionResult> questionResults = new List<QuestionResult>();
        foreach (var question in test.Questions)
        {
            var selectedOptionId = checkTestDto.Answers.FirstOrDefault(q => q.QuestionId == question.Id).OptionId;
            var userOption = question.Options.FirstOrDefault(option=>option.Id==selectedOptionId);
            var correctOption = question.Options.FirstOrDefault(e => e.Correct);
            if (userOption!=null)
            {

                if (correctOption!=null)
                {
                    storageBroker.GetAllAnswer().Add(new Answer()
                    {
                        ResultId = result.Id,
                        OpionId = userOption.Id,
                        QuestionId = question.Id,
                        Correct = correctOption.Correct
                    });
                    questionResults.Add(new QuestionResult()
                    {
                        Correct = userOption.Correct,
                        SelectedOpion = new OptionResult()
                        {
                          Id = userOption.Id,
                          Content = userOption.Content,
                          Correct = userOption.Correct
                        },
                        CorrectOpionId = correctOption.Id,
                        CorrectOpion =  new OptionResult()
                        {
                            Content = correctOption.Content,
                            Id = correctOption.Id,
                            Correct = correctOption.Correct
                        }
                    });
                    if (userOption.Correct)correctAnswer++;
                }
            }

            result.Score = (int)(((double) correctAnswer / (double)checkTestDto.Answers.Count()));
            result.CompletedAt=DateTime.Now;
            result =  await  storageBroker.UpdateResult(result);
            await  storageBroker.SaveChangesAsync();
            
        }

        return new(true)
        {
            Data = new CheckedAnswerDTO()
            {
                Result = new DTO.CheckTest.Result()
                {
                    CompletedAt = result.CompletedAt,
                    StartedAt = result.StartedAt,
                    Score = result.Score,
                    CorrectAnswer = correctAnswer,
                    InCorrectAnswer =checkTestDto.Answers.Count() - correctAnswer
                },
                QuestionResults = questionResults
            }
        };
    }
    }
