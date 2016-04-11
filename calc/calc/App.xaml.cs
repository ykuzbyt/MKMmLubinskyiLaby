using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows;
using calc.ClientSide;

namespace calc
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>

    public partial class App : Application
    {
        [DllImport("Kernel32.dll")]
        public static extern bool AttachConsole(int processId);

        protected override void OnStartup(StartupEventArgs e)
        {
            AttachConsole(-1);
            if (e.Args.Length > 0)
            {
                var  processResult = CommonUtilities.ProcessResult(e.Args[0]);
                try
               {                    
                    var parseResult = Int32.Parse(processResult);
                    Console.WriteLine(parseResult);
                    Console.WriteLine("0");

                }
                catch (Exception ex)
                {
                    Console.WriteLine(processResult);
                }
                
            }
            else
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
            }

        }
    }
}
