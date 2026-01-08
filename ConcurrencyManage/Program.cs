
SemaphoreSlim semaphore = new SemaphoreSlim(3, 3);
List<Task> tasks = new List<Task>();
// Simulate concurrency
for (int i = 1; i <= 10; i++)
{
	tasks.Add(DownloadDataAsync($"Download_{i}"));
}
// Wait for all tasks to complete
await Task.WhenAll(tasks);
Console.WriteLine("All tasks completed");



async Task DownloadDataAsync(string taskName)
{
    Console.WriteLine($"{taskName} is waiting to access the semaphore.");

	// Wait to enter semaphore (decrements the count)
    await semaphore.WaitAsync();

	try
	{
		Console.WriteLine($"{taskName} has entered the semaphore.");
		// Delay to simulate an async task
		await Task.Delay(1000);
		Console.WriteLine($"{taskName} is completing its work.");
	}
	finally
	{
		// Release the semaphore (increments the count) allowing another waiting thread to enter
		semaphore.Release();
		Console.WriteLine($"{taskName} has release the semaphore.");
	}


}