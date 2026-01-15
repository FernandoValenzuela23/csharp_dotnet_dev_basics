
async Task LongRunningOperationAsync(CancellationToken cancellationToken)
{
    try
    {
        for (int i = 1; i <= 10; i++)
        {
            cancellationToken.ThrowIfCancellationRequested();

            Console.WriteLine($"Operation in progress, step {i}");

            await Task.Delay(1000, cancellationToken);

        }
    }
    catch (OperationCanceledException)
    {
    
        Console.WriteLine("Cancellation requested outside");

        throw;
    }

}



#region _MAIN_

Console.WriteLine("Starting a long operation");

// Creating a cancellation token
var cts = new CancellationTokenSource();
CancellationToken token = cts.Token;

// Running an async task
Task operationTask = LongRunningOperationAsync(token);
Console.WriteLine("Press [c/C] to cancel the operation");
char input = Console.ReadKey(false).KeyChar;

// If the operation is cancelled manually
if(String.Equals(input.ToString(), "c", StringComparison.OrdinalIgnoreCase))
{
    cts.Cancel();
    Console.WriteLine("Cancellation requested.");
}

try
{
    await operationTask;
    Console.WriteLine("Operation completed successfully");
}
catch(OperationCanceledException)
{
    Console.WriteLine("Operation cancelled on source");
}
catch (Exception ex)
{
    Console.WriteLine("An error ocurred: " + ex.ToString());
}
finally
{
    cts.Dispose();
}

Console.WriteLine("Program finished.");
#endregion