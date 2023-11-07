using System;
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
    private Client ClientAuth;
    public WindowReport()
    {
        InitializeComponent();
        DownloadDataGrid();
        UpdateComboBox();
    }
    public WindowReport(Client client)
    {
        InitializeComponent();
        DownloadDataGrid();
        UpdateComboBox();
        ClientAuth = client;
        SearchBox.IsEnabled = false;
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
        
        

        if (DataGrid.SelectedItem == null)
        {
            DataBaseManager.AddReports(new Report(
                0, 
                Convert.ToInt32(NUpDownTimeSpent.Value), 
                    Convert.ToInt32(TBoxCost.Text), 
                TBoxFailureReason.Text,
                TBoxAssistanceProvided.Text,
                ((RepairRequest)CBoxRequest.SelectedItem).ID
            ));
        }
        else
        {
            DataBaseManager.UpdateReport(new Report(
                ((Report)DataGrid.SelectedItem).ID,
                Convert.ToInt32(NUpDownTimeSpent.Value), 
                Convert.ToInt32(TBoxCost.Text), 
                TBoxFailureReason.Text,
                TBoxAssistanceProvided.Text,
                ((RepairRequest)CBoxRequest.SelectedItem).ID
            ));
        }
        DownloadDataGrid();
    }

    private void DataGrid_OnSelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        if (DataGrid.SelectedItem == null)
        {
            NUpDownTimeSpent.IsEnabled = true;
            TBoxCost.IsEnabled = true;
            TBoxFailureReason.IsEnabled = true;
            
            NUpDownTimeSpent.Value = 0;
            TBoxCost.Text = "";
            TBoxFailureReason.Text = "";
            TBoxAssistanceProvided.Text = "";
            CBoxRequest.SelectedItem = null;
        }
        else
        {
            Report report = DataGrid.SelectedItem as Report;
            
            NUpDownTimeSpent.IsEnabled = false;
            TBoxCost.IsEnabled = false;
            TBoxFailureReason.IsEnabled = false;
            
            NUpDownTimeSpent.Value = report.TimeSpent;
            TBoxCost.Text = report.Costs.ToString();
            TBoxFailureReason.Text = report.FailureReason;
            TBoxAssistanceProvided.Text = report.AssistanceProvided;
            CBoxRequest.SelectedItem = RepairRequestsList.Where(w => w.ID == report.RequestID).First() as RepairRequest;
        }
    }
}