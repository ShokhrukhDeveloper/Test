namespace Test.Api.Constants;

public  class JwtConst
{
    public JwtConst()
    {
    
    }
    public JwtConst(int Id,string Role)
    {
        this.Id=Id;
       // this.Role=Role;
    }
    public int Id { get; set; }  
    //public string? Role { get; set; }  
}
public static class Roles
{
    public const string Student="Student";
    public const string SuperAdmin="SuperAdmin";
}