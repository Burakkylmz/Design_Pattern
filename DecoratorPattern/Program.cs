using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DecoratorPattern
{
    /*Decorator Pattern'ın amacı dinamik olarak nesneye yeni durum ve davranış eklemenin bir yolunu sağlamaktır. Nesne dekore edildiğini bilmediğinden bu durum gelişen sistemler için faydalı bir model haline geliyor. Dekoratör modelindeki önemli bir uygulama noktası, dekoratörlerin hem orjinal sınıfı miras alması hemde bir örneklemin kendisini içermesidir.
     
        Decorator Pattern Bileşenleri
        1.Component: Operasyonların eklenmiş veya değiştirilmiş olabilecek orijinal bir nesne sınıfı (burada böyle bir sınıftan bir kaç tane bulunabilir)
        2.Operation: IComponent nesnelerinde değiştirilebilecek bir işlem
        3.IComponent: Dekore edilecek nesne sınıflarını tanımlayan arayüz
        4.Dekoratör: IComponent interface'sine uyan durum veya davranış ekleyen bir sınıf
         
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
            IComponent component = new Component();
            Display("1. Basic component: ", component);
            Display("2. A-decorated : ", new DecoratorA(component));
            Display("3. B-decorated : ", new DecoratorB(component));
            Display("4. B-A-decorated : ", new DecoratorB(new DecoratorA(component)));

            DecoratorB b = new DecoratorB(new Component());
            Display("5. A-B-decorated : ", new DecoratorA(b));
            //Eklenen duurmu ve davranışı çağırmak
            Console.WriteLine("\t\t\t" + b.addedState + b.AddedBehavior());
            Console.ReadKey();
        }
    }

    interface IComponent
    {
        string Operation();
    }

    class Component : IComponent
    {
        public string Operation()
        {
            return "I produce network infrastructure";
        }
    }

    class DecoratorA : IComponent
    {
        IComponent component;

        public DecoratorA (IComponent c)
        {
            component = c;
        }

        public string Operation()
        {
            string s = component.Operation();
            s += "with Software Defined Network.";
            return s;
        }
    }

    class DecoratorB : IComponent
    {
        IComponent component;

        public string addedState = "and developmet some robotic process";

        public DecoratorB(IComponent c)
        {
            component = c;
        }

        public string Operation()
        {
            string s = component.Operation();
            s += "to my company";
            return s;
        }

        public string AddedBehavior()
        {
            return "also I studied my master degree.";
        }
    }

    class Client
    {
        public static void Display(string s, IComponent c)
        {
            Console.WriteLine(s + c.Operation());
        }
    }
}
