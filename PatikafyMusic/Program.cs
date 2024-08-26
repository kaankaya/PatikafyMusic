using PatikafyMusic;
using System.Linq;
class Program
{
    public static void Main(string[] args)
    {
        //Liste Oluşturma ve Veri Girişi
        List<Artist> artists = new List<Artist>();
        artists.Add(new Artist("Ajda Pekkan", "POP", 1968, 20000000));
        artists.Add(new Artist("Sezen Aksu", "POP", 1971, 10000000));
        artists.Add(new Artist("Funda Arar", "POP", 1999, 3000000));
        artists.Add(new Artist("Sertab Erener", "POP", 1994, 5000000));
        artists.Add(new Artist("Sıla", "POP", 2009, 3000000));
        artists.Add(new Artist("Serdar Ortaç", "POP", 1994, 10000000));
        artists.Add(new Artist("Tarkan", "POP", 1992, 40000000));
        artists.Add(new Artist("Hande Yener", "POP", 1999, 7000000));
        artists.Add(new Artist("Hadise", "POP", 2005, 5000000));
        artists.Add(new Artist("Gülben Ergen", "POP", 1997, 10000000));
        artists.Add(new Artist("Neşet Ertaş", "Türk Halk Müziği", 1960, 2000000));



        //Satışı 10 milyon üzeri olanları listele
        Console.WriteLine("-ALBÜM SATIŞI 10 MİLYON ÜZERİ OLAN SANATÇILAR");
        Console.WriteLine();
        var result = from artist in artists
                     where artist.AlbumSales > 10000000
                     select artist;

        foreach (var artist in result)
        {
            Console.WriteLine($"Sanatçı Adı : {artist.FullName} - Albüm Satış Rakamı : Yaklaşık {artist.AlbumSales.ToString("N0")} Milyon "); //ToString("N0") ile sayıyı ondalık olarak gösteriyoruz.
        }
        Console.WriteLine();
        //En çok Albüm satan sanatçı Gösterme.(Max ile en büyük değeri alıp gösteriyoruz)
        Console.WriteLine("----EN ÇOK ALBÜM SATIŞI OLAN SANATÇI---");
        var result2 = artists.Max(a => a.FullName);
        Console.WriteLine($"En Çok Albüm Satışı Olan Sanatçı : {result2}");
        //En Eski Çıkış Yapan Sanatçı
        Console.WriteLine();
        Console.WriteLine("---EN ESKİ ÇIKIŞ YAPAN SANATÇI----");
        var result3 = artists.OrderBy(x => x.ReleaseYear).FirstOrDefault();
        Console.WriteLine($"En Eski Çıkış Yapan Sanatçı : {result3.FullName}");
        
        Console.WriteLine();
        Console.WriteLine("---EN YENİ ÇIKIŞ YAPAN SANATÇI----");
        //En Yeni çıkış yapan Sanatçı Gösterimi
        var result4 = artists.OrderByDescending(x => x.ReleaseYear).FirstOrDefault();
        Console.WriteLine($"En Yeni Çıkış Yapan Sanatçı : {result4.FullName}");
        Console.WriteLine();
        //Adı 'S' İle başlayanlar starts with ile belirliyoruz
        Console.WriteLine("--S İLE BAŞLAYAN SANATÇILAR----");
        var result5 = from artist in artists
                      where artist.FullName.StartsWith('S')
                      select artist;
        foreach(var artist in result5)
        {
            Console.WriteLine(artist.FullName);
        }

        //2000 Yılı öncesi çıkış yapmış ve pop müzik yapan şarkıcılar

        var result6 = artists
            .Where(x => x.ReleaseYear < 2000 && x.MusicGenre == "POP")
            .OrderBy(x => x.ReleaseYear)
            .ThenBy(x => x.FullName)
            .ToList();

        foreach(var artist in result6)
        {
            Console.WriteLine($"Sanatçı Adı : {artist.FullName} - Çıkış Yılı : {artist.ReleaseYear}");
        }
                     
                      
                      

    }
}