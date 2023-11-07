using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using AvaloniaApplication1.Model;

namespace AvaloniaApplication1.Pages;

public partial class WindowAddReport : Window
{
    private Execution execution;
    public WindowAddReport(Execution execution)
    {
       
        InitializeComponent();
        this.execution = execution;
        //TODO: Добавить данные на фому
    }

    private void BtnAdd_OnClick(object? sender, RoutedEventArgs e)
    {
        throw new System.NotImplementedException();
            //if (TBoxName.Text.Length <= 0 || TBoxPhoneNumber.Text.Length <= 0)
      //  {
       //     MessageBoxManager.GetMessageBoxStandard("Ошибка", "Данные не добавлены", ButtonEnum.Ok).ShowAsync();
      //      return;
       // }
        
        
      //  DataBaseManager.AddClients(new Client(0,TBoxName.Text, TBoxPhoneNumber.Text));
    }

    private void BtnBack_OnClick(object? sender, RoutedEventArgs e)
    {
        this.Close();
    }
}