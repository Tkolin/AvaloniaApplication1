using System;
using System.Collections.Generic;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using AvaloniaApplication1.Model;
using AvaloniaApplication3.Model;

namespace AvaloniaApplication1.Pages;

public partial class WindowAddReport : Window
{
    private Execution execution;
    private List<RepairRequest> RepairRequestsList { get; set; }
    public WindowAddReport(Execution execution)
    {
       
        InitializeComponent();
        this.execution = execution;
        UpdateComboBox();
        CBoxRequest.SelectedItem = RepairRequestsList.Where(w => w.ID == execution.ID).First() as RepairRequest;
        CBoxRequest.IsEnabled = false;
    }
    private void UpdateComboBox()
    {
        RepairRequestsList = DataBaseManager.GetCRepairRequests();
        
        CBoxRequest.Items.Clear();
        
        CBoxRequest.ItemsSource = RepairRequestsList; ;
    }
    private void BtnAdd_OnClick(object? sender, RoutedEventArgs e)
    {
        DataBaseManager.AddReports(new Report(
            0, 
            Convert.ToInt32(NUpDownTimeSpent.Value), 
            Convert.ToInt32(TBoxCost.Text), 
            TBoxFailureReason.Text,
            TBoxAssisment.Text,
            ((RepairRequest)CBoxRequest.SelectedItem).ID
        ));
        this.Close();
    }

    private void BtnBack_OnClick(object? sender, RoutedEventArgs e)
    {
        this.Close();
    }
}