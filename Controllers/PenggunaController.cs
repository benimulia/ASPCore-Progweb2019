using System;
using ASPCoreGroupB.DAL;
using ASPCoreGroupB.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace ASPCoreGroupB.Controllers{
    public class PenggunaController:Controller {
        private IPengguna _pengguna;
        private object ret;

        public PenggunaController(IPengguna pengguna)
        {
            _pengguna = pengguna;
        }

        public IActionResult Registrasi(Pengguna pengguna){
            try{
                _pengguna.Insert(pengguna);
                return View();
            }
            catch(Exception ex){
                return Content($"Error: {ex.Message}");
            }
        }

    }
}