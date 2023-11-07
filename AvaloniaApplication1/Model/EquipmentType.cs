namespace AvaloniaApplication1.Model;

public class EquipmentType
{
    public int ID { get; set; }
    public string Name { get; set; }


    public EquipmentType(int id, string name )
    {
        ID = id;
        Name = name;

    }
}