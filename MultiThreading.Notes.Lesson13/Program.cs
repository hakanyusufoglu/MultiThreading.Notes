#region System.Threading.Timer
Timer timer = new(state =>
{
Console.WriteLine(state);
}, "Tick!", 15000, 100); //15 saniye sonra 100 ms'de bir console writeline çalıştırıyor. 100 yerine Timeout.Infinite diyerek sonsuz döngü yapılabilir.

Thread.Sleep(20000);

//Periyodik çalışma zamanı değiştirmek için kullanılır
timer.Change(0, 1500); //artık 1.5 saniyede bir çalışacak.

Console.ReadLine(); 
#endregion