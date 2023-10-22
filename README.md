# E-Sinav-Uygulamasi
Öğrencilerin Öğretmenleri tarafından hazırladıkları sınavları elektronik ortamda çözebilecekleri uygulama.



**1.PROJE KONUSU VE TERCİH EDİLME SEBEPLERİ**

**1.1.Proje Konusu:** 

E-Sınav Sistemi, okul veya dershane gibi eğitim kurumlarının sınav yönetim sürecini dijitalleştirmek ve kolaylaştırmak amacıyla geliştirilen bir uygulamadır.

**1.2.Projenin Tercih Edilme Sebepleri**

Bu konuyu tercih etmemin sebebi şu sıralar gerek Covid-19 gerek yaşanan doğal afetler sebebiyle eğitim öğretim kurumlarında eğitim uzaktan eğitim şeklinde sürdürülmek zorunda kalınabiliyor. Böyle durumlarda öğrencilerin sınavlarını bu sistemle yapmaları için bu projeyi tercih ettim.

**1.3.Projenin Faydaları ve Kullanılacağı Alanlar**

**1 -** Dijitalleştirme ve Verimlilik: Sistem, kağıt kullanımını azaltarak çevre dostu bir yaklaşım sunar ve sınav yönetim sürecini dijitalleştirir. Bu sayede zaman, kaynak ve iş gücünden tasarruf sağlanır. Öğretmenler sınav hazırlama ve değerlendirme süreçlerini daha verimli bir şekilde yönetebilir.

**2 -** Kolay Erişim ve Takip: Öğrenciler, çevrimiçi olarak sisteme erişerek sınavlarını görüntüleyebilir, sınav sonuçlarını takip edebilir ve performanslarını değerlendirebilir. Bu, öğrencilerin sınavlara daha aktif katılımını teşvik eder ve öğrenme sürecine daha fazla dahil olmalarını sağlar.

**3 -** Şeffaflık ve İletişim: Öğrenciler, sınavları çözüp sonuçlarını görüntüledikten sonra sisteme şikayet talepleri oluşturabilir. Bu, öğrencilerin geri bildirimlerini iletmelerini sağlar ve eğitim kurumu ile öğrenci arasında daha iyi bir iletişim ve şeffaflık sağlar.

**4 -** Yönetim Kolaylığı: Müdür kullanıcısı, sisteme sınıflar, dersler ve öğretmenleri ekleyerek yönetim sürecini kolaylaştırır. Dersleri belirli sınıflara ve ilgili öğretmenlere atamak, sınavların düzenlenmesini ve takibini daha verimli hale getirir.

**5 -** Uzaktan Eğitim İmkanı: E-Sınav Yönetim Sistemi, uzaktan eğitim veya hibrit eğitim süreçlerinde de kullanılabilir. Öğrenciler, internet bağlantısı olan herhangi bir yerden sisteme erişebilir ve sınavlara katılabilirler. Bu da öğrenme sürecinin esnekliğini artırır ve öğrencilerin uzaktan eğitimde eşit fırsatlara erişmelerini sağlar.

**2.PROJE KONUSUNUN ANALİZİ VE ÇALIŞMA SİSTEMİ**

**2.1.Proje Konusunun Analizi**

**1 -** Proje gereksinimlerinin belirlenmesi: Müşteri (okul veya dershane) ile görüşmeler yapılarak, sistemden beklentiler ve gereksinimler belirlenir. Bu aşamada, kullanıcı rolleri, kullanıcıların yapabileceği işlemler, veri saklama gereksinimleri ve güvenlik önlemleri gibi detaylar ele alınır.

**2 -** Veri modeli oluşturma: Sistemin gereksinimlerine uygun bir veri modeli tasarlanır. Bu modelde sınıflar, dersler, öğretmenler, öğrenciler, sınavlar, şikayetler gibi temel veri bileşenleri ve ilişkileri bulunur.

**3 -** Arayüz tasarımı: Kullanıcıların sisteme erişebileceği kullanıcı arabirimi (UI) tasarlanır. Bu, kullanıcıların rahatlıkla sistemi kullanabilecekleri, bilgileri giriş yapabilecekleri ve işlemleri gerçekleştirebilecekleri bir arayüz sağlar.

**4 -** Sistem gereksinimleri: Donanım, yazılım ve ağ gereksinimleri belirlenir. Sistem performansı, kullanıcı sayısı ve veri saklama ihtiyaçları göz önünde bulundurularak, gereken altyapı ve teknolojiler belirlenir.

**2.2.Projenin Çalışma Sistemi**

**1 -** Uygulamaya Veritabanı Sunucu bilgilerinin girilmesi: Uygulama kurulumunda veritabanının kurulduğu sunucu bilgileri Sunucu Ayarları menüsünden uygulamaya kaydedilir.

**2 -** Kullanıcı kaydı ve yetkilendirme: Müdür, öğretmen ve öğrenci kullanıcıları için kayıt işlemi yapılır. Her kullanıcıya özel bir hesap oluşturulur ve yetkilendirme işlemi gerçekleştirilir. Kullanıcılar sisteme giriş yaparak kendi yetki seviyeleriyle ilgili işlemleri gerçekleştirirler.

**3 -** Okul, sınıf ve ders yönetimi: Müdür kullanıcısı, sisteme sınıfları ve dersleri ekler. Her ders belirli bir sınıfa ve öğretmene atanır. Öğrenci kaydı yapılırken sınıf bilgisi girilir.

**4 -** Sınav hazırlama ve yükleme: Öğretmen kullanıcısı, atandığı derslerle ilgili sınavlar hazırlar. Belirli bir tarih ve saatte sınavlar sisteme yüklenir. Sınavlar, öğrencilere görüntülenmek üzere hazır hale gelir.

