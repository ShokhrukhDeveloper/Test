using Microsoft.EntityFrameworkCore;
using Test.Api.Entities;

namespace Test.Api.Brokers;

public partial interface IStorageBroker
{
    ValueTask<Answer> CreateAnswer(Answer answer);
    ValueTask<Answer> UpdateAnswer(Answer answer);
    ValueTask<Answer> RemoveAnswer(Answer answer);
    ValueTask<Answer> GetAnswerById(int id);
    DbSet<Answer> GetAllAnswer();
}