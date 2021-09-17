using KioskoDatos;
using KioskoEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KioskoNegocio
{
    public class UsuarioNeg
    {
        private UsuariosDat UsuarioDato = new UsuariosDat();

        public List<UsuariosEnt> Listar()
        {
            return UsuarioDato.Listar();
        }

        public UsuariosEnt Obtener(int Id)
        {
            return UsuarioDato.Obtener(Id);
        }

        public bool Registrar(UsuariosEnt usuario)
        {
            return UsuarioDato.Registrar(usuario);
        }

        public bool Actualizar(UsuariosEnt usuario)
        {
            return UsuarioDato.Actualizar(usuario);
        }

        public bool Eliminar(int Id)
        {
            return UsuarioDato.Eliminar(Id);
        }
    }
}
