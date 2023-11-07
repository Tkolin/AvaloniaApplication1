namespace AvaloniaApplication1.Model;

public class Client
{
    public int ID { get; set; }
    public string Name { get; set; }
    public string PhoneNumber { get; set; }

    public Client(int id, string name, string phoneNumber)
    {
        ID = id;
        Name = name;
        PhoneNumber = phoneNumber;
    }
}