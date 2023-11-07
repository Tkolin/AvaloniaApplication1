using System.Collections.Generic;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using AvaloniaApplication1.Model;
using AvaloniaApplication3.Model;
using MsBox.Avalonia;
using MsBox.Avalonia.Enums;

namespace AvaloniaApplication1.Pages;

public partial class WindowReport : Window
{
    private List<RepairRequest> RepairRequestsList { get; set; }
    private List<Report> ReportsListData { get; set; }
    private List<Report> ReportsListViewa { get; set; }
    public WindowReport()
    {
        InitializeComponent();
        DownloadDataGrid();
        UpdateComboBox();
    }
      public void DownloadDataGrid()
    {
        ReportsListData = DataBaseManager.GetReports();
        UpdateDataGrid();
    }
    private void UpdateDataGrid()
    {
        ReportsListViewa = ReportsListData;
        
        if (SearchBox.Text.Length > 0)
            ReportsListViewa = ReportsListViewa.Where(c => c.RequestID.ToString().ToLower().Contains(SearchBox.Text.ToLower()) ||
                                                           c.TimeSpent.ToString().ToLower().Contains(SearchBox.Text.ToLower()) ||
                                                           c.Costs.ToString().ToLower().Contains(SearchBox.Text.ToLower()) ||
                                                           c.FailureReason.ToString().ToLower().Contains(SearchBox.Text.ToLower()) ||
                                                           c.AssistanceProvided.ToString().ToLower().Contains(SearchBox.Text)).ToList();
        
        DataGrid.ItemsSource = ReportsListViewa;
        
    }

    private void UpdateComboBox()
    {
        RepairRequestsList = DataBaseManager.GetCRepairRequests();
       
        CBoxRequest.Items.Clear();
        
        CBoxRequest.ItemsSource = RepairRequestsList;
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
        
        DataBaseManager.RemoveReport(DataGrid.SelectedItem as Report);
        
        DownloadDataGrid();
    }

    private void BtnRemoveSelect_OnClick(object? sender, RoutedEventArgs e)
    {
        DataGrid.SelectedItem = null;
    }

    private void BtnSavet_OnClick(object? sender, RoutedEventArgs e)
    {
        if (NUpDownTimeSpent.Value == 0 || TBoxCost.Text.Length <= 0 || TBoxFailureReason.Text.Length <= 0 
            || CBoxRequest.SelectedItem == null)
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
  
}