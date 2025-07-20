# 📚 SchoolSystem

**SchoolSystem**, Windows Forms (WinForms) ve SQL Server kullanılarak geliştirilmiş bir masaüstü öğrenci bilgi sistemidir. Bu uygulama, öğrenci kayıtları, ders bilgileri, kulüpler, öğretmen branşları ve not sisteminin yönetimini sağlar. Eğitim kurumları için sade, kullanışlı ve geliştirilebilir bir otomasyon çözümüdür.

## 🚀 Özellikler

- Öğrenci yönetimi (ekle, sil, güncelle)
- Kulüp ve kulüp üyelik takibi
- Öğretmen-ders eşlemesi
- Sınav ve proje notlarının takibi
- Otomatik ortalama ve geçme/durma hesaplaması
- SQL Server ile veri bütünlüğü ve ilişkili tablolar
- ADO.NET ile güvenli veri erişimi
- Kullanıcı dostu Windows Forms arayüzü

---

## 🏗️ Proje Mimarisi

| Katman              | Teknoloji                       |
|---------------------|----------------------------------|
| Arayüz (UI)         | C# WinForms (.NET Framework 4.8) |
| Veri Katmanı        | SQL Server                      |
| Veri Bağlantısı     | ADO.NET                         |
| Geliştirme Ortamı   | Visual Studio                   |

---

## 🧩 Modül Yapısı

### 🎛️ Ana Form
- `Form1.cs`: Tüm kullanıcı etkileşimlerinin gerçekleştiği ana arayüz.
- `Form1.Designer.cs`: Form nesnelerinin tasarımı.

### 🗂️ Veritabanı Entegrasyonu
- `DataSet1.xsd`: TableAdapter ile güvenli veri modeli tanımı.
- `App.config`: SQL Server bağlantı dizesini içerir.

---

## 🗃️ Veritabanı Tasarımı

Aşağıdaki tablolar kullanılmıştır:

### 🔹 TBL_Students
| Sütun Adı      | Veri Tipi   | Açıklama                     |
|----------------|--------------|-------------------------------|
| StudentID      | int          | Birincil anahtar (PK)         |
| StudentName    | varchar(30)  | Öğrencinin adı                |
| StudentSurName | varchar(30)  | Öğrencinin soyadı             |
| StudentClub    | tinyint      | Kulüp kimliği (FK)            |
| StudentGender  | varchar(6)   | Cinsiyet bilgisi              |

### 🔹 TBL_Clubs
| Sütun Adı   | Veri Tipi   | Açıklama              |
|-------------|--------------|------------------------|
| ClubID      | tinyint      | Birincil anahtar (PK)  |
| ClubName    | varchar(30)  | Kulüp adı              |

### 🔹 TBL_Lectures
| Sütun Adı   | Veri Tipi   | Açıklama               |
|-------------|--------------|-------------------------|
| LectureID   | tinyint      | Birincil anahtar (PK)   |
| LectureName | varchar(30)  | Ders adı                |

### 🔹 TBL_Teachers
| Sütun Adı     | Veri Tipi   | Açıklama                             |
|----------------|--------------|---------------------------------------|
| TeacherID      | tinyint      | Birincil anahtar (PK)                 |
| TeacherBranch  | tinyint      | Branş (LectureID ile ilişkili)        |
| TeacherName    | varchar(50)  | Öğretmenin adı                        |

### 🔹 TBL_Notes
| Sütun Adı     | Veri Tipi     | Açıklama                                 |
|----------------|----------------|-------------------------------------------|
| NoteID         | int            | Birincil anahtar (PK)                     |
| LectureID      | tinyint        | Ders ID'si (FK)                           |
| StudentID      | int            | Öğrenci ID'si (FK)                        |
| Exam1          | tinyint        | 1. sınav notu                             |
| Exam2          | tinyint        | 2. sınav notu                             |
| Exam3          | tinyint        | 3. sınav notu                             |
| ProjectNote    | tinyint        | Proje notu                                |
| Average        | decimal(5,2)   | Ortalama                                  |
| Status         | bit            | Geçti (1) / Kaldı (0)                     |

---

## 🔗 Tablolar Arası İlişkiler

- `TBL_Students.StudentClub` → `TBL_Clubs.ClubID`
- `TBL_Notes.StudentID` → `TBL_Students.StudentID`
- `TBL_Notes.LectureID` → `TBL_Lectures.LectureID`
- `TBL_Teachers.TeacherBranch` → `TBL_Lectures.LectureID`

Veritabanı şeması diyagramı aşağıda yer almaktadır:

![Veritabanı Şeması](f922864a-fe07-4144-9e3f-dc5f4acd9e51.png)

---

## ⚙️ Kullanım

1. **Projeyi klonlayın:**
   ```bash
   git clone https://github.com/kullaniciadi/SchoolSystem.git
   ```

2. **Visual Studio ile açın**
   - `SchoolSystem.sln` dosyasını başlatın.
   - `App.config` içerisindeki `connectionString` alanını kendi SQL Server ayarlarınıza göre güncelleyin.

3. **Veritabanı kurulumunu gerçekleştirin**
   - `SQL_Schema.sql` içeriğini SQL Server Management Studio ile çalıştırarak veritabanını oluşturun.

4. **Projeyi çalıştırın**
   - `F5` tuşu ile uygulamayı başlatın.

---

## 👤 Geliştirici

- 🌐 [alican-kaya.com](https://alican-kaya.com/)
- 💼 [LinkedIn: Alican Kaya](https://www.linkedin.com/in/alican-kaya-881650234/)

---

## 📝 Lisans

Bu proje [MIT Lisansı](LICENSE) ile lisanslanmıştır.
