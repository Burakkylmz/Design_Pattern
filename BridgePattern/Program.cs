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
            Console.WriteLine(new Abstraction(new ImplementationA()).Operation());
            Console.WriteLine(new Abstraction(new ImplementationB()).Operation());
            Console.ReadKey();
        }
    }

    class Abstraction
    {
        Bridge bridge;
        public Abstraction(Bridge implementation)
        {
            bridge = implementation;
        }

        public string Operation()
        {
            return "Abstraction" + "<<<BRIDGE>>>" + bridge.OperationImp();
        }
    }

    interface Bridge
    {
        string OperationImp();
    }

    class ImplementationA : Bridge
    {
        public string OperationImp()
        {
            return "ImplementationA";
        }
    }

    class ImplementationB : Bridge
    {
        public string OperationImp()
        {
            return "ImplementationB";
        }
    }
}
