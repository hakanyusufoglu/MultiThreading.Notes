//Async sayesinde bu metot asenkrondur diyebiliyoruz. Bu metot içerisinde asenkron işlemler olacaktır dememizi sağlıyor.
//await ise asenkron metotlarda kullanılır ve işlem bitene kadar bekler.

//Not: async void TestAsync() gibi bir metot olsun bu metodu kullanırken hata alırsak hiçbir şekilde hatayı yakalayamayız. Bu yüzden async Task kullanılır.
async Task<string> ReadFile()
{
    //async & await 
    StreamReader streamReader = new("fileName");
    var task = streamReader.ReadToEndAsync();

    //Asenkron operation 1
    //Asenkron operation 2
    //Asenkron operation 3

    var content = await task;
    return content;

}


