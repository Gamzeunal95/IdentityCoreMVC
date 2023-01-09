
# IdentityCoreMVC
MVC Projecesi Açıldı.


# Project 1 - IdentityCoreMVC
- Aşağıdaki paketler install edildi.
- Microsoft.AspNetCore.Identity.EntityFrameworkCore
- Microsoft.EntityFrameworkCore.SqlServer
- Microsoft.EntityFrameworkCore.Tools

ettıbute Route ??

Bu projede ıdentity ayarları yazıldı. Kullanıcı olusturma kriterleri - kullanıcı register işlemleri - SMTP ayarları ile alakalı çalışmalar yapıldı.
SMTP ile ilgili onay maili atma işlemi başarısız oldu SMTP ayarlarından kaynaklı hata aldık.

# Project 2 - Mersin.Api
- Api projesi 
- Mernis DB kullanıldı. 
- Postgresql üzerinden başka pc ye bağlanıldı.
- DBeaver kullanıldı. Postgresql seçildi.
#### NOT:
postgresql dump import bak (evde mernis db kullanabilmek için)[bu dökümandan](https://www.postgresql.org/docs/current/backup-dump.html) bakabilirsin.
- Aşağıdaki paketler install edildi.
- Npgsql.EntityFrameworkCore.PostgreSQL
- Npgsql.EntityFrameworkCore.PostgreSQL.Design
- Microsoft.EntityFrameworkCore.Design
- Microsoft.AspNetCore.Authentication.JwtBearer
------------------------------------------------------
- Aşağıdaki komutla terminalde projeye konumlanıp mernis scaffold edildi
- `dotnet ef dbcontext scaffold "Server=11.0.17.100;Port=5432;Database=Mernis;User Id=postgres;Password=123;" Npgsql.EntityFrameworkCore.PostgreSQL -o entities`
------------------------------------------------------
- **Controller**
- API Controller -> MernisController 
- API Controller -> Logincontroller 

- **Entities** 
- Users class
- Role
- UserRole

- **Models**
- Token
- TokenHandler
- LoginModel
------------------------------------------------------
- appsettings.json içine ConnectionStrings yazıldı.
- program.cs de dbcontext eklemesi yap belirttiğimiz connectionstring bu kısımda tanımlandı
------------------------------------------------------
jwt token

- Cascadia Mono font tipini kullanıyordukm Cascadia Code kullandım UNUTMA
- API Controller kullanıyorsun apı için

![tcilesorgulama](https://user-images.githubusercontent.com/101207897/211054641-3592af6a-897a-4868-b98b-29177ed750ba.png)
![Tokenaldıktansonra10veri](https://user-images.githubusercontent.com/101207897/211054645-7f1a80f7-902c-4452-84e0-c2b689ede7d7.png)
![Tokenalmakiçin](https://user-images.githubusercontent.com/101207897/211054650-adf8efce-7047-4a1a-b04c-821c01222984.png)


# Project 3 - TestApiConsole  (Bu Proje ve Mersin.APi birlikte çalıştırıldı.)
- [Convert Json to C#](https://json2csharp.com/)
- Aşağıdaki classlar açıldı.
  - LoginModel
  - Token
  - Citizen
  - WebApiService
- Aşağıdaki paketler eklendi.
  - Newtonsoft.Json

## NOT
- **VISUAL STUDIODA BİRDEN FAZLA PROJEYİ ÇALIŞTIRMAK İÇİN**
- Solution'a sağ click 
- Configure Startup Projects
- Multiple Startıp Projects -> bu kısımdan hangi projeler aynı anda çalışsın istiyorsanız Action kısmından güncelleyerek Uygula demeniz yeterli.
  

