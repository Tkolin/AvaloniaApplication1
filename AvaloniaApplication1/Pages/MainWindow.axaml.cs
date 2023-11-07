using System.Collections.Generic;
using Avalonia.Controls;
using Avalonia.Interactivity;
using AvaloniaApplication1.Model;
using AvaloniaApplication1.Pages;
using AvaloniaApplication3.Model;
using MsBox.Avalonia;
using MsBox.Avalonia.Enums;

namespace AvaloniaApplication1;

public partial class MainWindow : Window
{
    private bool isClient = false;
    private Employee employeeAuth;
    public MainWindow()
    {
        InitializeComponent();
        employeeAuth = null;
    }



    private void BtnAuth_OnClick(object? sender, RoutedEventArgs e)
    {
        if (TBoxLogin.Text.Length <= 1 || TBoxPassword.Text.Length <= 1)
        {
            MessageBoxManager.GetMessageBoxStandard("Ошибка", "Поля не заполнены",ButtonEnum.Ok).ShowAsync();;
            return;
        }

        List<Employee> employees = DataBaseManager.GetEmployees();
        if (employees.Count == 0)
        {
            
            MessageBoxManager.GetMessageBoxStandard("Ошибка", "В базе нет сотрудников",ButtonEnum.Ok).ShowAsync();;
            return;
        }
        for(int i = 0; i < employees.Count; i++)
        {
            if (employees[i].Login == (TBoxLogin.Text) &&
                employees[i].Password == (TBoxPassword.Text))
            {
                employeeAuth = employees[i];
                break;
            }
        }

        if (employeeAuth == null)
        {
            MessageBoxManager.GetMessageBoxStandard("Ошибка", "Данные не верны",ButtonEnum.Ok).ShowAsync();;
            return;
        }
        else
        {
            WindowMeny wMeny = new WindowMeny(employeeAuth);
            wMeny.ShowDialog(this);
        }
    }

    private void BtnClose_OnClick(object? sender, RoutedEventArgs e)
    {
        this.Close();
    }

    private void BtnSwitch_OnClick(object? sender, RoutedEventArgs e)
    {
        isClient = !isClient;
        if (isClient)
        {
            PanelClient.IsVisible = true;
            PanelEmployee.IsVisible = false;
        }
        else
        {
            PanelClient.IsVisible = false;
            PanelEmployee.IsVisible = true;
        }
    }
}