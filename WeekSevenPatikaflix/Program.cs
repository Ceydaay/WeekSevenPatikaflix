using WeekSevenPatikaflix;


class Program
{
    static void Main(string[] args)
    {
        List<Dizi> diziler = new List<Dizi>();
        string devam;

        // Dizi ekleme
        do
        {
            Dizi yeniDizi = new Dizi();

            Console.WriteLine("Dizi adını giriniz:");
            yeniDizi.DiziAdi = Console.ReadLine();

            Console.WriteLine("Yapım yılını giriniz:");
            yeniDizi.YapimYili = int.Parse(Console.ReadLine());

            Console.WriteLine("Türünü giriniz:");
            yeniDizi.Turu = Console.ReadLine();

            Console.WriteLine("Yayınlanmaya başlama yılını giriniz:");
            yeniDizi.YayinaBaslamaYili = int.Parse(Console.ReadLine());

            Console.WriteLine("Yönetmen adını giriniz:");
            yeniDizi.Yoneten = Console.ReadLine();

            Console.WriteLine("Yayınlandığı ilk platformu giriniz:");
            yeniDizi.YayimlananIlkPlatform = Console.ReadLine();

            diziler.Add(yeniDizi);

            Console.WriteLine("Başka bir dizi eklemek istiyor musunuz? (e/h)");
            devam = Console.ReadLine();
        }
        while (devam.ToLower() == "e");

        // Komedi dizilerini filtreleme
        List<KomediDizi> komediDiziler = diziler
            .Where(d => d.Turu.ToLower() == "komedi")
            .Select(d => new KomediDizi
            {
                DiziAdi = d.DiziAdi,
                Turu = d.Turu,
                Yoneten = d.Yoneten
            })
            .OrderBy(d => d.DiziAdi)
            .ThenBy(d => d.Yoneten)
            .ToList();

        // Sonuçları ekrana yazdırma
        foreach (var dizi in komediDiziler)
        {
            Console.WriteLine($"Dizi Adı: {dizi.DiziAdi}, Tür: {dizi.Turu}, Yönetmen: {dizi.Yoneten}");
        }
    }
}
