# Exchange Rate Project

Bu proje, TCMB'den alınan döviz kurlarını veritabanına kaydeden bir Data API, bu kurları önbelleğe alıp istemcilere sunan bir Business API ve bu verilerle grafik oluşturan bir Currency Web Sitesi içerir.

## İçindekiler

1. [Giriş](#1-giriş)
    1.1. [Data API](#11-data-api)
    1.2. [Business API](#12-business-api)
    1.3. [Currency Web Sitesi](#13-currency-web-sitesi)
2. [Çalışma Ortamı](#2-çalışma-ortamı)


## 1. Giriş

Bu projede, TCMB'nin belirtilen linkteki verilerini son 2 ay içerisindeki döviz kurlarıyla bir veritabanına kaydeden bir Data API geliştirildi.

### 1.1. Data API

Data API, belirtilen linkteki verileri PostgreSQL veritabanına kaydeder. EFCore kullanılarak veri katmanı geliştirildi ve API, Swagger belgelerini destekler.

### 1.2. Business API

Business API, önbelleğe alınan döviz kurlarını veritabanından çeker. Veri kaynağı olarak önbellek veritabanı kullanılır ve API, Swagger belgelerini destekler.

### 1.3. Currency Web Sitesi

Currency Web Sitesi, ASP.Net Core MVC kullanılarak oluşturuldu. Arama düğmesine tıklandığında, Business API'den veri alır ve d3js framework'üyle grafik oluşturur. Web sayfası, Ajax ile Business API'yi çağırır ve jQuery ve Bootstrap framework'lerini kullanır.

## 2. Çalışma Ortamı

Projeyi çalıştırmak için Docker kullanılır. Docker-compose ile aşağıdaki bileşenleri çalıştırabilirsiniz:
- Data API
- Business API
- Veritabanı Sunucusu
- Currency Web Sitesi

![Exchange Rate Project](https://i.hizliresim.com/8u0i1dg.png)
