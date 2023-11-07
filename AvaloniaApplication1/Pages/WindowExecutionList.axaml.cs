using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using AvaloniaApplication1.Model;
using AvaloniaApplication3.Model;
using MsBox.Avalonia;
using MsBox.Avalonia.Enums;

namespace AvaloniaApplication1.Pages;

public partial class WindowExecutionList : Window
{
    private List<Employee> EmployeesList { get; set; }
    private List<Execution> ExecutionsListData { get; set; }
    private List<Execution> ExecutionsListView { get; set; }
    private List<Status> StatusList { get; set; }
    private List<RepairRequest> RepairRequestsList { get; set; }

    private Employee user;

    public WindowExecutionList(Employee user)
    {
        InitializeComponent();
        DownloadDataGrid();
        UpdateComboBox();

        this.user = user;
    }
    
      public void DownloadDataGrid()
    {
        ExecutionsListData = DataBaseManager.GetExecutions();
        UpdateDataGrid();
    }
    private void UpdateDataGrid()
    {
        ExecutionsListView = ExecutionsListData;
        
        if (SearchBox.Text.Length > 0)
            ExecutionsListView = ExecutionsListView.Where(c => c.RequestID.ToString().ToLower().Contains(SearchBox.Text.ToLower()) ||
                                                               c.StartDate.Date.ToString().ToLower().Contains(SearchBox.Text.ToLower()) ||
                                                               c.EndDate.Date.ToString().ToLower().Contains(SearchBox.Text.ToLower()) ||
                                                               c.ExecutorID.ToString().ToLower().Contains(SearchBox.Text.ToLower()) ||
                                                               c.StatusID.ToString().ToLower().Contains(SearchBox.Text)).ToList();
        
        DataGrid.ItemsSource = ExecutionsListView;
        
    }

    private void UpdateComboBox()
    {
        StatusList = DataBaseManager.GetStatuse();
        EmployeesList = DataBaseManager.GetEmployees();
        RepairRequestsList = DataBaseManager.GetCRepairRequests();
     
        CBoxStatus.Items.Clear();
        CBoxEmploye.Items.Clear();
        CBoxRqiesrtID.Items.Clear();
        
        
        CBoxStatus.ItemsSource = StatusList;
        CBoxEmploye.ItemsSource = EmployeesList;
        CBoxRqiesrtID.ItemsSource = RepairRequestsList;
    }

    private void SearchBox_OnTextChanged(object? sender, TextChangedEventArgs e)
    {
        UpdateDataGrid();
    }

    private void ResetBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        SearchBox.Text = "";
    }
    

    private void BtnDelet_OnClick(object? sender, RoutedEventArgs e)
    {
        if(DataGrid.SelectedItem == null)
            return;
        
        DataBaseManager.RemoveExecution(DataGrid.SelectedItem as Execution);
        
        DownloadDataGrid();
    }

    private void BtnRemoveSelect_OnClick(object? sender, RoutedEventArgs e)
    {
        DataGrid.SelectedItem = null;
    }

    private void BtnSavet_OnClick(object? sender, RoutedEventArgs e)
    {
        if (CBoxEmploye.SelectedItem == null || CBoxStatus.SelectedItem == null || CBoxRqiesrtID.SelectedItem == null)
        {
            MessageBoxManager.GetMessageBoxStandard("Ошибка", "Данные не добавлены", ButtonEnum.Ok).ShowAsync();
            return;
        }
        
        
        // if(DataGrid.SelectedItem == null) 
            //TODO: Добавление с формы
        //else
            //TODO: Обновление с формы

            DownloadDataGrid();
    }
   

    private void BtnFinalFixed_OnClick(object? sender, RoutedEventArgs e)
    {
        throw new System.NotImplementedException();
    }


    private void BtnCreateReport_OnClick(object? sender, RoutedEventArgs e)
    {
        if(DataGrid.SelectedItem == null)
            return;

        Execution execution = DataGrid.SelectedItem as Execution;
        
        WindowAddReport wAddReport = new WindowAddReport(execution);
        wAddReport.ShowDialog(this);
    }

    private void BtnCreateApplication_OnClick(object? sender, RoutedEventArgs e)
    {
        if(DataGrid.SelectedItem == null)
            return;

        Execution execution = DataGrid.SelectedItem as Execution;

        
        DataBaseManager.AddApplicationOfSpecialist(new ApplicationOfSpecialist(0, TBoxApplication.Text, 1, execution.ID));
        
        TBoxApplication.Text = "";
        MessageBoxManager.GetMessageBoxStandard("Успех", "Данные Добавлены",ButtonEnum.Ok).ShowAsync();;

    }

    private void BtnMovetToApplication_OnClick(object? sender, RoutedEventArgs e)
    {
        throw new System.NotImplementedException();
    }
}