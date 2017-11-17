using Model;
using Model.ModelContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;



namespace IdentiyApp.Controllers
{
    public class NegocioController : Controller
    {

        private negocio negocios = new negocio();
        private AspNetUsers _AspNetUsers = new AspNetUsers();
        private meses _meses = new meses();
        private Mes_Pago _mes_pago = new Mes_Pago();
        private pagos _pagos = new pagos();

        private direccion_negocio _direccion = new direccion_negocio();
        private actividad _actividad = new actividad();
        private tributos _tributos = new tributos();
        private formatos _formatos = new formatos();
        // GET: Negocio
        public ActionResult Index(string id)
        {
           
            if (id.Length==0)
            {
                return Redirect("~/home");
            }else
            {
                return View(
                id.Length == 0 ? new AspNetUsers()
                        : _AspNetUsers.Obtener(id)
            );
            }
            
        }

        public ActionResult CrudNegocio(int Id=0)
        {

            ViewBag.ListarMes = _mes_pago.Listar_mes();
            ViewBag.ListarNegocio = negocios.Listar_Negocios();
            ViewBag.Listarmeses = _meses.Listar_meses();
            ViewBag.ListarUser = _AspNetUsers.Todo();
            ViewBag.ListerPagos = _pagos.Listar_pagos(Id);

            ViewBag.ListarFormatos = _formatos.Listar_Formato();
            ViewBag.Listar_Direccion = _direccion.Listar_Direccion();
            ViewBag.ListarTributos = _tributos.ListarTributos();
            ViewBag.ListarActividad = _actividad.Listar_Actividad();
            return View(
                Id > 0 ? negocios.Obtener(Id)
                :negocios
                );
         }


        public ActionResult NuevoNegocio(int Id=0)
        {
            ViewBag.ListarMes = _mes_pago.Listar_mes();
            ViewBag.ListarNegocio = negocios.Listar_Negocios();
            ViewBag.Listarmeses = _meses.Listar_meses();
            ViewBag.ListarUser = _AspNetUsers.Todo();
            ViewBag.ListerPagos = _pagos.Listar_pagos();

            return View(
                Id > 0 ? negocios.Obtener(Id)
                : negocios
                );
        }


        //Realizar Pagos
        public ActionResult Realizar_Pagos(int id_n=0)
        {

           
            ViewBag.ListarNegocio = negocios.Listar_Negocios(id_n);
            return View();
        }



        //Guardar Nuevo Negocio
        [HttpPost]
        public ActionResult Guardar(negocio model,int mat=0)
        {

            model.Guardar();
            return Redirect("~/Negocio/crudnegocio/"+mat);
        }

        //Guardar Pago

        public ActionResult Guardar_Pago(pagos model)
        {

            model.Guardar_Pago();
            return Redirect("~/Home/Index/");
        }



    }

}