**5 -** Sınav çözme ve sonuçlar: Öğrenci kullanıcısı, katıldığı derslerin sınavlarını görüntüler ve çözer. Çözülen sınav sonuçları sisteme kaydedilir ve öğrenci tarafından görüntülenebilir.

**6 -** Geri Bildirim talepleri

**3.PROJENİN ALGORİTMA VE AKIŞ ŞEMASI**

**3.1.Projenin Algoritması**

**1 - Kullanıcı Kaydı :**

Müdür, öğretmen ve öğrenci kullanıcıları için ayrı hesaplar oluşturulur. Öğretmenler oluşturulan varsayılan şifrelerini Mail ile doğrulama yapılarak yeniler.

Kullanıcının yetki seviyesi belirlenir ve sistemdeki ilgili rolle ilişkilendirilir.

**2 - Okul, Sınıf ve Ders Yönetimi:**

Müdür, sisteme yeni sınıflar ve dersler ekler.

Her ders, belirli bir sınıfa ve öğretmene atanır.

**3 - Sınav Hazırlama ve Yükleme:**

Öğretmen, atandığı dersler için sınavlar hazırlar.

Sınavlar belirli bir tarih ve saatte sisteme yüklenir.


**4 - Sınav Çözme ve Sonuçlar:**

Öğrenci, katıldığı derslerin sınavlarını görüntüler.

Eğer sınavın tarihi geçmemişse, öğrenci sınavı çözebilir.

Çözülen sınav sonuçları sisteme kaydedilir ve öğrenci tarafından görüntülenebilir.

**5 - Geri Bildirim Talepleri:**

Öğrenci, sınav veya diğer konularla ilgili geri bildirim talepleri oluşturabilir.

Şikayet talepleri sisteme kaydedilir ve ilgili kullanıcılara yönlendirilir.






**4. Projenin Ekran Görüntüleri**

