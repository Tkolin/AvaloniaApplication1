namespace AvaloniaApplication1.Model;

public class Employee
{
    public int ID { get; set; }
    public string Password { get; set; }
    public string Login { get; set; }
    public string Name { get; set; }
    public int PositionID { get; set; }

    public Employee(int id, string name, int positionID, string login, string password)
    {
        ID = id;
        Name = name;
        PositionID = positionID;
        Login = login;
        Password = password;
    }
}