using Lab_2.Interface;

namespace Lab_2.Services;

public class ViewModelProgressReporter: IProgressReporter
{
    
    public event Action<int>? ProgressChanged;
    public void ReportProgress(int percentage) => ProgressChanged?.Invoke(percentage);
}