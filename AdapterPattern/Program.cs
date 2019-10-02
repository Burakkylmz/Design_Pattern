using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterPattern
{
    /*Adapter Pattern sistemin arabirimleri gereksinimlerine tam olarak uymayan sınıfları kullanılmasını sağlar. Bu pattern özellikle hazır kodlar, araç setleri ve kütüphaneler için kullanışlıdır. Adapter Pattern'ın bir çok örneği input/output gerektirir. Örneğin geçmiş yıllarda yazılmış olan bir uygulama günümüz uygulamalarından farklı kullanıcı arayüzlerine sahip olacaktır. Sistemin bu bölümlerini yeni donanım kaynak ve olanaklarına uyarlamak, yeniden yazmaktan çok daha uygun maliyetli olacaktır. Burada araç kitleri adaptörlere ihtiyaç duyar. Yeniden kullanım için tasarlanmış olsalarda, tüm uygulamalar araç setlerinin sağladığı arabirimleri kullanamk istemeyecektir. Bu gibi durumlarda bağdaştırıcı uygulamadan çağrıları kabul edebilir ve araç takımı yöntemleriyle cağrıları uygun aktivitelere dönüştürebilir. Bu desnin önemli katkısı programlamayı arayüzlerle teşvik etmesidir. */
    class Program
    {
        static void Main(string[] args)
        {
            Uyarlayıcı birinciAdaptor = new Uyarlayıcı();
            Console.WriteLine(birinciAdaptor.SpesifikIstek(5,3));

            IHedef ikinciAdaptor = new Adaptor();
            Console.WriteLine(ikinciAdaptor.Istek(5));
            Console.ReadKey();
        }
    }

    class Uyarlayıcı//Uyarlanması gereken bir uygulama
    {
        public double SpesifikIstek (double a, double b)
        {
            return a / b;
        }
    }

    interface IHedef//Client'ın kullanmak istediği arayüz
    {
        string Istek(int i);
    }

    class Adaptor : Uyarlayıcı, IHedef //IHedef arayüzünü Uyarlayıcı açısından uygulayan sınıf
    {
        public string Istek(int i) //Client'ın istediği herhangi bir işlem
        {
            return "Yaklaşık tahmin " + (int)Math.Round(SpesifikIstek(i, 3));
        }
    }
}
