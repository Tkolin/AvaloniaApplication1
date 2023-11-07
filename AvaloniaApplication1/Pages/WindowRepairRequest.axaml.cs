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

public partial class WindowRepairRequest : Window
{
    private List<RepairRequest> RepairRequestsListData { get; set; }
    private List<RepairRequest> RepairRequestsListView { get; set; }

    private List<EquipmentType> EquipmentTypesList { get; set; }
    private List<Client> ClientsList { get; set; }

    public WindowRepairRequest()
    {
        InitializeComponent();
        DownloadDataGrid();
        UpdateComboBox();
    }

    public void DownloadDataGrid()
    {
        RepairRequestsListData = DataBaseManager.GetCRepairRequests();
        UpdateDataGrid();
    }

    private void UpdateDataGrid()
    {
        RepairRequestsListView = RepairRequestsListData;

        if (SearchBox.Text.Length > 0)
            RepairRequestsListView = RepairRequestsListView.Where(c =>
                c.CreatedDate.Date.ToString().ToLower().Contains(SearchBox.Text.ToLower()) ||
                c.EquipmentTypeID.ToString().ToLower().Contains(SearchBox.Text.ToLower()) ||
                c.SerialNumber.ToString().ToLower().Contains(SearchBox.Text.ToLower()) ||
                c.ProblemDescription.ToString().ToLower().Contains(SearchBox.Text.ToLower()) ||
                c.Priority.ToString().ToLower().Contains(SearchBox.Text)).ToList();

        DataGrid.ItemsSource = RepairRequestsListView;

    }

    private void UpdateComboBox()
    {
        EquipmentTypesList = DataBaseManager.GetEquipmentTypes();
        ClientsList = DataBaseManager.GetClients();

        CBoxEquipmentTypeID.Items.Clear();
        CBoxClient.Items.Clear();

        CBoxClient.ItemsSource = ClientsList;
        CBoxEquipmentTypeID.ItemsSource = EquipmentTypesList;
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
        if (DataGrid.SelectedItem == null)
            return;

        DataBaseManager.RemoveRepairRequest(DataGrid.SelectedItem as RepairRequest);

        DownloadDataGrid();
    }

    private void BtnRemoveSelect_OnClick(object? sender, RoutedEventArgs e)
    {
        DataGrid.SelectedItem = null;
    }

    private void BtnSavet_OnClick(object? sender, RoutedEventArgs e)
    {
        if (DPickerCreatedDate.SelectedDate == null ||
            CBoxEquipmentTypeID.SelectedItem == null ||
            TBoxSerialNumber.Text.Length <= 0 ||
            TBoxProblemDescription.Text.Length <= 0)
        {
            MessageBoxManager.GetMessageBoxStandard("Ошибка", "Данные не добавлены", ButtonEnum.Ok).ShowAsync();
            return;
        }


        if (DataGrid.SelectedItem == null)
        {
            DataBaseManager.AddRepairRequests(new RepairRequest(
                0,
                ((EquipmentType)CBoxEquipmentTypeID.SelectedItem).ID,
                TBoxSerialNumber.Text,
                TBoxProblemDescription.Text,
                DPickerCreatedDate.SelectedDate.Value.Date,
                Convert.ToInt32(NUpDownPriority.Value) ,
                ((Client)CBoxClient.SelectedItem).ID
            ));
        }

        else
        {
            DataBaseManager.UpdateRepairRequest(new RepairRequest(
                ((RepairRequest)DataGrid.SelectedItem).ID,
                ((EquipmentType)CBoxEquipmentTypeID.SelectedItem).ID,
                TBoxSerialNumber.Text,
                TBoxProblemDescription.Text,
                DPickerCreatedDate.SelectedDate.Value.Date,
                Convert.ToInt32(NUpDownPriority.Value) ,
                ((Client)CBoxClient.SelectedItem).ID
                
            ));
        }

        DownloadDataGrid();
    }


    private void BtnCreateExecution_OnClick(object? sender, RoutedEventArgs e)
    {
        throw new System.NotImplementedException();
    }

    private void DataGrid_OnSelectionChanged(object? sender, SelectionChangedEventArgs e)
    {

        {
            if (DataGrid.SelectedItem == null)
            {
                DPickerCreatedDate.SelectedDate = DateTime.Now;
                CBoxEquipmentTypeID.SelectedItem = null;
                TBoxSerialNumber.Text = "";
                TBoxProblemDescription.Text = "";
                CBoxClient.SelectedItem = null;
                NUpDownPriority.Value = 0;

            }
            else
            {

                RepairRequest selectedRepairRequestDG = DataGrid.SelectedItem as RepairRequest;

                DPickerCreatedDate.SelectedDate = selectedRepairRequestDG.CreatedDate;
                CBoxEquipmentTypeID.SelectedItem =
                    EquipmentTypesList.Where(w => w.ID == selectedRepairRequestDG.EquipmentTypeID).First() as
                        EquipmentType;
                TBoxSerialNumber.Text = selectedRepairRequestDG.SerialNumber;
                TBoxProblemDescription.Text = selectedRepairRequestDG.ProblemDescription;
                CBoxClient.SelectedItem =
                    ClientsList.Where(w => w.ID == selectedRepairRequestDG.ClientID).First() as Client;
                NUpDownPriority.Value = selectedRepairRequestDG.Priority;
            }
        }
    }
}