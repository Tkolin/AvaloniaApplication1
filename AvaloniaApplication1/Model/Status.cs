namespace AvaloniaApplication1.Model;

public class Status
{
    public int ID { get; set; }
    public string Name { get; set; }


    public Status(int id, string name)
    {
        ID = id;
        Name = name;

    }
}