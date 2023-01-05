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
------------------------------------------------------
- Aşağıdaki komutla terminalde projeye konumlanıp mernis scaffold edildi
- `dotnet ef dbcontext scaffold "Server=11.0.17.100;Port=5432;Database=Mernis;User Id=postgres;Password=123;" Npgsql.EntityFrameworkCore.PostgreSQL -o entities`
------------------------------------------------------
- Controller
- API Controller -> MernisController 
------------------------------------------------------
- appsettings.json içine ConnectionStrings yazıldı.
- program.cs de dbcontext eklemesi yap belirttiğimiz connectionstring bu kısımda tanımlandı
------------------------------------------------------
