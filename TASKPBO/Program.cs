//sistem karyawan


public class Karyawan
{
    public string nama { get; set; }
    public int gaji { get; set; }

    public Karyawan(string nama, int gaji)
    {
        this.nama = nama;
        this.gaji = gaji;
    }

    public virtual void Kerja()
    {
        Console.WriteLine($"{nama} sedang bekerja");
    }

    public virtual void InfoKaryawan()
    {
        Console.WriteLine($"nama:{nama}, gaji:Rp.{gaji}");
    }
}


public class Tetap : Karyawan
{
    public int tunjangan { get; set; }

    public Tetap(string nama, int gaji, int tunjangan) : base(nama, gaji)
    {
        this.tunjangan = tunjangan;
    }

    public int HitungGajiTotal()
    {
        return gaji + tunjangan;
    }

    public override void Kerja()
    {
        Console.WriteLine($"{nama} bekerja sebagai karyawan tetap");
    }

    public override void InfoKaryawan()
    {
        Console.WriteLine($"nama:{nama}, gaji:Rp.{gaji}, tunjangan:Rp.{tunjangan}, gaji total:Rp.{HitungGajiTotal()}");
    }
}


public class Kontrak : Karyawan
{
    public int durasi { get; set; }

    public Kontrak(string nama, int gaji, int durasi) : base(nama, gaji)
    {
        this.durasi = durasi;
    }

    public void CekKontrak()
    {
        Console.WriteLine($"{nama} dikontrak selama {durasi} bulan");
    }

    public override void Kerja()
    {
        Console.WriteLine($"{nama} bekerja sebagai karyawan kontrak");
    }

    public override void InfoKaryawan()
    {
        Console.WriteLine($"nama:{nama}, gaji:Rp.{gaji}, durasi kontrak:{durasi} bulan");
    }
}


public class Manager : Tetap
{
    public Manager(string nama, int gaji, int tunjangan) : base(nama, gaji, tunjangan)
    {
    }

    public void Memimpin()
    {
        Console.WriteLine($"{nama} sedang memimpin rapat tim rrq");
    }

    public override void Kerja()
    {
        Console.WriteLine($"{nama} (kink manager) mengatur dan mengawasi pekerjaan tim");
    }
}


public class Staff : Tetap
{
    public Staff(string nama, int gaji, int tunjangan) : base(nama, gaji, tunjangan)
    {
    }

    public void KerjakanTugas()
    {
        Console.WriteLine($"{nama} sedang mengerjakan tugas harian tapi ditinggal tidur");
    }

    public override void Kerja()
    {
        Console.WriteLine($"{nama} (staff biasa) mengerjakan tugas dari manager");
    }
}


public class Magang : Kontrak
{
    public Magang(string nama, int gaji, int durasi) : base(nama, gaji, durasi)
    {
    }

    public void Belajar()
    {
        Console.WriteLine($"{nama} sedang belajar dari karyawan sepuh");
    }

    public override void Kerja()
    {
        Console.WriteLine($"{nama} (bocah magang) membantu pekerjaan sambil ngopi");
    }
}


public class Freelancer : Kontrak
{
    public Freelancer(string nama, int gaji, int durasi) : base(nama, gaji, durasi)
    {
    }

    public void AmbilProyek()
    {
        Console.WriteLine($"{nama} mengambil proyek baru");
    }

    public override void Kerja()
    {
        Console.WriteLine($"{nama} (freelancer) mengerjakan proyek dari rumah");
    }
}


public class Perusahaan
{
    //koleksi karyawan
    public List<Karyawan> daftar = new List<Karyawan>();

    public void TambahKaryawan(Karyawan karyawan)
    {
        daftar.Add(karyawan);
        Console.WriteLine($"{karyawan.nama} berhasil ditambahkan ke perusahaan");
    }

    public void DaftarKaryawan()
    {
        int nomor = 1;
        foreach (Karyawan k in daftar)
        {
            Console.Write($"{nomor}. ");
            k.InfoKaryawan();
            nomor++;
        }
    }

    //dipakai untuk demo polymorphism
    public void SemuaKerja()
    {
        foreach (Karyawan k in daftar)
        {
            k.Kerja();
        }
    }
}



public class program
{
    public static void Main(string[] args)
    {
        //a. buat objek perusahaan
        Perusahaan perusahaan1 = new Perusahaan();

        //b. buat beberapa objek karyawan
        Manager manager1 = new Manager("dhani", 10000000, 3000000);
        Staff staff1 = new Staff("diva", 6000000, 1000000);
        Magang magang1 = new Magang("kurniawan", 1500000, 6);
        Freelancer freelancer1 = new Freelancer("mega", 4000000, 3);

        //c. tambahkan ke perusahaan
        Console.WriteLine("=== tambah karyawan ===");
        perusahaan1.TambahKaryawan(manager1);
        perusahaan1.TambahKaryawan(staff1);
        perusahaan1.TambahKaryawan(magang1);
        perusahaan1.TambahKaryawan(freelancer1);

        //d. tampilkan semua data
        Console.WriteLine("\n=== daftar karyawan ===");
        perusahaan1.DaftarKaryawan();

        //e. demonstrasi polymorphism (satu perintah Kerja(), hasilnya beda tiap objek)
        Console.WriteLine("\n=== polymorphism: semua karyawan kerja ===");
        perusahaan1.SemuaKerja();

        //f. panggil method khusus
        Console.WriteLine("\n=== method khusus ===");
        manager1.Memimpin();
        staff1.KerjakanTugas();
        magang1.Belajar();
        freelancer1.AmbilProyek();
        magang1.CekKontrak();
        Console.WriteLine($"gaji total {manager1.nama}: Rp.{manager1.HitungGajiTotal()}");



        //soal 1
        Console.WriteLine("\n=== soal 1 ===");
        manager1.Kerja();
        freelancer1.Kerja();

        //soal 2
        Console.WriteLine("\n=== soal 2 ===");
        manager1.Memimpin();

        //soal 3
        Console.WriteLine("\n=== soal 3 ===");
        manager1.InfoKaryawan();
        Console.WriteLine($"nama:{manager1.nama}, gaji:{manager1.gaji}, tunjangan:{manager1.tunjangan}");

        //soal 4
        Console.WriteLine("\n=== soal 4 ===");
        magang1.Belajar();

        //soal 5
        Console.WriteLine("\n=== soal 5 ===");
        Karyawan karyawan1 = new Staff("uncle mutho", 5500000, 800000);
        karyawan1.Kerja();
    }
}