namespace AvaloniaApplication1.Model;

public class Report
{
    public int ID { get; set; }

    public int TimeSpent { get; set; }
    public decimal Costs { get; set; }
    public string FailureReason { get; set; }
    public string AssistanceProvided { get; set; }
    public int RequestID { get; set; }
    
    public Report(int id, int timeSpent,
        decimal costs, string failureReason, string assistanceProvided, int requestID)
    {
        ID = id;

        TimeSpent = timeSpent;
        Costs = costs;
        FailureReason = failureReason;
        AssistanceProvided = assistanceProvided;
        RequestID = requestID;
    }
}