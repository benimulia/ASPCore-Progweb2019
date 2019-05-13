using System;
using ASPCoreGroupB.DAL;
using ASPCoreGroupB.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace ASPCoreGroupB.Controllers{
    public class DosenController:Controller {
        private IDosen _dsn;
        public DosenController(IDosen dsn)
        {
            _dsn = dsn;
        }

        public IActionResult Index(){
            var data = _dsn.GetAll();
            return View(data);
        }

        [HttpPost]
        public IActionResult Search(string keyword){
            var data = _dsn.GetAllByNik(keyword);
            return View("Index",data);
        }

        [HttpPost]
        public IActionResult SearchNama(string keyword){
            var data = _dsn.GetAllByNama(keyword);
            return View("Index",data);
        }

        [HttpPost]
        public IActionResult SearchAll(string keyword, string pilih){
            IEnumerable<Dosen> data;
            if (pilih=="Nik")
            {
                data = _dsn.GetAllByNik(keyword);
            }else
            {
                data = _dsn.GetAllByNama(keyword);
               
            }
            return View("Index",data);   
        }

        public IActionResult Create(){
            return View();
        }

        [HttpPost]
        public IActionResult Edit(Dosen dsn){
            try{
                _dsn.Insert(dsn);
                ViewData["pesan"] =
                    "<span class = 'alert alert-success'>Data berhasil diedit !</span>";
                return View("Details");
            }
            catch(Exception ex){
                ViewData["pesan"] =
                $"<span class = 'alert alert-success'>Data Gagal Diedit ! {ex.Message} </span>";
                return Content(ex.Message);
            }
        }

        public IActionResult Delete(string id){
            try{
                _dsn.Delete(id);
                var data = _dsn.GetAll();
                ViewData["pesan"] =
                    "<span class = 'alert alert-success'>Data berhasil dihapus !</span>";
                return View("Index",data);
            }catch(Exception ex){
                return Content(ex.Message);
            }
        }
        public IActionResult Details(string id){
            var data = _dsn.GetById(id);
            return View(data);
        }

        [HttpPost]
        public IActionResult CreatePost(Dosen dsn){
            try{
                _dsn.Insert(dsn);
                ViewData["pesan"] =
                    "<span class='alert alert-success'>Data Dosen berhasil ditambah</span>";
                return View("Create");    
            }
            catch(Exception ex){
                ViewData["pesan"] =
                $"<span class='alert alert-danger'>Data Gagal Ditambah, {ex.Message}</span>";
                return View("Create");
            }
        }
    }
}