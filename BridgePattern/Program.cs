using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgePattern
{
    /*Bridge Pattern mevcut bir sürümün yerini alacak yeni bir yazılım sürümü çıkarıldığında kullanışlıdır. Uygulamasından bir soyutlamayı ayırır ve bağımsız olarak değişmelerini sağlar.Bridge çok basit ama çık güçlü bir kalıptır. Tek bir uygulama göz önüne alındığında bir köprü ve bir soyutlama ile birlikte ikinci bir tane ekleyebilir ve original tasarım üzerinde kayda değer bir genellik kazanabiliriz.
     
         Bu modeli şu durumlarda kullanın:
         1.Her zaman aynı şekilde uygulanması gerekmeyen işlemler olduğunda bu gibi durumlarda
         2.Uygulamaları client'tan tamamen gizlemek istediğimizde
         3.Bir soyutlamayı tekrar derlemeden bir uygulamayı değiştirmek istediğimizde.
         4.Çalışma zamanında bir sistemin farklı parçalarını birleştirmke istediğimizde.*/
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(new Soyutlama(new Uygulama_A()).Operasyon());
            Console.WriteLine(new Soyutlama(new Uygulama_B()).Operasyon());
            Console.ReadKey();
        }
    }

    class Soyutlama//client'ın gördüğü arayüz
    {
        Kopru kopru;
        public Soyutlama(Kopru uygulama)
        {
            kopru = uygulama;
        }

        public string Operasyon()//client tarafından çağrılan bir yöntem
        {
            return "Soyutlama" + "==Koprü==" + kopru.OperasyonUygulaması();
        }
    }

    interface Kopru //Soyutlamanın farklı olabilecek kısımlarını tanımlayan bir interface
    {
        string OperasyonUygulaması();
    }

    class Uygulama_A : Kopru // Köprü uygulamaları
    {
        public string OperasyonUygulaması()
        {
            return "Uygulama A"; // Köprüde, Soyutlama işleminden çağrılan bir yöntem
        }
    }

    class Uygulama_B : Kopru //Köprü uygulamaları
    {
        public string OperasyonUygulaması()
        {
            return "Uygulama_B";
        }
    }
}
