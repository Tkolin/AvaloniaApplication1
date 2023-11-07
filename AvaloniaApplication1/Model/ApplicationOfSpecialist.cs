namespace AvaloniaApplication1.Model;

public class ApplicationOfSpecialist
{
    public int ID { get; set; }
    public string Massage { get; set; }
    public int StatusID { get; set; }
    public int ExecutionID { get; set; }

    public ApplicationOfSpecialist(int id, string massage, int statusID, int executionID)
    {
        ID = id;
        Massage = massage;
        StatusID = statusID;
        ExecutionID = executionID;
    }
}