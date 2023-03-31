using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AsyncExample
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();
    }

    private CancellationTokenSource cts;
    private CancellationToken cancellationToken;

    private async void Button_Click(object sender, RoutedEventArgs e)
    {
      cts = new CancellationTokenSource();
      cancellationToken = cts.Token;

      BTN_Start.IsEnabled = false;
      BTN_Stop.IsEnabled = true;
      //Increment();
      //Task.Run(Increment)
      //  .ContinueWith(t => BTN_Start.IsEnabled = true, TaskScheduler.FromCurrentSynchronizationContext());

      Task t;
      try
      {
        t = Task.Run(Increment, cancellationToken);
        await t; // GetAwaiter()
        //await 1000;
        
      }
      catch (Exception ex)
      {
        LBL.Content = "Aborted";
      }

      BTN_Stop.IsEnabled = false;
      BTN_Start.IsEnabled = true;
    }

    private void Increment()
    {
      for (int i = 0; i <= 5; i++)
      {
        if (cancellationToken.IsCancellationRequested)
        {
          // cleanup
          cancellationToken.ThrowIfCancellationRequested();
        }

        int k = i;
        Thread.Sleep(1000);  // do not use in real live!!!

        //LBL.Content = i;

        // be careful using closures!!!
        Dispatcher.BeginInvoke(() => LBL.Content = k);
        //Dispatcher.BeginInvoke(() => Debug.WriteLine(k));
      }
    }

    private void BTN_Stop_Click(object sender, RoutedEventArgs e)
    {
      cts.Cancel();
    }
  }
}
