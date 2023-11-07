using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using AvaloniaApplication1.Model;

namespace AvaloniaApplication1.Pages;

public partial class WindowMeny : Window
{
    private Employee user;
    public WindowMeny(Employee user)
    {
        InitializeComponent();
        this.user = user;
        switch (user.PositionID)
        {
            case 1://Админ
                BtnRepairRequest.IsVisible = true;
                BtnExecution.IsVisible = true;
                BtnApplicationOfSpec.IsVisible = true;
                BtnReports.IsVisible = true;
                break;
            case 2://Менеджер
                BtnRepairRequest.IsVisible = true;
                BtnExecution.IsVisible = false;
                BtnApplicationOfSpec.IsVisible = true;
                BtnReports.IsVisible = true;
                break;
            case 3://Специалист
                BtnRepairRequest.IsVisible = false;
                BtnExecution.IsVisible = true;
                BtnApplicationOfSpec.IsVisible = true;
                BtnReports.IsVisible = false;
                break;
                
        }
    }

    private void BtnRepairRequest_OnClick(object? sender, RoutedEventArgs e)
    {
        WindowRepairRequest window = new WindowRepairRequest();
        window.ShowDialog(this); 
    }

    private void BtnExecution_OnClick(object? sender, RoutedEventArgs e)
    {
        WindowExecutionList window = new WindowExecutionList(user);
        window.ShowDialog(this); 
    }

    private void BtnApplicationOfSpec_OnClick(object? sender, RoutedEventArgs e)
    {
        WindowApplicationList window = new WindowApplicationList();
        window.ShowDialog(this); 
    }

    private void BtnReports_OnClick(object? sender, RoutedEventArgs e)
    {
        WindowReport window = new WindowReport();
        window.ShowDialog(this); 
    }
    
}