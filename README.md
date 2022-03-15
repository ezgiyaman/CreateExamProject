
* ## Projemin daha anlaşılır olması için Onion Architecture uyarak Domain Design Pattern mantığı ile gerçekleştirdim.
* ## Veritabanı  : SQLite 
* ## ORM Aracı : Tasarlama sırasında Entity Framework’den yararlanarak Code first yaklaşımı ile geliştirdim.
* ## Programlama Dili: C#
* ## Uygulama Dil : ASP.NET Core




## Sınav Sistemine Giriş İçin : 
  * Kullanıcı Adı : ezgiymn
  * Şifre : 123



1.Katmanlı mimari üzerinden projemi kuracağım için öncellikle Blank Solution açtım.

 ## 2.Domain adında Class Library türünde projemi açıp,
 
Bu katmanda :

Bu katmanda ihtiyacım doğrultusunda aşağıdaki paketi yükledim.Üyelik işlemleri için : 

 - Microsoft.Extensitation.Identity.Stores 


 2.1.Enums klasörü açıp Status.cs enumlarımı tanımladım.
2.2.Entities Folder'ı açıp proje boyunca kullanacağım ana class'larımı belirtiyorum.
Interface Folder altında IBaseEntity class'ında Concretelerin hepsi bu sınıfı implement edip kendisine ait özellikler kazandırır.
Concrete Folder'ında proje de ihtiyaç duyulan varlıklar ilişkisel veri tabanı standartına göre dizayn ettim.

2.3.Repository Pattern kullandım.Veritabanında CRUD (Create Read Update Delete) işlemleri için oluşturmuş olduğum kodların tekrar kullanılabilirliğini sağlamak için.Bu pattern kod tekrarını önlemede büyük önem taşır.
2.4.Repository Patternle kullanılıp veritabanı maliyetlerini oldukça minimize eden bir tasarım deseni olduğu için Unit Of Work Pattern kullandım.Unit Of Work tasarım deseni,veritabanıyla ilgili her bir aksiyonu anlık olarak veritabanına yansıtılmasını engelleyen ve tüm aksiyonların birikip bir bütün olarak bir defada tek bir connection üzerinden gerçekleşmesini sağlayan tasarım desenidir.

 ## 3.Infrastructure adında Class Library türünde projemi açıp,
 
Bu katmanda : 

* Domain katmanını Infrastructure katmanına refarances olarak ekledim.

İhtiyacım doğrultusunda aşağıdaki paketleri yükledim.

* Microsoft.EntityFrameworkCore.Tools 
* Microsoft.EntityFrameworkCore.Sqlite 
* Microsoft.AspNetCore.Identity.EntityFrameworkCore 5.0.12


## 4."Application" adında Class Library türünde projemi açıp,

Bu katmanda :

 İhtiyacım doğrultusunda aşağıdaki paketleri yükledim.

* AutoMapper
* AutoMapper.Extensions.Microsoft.DependencyInjection
* Autofac.Extensions.DependencyInjection
* FluentValidation.AspNetCore 
* FluentValidation.DependencyInjectionExtension
* Microsoft.AspNetCore.Http.Features

* Domain ve Infrastructure katmanları refarances olarak ekledim.

4.1.Models Folderının altında oluşturmuş olduğum, DTO, VM folderlarında business
mantığıma göre ihtiyacım olan data transfer objelerini ve view model'ler oluşturdum.
4.2.AutoMapper içerinde oluşturmuş olduğum VM ve DTOları Mapleme işlemi gerçekleştirdim.
4.3.FluentValidation klasörü açıp bu klasör içerisinde kullanıcı giriş yaparken ve kayıt olurken uyulması gereken kuralları 3rd part tool ile belirttim.
4.4.Servis folder içerisinde Interface klasöründe Business mantıklarımı yürütürken kullanacağım methodlarımı soyut olarak oluşturdum.Concrete klasöründe ise Business mantıklarımı yürütürken kullanacağımız methodlarımı somutlaştırdım.
4.5.IoC : Alt yapı geliştirken sıkı sıkıya bağlı (tight coupled) olmadan  gevşek bağlanmış (loosely coupled) bir şekilde geliştirmeye çalıştım , esnek bir şekilde entegre edebilmek için dependency inversion (bağımlılığın ters çevirilmesi) prensibinden faydalanarak alt yapıyı esnek ve tekrar kullanılabilir bir şekilde tasarladım.

## 5. "Prensentation" adında Asp.net Core web Application (model-view-controller) projesi açtım.Prensentation,kullanıcının uygulama ile iletişime geçtiği katmandır. 

* Application ve Infrastructure katmanlarınıı rerefences olarak ekledim.

İhtiyacım doğrultusunda aşağıdaki paketleri yükledim.

* Microsoft.EntityFrameworkCore.Design
* Microsoft.VisualStudio.Web.CodeGeneration.Design
* HtmlAgilityPack

5.1.Program.cs sınıfına autofac ekledim.IIS ayağa kaldırılırken 3rd part olarak kullandığım Autofac cointanier ayağı kaldırılması gerekmektedir.

5.2.Startup sınıfında :
  * SqLite Resolve ettim.
     => appsettings.json  içinde ConnectionString tanımladım.

     "AllowedHosts": "*",
  "ConnectionStrings": {
    "ProjectContext": "Data Source=CreateExamProject.db"}

  * FluentValidation koyduğum kuralların çalışması için Startupta belirttim.
  * Identity Resolve ettim.
  * LogIn işlemi için endpoints yolunu belirttim.
















