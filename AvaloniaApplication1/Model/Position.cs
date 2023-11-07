namespace AvaloniaApplication1.Model;

public class Position
{
    public int ID { get; set; }
    public string Name { get; set; }

    public Position(int id, string name)
    {
        ID = id;
        Name = name;
    }
}