using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Windows.Controls;
using System.Windows;
using System;
using System.Windows.Data;

namespace TaskManager
{
    public partial class MainWindow : Window
    {
        public List<ProcessInfo> Processes { get; set; }
        private readonly Thread thread;
        private ProcessInfo? selectedProcess;

        public MainWindow()
        {
            InitializeComponent();

            Processes = new List<ProcessInfo>();
            processListView.DataContext = this;

            thread = new Thread(UpdateProcessList)
            {
                IsBackground = true
            };
            thread.Start();
        }

        private void UpdateProcessList()
        {
            while (true)
            {
                if (selectedProcess == null)
                {
                    Process[] processes = Process.GetProcesses();
                    Processes.Clear();

                    foreach (Process process in processes)
                    {
                        try
                        {
                            process.Refresh();
                            var processInfo = new ProcessInfo
                            {
                                Id = process.Id,
                                Name = process.ProcessName,
                                CpuUsage = process.TotalProcessorTime.ToString(),
                                MemoryUsage = (process.WorkingSet64 / (1024 * 1024)).ToString("N0")
                            };
                            Processes.Add(processInfo);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                }

                Application.Current.Dispatcher.Invoke(() =>
                {
                    CollectionViewSource.GetDefaultView(Processes).Refresh();
                });

                Thread.Sleep(1000);
            }
        }

        private void ProcessListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedProcess = processListView.SelectedItem as ProcessInfo;
            if (selectedProcess != null)
            {
                selectedProcessTextBlock.Text = $"Selected Process: {selectedProcess.Name}";
            }
            else
            {
                selectedProcessTextBlock.Text = string.Empty;
            }
        }

        private void KillButton_Click(object sender, RoutedEventArgs e)
        {
            if (selectedProcess != null)
            {
                try
                {
                    Process process = Process.GetProcessById(selectedProcess.Id);
                    process.Kill();
                    process.WaitForExit();
                    Processes.Remove(selectedProcess);

                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        CollectionViewSource.GetDefaultView(Processes).Refresh();
                    });
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            base.OnClosing(e);
            thread.Abort();
        }
    }
}
    public class ProcessInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CpuUsage { get; set; }
        public string MemoryUsage { get; set; }
    }

