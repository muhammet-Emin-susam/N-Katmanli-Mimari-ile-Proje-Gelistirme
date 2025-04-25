# 🧱 N Katmanlı Mimari ile ASP.NET Core Web Projesi

Bu proje, ASP.NET Core kullanılarak geliştirilen ve N Katmanlı Mimari prensiplerine uygun olarak yapılandırılmış bir web uygulamasıdır. Proje, Entity Framework Core ile veritabanı işlemleri gerçekleştirir ve Bootstrap ile responsive bir kullanıcı arayüzü sunar.

## 🚀 Proje Özellikleri

- **N Katmanlı Mimari**: Proje, Presentation, Business, Data Access ve Entity katmanlarından oluşmaktadır.
- **Entity Framework Core**: Code First yaklaşımı ile veritabanı işlemleri gerçekleştirilmiştir.
- **Generic Repository Deseni**: Veritabanı işlemleri için tekrar kullanılabilir ve genişletilebilir bir yapı sağlanmıştır.
- **Fluent Validation**: Kullanıcı girdileri için doğrulama kuralları uygulanmıştır.
- **Bootstrap**: Duyarlı ve kullanıcı dostu bir arayüz tasarımı sunulmuştur.

## 🛠️ Kullanılan Teknolojiler

- ASP.NET Core
- Entity Framework Core
- SQL Server
- Fluent Validation

## 📁 Proje Yapısı

- **Presentation Layer**: Kullanıcı arayüzü ve controller'ları içerir.
- **Business Layer**: İş kuralları ve servisleri barındırır.
- **Data Access Layer**: Veritabanı işlemleri ve repository'leri içerir.
- **Entity Layer**: Veritabanı tablolarına karşılık gelen sınıfları barındırır.

## 📌 Kurulum

1. Bu repoyu klonlayın:
   ```bash
  git clone https://github.com/muhammet-Emin-susam/N-Katmanli-Mimari-ile-Proje-Gelistirme.git
  
2.Gerekli NuGet paketlerini yükleyin.

3.Veritabanı bağlantı dizesini appsettings.json dosyasında yapılandırın.

