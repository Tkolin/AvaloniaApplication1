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
            RepairRequestsListView = RepairRequestsListView.Where(c => c.CreatedDate.Date.ToString().ToLower().Contains(SearchBox.Text.ToLower()) ||
                                                                       c.EquipmentTypeID.ToString().ToLower().Contains(SearchBox.Text.ToLower()) ||
                                                                       c.SerialNumber.ToString().ToLower().Contains(SearchBox.Text.ToLower()) ||
                                                                       c.ProblemDescription.ToString().ToLower().Contains(SearchBox.Text.ToLower()) ||
                                                                       c.Priority.ToString().ToLower().Contains(SearchBox.Text)).ToList();
        
        DataGrid.ItemsSource = RepairRequestsListView;
        
    }

    private void UpdateComboBox()
    {
        EquipmentTypesList = DataBaseManager.GetEquipmentTypes();
        
        CBoxEquipmentTypeID.Items.Clear();
        
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
        if(DataGrid.SelectedItem == null)
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
        
        
        // if(DataGrid.SelectedItem == null) 
            //TODO: Добавление с формы
        //else
            //TODO: Обновление с формы

            DownloadDataGrid();
    }


    private void BtnCreateExecution_OnClick(object? sender, RoutedEventArgs e)
    {
        throw new System.NotImplementedException();
    }
}