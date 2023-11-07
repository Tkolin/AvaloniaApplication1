using System;
using System.Collections.Generic;
using Avalonia.Media;
using AvaloniaApplication1.Model;
using MsBox.Avalonia;
using MsBox.Avalonia.Enums;
using MySqlConnector;

namespace AvaloniaApplication3.Model;

public static class DataBaseManager
{

    /// Настройки подключения
    public static MySqlConnectionStringBuilder ConnectionString =
            new MySqlConnectionStringBuilder
            {
                Server = "localhost",
                Database = "mdk",
                UserID = "root",
                Password = "tkl909"// "tkl909"//"nrjkby99"
            };
    // Локальная база данных


    
    // Получение
    public static List<ApplicationOfSpecialist> GetApplicationOfSpecialists()
    {
        List<ApplicationOfSpecialist> data = new List<ApplicationOfSpecialist>();

        using (var connection = new MySqlConnection(ConnectionString.ConnectionString))
        {
            connection.Open();

            using (var comand = connection.CreateCommand())
            {
                comand.CommandText = "SELECT * FROM заявки_от_специалистов";

                using (var reader = comand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        data.Add(
                            new ApplicationOfSpecialist(
                                reader.GetInt32("ID"),
                                reader.GetString("Содержание"),
                                reader.GetInt32("ID_Статус"),
                                reader.GetInt32("ID_Исполняемая_заявка")));
                    }
                }
            }
            connection.Close();
        }
        return data;
    }
    public static List<Client> GetClients()
    {
        List<Client> data = new List<Client>();

        using (var connection = new MySqlConnection(ConnectionString.ConnectionString))
        {
            connection.Open();

            using (var comand = connection.CreateCommand())
            {
                comand.CommandText = "SELECT * FROM клиенты";

                using (var reader = comand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        data.Add(
                            new Client(
                                reader.GetInt32("ID"),
                                reader.GetString("Имя"),
                                reader.GetString("Номер_телефона")));
                    }
                }
            }
            connection.Close();
        }
        return data;
    }
    public static List<Employee> GetEmployees()
    {
        List<Employee> data = new List<Employee>();

        using (var connection = new MySqlConnection(ConnectionString.ConnectionString))
        {
            connection.Open();

            using (var comand = connection.CreateCommand())
            {
                comand.CommandText = "SELECT * FROM сотрудники";

                using (var reader = comand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        data.Add(
                            new Employee(
                                reader.GetInt32("ID"),
                                reader.GetString("Имя"),
                                reader.GetInt32("ID_Должность"),
                                reader.GetString("Логин"),
                                reader.GetString("Пароль")));
                    }
                }
            }
            connection.Close();
        }
        return data;
    }
    public static List<EquipmentType> GetEquipmentTypes()
    {
        List<EquipmentType> data = new List<EquipmentType>();

        using (var connection = new MySqlConnection(ConnectionString.ConnectionString))
        {
            connection.Open();

            using (var comand = connection.CreateCommand())
            {
                comand.CommandText = "SELECT * FROM тип_оборудования";

                using (var reader = comand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        data.Add(
                            new EquipmentType(
                                reader.GetInt32("ID"),
                                reader.GetString("Название")));
                    }
                }
            }
            connection.Close();
        }
        return data;
    }
    public static List<Execution> GetExecutions()
    {
        List<Execution> data = new List<Execution>();

        using (var connection = new MySqlConnection(ConnectionString.ConnectionString))
        {
            connection.Open();

            using (var comand = connection.CreateCommand())
            {
                comand.CommandText = "SELECT * FROM исполнение_заявок";

                using (var reader = comand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        data.Add(
                            new Execution(
                                reader.GetInt32("ID"),
                                reader.GetInt32("ID_заявки"),
                                reader.GetDateTime("Дата_начала"),
                                reader.GetDateTime("Дата_окончания"),
                                reader.GetInt32("Исполнитель"),
                                reader.GetInt32("ID_Статус")));
                    }
                }
            }
            connection.Close();
        }
        return data;
    }
    public static List<Position> GetCPositions()
    {
        List<Position> data = new List<Position>();

        using (var connection = new MySqlConnection(ConnectionString.ConnectionString))
        {
            connection.Open();

            using (var comand = connection.CreateCommand())
            {
                comand.CommandText = "SELECT * FROM должность";

                using (var reader = comand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        data.Add(
                            new Position(
                                reader.GetInt32("ID"),
                                reader.GetString("Название")));
                    }
                }
            }
            connection.Close();
        }
        return data;
    }
    public static List<RepairRequest> GetCRepairRequests()
    {
        List<RepairRequest> data = new List<RepairRequest>();

        using (var connection = new MySqlConnection(ConnectionString.ConnectionString))
        {
            connection.Open();

            using (var comand = connection.CreateCommand())
            {
                comand.CommandText = "SELECT * FROM заявки_на_ремонт";

                using (var reader = comand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        data.Add(
                            new RepairRequest(
                                reader.GetInt32("ID"),
                                reader.GetInt32("ID_Тип_оборудования"),
                                reader.GetString("Серийный_номер"),
                                reader.GetString("Описание_проблемы"),
                                reader.GetDateTime("Дата_создания"),
                                reader.GetInt32("Приоритет"),
                                reader.GetInt32("ID_клиента")));
                    }
                }
            }
            connection.Close();
        }
        return data;
    }
    public static List<Report> GetReports()
    {
        List<Report> data = new List<Report>();

        using (var connection = new MySqlConnection(ConnectionString.ConnectionString))
        {
            connection.Open();

            using (var comand = connection.CreateCommand())
            {
                comand.CommandText = "SELECT * FROM отчёты_о_ремонте";

                using (var reader = comand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        data.Add(
                            new Report(
                                reader.GetInt32("ID"),
                                reader.GetInt32("Затраченное_время"),
                                reader.GetInt32("Затраты"),
                                reader.GetString("Причина_неисправности"),
                                reader.GetString("Помощь_оказана"),
                                reader.GetInt32("ID_Заявки")));
                    }
                }
            }
            connection.Close();
        }
        return data;
    }
    public static List<Status> GetStatuse()
    {
        List<Status> data = new List<Status>();

        using (var connection = new MySqlConnection(ConnectionString.ConnectionString))
        {
            connection.Open();

            using (var comand = connection.CreateCommand())
            {
                comand.CommandText = "SELECT * FROM статус";

                using (var reader = comand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        data.Add(
                            new Status(
                                reader.GetInt32("ID"),
                                reader.GetString("Название")));
                    }
                }
            }
            connection.Close();
        }
        return data;
    }
    /// Добавление
    public static void AddApplicationOfSpecialist (ApplicationOfSpecialist data)
    {
        using (var connection = new MySqlConnection(ConnectionString.ConnectionString))
                {
                    connection.Open();
        
                    using (var comand = connection.CreateCommand())
                    {
                        comand.CommandText = "INSERT INTO заявки_от_специалистов" +
                                             " (Содержание, ID_Статус, ID_Исполняемая_заявка) "+
                                             "VALUES (@Содержание, @ID_Статус, @ID_Исполняемая_заявка);";

                        comand.Parameters.AddWithValue("@Содержание", data.Massage);
                        comand.Parameters.AddWithValue("@ID_Статус", data.StatusID);
                        comand.Parameters.AddWithValue("@ID_Исполняемая_заявка", data.ExecutionID);

                        var rowsCount = comand.ExecuteNonQuery();

                        if (rowsCount == 0)
                        {
                            MessageBoxManager.GetMessageBoxStandard("Ошибка", "Данные не добавлены",ButtonEnum.Ok).ShowAsync();;
                        }
                    }
                    connection.Close();
                }
    }
    public static void AddClients(Client data)
    {
        using (var connection = new MySqlConnection(ConnectionString.ConnectionString))
        {
            connection.Open();
        
            using (var comand = connection.CreateCommand())
            {
                comand.CommandText = "INSERT INTO клиенты (Имя, Номер_телефона) "+
                                     "VALUES (@Имя, @Номер_телефона);";

                comand.Parameters.AddWithValue("@Имя", data.Name);
                comand.Parameters.AddWithValue("@Номер_телефона", data.PhoneNumber); 
               
                var rowsCount = comand.ExecuteNonQuery();

                if (rowsCount == 0)
                {
                    MessageBoxManager.GetMessageBoxStandard("Ошибка", "Данные не добавлены",ButtonEnum.Ok).ShowAsync();;
                }
            }
            connection.Close();
        }
    }

    public static void AddExecutions(Execution data)
    {
        using (var connection = new MySqlConnection(ConnectionString.ConnectionString))
        {
            connection.Open();
        
            using (var comand = connection.CreateCommand())
            {
                comand.CommandText = "INSERT INTO исполнение_заявок" +
                                     " (ID_заявки, Дата_начала, Дата_окончания, Исполнитель, ID_Статус) "+
                                     "VALUES (@ID_заявки, @Дата_начала, @Дата_окончания, @Исполнитель, @ID_Статус);";

                comand.Parameters.AddWithValue("@ID_заявки", data.RequestID);
                comand.Parameters.AddWithValue("@Дата_начала", data.StartDate.ToString("dd.MM.yyyy"));
                comand.Parameters.AddWithValue("@Дата_окончания", data.EndDate.ToString("dd.MM.yyyy"));
                comand.Parameters.AddWithValue("@Исполнитель", data.ExecutorID);
                comand.Parameters.AddWithValue("@ID_Статус", data.StatusID);

                var rowsCount = comand.ExecuteNonQuery();

               // if (rowsCount == 0)
               // {
               //     MessageBoxManager.GetMessageBoxStandard("Ошибка", "Данные не добавлены",ButtonEnum.Ok).ShowAsync();;
               // }
            }
            connection.Close();
        }
    }

    public static void AddRepairRequests(RepairRequest data)
    {
        using (var connection = new MySqlConnection(ConnectionString.ConnectionString))
        {
            connection.Open();
        
            using (var comand = connection.CreateCommand())
            {
                comand.CommandText = "INSERT INTO заявки_на_ремонт " +
                                     "(ID_Тип_оборудования, Серийный_номер, Описание_проблемы, Дата_создания, Приоритет, ID_клиента) "+
                                     "VALUES (@ID_Тип_оборудования, @Серийный_номер, @Описание_проблемы, @Дата_создания, @Приоритет, @ID_клиента);";

                comand.Parameters.AddWithValue("@ID_Тип_оборудования", data.EquipmentTypeID);
                comand.Parameters.AddWithValue("@Серийный_номер", data.SerialNumber);
                comand.Parameters.AddWithValue("@Описание_проблемы", data.ProblemDescription);
                comand.Parameters.AddWithValue("@Дата_создания", data.CreatedDate.ToString("dd.MM.yyyy"));
                comand.Parameters.AddWithValue("@Приоритет", data.Priority);
                comand.Parameters.AddWithValue("@ID_клиента", data.ClientID);

                var rowsCount = comand.ExecuteNonQuery();

                if (rowsCount == 0)
                {
                    MessageBoxManager.GetMessageBoxStandard("Ошибка", "Данные не добавлены",ButtonEnum.Ok).ShowAsync();;
                }
            }
            connection.Close();
        }
    }

    public static void AddReports(Report data)
    {
        using (var connection = new MySqlConnection(ConnectionString.ConnectionString))
        {
            connection.Open();
        
            using (var comand = connection.CreateCommand())
            {
                comand.CommandText = "INSERT INTO отчёты_о_ремонте" +
                                     " ( Затраченное_время, Затраты, Причина_неисправности, Помощь_оказана, ID_Заявки) "+
                                     "VALUES ( @Затраченное_время, @Затраты, @Причина_неисправности, @Помощь_оказана, @ID_Заявки);";
                
                comand.Parameters.AddWithValue("@Затраченное_время", data.TimeSpent);
                comand.Parameters.AddWithValue("@Затраты", data.Costs);
                comand.Parameters.AddWithValue("@Причина_неисправности", data.FailureReason);
                comand.Parameters.AddWithValue("@Помощь_оказана", data.AssistanceProvided);
                comand.Parameters.AddWithValue("@ID_Заявки", data.RequestID);
                var rowsCount = comand.ExecuteNonQuery();

                if (rowsCount == 0)
                {
                    MessageBoxManager.GetMessageBoxStandard("Ошибка", "Данные не добавлены",ButtonEnum.Ok).ShowAsync();;
                }
            }
            connection.Close();
        }
    }

    
    /// Удаление
    public static void RemoveApplicationOfSpecialist(ApplicationOfSpecialist data)
         {
             using (var connection = new MySqlConnection(ConnectionString.ConnectionString))
             {
                 connection.Open();
             
                 using (var comand = connection.CreateCommand())
                 {
                     comand.CommandText = "DELETE FROM заявки_от_специалистов " +
                                          "WHERE id = @id;";
     
                     comand.Parameters.AddWithValue("@id", data.ID.ToString());
                     try
                     {
                         var rowsCount = comand.ExecuteNonQuery();
                     }
                     catch (Exception e)
                     {
                         MessageBoxManager.GetMessageBoxStandard("Ошибка", "Данные не удаленыЖ: " + e.Message,ButtonEnum.Ok).ShowAsync();;
                     }
                 }
                 connection.Close();
             }
         }
    public static void RemoveClient(Client data)
    {
        using (var connection = new MySqlConnection(ConnectionString.ConnectionString))
        {
            connection.Open();
        
            using (var comand = connection.CreateCommand())
            {
                comand.CommandText = "DELETE FROM клиенты " +
                                     "WHERE id = @id;";

                comand.Parameters.AddWithValue("@id", data.ID.ToString());
                try
                {
                    var rowsCount = comand.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    MessageBoxManager.GetMessageBoxStandard("Ошибка", "Данные не удаленыЖ: " + e.Message,ButtonEnum.Ok).ShowAsync();;
                }
            }
            connection.Close();
        }
    }
    public static void RemoveExecution(Execution data)
    {
        using (var connection = new MySqlConnection(ConnectionString.ConnectionString))
        {
            connection.Open();
        
            using (var comand = connection.CreateCommand())
            {
                comand.CommandText = "DELETE FROM исполнение_заявок " +
                                     "WHERE id = @id;";

                comand.Parameters.AddWithValue("@id", data.ID.ToString());
                try
                {
                    var rowsCount = comand.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    MessageBoxManager.GetMessageBoxStandard("Ошибка", "Данные не удалены",ButtonEnum.Ok).ShowAsync();;

                }
            }
            connection.Close();
        }
    }
    public static void RemoveRepairRequest(RepairRequest data)
    {
        using (var connection = new MySqlConnection(ConnectionString.ConnectionString))
        {
            connection.Open();
        
            using (var comand = connection.CreateCommand())
            {
                comand.CommandText = "DELETE FROM заявки_на_ремонт " +
                                     "WHERE id = @id;";

                comand.Parameters.AddWithValue("@id", data.ID.ToString());
                try
                {
                    var rowsCount = comand.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    MessageBoxManager.GetMessageBoxStandard("Ошибка", "Данные не удаленыЖ: " + e.Message,ButtonEnum.Ok).ShowAsync();;
                }
               

                
            }
            connection.Close();
        }
    }
    public static void RemoveReport(Report data)
    {
        using (var connection = new MySqlConnection(ConnectionString.ConnectionString))
        {
            connection.Open();
        
            using (var comand = connection.CreateCommand())
            {
                comand.CommandText = "DELETE FROM отчёты_о_ремонте " +
                                     "WHERE id = @id;";

                comand.Parameters.AddWithValue("@id", data.ID.ToString());
                try
                {
                    var rowsCount = comand.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    MessageBoxManager.GetMessageBoxStandard("Ошибка", "Данные не удалены",ButtonEnum.Ok).ShowAsync();;

                }
            }
            connection.Close();
        }
    }
    
    /// Обновление
    ///
    ///
    ///
    ///
    /// 
    public static void UpdateApplicationOfSpecialist(ApplicationOfSpecialist data)
    {
        using (var connection = new MySqlConnection(ConnectionString.ConnectionString))
        {
            connection.Open();
        
            using (var comand = connection.CreateCommand())
            {

                comand.CommandText = "UPDATE заявки_от_специалистов " +
                                     "SET Содержание = @Содержание, ID_Статус = @ID_Статус, ID_Исполняемая_заявка = @ID_Исполняемая_заявка " +
                                     "WHERE id = @id;";
                comand.Parameters.AddWithValue("@id", data.ID);
                comand.Parameters.AddWithValue("@Содержание", data.Massage);
                comand.Parameters.AddWithValue("@ID_Статус", data.StatusID);
                comand.Parameters.AddWithValue("@ID_Исполняемая_заявка", data.ExecutionID);

                
                var rowsCount = comand.ExecuteNonQuery();

                if (rowsCount == 0)
                {
                    MessageBoxManager.GetMessageBoxStandard("Ошибка", "Данные не Обновлены",ButtonEnum.Ok).ShowAsync();;
                }
            }
            connection.Close();
        }
    }
    public static void UpdateClient(Client data)
    {
        using (var connection = new MySqlConnection(ConnectionString.ConnectionString))
        {
            connection.Open();
        
            using (var comand = connection.CreateCommand())
            {


                comand.CommandText = "UPDATE клиенты " +
                                     "SET  @Имя = Имя, @Номер_телефона =  Номер_телефона "+
                                     "WHERE id = @id;";

                comand.Parameters.AddWithValue("@Имя", data.Name);
                comand.Parameters.AddWithValue("@Номер_телефона", data.PhoneNumber); 
                
                var rowsCount = comand.ExecuteNonQuery();

                if (rowsCount == 0)
                {
                    MessageBoxManager.GetMessageBoxStandard("Ошибка", "Данные не Обновлены",ButtonEnum.Ok).ShowAsync();;
                }
            }
            connection.Close();
        }
    }
    public static void UpdateExecution(Execution data)
    {
        using (var connection = new MySqlConnection(ConnectionString.ConnectionString))
        {
            connection.Open();
        
            using (var comand = connection.CreateCommand())
            {

                comand.CommandText = "UPDATE исполнение_заявок " +
                                     "SET  ID_заявки = @ID_заявки , Дата_начала = @Дата_начала, Дата_окончания = @Дата_окончания," +
                                     "Исполнитель = @Исполнитель, ID_Статус = @ID_Статус "+
                                     "WHERE ID = @id;";

                comand.Parameters.AddWithValue("@id", data.ID);
                comand.Parameters.AddWithValue("@ID_заявки", data.RequestID);
                comand.Parameters.AddWithValue("@Дата_начала", data.StartDate);
                comand.Parameters.AddWithValue("@Дата_окончания", data.EndDate);
                comand.Parameters.AddWithValue("@Исполнитель", data.ExecutorID);
                comand.Parameters.AddWithValue("@ID_Статус", data.StatusID);

                
                var rowsCount = comand.ExecuteNonQuery();

                if (rowsCount == 0)
                {
                    MessageBoxManager.GetMessageBoxStandard("Ошибка", "Данные не Обновлены",ButtonEnum.Ok).ShowAsync();;
                }
            }
            connection.Close();
        }
    }
    public static void UpdateRepairRequest(RepairRequest data)
    {
        using (var connection = new MySqlConnection(ConnectionString.ConnectionString))
        {
            connection.Open();
        
            using (var comand = connection.CreateCommand())
            {
                comand.CommandText = "UPDATE заявки_на_ремонт " +
                                     "SET ID_Тип_оборудования = @ID_Тип_оборудования, " +
                                     "Серийный_номер = @Серийный_номер, " +
                                     "Описание_проблемы = @Описание_проблемы, " +
                                     "Дата_создания = @Дата_создания " +
                                     "WHERE id = @id;";

                comand.Parameters.AddWithValue("@id", data.ID);
                comand.Parameters.AddWithValue("@ID_Тип_оборудования", data.EquipmentTypeID);
                comand.Parameters.AddWithValue("@Серийный_номер", data.SerialNumber);
                comand.Parameters.AddWithValue("@Описание_проблемы", data.ProblemDescription);
                comand.Parameters.AddWithValue("@Дата_создания", data.CreatedDate.ToString("dd.MM.yyyy"));
                
                var rowsCount = comand.ExecuteNonQuery();

                if (rowsCount == 0)
                {
                    MessageBoxManager.GetMessageBoxStandard("Ошибка", "Данные не Обновлены",ButtonEnum.Ok).ShowAsync();;
                }
            }
            connection.Close();
        }
    }
    public static void UpdateReport(Report data)
    {
        using (var connection = new MySqlConnection(ConnectionString.ConnectionString))
        {
            connection.Open();
        
            using (var comand = connection.CreateCommand())
            {
                comand.CommandText = "UPDATE отчёты_о_ремонте " +
                                     "SET  Затраченное_время = @Затраченное_время, " +
                                     "Затраты = @Затраты, Причина_неисправности = @Причина_неисправности, " +
                                     "Помощь_оказана = @Помощь_оказана, " +
                                     "ID_Заявки = @ID_Заявки " +
                                     "WHERE id = @id;";
                comand.Parameters.AddWithValue("@id", data.ID);
                comand.Parameters.AddWithValue("@Затраченное_время", data.TimeSpent);
                comand.Parameters.AddWithValue("@Затраты", data.Costs);
                comand.Parameters.AddWithValue("@Причина_неисправности", data.FailureReason);
                comand.Parameters.AddWithValue("@Помощь_оказана", data.AssistanceProvided);
                comand.Parameters.AddWithValue("@ID_Заявки", data.RequestID);
                
                var rowsCount = comand.ExecuteNonQuery();

                if (rowsCount == 0)
                {
                    MessageBoxManager.GetMessageBoxStandard("Ошибка", "Данные не Обновлены",ButtonEnum.Ok).ShowAsync();;
                }
            }
            connection.Close();
        }
    }
}