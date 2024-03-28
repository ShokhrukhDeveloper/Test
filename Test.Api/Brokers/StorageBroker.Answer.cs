using Microsoft.EntityFrameworkCore;
using Test.Api.Entities;

namespace Test.Api.Brokers;

public partial class StorageBroker
{
    public async ValueTask<Answer> CreateAnswer(Answer answer)
    {
        var result =  _dbContext.Answers.Add(answer);
        await _dbContext.SaveChangesAsync();
        return result.Entity;
    }

    public async ValueTask<Answer> UpdateAnswer(Answer answer)
    {
        var result =  _dbContext.Answers.Update(answer);
        await _dbContext.SaveChangesAsync();
        return result.Entity;
    }

    public async ValueTask<Answer> RemoveAnswer(Answer answer)
    {
        var result =  _dbContext.Answers.Remove(answer);
        await _dbContext.SaveChangesAsync();
        return result.Entity;
    }

    public async ValueTask<Answer> GetAnswerById(int id)
        => await _dbContext.Answers.FirstOrDefaultAsync(i=>i.Id==id);


    public IQueryable<Answer> GetAllAnswer()
        => _dbContext.Answers;
}