using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyPattern
{
    /*Proxy Pattern diğer nesnelerin oluşturulmasını ve bunlara erişimi kontrol eden nesneleri destekler. Proxy genellikle belirli koşullar netleştiğinde etkinleştirilen daha karmaşık (özel) bir nesnenin yerine geçen küçük (genel) bir nesnedir.*/


    class Program
    {
        static void Main(string[] args)
        {
            //subject => konu
            IKonu subject = new Proxy();

            Console.WriteLine(subject.Talep());            Console.WriteLine(subject.Talep());

            ProtectionProxy subjectProxy = new ProtectionProxy();
            Console.WriteLine(subjectProxy.Talep());
            Console.WriteLine((subjectProxy as ProtectionProxy).KimlikDogrulaması("Secret"));
            Console.WriteLine((subjectProxy as ProtectionProxy).KimlikDogrulaması("besatMikeTyson"));            Console.WriteLine(subjectProxy.Talep());

            Console.ReadKey();
        }
    }


    interface IKonu//Nesneler ve procy'ler için birbirlerinin yerine kullanılmalarını sağlayan ortak bir arabirim
    {
       string Talep();
    }

    class Konu//Bir proxy'nin temsil ettiği sınıf
    {
        public string Talep() //Konuyla ilgili bir proxy üzerinden yönlendirilen bir işlem
        {
            return "Subject Talebi ";
        }
    }
     //Proxy => Vekil
    public class Proxy : IKonu //Bir Konuya erişimi oluşturan, kontrol eden, geliştiren ve doğrulayan bir sınıf
    {
        Konu konu;

        public string Talep()
        {
            if (konu == null)
            {
                Console.WriteLine("Subject aktif değil");
                konu = new Konu();
            }
            Console.WriteLine("Subject aktif");
            return "Proxy: Çağrılıyor... " + konu.Talep();
        }
    }

    public class ProtectionProxy : IKonu
    {
        Konu konu;
        string sifre = "besatMikeTyson";

        public string KimlikDogrulaması (string gelenSifre)
        {
            if (gelenSifre != sifre)
            {
                return "Protection Proxy : Erişim yok";
            }
            else
            {
                konu = new Konu();
                return "Protection Proxy: Kimlik Doğrulanmış";
            }
        }

        public string Talep()
        {
            if (konu == null)
            {
                return "Protection Proxy: Önce Kimliğini Doğrula";
            }
            else
            {
                return "Protection Proxy: Çağrılıyor... " + konu.Talep();
            }
        }
    }
}
