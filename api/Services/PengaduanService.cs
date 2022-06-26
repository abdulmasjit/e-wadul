#nullable disable
namespace Ewadul.Api.Services;
using System;
using Microsoft.EntityFrameworkCore;
using Ewadul.Api.Models;
using Ewadul.Api.DTO;
using MySql.Data.MySqlClient;
public interface IPengaduanService
{
    IEnumerable<PengaduanDTO.PengaduanResponse> GetAll(int? idUser);
    // IEnumerable<PengaduanDTO.PengaduanResponse> GetFotoPengaduan();
}

public class PengaduanService : IPengaduanService
{
    private readonly IConfiguration configuration;

    public PengaduanService(IConfiguration config)
    {
        configuration = config;
    }
    public IEnumerable<PengaduanDTO.PengaduanResponse> GetAll(int? idUser)
    {
        IList<PengaduanDTO.PengaduanResponse> pengaduanList = new List<PengaduanDTO.PengaduanResponse>();
        // koneksi database
        MySqlConnection conn = new MySqlConnection{
            ConnectionString = configuration.GetConnectionString("DBConnection")
        };
        conn.Open();
        string q = @"
            SELECT p.*, us.nama as nama_user, jp.nama as jenis_pengaduan, k.nama as nama_kecamatan, sp.status as status_pengaduan,
            us.nik, us.telepon FROM pengaduan p
            LEFT JOIN jenis_pengaduan jp ON p.id_jenis_pengaduan = jp.id
            LEFT JOIN kecamatan k ON p.id_kecamatan= k.id
            LEFT JOIN users us ON p.id_user = us.id
            LEFT JOIN status_pengaduan sp ON p.status = sp.id
        ";

        // get by id_user
        if(idUser!=null){
            q += " WHERE p.id_user = @idUser ";        
        }

        MySqlCommand cmd = new MySqlCommand(q, conn);

        // binding parameter
        if(idUser!=null){
            cmd.Parameters.AddWithValue("@idUser", idUser);
        }

        MySqlDataReader dataReader = cmd.ExecuteReader();
        while (dataReader.Read()){
            PengaduanDTO.PengaduanResponse item = new PengaduanDTO.PengaduanResponse();
            item.Id = Convert.ToInt16(dataReader["id"]);
            item.Tanggal = Convert.ToDateTime(dataReader["tanggal"]);
            item.IdJenisPengaduan = Convert.ToInt16(dataReader["id_jenis_pengaduan"]);
            item.JenisPengaduan = Convert.ToString(dataReader["jenis_pengaduan"]);
            item.IdKecamatan = Convert.ToString(dataReader["id_kecamatan"]);
            item.NamaKecamatan = Convert.ToString(dataReader["nama_kecamatan"]);
            item.Longitude = Convert.ToString(dataReader["longitude"]);
            item.Latitude = Convert.ToString(dataReader["latitude"]);
            item.Alamat = Convert.ToString(dataReader["alamat"]);
            item.Keterangan = Convert.ToString(dataReader["keterangan"]);
            item.Status = Convert.ToString(dataReader["status"]);
            item.StatusPengaduan = Convert.ToString(dataReader["status_pengaduan"]);
            item.IdUser = Convert.ToInt16(dataReader["id_user"]);
            item.Nik = Convert.ToString(dataReader["nik"]);
            item.NamaUser = Convert.ToString(dataReader["nama_user"]);
            item.Telepon = Convert.ToString(dataReader["telepon"]);
            // Push to model
            pengaduanList.Add(item);
        }
        dataReader.Close();
        conn.Close();

        return pengaduanList;
    }
}