![image](https://github.com/yunusemrekarakus/E-Sinav-Uygulamasi/assets/124718913/3354bf35-58f7-4e37-984f-0cdcfe94e67e)


**Ekran Görüntüsü -4-1: Giriş Ekranı**

Giriş ekranı, sisteme erişim sağlamak isteyen kullanıcıların tanımlı rollerine göre giriş yapmalarını sağlar. Yönetici (müdür), öğretmen ve öğrenci olmak üzere üç farklı kullanıcı tipi vardır.

Yönetici (Müdür) Girişi: Yönetici, eğitim kurumunun yönetiminden sorumlu olan kişidir. Giriş yapabilmek için kullanıcı adı ve şifre bilgilerini girmesi gerekmektedir. Ayrıca, giriş ekranında bir CAPTCHA  kodu bulunmaktadır. Bu kod, kullanıcının gerçek bir insan olduğunu doğrulamak amacıyla kullanılır.

Öğretmen Girişi: Öğretmen, sistemde dersleri ve sınavları yöneten kişidir. Öğretmenler, kullanıcı adı ve şifreleriyle sisteme giriş yapabilirler. CAPTCHA kodu da burada kullanıcı doğrulaması için bulunmaktadır.

Öğrenci Girişi: Öğrenciler, sınavları çözen ve sonuçlarına erişen kullanıcılardır. Sisteme giriş yapabilmek için öğrenci numarası ve şifre bilgileri gerekmektedir. CAPTCHA kodu, öğrencilerin gerçek kullanıcılar olduğunu doğrulamak için kullanılır.

![image](https://github.com/yunusemrekarakus/E-Sinav-Uygulamasi/assets/124718913/8e4504c6-62a4-4cbd-847d-5dc8f5ba6b8d)


Bu giriş ekranı, sisteme güvenli ve yetkili erişim sağlanmasını sağlar. Kullanıcıların doğru kimlik bilgileriyle giriş yapmaları ve CAPTCHA kodunu doğru bir şekilde çözmeleri gerekmektedir. Bu önlemler, sistemde güvenliği sağlamak ve yetkisiz erişimleri engellemek amacıyla kullanılmaktadır.


**Ekran Görüntüsü-4-2: Sunucu Ayarları** 

Sunucu Ayarları Paneli, e-sınav sistemine yönetici (müdür) erişimi olan kullanıcıların sunucu bağlantı bilgilerini yapılandırmalarını sağlayan bir arayüzdür. Bu panel, kullanıcılara sunucu IP adresi, port numarası, veritabanı kullanıcı adı ve parola gibi bilgileri girebilmelerini sağlar.

Sunucu IP Adresi: Bu alanda, e-sınav sistemine bağlanılacak olan sunucunun IP adresi girilir. IP adresi, sunucunun bulunduğu ağı ve sunucuya erişim sağlamak için kullanılan adresi belirtir.

Port Numarası: Sunucu üzerindeki hizmetlere erişim için kullanılan port numarası burada belirtilir. Örneğin, PostgreSQL veritabanı için yaygın olarak kullanılan port numarası 5432'dir.

Veritabanı Kullanıcı Adı ve Parola: E-sınav sistemi, verileri depolamak ve yönetmek için bir veritabanı kullanır. Bu alanda, sunucu üzerindeki veritabanına erişmek için kullanılacak kullanıcı adı ve parola bilgileri girilir. Bu bilgiler, sistem yöneticisi tarafından sağlanır ve veritabanına yetkili erişimi olan bir kullanıcıyı temsil eder.

Sunucu Ayarları Paneli, sistemin sunucuyla doğru şekilde iletişim kurmasını sağlamak için kullanılır. Doğru IP adresi, port numarası ve veritabanı kullanıcı bilgileri girilerek sunucuyla başarılı bir bağlantı sağlanır. Bu panel, sistem yöneticisinin sunucu ayarlarını kolayca yapılandırabilmesini ve gerektiğinde güncelleyebilmesini sağlar.


![image](https://github.com/yunusemrekarakus/E-Sinav-Uygulamasi/assets/124718913/41c74488-e837-413a-8dc1-e7dee5bf3472)



**Ekran Görüntüsü-4-3: Root Panel** 

Root Paneli, e-sınav sisteminde yönetici (müdür) hesabının oluşturulduğu ve yönetildiği bir arayüzdür. Bu panel, sistemi yönetecek olan müdürlerin kayıt işlemlerini gerçekleştirebilmelerini sağlar.





![image](https://github.com/yunusemrekarakus/E-Sinav-Uygulamasi/assets/124718913/b25aef9c-2cae-4ca8-b651-87a68e476158)





**Ekran Görüntüsü-4-4: Yönetici Panel** 

Yönetici Paneli, e-sınav sisteminin yönetiminde kritik bir rol oynayan bir arayüzdür. Bu panel, öğrenci ve öğretmen kayıtlarının yönetildiği, öğrenci bilgilerinin güncellenip silindiği bir bölümdür.

Öğrenci Kayıt: Yönetici Paneli, yeni öğrencilerin sisteme kaydedilmesini sağlar. Yönetici, öğrencinin adı, soyadı, öğrenci numarası, sınıfı gibi bilgileri girerek öğrencinin sisteme kaydını gerçekleştirir. Bu sayede öğrencilerin e-sınav sistemine erişimi ve katılımı sağlanır.

Öğretmen Kayıt: Yönetici Paneli, yeni öğretmenlerin sisteme kaydedilmesini sağlar. Yönetici, öğretmenin adı, soyadı, kullanıcı adı, parola gibi bilgileri girerek öğretmenin sisteme kaydını gerçekleştirir. Bu sayede öğretmenlerin sınav hazırlama ve değerlendirme gibi görevleri üzerlerine alması sağlanır.

Öğrenci Silme: Yönetici Paneli, öğrenci kayıtlarının silinmesini sağlar. Yönetici, öğrencinin bilgilerini aratarak sistemden öğrenciyi siler. Bu işlem genellikle öğrencinin mezun olması veya sistemden ayrılması durumunda gerçekleştirilir.

Öğrenci Bilgi Güncelleme: Yönetici Paneli, mevcut öğrenci bilgilerinin güncellenmesini sağlar. Yönetici, öğrencinin adı, soyadı, sınıfı gibi bilgilerini değiştirerek güncelleme işlemini gerçekleştirir. Bu sayede öğrenci bilgileri güncel tutulur ve doğru bir şekilde sisteme yansıtılır.


![image](https://github.com/yunusemrekarakus/E-Sinav-Uygulamasi/assets/124718913/86b49eb6-96af-43ca-b4d1-f762306e479f)


**Ekran Görüntüsü-4-5: Yönetici Menü** 




![image](https://github.com/yunusemrekarakus/E-Sinav-Uygulamasi/assets/124718913/0cfec2e6-f3d2-4083-bfff-6bf18d1b30d2)






**Ekran Görüntüsü-4-6: Öğretmen Kayıt Ekranı**





![image](https://github.com/yunusemrekarakus/E-Sinav-Uygulamasi/assets/124718913/99030544-09f4-41a1-af5e-1377174c4390)






**Ekran Görüntüsü-4-7: Öğrenci Kayıt Ekranı** 





![image](https://github.com/yunusemrekarakus/E-Sinav-Uygulamasi/assets/124718913/ac539f16-cfa0-46be-824c-66c049b2ff8e)






**Ekran Görüntüsü-4-8: Sınıf Oluşturma Ekranı** 

![image](https://github.com/yunusemrekarakus/E-Sinav-Uygulamasi/assets/124718913/5e3ae36a-c09c-4f80-8d64-38f5b76b5326)


**Ekran Görüntüsü-4-9: Öğrenci Bilgi Güncelleme Görüntüleme Ekranı** 






![image](https://github.com/yunusemrekarakus/E-Sinav-Uygulamasi/assets/124718913/f952e987-864c-4d64-addb-5e7da261b60e)






**Ekran Görüntüsü-4-11: Öğretmen Ana Sayfa Ekranı** 

Sınav Hazırlama: Öğretmen Paneli, öğretmenlerin derslerine uygun sınavlar oluşturmasını sağlar. Öğretmenler, ders seçimi yaparak sınavın türünü, süresini, soru sayısını ve diğer gereken parametreleri belirleyebilir. Ayrıca, soru havuzu oluşturma ve soruları kategorize etme gibi işlevlere de erişebilirler. Bu şekilde öğretmenler, öğrencilere uygun ve kaliteli sınavlar hazırlayabilir.

Öğrenci Notlarını Görüntüleme: Öğretmen Paneli, öğrencilerin sınav performanslarını ve notlarını görüntülemek için kullanılır. Öğretmenler, sınav sonuçlarına erişerek öğrencilerin aldıkları notları, doğru ve yanlış cevapları, sıralamalarını ve diğer ilgili istatistikleri görüntüleyebilirler. Bu sayede öğretmenler, öğrencilerin başarı seviyelerini değerlendirebilir ve gerektiğinde ilave geri bildirimler sağlayabilir.

Geri Bildirim Gönderme: Öğretmen Paneli, öğrencilerden gelen geri bildirimleri takip etmek için kullanılır. Öğrenciler, sınav sonrasında öğretmenlere geri bildirimlerde bulunabilirler. Öğretmenler, bu panel üzerinden öğrenci geri bildirimlerini görüntüleyebilir, değerlendirebilir ve gerektiğinde yanıtlayabilirler. Bu, öğretmenlerin öğrenci memnuniyetini takip etmelerini ve gerekli düzeltici önlemleri alabilmelerini sağlar.



![image](https://github.com/yunusemrekarakus/E-Sinav-Uygulamasi/assets/124718913/82625be6-8011-40f1-9f69-712382fee072)




**Ekran Görüntüsü-4-12: Öğretmen Paneli Menü** 







![image](https://github.com/yunusemrekarakus/E-Sinav-Uygulamasi/assets/124718913/daefb287-5c1e-4bcc-89f3-e6e9018339df)











**Ekran Görüntüsü-4-13: Sınav Oluşturma Ekranı** 

![image](https://github.com/yunusemrekarakus/E-Sinav-Uygulamasi/assets/124718913/77a37b9b-1991-4a0b-b2dd-4f8ccd79ee1f)


**Ekran Görüntüsü-4-14: Sınav Soru Ekleme Ekranı** 


![image](https://github.com/yunusemrekarakus/E-Sinav-Uygulamasi/assets/124718913/27a35ec6-eba4-4701-9b05-ef641453c1ef)



**Ekran Görüntüsü-4-15: Sistemdeki Sınavlar Ekranı** 






![image](https://github.com/yunusemrekarakus/E-Sinav-Uygulamasi/assets/124718913/0b41a18a-060c-4081-a5d0-75cd84fb1f98)







**Ekran Görüntüsü-4-16: Sınavlara Giren Öğrencilerin Not Ekranı** 






![image](https://github.com/yunusemrekarakus/E-Sinav-Uygulamasi/assets/124718913/0b591bf2-a06f-4200-ba91-f1c5cd35fa04)








**Ekran Görüntüsü-4-17: Sınavlar Hakkındaki Geri Bildirim Görüntüleme Ekranı** 


![image](https://github.com/yunusemrekarakus/E-Sinav-Uygulamasi/assets/124718913/87bfab0d-f390-4dc5-8a96-9adb8bd6d15c)



**Ekran Görüntüsü-4-18: Öğrenci Paneli** 

**Sınavları Çözme:** Öğrenci Paneli, öğrencilerin oluşturulan sınavları tarih ve saatleri uygun olduğunda çözebilmesini sağlar. Öğrenciler, panel üzerinden sınavları seçebilir ve belirtilen süre içerisinde soruları yanıtlayabilir. Sınavı tamamladıktan sonra, öğrenciler cevaplarını kaydeder.

**Notları Görüntüleme:** Öğrenci Paneli, öğrencilerin sınav notlarını görüntülemek için kullanılır. Öğrenciler, sınav sonrasında notlarını panel üzerinden kontrol edebilirler. Sınav notları, öğrencinin başarı düzeyini gösterir ve öğrencinin performansını değerlendirmeye yardımcı olur.

**Velilere Not Gönderme:** Öğrenci Paneli, öğrencinin sınav sonucunu velisine göndermek için kullanılır. Öğrenciler, sınavı tamamladıktan sonra notları panel üzerinden kaydeder ve velisinin mail adresini girer. Sistem, otomatik olarak veliye öğrencinin sınav notunu içeren bir e-posta gönderir.


**Geri Bildirim Oluşturma:** Öğrenci Paneli, öğrencilerin sınavla ilgili geri bildirim oluşturmasını sağlar. Öğrenciler, sınav sonrasında "Geri Bildirim Oluştur" bölümünde sınavla ilgili sorunları veya görüşlerini paylaşabilirler. Bu geri bildirimler, öğrencilerin sınav deneyimlerini iyileştirmek ve öğretmenlere geri bildirim sağlamak amacıyla kullanılır.


![image](https://github.com/yunusemrekarakus/E-Sinav-Uygulamasi/assets/124718913/c9a98e74-40e7-4831-9e12-d97b9d05c6e9)



**Ekran Görüntüsü-4-19: Öğrenci Menü**


![image](https://github.com/yunusemrekarakus/E-Sinav-Uygulamasi/assets/124718913/87652461-5a3d-4e60-bdd2-ba6f1e338c8d)


**Ekran Görüntüsü-4-20: Sınav Çözme Ekranı** 


![image](https://github.com/yunusemrekarakus/E-Sinav-Uygulamasi/assets/124718913/e4d675ef-bb96-4e80-b794-f52b4b0b2b15)



**Ekran Görüntüsü-4-21: Sınav Çözüldükten Sonra Gönderilen Not Bilgi Mail’i**




![image](https://github.com/yunusemrekarakus/E-Sinav-Uygulamasi/assets/124718913/7777a455-a991-477c-b9f8-0f68f94547a7)





**Ekran Görüntüsü-4-22: Öğrenci Sınav Sonuç Ekranı** 






![image](https://github.com/yunusemrekarakus/E-Sinav-Uygulamasi/assets/124718913/68459d81-46d9-4986-957f-f69101efbd55)









**Ekran Görüntüsü-4-23: Geri Bildirim Oluşturma Ekranı**








![image](https://github.com/yunusemrekarakus/E-Sinav-Uygulamasi/assets/124718913/cb2a95f8-d2ed-46c2-8b54-a068f42c9f55)








**Ekran Görüntüsü-4-24: Öğretmen Parola Güncelleme Paneli** 

Öğretmen Parola Güncelleme Paneli, öğretmenin parolasını güncellemesine olanak tanıyan bir arayüz sağlar. İşleyiş aşağıdaki adımları içerir:

Öğretmen kullanıcı adını girdikten sonra "Onay Kodu Gönder" butonuna tıklar. Sistem, öğretmenin kayıtlı olan e-posta adresine bir doğrulama kodu gönderir. Öğretmen, doğrulama kodunu parola güncelleme panelindeki ilgili alana girer. Eski parolasını ve yeni parolasını iki kez girerek güncelleme işlemine devam eder. Sistem, girilen bilgileri doğrular ve parola güncelleme işlemini gerçekleştirir.



![image](https://github.com/yunusemrekarakus/E-Sinav-Uygulamasi/assets/124718913/f153ef89-718c-4b7f-88b3-ff6677edbf04)



**Ekran Görüntüsü-4-25: Parola Güncelleme Onay Kodu** 

**5.1 Projenin Veri Tabanı Oluşturma Sorgusu:**

CREATE DATABASE esinav

`    `WITH

`    `OWNER = postgres

`    `ENCODING = 'UTF8'

`    `LC\_COLLATE = 'Turkish\_Turkey.1254'

`    `LC\_CTYPE = 'Turkish\_Turkey.1254'

`    `TABLESPACE = pg\_default

`    `CONNECTION LIMIT = -1

`    `IS\_TEMPLATE = False;


**5.2 ‘admin’ Tablo Oluşturma Sorgu:**

CREATE TABLE IF NOT EXISTS public.admin

(

`    `id integer NOT NULL,

`    `username character varying COLLATE pg\_catalog."default" NOT NULL,

`    `password character varying COLLATE pg\_catalog."default" NOT NULL,

`    `CONSTRAINT admin\_pkey PRIMARY KEY (id)

)

TABLESPACE pg\_default;

ALTER TABLE IF EXISTS public.admin

`    `OWNER to postgres;

**5.3 ‘class’ Tablo Oluşturma Sorgu:**

CREATE TABLE IF NOT EXISTS public.class

(

`    `class\_id integer NOT NULL GENERATED BY DEFAULT AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 2147483647 CACHE 1 ),

`    `class\_num integer NOT NULL,

`    `branch text COLLATE pg\_catalog."default" NOT NULL,

`    `CONSTRAINT class\_pkey PRIMARY KEY (class\_id)

)

TABLESPACE pg\_default;

ALTER TABLE IF EXISTS public.class

`    `OWNER to postgres;






**5.4 ‘exams’ Tablo Oluşturma Sorgu:**

CREATE TABLE IF NOT EXISTS public.exams

(

`    `exam\_id integer NOT NULL GENERATED BY DEFAULT AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 2147483647 CACHE 1 ),

`    `exam\_names text COLLATE pg\_catalog."default" NOT NULL,

`    `lesson\_id integer NOT NULL,

`    `exam\_date date NOT NULL,

`    `exam\_start\_time character varying COLLATE pg\_catalog."default" NOT NULL,

`    `exam\_finish\_time character varying COLLATE pg\_catalog."default" NOT NULL,

`    `exam\_duration integer NOT NULL,

`    `CONSTRAINT questions\_pkey PRIMARY KEY (exam\_id)

)

TABLESPACE pg\_default;

ALTER TABLE IF EXISTS public.exams

`    `OWNER to postgres;

**5.5 ‘manager’ Tablo Oluşturma Sorgu:**

CREATE TABLE IF NOT EXISTS public.exams

(

`    `exam\_id integer NOT NULL GENERATED BY DEFAULT AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 2147483647 CACHE 1 ),

`    `exam\_names text COLLATE pg\_catalog."default" NOT NULL,

`    `lesson\_id integer NOT NULL,

`    `exam\_date date NOT NULL,

`    `exam\_start\_time character varying COLLATE pg\_catalog."default" NOT NULL,

`    `exam\_finish\_time character varying COLLATE pg\_catalog."default" NOT NULL,

`    `exam\_duration integer NOT NULL,

`    `CONSTRAINT questions\_pkey PRIMARY KEY (exam\_id)

)

TABLESPACE pg\_default;

ALTER TABLE IF EXISTS public.exams

`    `OWNER to postgres;

**5.6 ‘parent’ Tablo Oluşturma Sorgu:**

CREATE TABLE IF NOT EXISTS public.parent

(

`    `veli\_id integer NOT NULL GENERATED BY DEFAULT AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 2147483647 CACHE 1 ),

`    `adi character varying COLLATE pg\_catalog."default" NOT NULL,

`    `tc character varying(11) COLLATE pg\_catalog."default" NOT NULL,

`    `tel\_no character varying(10) COLLATE pg\_catalog."default" NOT NULL,

`    `email character varying COLLATE pg\_catalog."default" NOT NULL,

`    `CONSTRAINT parent\_pkey PRIMARY KEY (veli\_id)

)

TABLESPACE pg\_default;

ALTER TABLE IF EXISTS public.parent

`    `OWNER to postgres;

**5.7 ‘questions’ Tablo Oluşturma Sorgu:**

CREATE TABLE IF NOT EXISTS public.parent

(

`    `veli\_id integer NOT NULL GENERATED BY DEFAULT AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 2147483647 CACHE 1 ),

`    `adi character varying COLLATE pg\_catalog."default" NOT NULL,

`    `tc character varying(11) COLLATE pg\_catalog."default" NOT NULL,

`    `tel\_no character varying(10) COLLATE pg\_catalog."default" NOT NULL,

`    `email character varying COLLATE pg\_catalog."default" NOT NULL,

`    `CONSTRAINT parent\_pkey PRIMARY KEY (veli\_id)

)

TABLESPACE pg\_default;

ALTER TABLE IF EXISTS public.parent

`    `OWNER to postgres;

**5.8 ‘student’ Tablo Oluşturma Sorgu:**

CREATE TABLE IF NOT EXISTS public.student

(

`    `ogrenci\_no integer NOT NULL GENERATED BY DEFAULT AS IDENTITY ( INCREMENT 1 START 123414 MINVALUE 123414 MAXVALUE 2147483647 CACHE 1 ),

`    `adi character varying COLLATE pg\_catalog."default" NOT NULL,

`    `soyadi character varying COLLATE pg\_catalog."default" NOT NULL,

`    `tc character varying(11) COLLATE pg\_catalog."default" NOT NULL,

`    `sinif\_id integer NOT NULL,

`    `cinsiyet character varying COLLATE pg\_catalog."default" NOT NULL,

`    `adres text COLLATE pg\_catalog."default" NOT NULL,

`    `veli\_id integer NOT NULL,

`    `ogr\_parola character varying COLLATE pg\_catalog."default" NOT NULL,

`    `ogr\_resim text COLLATE pg\_catalog."default" NOT NULL,

`    `CONSTRAINT student\_pkey PRIMARY KEY (ogrenci\_no),

`    `CONSTRAINT veli\_ogrenc\_foreign FOREIGN KEY (veli\_id)

`        `REFERENCES public.parent (veli\_id) MATCH SIMPLE

`        `ON UPDATE NO ACTION

`        `ON DELETE NO ACTION

`        `NOT VALID

)

TABLESPACE pg\_default;

ALTER TABLE IF EXISTS public.student

`    `OWNER to postgres;

-- Index: fki\_veli\_ogrenc\_foreign

-- DROP INDEX IF EXISTS public.fki\_veli\_ogrenc\_foreign;

CREATE INDEX IF NOT EXISTS fki\_veli\_ogrenc\_foreign

`    `ON public.student USING btree

`    `(veli\_id ASC NULLS LAST)

`    `TABLESPACE pg\_default;




**5.9 ‘teacher’ Tablo Oluşturma Sorgu:**

CREATE TABLE IF NOT EXISTS public.teacher

(

`    `ogretmen\_id integer NOT NULL GENERATED BY DEFAULT AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 2147483647 CACHE 1 ),

`    `t\_name character varying COLLATE pg\_catalog."default" NOT NULL,

`    `t\_surname character varying COLLATE pg\_catalog."default" NOT NULL,

`    `t\_tc character varying COLLATE pg\_catalog."default" NOT NULL,

`    `t\_phone\_num character varying COLLATE pg\_catalog."default" NOT NULL,

`    `t\_email text COLLATE pg\_catalog."default" NOT NULL,

`    `t\_username character varying COLLATE pg\_catalog."default" NOT NULL,

`    `t\_password character varying COLLATE pg\_catalog."default" NOT NULL,

`    `t\_pictures text COLLATE pg\_catalog."default" NOT NULL,

`    `CONSTRAINT teacher\_pkey PRIMARY KEY (ogretmen\_id)

)

TABLESPACE pg\_default;

ALTER TABLE IF EXISTS public.teacher

`    `OWNER to postgres;







**5.10 ‘feedbacks’ Tablo Oluşturma Sorgu:**

CREATE TABLE IF NOT EXISTS public.feedbacks

(

`    `feedback\_id integer NOT NULL GENERATED BY DEFAULT AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 2147483647 CACHE 1 ),

`    `exam\_id integer NOT NULL,

`    `feedback\_title text COLLATE pg\_catalog."default" NOT NULL,

`    `feedback\_body text COLLATE pg\_catalog."default" NOT NULL,

`    `feedback\_date timestamp with time zone NOT NULL,

`    `ogrenci\_no integer,

`    `CONSTRAINT feedbacks\_pkey PRIMARY KEY (feedback\_id),

`    `CONSTRAINT exam\_feedback FOREIGN KEY (exam\_id)

`        `REFERENCES public.exams (exam\_id) MATCH SIMPLE

`        `ON UPDATE NO ACTION

`        `ON DELETE NO ACTION

`        `NOT VALID,

`    `CONSTRAINT student\_feedback FOREIGN KEY (ogrenci\_no)

`        `REFERENCES public.student (ogrenci\_no) MATCH SIMPLE

`        `ON UPDATE NO ACTION

`        `ON DELETE NO ACTION

`        `NOT VALID

)

TABLESPACE pg\_default;

ALTER TABLE IF EXISTS public.feedbacks

`    `OWNER to postgres;

-- Index: fki\_exam\_feedback

-- DROP INDEX IF EXISTS public.fki\_exam\_feedback;

CREATE INDEX IF NOT EXISTS fki\_exam\_feedback

`    `ON public.feedbacks USING btree

`    `(exam\_id ASC NULLS LAST)

`    `TABLESPACE pg\_default;

**5.11 ‘lessons’ Tablo Oluşturma Sorgu:**

CREATE TABLE IF NOT EXISTS public.lessons

(

`    `lesson\_id integer NOT NULL GENERATED BY DEFAULT AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 2147483647 CACHE 1 ),

`    `lesson\_name character varying COLLATE pg\_catalog."default" NOT NULL,

`    `lesson\_code character varying COLLATE pg\_catalog."default" NOT NULL,

`    `lesson\_coefficient integer NOT NULL,

`    `teacher\_id integer,

`    `CONSTRAINT lessons\_pkey PRIMARY KEY (lesson\_id),

`    `CONSTRAINT teacher\_lesson\_foreign FOREIGN KEY (teacher\_id)

`        `REFERENCES public.teacher (ogretmen\_id) MATCH SIMPLE

`        `ON UPDATE NO ACTION

`        `ON DELETE NO ACTION

`        `NOT VALID

)

TABLESPACE pg\_default;

ALTER TABLE IF EXISTS public.lessons

`    `OWNER to postgres;

-- Index: fki\_teacher\_lesson\_foreign

-- DROP INDEX IF EXISTS public.fki\_teacher\_lesson\_foreign;

CREATE INDEX IF NOT EXISTS fki\_teacher\_lesson\_foreign

`    `ON public.lessons USING btree

`    `(teacher\_id ASC NULLS LAST)

`    `TABLESPACE pg\_default;

**5.12 ‘class\_lesson’ Tablo Oluşturma Sorgu:**

CREATE TABLE IF NOT EXISTS public.class\_lesson

(

`    `class\_les\_id integer NOT NULL GENERATED BY DEFAULT AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 2147483647 CACHE 1 ),

`    `class\_id integer NOT NULL,

`    `lesson\_id integer NOT NULL,

`    `teacher\_id integer NOT NULL,

`    `CONSTRAINT class\_lesson\_pkey PRIMARY KEY (class\_les\_id),

`    `CONSTRAINT class FOREIGN KEY (class\_id)

`        `REFERENCES public.class (class\_id) MATCH SIMPLE

`        `ON UPDATE NO ACTION

`        `ON DELETE NO ACTION

`        `NOT VALID,

`    `CONSTRAINT lesson FOREIGN KEY (lesson\_id)

`        `REFERENCES public.lessons (lesson\_id) MATCH SIMPLE

`        `ON UPDATE NO ACTION

`        `ON DELETE NO ACTION

`        `NOT VALID,

`    `CONSTRAINT teach FOREIGN KEY (teacher\_id)

`        `REFERENCES public.teacher (ogretmen\_id) MATCH SIMPLE

`        `ON UPDATE NO ACTION

`        `ON DELETE NO ACTION

`        `NOT VALID

)

TABLESPACE pg\_default;

ALTER TABLE IF EXISTS public.class\_lesson

`    `OWNER to postgres;

-- Index: fki\_class

-- DROP INDEX IF EXISTS public.fki\_class;

CREATE INDEX IF NOT EXISTS fki\_class

`    `ON public.class\_lesson USING btree

`    `(class\_id ASC NULLS LAST)

`    `TABLESPACE pg\_default;

-- Index: fki\_lesson

-- DROP INDEX IF EXISTS public.fki\_lesson;

CREATE INDEX IF NOT EXISTS fki\_lesson

`    `ON public.class\_lesson USING btree

`    `(lesson\_id ASC NULLS LAST)

`    `TABLESPACE pg\_default;

-- Index: fki\_teach

-- DROP INDEX IF EXISTS public.fki\_teach;

CREATE INDEX IF NOT EXISTS fki\_teach

`    `ON public.class\_lesson USING btree

`    `(teacher\_id ASC NULLS LAST)

`    `TABLESPACE pg\_default;

**5.13 ‘exam\_student’ Tablo Oluşturma Sorgu:**

CREATE TABLE IF NOT EXISTS public.exam\_student

(

`    `exam\_id integer NOT NULL,

`    `ogrenci\_no integer NOT NULL,

`    `cozme\_drm boolean NOT NULL DEFAULT false,

`    `exam\_not integer,

`    `CONSTRAINT exam FOREIGN KEY (exam\_id)

`        `REFERENCES public.exams (exam\_id) MATCH SIMPLE

`        `ON UPDATE NO ACTION

`        `ON DELETE NO ACTION,

`    `CONSTRAINT student FOREIGN KEY (ogrenci\_no)

`        `REFERENCES public.student (ogrenci\_no) MATCH SIMPLE

`        `ON UPDATE NO ACTION

`        `ON DELETE NO ACTION

)

TABLESPACE pg\_default;

ALTER TABLE IF EXISTS public.exam\_student

`    `OWNER to postgres;

-- Index: fki\_student

-- DROP INDEX IF EXISTS public.fki\_student;

CREATE INDEX IF NOT EXISTS fki\_student

`    `ON public.exam\_student USING btree

`    `(ogrenci\_no ASC NULLS LAST)

`    `TABLESPACE pg\_default;

**5.14 ‘student\_lesson’ Tablo Oluşturma Sorgu:**

CREATE TABLE IF NOT EXISTS public.student\_lesson

(

`    `st\_ls\_id integer NOT NULL GENERATED BY DEFAULT AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 2147483647 CACHE 1 ),

`    `student\_id integer NOT NULL,

`    `lesson\_id integer NOT NULL,

`    `"not" integer,

`    `CONSTRAINT student\_lesson\_pkey PRIMARY KEY (st\_ls\_id),

`    `CONSTRAINT less FOREIGN KEY (lesson\_id)

`        `REFERENCES public.lessons (lesson\_id) MATCH SIMPLE

`        `ON UPDATE NO ACTION

`        `ON DELETE NO ACTION

`        `NOT VALID,

`    `CONSTRAINT stdls FOREIGN KEY (student\_id)

`        `REFERENCES public.student (ogrenci\_no) MATCH SIMPLE

`        `ON UPDATE NO ACTION

`        `ON DELETE NO ACTION

`        `NOT VALID

)

TABLESPACE pg\_default;

ALTER TABLE IF EXISTS public.student\_lesson

`    `OWNER to postgres;

-- Index: fki\_less

-- DROP INDEX IF EXISTS public.fki\_less;

CREATE INDEX IF NOT EXISTS fki\_less

`    `ON public.student\_lesson USING btree

`    `(lesson\_id ASC NULLS LAST)

`    `TABLESPACE pg\_default;

-- Index: fki\_stdls

-- DROP INDEX IF EXISTS public.fki\_stdls;

CREATE INDEX IF NOT EXISTS fki\_stdls

`    `ON public.student\_lesson USING btree

`    `(student\_id ASC NULLS LAST)

`    `TABLESPACE pg\_default;

**5.15 ‘teacher\_lesson’ Tablo Oluşturma Sorgu:**

CREATE TABLE IF NOT EXISTS public.teacher\_lesson

(

`    `teach\_les\_id integer NOT NULL GENERATED BY DEFAULT AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 2147483647 CACHE 1 ),

`    `teacher\_id integer NOT NULL,

`    `lesson\_id integer NOT NULL,

`    `CONSTRAINT teacher\_lesson\_pkey PRIMARY KEY (teach\_les\_id),

`    `CONSTRAINT less FOREIGN KEY (lesson\_id)

`        `REFERENCES public.lessons (lesson\_id) MATCH SIMPLE

`        `ON UPDATE NO ACTION

`        `ON DELETE NO ACTION

`        `NOT VALID,

`    `CONSTRAINT teacher FOREIGN KEY (teacher\_id)

`        `REFERENCES public.teacher (ogretmen\_id) MATCH SIMPLE

`        `ON UPDATE NO ACTION

`        `ON DELETE NO ACTION

`        `NOT VALID

)

TABLESPACE pg\_default;

ALTER TABLE IF EXISTS public.teacher\_lesson

`    `OWNER to postgres;

-- Index: fki\_teacher

-- DROP INDEX IF EXISTS public.fki\_teacher;

CREATE INDEX IF NOT EXISTS fki\_teacher

`    `ON public.teacher\_lesson USING btree

`    `(teacher\_id ASC NULLS LAST)

`    `TABLESPACE pg\_default;

**5.16 ‘reply’ Tablo Oluşturma Sorgu:**

CREATE TABLE IF NOT EXISTS public.reply

(

`    `ogrenci\_no integer NOT NULL,

`    `lesson\_id integer NOT NULL,

`    `exam\_id integer NOT NULL,

`    `questions\_id bigint NOT NULL,

`    `is\_it\_true boolean NOT NULL DEFAULT false,

`    `CONSTRAINT exam FOREIGN KEY (exam\_id)

`        `REFERENCES public.exams (exam\_id) MATCH SIMPLE

`        `ON UPDATE NO ACTION

`        `ON DELETE NO ACTION,

`    `CONSTRAINT lessons FOREIGN KEY (lesson\_id)

`        `REFERENCES public.lessons (lesson\_id) MATCH SIMPLE

`        `ON UPDATE NO ACTION

`        `ON DELETE NO ACTION,

`    `CONSTRAINT ques\_for FOREIGN KEY (questions\_id)

`        `REFERENCES public.questions (question\_id) MATCH SIMPLE

`        `ON UPDATE NO ACTION

`        `ON DELETE NO ACTION,

`    `CONSTRAINT studet\_reply FOREIGN KEY (ogrenci\_no)

`        `REFERENCES public.student (ogrenci\_no) MATCH SIMPLE

`        `ON UPDATE NO ACTION

`        `ON DELETE NO ACTION

)

TABLESPACE pg\_default;

ALTER TABLE IF EXISTS public.reply

`    `OWNER to postgres;

-- Index: fki\_exam

-- DROP INDEX IF EXISTS public.fki\_exam;

CREATE INDEX IF NOT EXISTS fki\_exam

`    `ON public.reply USING btree

`    `(exam\_id ASC NULLS LAST)

`    `TABLESPACE pg\_default;

-- Index: fki\_lessons

-- DROP INDEX IF EXISTS public.fki\_lessons;

CREATE INDEX IF NOT EXISTS fki\_lessons

`    `ON public.reply USING btree

`    `(lesson\_id ASC NULLS LAST)

`    `TABLESPACE pg\_default;

-- Index: fki\_o

-- DROP INDEX IF EXISTS public.fki\_o;

CREATE INDEX IF NOT EXISTS fki\_o

`    `ON public.reply USING btree

`    `(ogrenci\_no ASC NULLS LAST)

`    `TABLESPACE pg\_default;

-- Index: fki\_questions

-- DROP INDEX IF EXISTS public.fki\_questions;

CREATE INDEX IF NOT EXISTS fki\_questions

`    `ON public.reply USING btree

`    `(questions\_id ASC NULLS LAST)

`    `TABLESPACE pg\_default;

-- Index: fki\_w

-- DROP INDEX IF EXISTS public.fki\_w;

CREATE INDEX IF NOT EXISTS fki\_w

`    `ON public.reply USING btree

`    `(questions\_id ASC NULLS LAST)

`    `TABLESPACE pg\_default;










**7. SONUÇ**

E-Sınav Sistemi, eğitim kurumlarının sınav süreçlerini modernize etmek ve daha verimli hale getirmek için tasarlanmış bir yazılımdır. Proje, C# programlama dili ve PostgreSQL veritabanı kullanılarak geliştirilmiştir. 



**8. KAYNAKLAR** 

**Programlama Dili:** C# (Microsoft Visual Studio)

C# programlama dili ve Microsoft Visual Studio geliştirme ortamı kullanılarak proje oluşturuldu.

**Veritabanı:** PostgreSQL

PostgreSQL veritabanı yönetim sistemi kullanılarak veri tabanı oluşturuldu ve veri işlemleri gerçekleştirildi.

**Arayüz Tasarımı:** Windows Forms

Windows Forms teknolojisi kullanılarak proje için kullanıcı arayüzü tasarlandı.

**E-posta Gönderimi:** SMTP Protokolü

SMTP (Simple Mail Transfer Protocol) protokolü kullanılarak e-posta gönderimi gerçekleştirildi.

**Veri Erişimi:** Npgsql (PostgreSQL için .NET veritabanı sürücüsü)

Npgsql, C# programlama dili için PostgreSQL veritabanı sürücüsü olarak kullanıldı.




