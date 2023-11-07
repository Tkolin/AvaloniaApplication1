using System;

namespace AvaloniaApplication1.Model;

public class Execution
{
    public int ID { get; set; }
    public int RequestID { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int ExecutorID { get; set; }
    public int StatusID { get; set; }

    public Execution(int id, int requestId, DateTime startDate, DateTime endDate
    , int executorId, int status)
    {
        ID = id;
        RequestID = requestId;
        StartDate = startDate;
        EndDate = endDate;
        ExecutorID = executorId;
        StatusID = status;
    }
}