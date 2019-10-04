using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypePattern
{
    class Program
    {
        /*Prototype Pattern: Birkaç depolanmış prototipten birirni klonlayarak yeni nesneler yaratılır. Prototype modelinin iki avantajı bulunmaktadır. Çok büyük dinamik olarak yüklenmiş sınıfların (nesnelerin kopyalanması daha hızlı olduğunda) başlatılmasını hızlandırır ve alt sınıfı  kopyalanabilen büyük bir veri yapısının tanımlanabilir bölümlerinin kaydını tutar.

          Prototype Pattern şu durumlarda kullanın
        1.Client'tan somut sınıfları gizlemek istediğinde
        2.Prototipler aracılığıyla çalışma ananında yeni sınıflar eklemek ve kaldırmak istediğimizde
        3.Sistemdeki sınıf sayısını minimumda tutmak istediğimde
        4.Composite pattern ile arşilemeyi sağlamayı düşündüğümüzde
        5.Alt sınıfların çoğalmaya başladığı durumlarda Factory Method Pattern yerine düşünülebilir
        
            Prototip modeli bir sınıfın bir modelini seçer ver gelecekteki tüm durumlar için onu üretici olarak kullanır. Composite and Decorator patterns yoğun olarak faydalınan tasarımlar. Prototipler, nesne başlatmanın maliyetli olduğu durumlarda faydalıdır ve başlatma parametrelerinde birkaç değişiklik olmasını beklersiniz. Bu bağlamda, Prototip modeli, önceden başlatılmış bir prototipin ucuz klonlanmasını destekleyen maliyetli “sıfırdan yaratma” işlemlerinden kaçınabilir. Nesne üretim maliyetlerinin minimize etemk amaçlanmaktadır. 
             */

        static void Main(string[] args)
        {

        }

        class Veri
        {
            public string;
        }
    }
}
