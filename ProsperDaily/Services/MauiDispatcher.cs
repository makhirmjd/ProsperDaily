
namespace ProsperDaily.Services;

public class MauiDispatcher : IDispatcher
{
    public bool IsDispatchRequired => !MainThread.IsMainThread;

    public IDispatcherTimer CreateTimer() => Shell.Current?.Dispatcher?.CreateTimer() 
        ?? Application.Current?.Dispatcher?.CreateTimer() 
        ?? throw new InvalidOperationException("No context found");

    public bool Dispatch(Action action)
    {
        try
        {
            if (IsDispatchRequired)
            {
                MainThread.BeginInvokeOnMainThread(action);
            }
            else
            {
                action();
            }
            return true;
        }
        catch
        {
            return false;
        }
    }

    public bool DispatchDelayed(TimeSpan delay, Action action)
    {
        try
        {
            MainThread.BeginInvokeOnMainThread(async () =>
            {
                await Task.Delay(delay);
                action();
            });
            return true;
        }
        catch
        {
            return false;
        }
    }
}
