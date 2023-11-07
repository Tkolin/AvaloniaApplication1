using System;

namespace AvaloniaApplication1.Model;

public class RepairRequest
{
    public int ID { get; set; }
    public int EquipmentTypeID { get; set; }
    public string SerialNumber { get; set; }
    public string ProblemDescription { get; set; }
    public DateTime CreatedDate { get; set; }
    public int ClientID { get; set; }
    public int Priority { get; set; }
    
    public RepairRequest(int id, int equipmentType, string serialNumber,
    string problemDescription, DateTime createdDate, int priority, int clientId)
    {
        ID = id;
        EquipmentTypeID = equipmentType;
        SerialNumber = serialNumber;
        ProblemDescription = problemDescription;
        CreatedDate = createdDate;
        Priority = priority;
        ClientID = clientId;
    }
}