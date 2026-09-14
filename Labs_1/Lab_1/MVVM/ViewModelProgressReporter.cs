using Lab_1.Interface;

namespace Lab_1.Services;

public class ViewModelProgressReporter: IProgressReporter
{
    
    public event Action<int>? ProgressChanged;
    public void ReportProgress(int percentage) => ProgressChanged?.Invoke(percentage);
}