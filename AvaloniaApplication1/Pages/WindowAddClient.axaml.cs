using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using AvaloniaApplication1.Model;
using AvaloniaApplication3.Model;
using MsBox.Avalonia;
using MsBox.Avalonia.Enums;

namespace AvaloniaApplication1.Pages;

public partial class WindowAddClient : Window
{
    public WindowAddClient()
    {
        InitializeComponent();
    }

    private void BtnBack_OnClick(object? sender, RoutedEventArgs e)
    {
       this.Close();
    }

    private void BtnAdd_OnClick(object? sender, RoutedEventArgs e)
    {
        if (TBoxName.Text.Length <= 0 || TBoxPhoneNumber.Text.Length <= 0)
        {
            MessageBoxManager.GetMessageBoxStandard("Ошибка", "Данные не добавлены", ButtonEnum.Ok).ShowAsync();
            return;
        }
        
        
        DataBaseManager.AddClients(new Client(0,TBoxName.Text, TBoxPhoneNumber.Text));
    }
}