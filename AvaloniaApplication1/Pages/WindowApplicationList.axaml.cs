using System;
using System.Collections.Generic;
using System.IO;
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

public partial class WindowApplicationList : Window
{
    private List<ApplicationOfSpecialist> applicationOfSpecialistsData { get; set; }
    private List<ApplicationOfSpecialist> applicationOfSpecialistsView { get; set; }
    private List<Status> StatusList { get; set; }
    private List<Execution> ExecutionList { get; set; }
    public WindowApplicationList()
    {
        InitializeComponent();
        DownloadDataGrid();
        UpdateComboBox();
    }

    public void DownloadDataGrid()
    {
        applicationOfSpecialistsData = DataBaseManager.GetApplicationOfSpecialists();
        UpdateDataGrid();
    }
    private void UpdateDataGrid()
    {
        applicationOfSpecialistsView = applicationOfSpecialistsData;
        
        if (SearchBox.Text.Length > 0)
            applicationOfSpecialistsView = applicationOfSpecialistsView.Where(c => c.Massage.ToLower().Contains(SearchBox.Text.ToLower()) ||
                c.StatusID.ToString().ToLower().Contains(SearchBox.Text.ToLower()) ||
                c.ExecutionID.ToString().ToLower().Contains(SearchBox.Text)).ToList();
        
        DataGrid.ItemsSource = applicationOfSpecialistsView;
        
    }

    private void UpdateComboBox()
    {
        StatusList = DataBaseManager.GetStatuse();
        ExecutionList = DataBaseManager.GetExecutions();
        
        CBoxStatus.Items.Clear();
        CBoxExecution.Items.Clear();
        
        CBoxStatus.ItemsSource = StatusList;
        CBoxExecution.ItemsSource = ExecutionList;
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
        
        DataBaseManager.RemoveApplicationOfSpecialist(DataGrid.SelectedItem as ApplicationOfSpecialist);
        
        DownloadDataGrid();
    }

    private void BtnRemoveSelect_OnClick(object? sender, RoutedEventArgs e)
    {
        DataGrid.SelectedItem = null;
    }

    private void BtnSavet_OnClick(object? sender, RoutedEventArgs e)
    {
        if (TBoxMassage.Text.Length <= 0 || CBoxStatus.SelectedItem == null)
        {
            MessageBoxManager.GetMessageBoxStandard("Ошибка", "Данные не добавлены", ButtonEnum.Ok).ShowAsync();
            return;
        }
        
        
        if (DataGrid.SelectedItem == null)
        {
            DataBaseManager.AddApplicationOfSpecialist(new ApplicationOfSpecialist(
                0,     
                TBoxMassage.Text,
                ((Status)CBoxStatus.SelectedItem).ID, 
                ((Execution)CBoxExecution.SelectedItem).ID

            ));
        }
  
        else
        {
            DataBaseManager.UpdateApplicationOfSpecialist(new ApplicationOfSpecialist(
                Convert.ToInt32(TBoxID.Text),
                TBoxMassage.Text,
                ((Status)CBoxStatus.SelectedItem).ID, 
                ((Execution)CBoxExecution.SelectedItem).ID
            ));
        }

        DownloadDataGrid();
    }

    private void DataGrid_OnSelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        if (DataGrid.SelectedItem == null)
        {
            CBoxExecution.IsEnabled = true;
            TBoxID.Text = "";
            TBoxMassage.Text = "";
            CBoxStatus.SelectedItem = null;
            CBoxExecution.SelectedItem = null;

        }
        else
        {
            ApplicationOfSpecialist applicationOfSpecialist = DataGrid.SelectedItem as ApplicationOfSpecialist;
            CBoxExecution.IsEnabled = false;
            TBoxID.Text = applicationOfSpecialist.ID.ToString();
            TBoxMassage.Text = applicationOfSpecialist.Massage;
            CBoxStatus.SelectedItem = StatusList.Where(s => s.ID == applicationOfSpecialist.StatusID).First() as Status;
            CBoxExecution.SelectedItem = ExecutionList.Where(s => s.ID == applicationOfSpecialist.ExecutionID).First() as Execution;
        }
    }
}