using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DecoratorPattern
{
    /*Decorator Pattern'ın amacı dinamik olarak nesneye yeni durum ve davranış eklemenin bir yolunu sağlamaktır. Nesne dekore edildiğini bilmediğinden bu durum gelişen sistemler için faydalı bir model haline geliyor. Dekoratör modelindeki önemli bir uygulama noktası, dekoratörlerin hem orjinal sınıfı miras alması hemde bir örneklemin kendisini içermesidir.
      
        Bu desenin temel özelliği, davranışı genişletmek için mirasa dayanmamasıdır. Decorator Pattern ile Arayüzlere herhangi bir yöntem uygulayarak bileşenin başlangıç davranışını değiştirebilirsiniz. Herhangi bir yeni durum ve davranış eklenebilir ve herhangi bir sınıfın public üyesine costruction üzerinden nesne ile erişim sağlanabilir.

        Decorator Pattern ne zaman tercih etmeliyim
        1.Alt sınıflandırma için kullanılmayan mevcut bir bileşen sınıfna sahipken
        2.Bir nesneye dinamik olarak ek durum veya davranış eklemek istediğimde
        3.Sınıftaki bazı nesnelerde diğer sınıfları etkilemeden değişiklikler yapmak istediğimizde
        4.Alt sınıflama yapmaktan kaçındığım durumlarda çünkü çok fazla sınıf ortaya çıkabilir 
         */

    class Program
    {
        static void Main(string[] args)
        {
            IBilesen component = new Bilesen();

            Client.Display("1. Basit bileşen: ", component);
            Client.Display("2. A-decorated : ", new DecoratorA(component));
            Client.Display("3. B-decorated : ", new DecoratorB(component));
            Client.Display("4. B-A-decorated : ", new DecoratorB(new DecoratorA(component)));

            DecoratorB b = new DecoratorB(new Bilesen());
            Client.Display("5. A-B-decorated : ", new DecoratorA(b));
            //Eklenen durmu ve davranışı çağırmak
            Console.WriteLine("\t\t\t" + b.addedState + b.EklenenDavranis());
            Console.ReadKey();
        }
    }

    interface IBilesen//Dekore edilecek nesne sınıflarını tanımlayan arayüz
    {
        string Operasyon();
    }

    class Bilesen : IBilesen//Operasyonların eklenmiş veya değiştirilmiş olabilecek orijinal bir nesne sınıf
    {
        public string Operasyon()//IComponent nesnelerinde değiştirilebilecek bir işlem
        {
            return "Çalıştığım firma için";
        }
    }

    class DecoratorA : IBilesen//IComponent interface'sine uyan durum veya davranış ekleyen bir sınıf
    {
        IBilesen bilesen;

        public DecoratorA (IBilesen b)
        {
            bilesen = b;
        }

        public string Operasyon()
        {
            string s = bilesen.Operasyon();
            s += "Yazılım Tanımlı Ağlar ile";
            return s;
        }
    }

    class DecoratorB : IBilesen//IComponent interface'sine uyan durum veya davranış ekleyen bir sınıf
    {
        IBilesen bilesen;

        public string addedState = "ağ altyapısı üretiyorum";

        public DecoratorB(IBilesen b)
        {
            bilesen = b;
        }

        public string Operasyon()
        {
            string s = bilesen.Operasyon();
            s += "ve bazı robotik süreçler geliştiriyorum.";
            return s;
        }

        public string EklenenDavranis()
        {
            return "Ayrıca yüksek lisans öğrencisiyim.";
        }
    }

    class Client
    {
        public static void Display(string s, IBilesen c)
        {
            Console.WriteLine(s + c.Operasyon());
        }
    }
}
