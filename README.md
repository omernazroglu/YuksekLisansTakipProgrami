<div align="center">

<img src="https://readme-typing-svg.demolab.com?font=Inter&weight=700&size=32&pause=1000&color=3B82F6&center=true&vCenter=true&width=600&lines=GradTracker+%F0%9F%8E%93;Y%C3%BCksek+Lisans+Ba%C5%9Fvuru+Takip+Sistemi" alt="GradTracker" />

<br/>

![ASP.NET Core](https://img.shields.io/badge/ASP.NET_Core-8.0-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![EF Core](https://img.shields.io/badge/Entity_Framework_Core-8.0-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![SQL Server](https://img.shields.io/badge/SQL_Server-LocalDB-CC2927?style=for-the-badge&logo=microsoftsqlserver&logoColor=white)
![CSS](https://img.shields.io/badge/Custom_CSS-Zero_Bootstrap-1572B6?style=for-the-badge&logo=css3&logoColor=white)
![C#](https://img.shields.io/badge/C%23-12.0-239120?style=for-the-badge&logo=csharp&logoColor=white)

<p align="center">
  <b>Üniversite yüksek lisans ilanlarını takip edin, ALES/dil puanlarını karşılaştırın, son başvuru tarihlerini kaçırmayın.</b>
</p>

</div>

---

## ✨ Özellikler

<table>
<tr>
<td width="50%">

### 📊 Dashboard
- Tüm ilanları son başvuru tarihine göre sıralı görüntüle
- **Renk kodlu** durum göstergesi:
  - 🟢 Aktif başvurular
  - 🟡 7 gün veya daha az kalanlar
  - ⚫ Süresi dolmuş ilanlar
- Anlık istatistik kartları (Toplam / Aktif / Acil / Süresi Dolmuş)

</td>
<td width="50%">

### 🔍 Arama & Filtreleme
- Üniversite veya bölüm adına göre **canlı arama**
- Durum bazlı **sekme filtreleri**
  - Tümü / Aktif / Acil / Süresi Dolmuş

</td>
</tr>
<tr>
<td width="50%">

### ➕ İlan Yönetimi
- Yeni ilan ekleme formu (ALES, dil puanı, tarih)
- **Dinamik toggle**: Dil puanı alanı, yalnızca gerektiğinde görünür
- Düzenleme ve silme işlemleri
- Server-side + client-side validasyon

</td>
<td width="50%">

### 🎨 Modern Tasarım
- Bootstrap **yok** — tamamen sıfırdan özel CSS
- Koyu glassmorphism tema
- Hover animasyonları & micro-interactions
- Tam responsive (mobil / tablet / masaüstü)

</td>
</tr>
</table>

---

## 🖼️ Ekran Görüntüleri

> 📌 Uygulama çalıştırıldıktan sonra ekran görüntüleri bu alana eklenebilir.

| Dashboard | İlan Ekleme |
|:---------:|:-----------:|
| *(screenshot)* | *(screenshot)* |

---

## 🛠️ Teknoloji Yığını

| Katman | Teknoloji |
|--------|-----------|
| **Backend** | ASP.NET Core 8 MVC, C# 12 |
| **ORM** | Entity Framework Core 8 (Code-First) |
| **Veritabanı** | Microsoft SQL Server (LocalDB) |
| **Frontend** | HTML5, Vanilla CSS (sıfırdan) |
| **Yazı Tipi** | Google Fonts — Inter |

---

## 🗃️ Veritabanı Modeli

```csharp
public class UniversityProgram
{
    public int     Id                { get; set; }  // PK
    public string  UniversityName    { get; set; }  // Zorunlu, max 200 karakter
    public string  DepartmentName    { get; set; }  // Zorunlu, max 200 karakter
    public decimal MinAlesScore      { get; set; }  // Zorunlu, 0–100
    public bool    RequiresLanguage  { get; set; }  // Yabancı dil gerekiyor mu?
    public decimal? MinLanguageScore { get; set; }  // Nullable
    public DateTime ApplicationDate  { get; set; }  // Son başvuru tarihi
    public DateTime CreatedAt        { get; set; }  // Otomatik
}
```

---

## 🚀 Kurulum & Çalıştırma

### Ön Gereksinimler

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [SQL Server LocalDB](https://learn.microsoft.com/tr-tr/sql/database-engine/configure-windows/sql-server-express-localdb) (Visual Studio ile birlikte gelir)
- [Git](https://git-scm.com/)

### Adım Adım Kurulum

```bash
# 1. Repoyu klonlayın
git clone https://github.com/omernazroglu/YuksekLisansTakipProgrami.git
cd YuksekLisansTakipProgrami

# 2. Bağımlılıkları yükleyin
dotnet restore

# 3. Veritabanını oluşturun (migration uygula)
dotnet ef database update

# 4. Uygulamayı başlatın
dotnet run
```

Tarayıcınızda açın → **http://localhost:5050**

> 💡 İlk çalıştırmada örnek veriler (Ankara Üniversitesi, İTÜ, ODTÜ) otomatik olarak eklenir.

---

## 📁 Proje Yapısı

```
YuksekLisansTakipProgrami/
├── Controllers/
│   ├── HomeController.cs          # Dashboard, arama, filtreleme
│   └── ApplicationsController.cs  # Tam CRUD işlemleri
├── Data/
│   └── AppDbContext.cs            # EF Core DbContext + Seed Data
├── Models/
│   └── UniversityProgram.cs       # Entity model
├── Migrations/                    # EF Code-First migration dosyaları
├── Views/
│   ├── Shared/
│   │   └── _Layout.cshtml         # Master layout (sidebar + topbar)
│   ├── Home/
│   │   └── Index.cshtml           # Dashboard
│   └── Applications/
│       ├── Create.cshtml          # İlan ekleme
│       ├── Edit.cshtml            # Düzenleme
│       ├── Delete.cshtml          # Silme onayı
│       └── Details.cshtml         # Detay sayfası
├── wwwroot/
│   └── css/
│       └── site.css               # ~700 satır özel CSS (Bootstrap yok)
├── appsettings.json               # Bağlantı ayarları
└── Program.cs                     # Uygulama başlangıç noktası
```

---

## ⚙️ Bağlantı Ayarları

`appsettings.json` içindeki bağlantı dizesini ortamınıza göre düzenleyin:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=GraduateAppTrackerDb;Trusted_Connection=True;"
  }
}
```

Farklı bir SQL Server örneği kullanmak için:
```
Server=YOUR_SERVER;Database=GraduateAppTrackerDb;User Id=sa;Password=YourPass;
```

---

## 🤝 Katkı

Pull request'ler memnuniyetle karşılanır. Büyük değişiklikler için lütfen önce bir issue açın.

1. Fork edin
2. Feature branch oluşturun (`git checkout -b feature/yeni-ozellik`)
3. Değişikliklerinizi commit edin (`git commit -m 'feat: yeni özellik eklendi'`)
4. Branch'i push edin (`git push origin feature/yeni-ozellik`)
5. Pull Request açın

---

## 📄 Lisans

Bu proje [MIT](LICENSE) lisansı altında dağıtılmaktadır.

---

<div align="center">

**⭐ Projeyi beğendiyseniz yıldız vermeyi unutmayın!**

Made with ❤️ using ASP.NET Core 8

</div>
