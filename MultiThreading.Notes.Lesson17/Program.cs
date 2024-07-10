#region ConfigureAwait
//// ConfigureAwait(false) şu işe yarar. Eğer bir task'in sonucunu kullanmayacaksak ve sadece bir işlemi başlatıp sonucunu kullanmayacaksak, 
//// bu durumda ConfigureAwait(false) kullanarak işlemi başka bir thread üzerinde çalıştırabiliriz. 
//// Bu sayede işlemi başka bir thread üzerinde çalıştırarak mevcut thread üzerindeki işlemlerin bloklanmasını engelleyebiliriz. 
//// Bu sayede performansı arttırabiliriz.
//async Task<string> ReadFileAsync(string path)
//{
//    StreamReader reader = new StreamReader(path);
//    // Buradaki işlemden sonra bir task döndürüyoruz. Bu task'in sonucunu kullanacağız, bu durumda ConfigureAwait(false) kullanarak 
//    // işlemin bitişini başka bir thread üzerinde bekleyebiliriz. Ancak dönen sonucu burada kullanmak istediğimiz için dikkatli olmalıyız.

//    // ConfigureAwait(true) kullanarak işlemi mevcut thread üzerinde çalıştırabiliriz. ve işlemler mevcut thread üzerinden devam eder.
//    var content = await reader.ReadToEndAsync().ConfigureAwait(false);

//    // ConfigureAwait(false) kullanarak işlemin devamının başka bir thread üzerinde çalışmasına izin veriyoruz. 
//    // Ancak bu durumda UI thread'i gerekmeyen bir console uygulaması olduğundan, devam eden işlemler thread bağımsız olabilir.
//    Console.WriteLine($"End.");

//    return content;
//}

//var filePath = Path.Combine(AppContext.BaseDirectory, "textfile.txt");
//var content = await ReadFileAsync(filePath);

//Console.WriteLine($"Content: {content}");

#endregion

#region CancellationToken & CancellationTokenSource
//CancellationToken: Ampül 
//CancellationTokenSource: Ampülü yanmasını sağlayacak kaynak 

//CancellationToken: Bir işlemi iptal etmek için kullanılır. Bir işlemi başlatırken CancellationToken parametresi alarak işlemi iptal edebiliriz.
//CancellationTokenSource: CancellationToken nesnesini oluşturmak için kullanılır. CancellationTokenSource nesnesi oluşturarak CancellationToken nesnesi oluşturabiliriz.

async Task DoWorkAsync(CancellationToken cancellationToken)
{
    for (int i = 0; i < 10; i++)
    {
        //Cancellation token kontrolü yapılması için kullanılır. İşlem iptal edildi mi? edilmedi mi? kontrolü yapılır.
        cancellationToken.ThrowIfCancellationRequested();
        await Console.Out.WriteLineAsync($"{i}");

        await Task.Delay(1000);
    }

    Console.WriteLine("Work completed...");
}

CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

Task.Run(async () =>
{
    //3 saniye sonra işlemi iptal et
    Task.Delay(3000);
    await cancellationTokenSource.CancelAsync();
});


try
{
    await DoWorkAsync(cancellationTokenSource.Token);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
#endregion

#region Task & ValueTask
//Ağır işlemler için Task kullanılır. (Heapte saklanır)
//Hafif işlemler için ValueTask kullanılır. (Stackte saklanır) Tasktaki tüm propertyler geçerlidir.
async Task X()
{

}

//Örnek 1+1 işlemi burada yapılır (en basit örnek)
async ValueTask Y()
{
}

await X();
await Y();
#endregion