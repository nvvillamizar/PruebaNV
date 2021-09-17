using KioskoDatos;
using KioskoEntidad;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace KioskoNegocio
{
    public class KioskoNeg
    {
        private KioskoDat kioskoDato = new KioskoDat();

        public List<VKioskoEnt> Listar()
        {
            return kioskoDato.Listar();
        }
        public List<SelectListItem> listaEstadoKiosko()
        {
            return kioskoDato.listarEstadoKiosko();
        }

        public KioskoEnt Obtener(int Id)
        {
            return kioskoDato.Obtener(Id);
        }

        public bool Registrar(KioskoEnt kiosco)
        {
            return kioskoDato.Registrar(kiosco);
        }

        public bool Actualizar(KioskoEnt kiosco)
        {
            return kioskoDato.Actualizar(kiosco);
        }

        public bool Eliminar(int Id)
        {
            return kioskoDato.Eliminar(Id);
        }
    }
}
