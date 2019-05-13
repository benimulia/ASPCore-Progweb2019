using System.Collections.Generic;
using System.Data.SqlClient;
using ASPCoreGroupB.Models;
using Microsoft.Extensions.Configuration;
using Dapper;
using System;

namespace ASPCoreGroupB.DAL { 
    public class DosenDAL : IDosen {
        private IConfiguration _config;
        public DosenDAL(IConfiguration config){
            _config = config;
        }

        private string GetConnStr(){
            return _config.GetConnectionString("DefaultConnection");
        }

        public IEnumerable<Dosen> GetAll(){
            using(SqlConnection conn = new SqlConnection(GetConnStr())){
                string strSql = @"select * from Data_Dosen order by Nama";
                return conn.Query<Dosen>(strSql);
            }
        }

        public IEnumerable<Dosen> GetAllByNik(string nik){
            using(SqlConnection conn = new SqlConnection(GetConnStr())){
                string strSql = @"select * from Data_Dosen where Nik=@Nik order by Nama";
                var param = new {nik=nik};
                return conn.Query<Dosen>(strSql,param);
            }
        }

        public IEnumerable<Dosen> GetAllByNama(string nama){
            using(SqlConnection conn = new SqlConnection(GetConnStr())){
                string strSql = @"select * from Data_Dosen where Nama like @nama order by Nama";
                var param = new {Nama="%"+nama+"%"};
                return conn.Query<Dosen>(strSql,param);
            }
        }

        public void Delete(string nik)
        {
            using(SqlConnection conn = new SqlConnection(GetConnStr())){
                var strSql = @"delete from Data_Dosen where Nik=@Nik";
                try{
                    var param = new {nik=nik};
                    conn.Execute(strSql,param);
                }catch(SqlException sqlEx){
                    throw new Exception($"Error : {sqlEx}");
                }   
            }
        }

        

        public Dosen GetById(string nik)
        {
            using(SqlConnection conn = new SqlConnection(GetConnStr())){
                var strSql = @"select * from Data_Dosen where Nik=@Nik";
                var param = new {Nik=nik};
                var result = conn.QuerySingleOrDefault<Dosen>(strSql,param);
                if(result==null)
                    throw new Exception("Error: Data Tidak Ditemukan !");
                    //tanda $ digunakan untuk menampilkan salah satu var;ex: menampilkan param.
                return result;
            }
        }

        public void Insert(Dosen dsn)
        {
            using(SqlConnection conn = new SqlConnection(GetConnStr())){
                var strSql = @"insert into Data_Dosen(Nik,Nama,Alamat,Email) 
                values(@Nik,@Nama,@Alamat,@Email)";

                try{
                    var param = new {Nik=dsn.Nik,Nama=dsn.Nama,Alamat=dsn.Alamat,
                        Email=dsn.Email};
                    conn.Execute(strSql,param);
                }
                catch(SqlException sqlEx){
                    throw new Exception($"Error : {sqlEx.Message}");
                }
            }
        }

        public void Update(Dosen dsn)
        {
            using(SqlConnection conn = new SqlConnection(GetConnStr())){
                var strSql ="update Data_Dosen set Nama=@Nama, Alamat=@Alamat, Email=@Email where Nik=@Nik";
                try{
                    var param = new {Nama=dsn.Nama,Alamat=dsn.Alamat,Email=dsn.Email, Nik=dsn.Nik };
                    conn.Execute(strSql,param);
                }catch(SqlException sqlEx){
                    throw new Exception($"Error : {sqlEx.Message} ");
                }

            }
        }
    }
}