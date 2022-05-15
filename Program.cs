using System;
using System.Data;
using Npgsql;

//data guru
namespace tugas99999
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool barang;
            data dat = new data();
            operasi op = new operasi();

            if (dat.ExecuteQuery(out barang) == true)
            {
                Console.WriteLine("Berhasil mengimput data");
            }
            else if (dat.ExecuteQuery(out barang) == false)
            {
                Console.WriteLine("Gagal mengimput data");
            }
            if (op.insert(ref barang) == true)
            {
                Console.WriteLine("Insert berhasil");
            }
            else if (op.insert(ref barang) == false)
            {
                Console.WriteLine("Insert gagal");
            }
            if (op.update(ref barang) == true)
            {
                Console.WriteLine("Update berhasil");
            }
            else if (op.update(ref barang) == false)
            {
                Console.WriteLine("Update gagal");
            }
            if (op.delete(ref barang) == true)
            {
                Console.WriteLine("Delete berhasil");
            }
            else if (op.delete(ref barang) == false)
            {
                Console.WriteLine("Delete gagal");
            }
        }
    }

    class data
    {
        private static NpgsqlConnection koneksi()
        {
            return new NpgsqlConnection(@"server=localhost;port=5432;user id=postgres;password=1905;database=toko;");
        }
        public bool ExecuteQuery(out bool barang)
        {
            barang = true;
            try
            {
                NpgsqlConnection con = koneksi();
                con.Open();
                string sql = "select * from barang";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return barang;
            }
            catch (Exception)
            {
                barang = false;
                return barang;
            }
        }
    }

    class operasi
    {
        private static NpgsqlConnection koneksi()
        {
            return new NpgsqlConnection(@"server=localhost;port=5432;user id=postgres;password=1905;database=toko;");
        }
        public bool insert(ref bool barang)
        {
            try
            {
                NpgsqlConnection con = koneksi();
                con.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("insert into barang(id_barang,nama_barang,harga,deskripsi) values(1,'makanan ringan',Rp 2000, 'makanan ringan ada bermacam rasa')", con);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                con.Close();
                barang = true;
                return barang;
            }
            catch (Exception)
            {
                return barang;
            }
        }
        public bool update(ref bool barang)
        {
            try
            {
                NpgsqlConnection con = koneksi();
                con.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("update barang set nama_barang = pasta gigi,harga = Rp 5000, deskripsi = pasta gigi rasa mind  where id_barang = 1", con);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                con.Close();
                barang = true;
                return barang;
            }
            catch (Exception)
            {
                return barang;
            }
        }
        public bool delete(ref bool barang)
        {
            try
            {
                NpgsqlConnection con = koneksi();
                con.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("delete from barang where id_barang = 1", con);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                con.Close();
                barang = true;
                return barang;
            }
            catch (Exception)
            {
                return barang;
            }
        }
    }
}



