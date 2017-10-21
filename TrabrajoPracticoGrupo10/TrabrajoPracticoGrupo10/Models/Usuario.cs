using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TrabrajoPracticoGrupo10;

namespace TrabajoPracticoGrupo10.Models
{
    public class UsuarioModel : Usuario 
    {
        public int IdModel { get; set; }
        public string EmailModel { get; set; }
        public string ContraseniaModel { get; set; }
        public bool AdminModel { get; set; }
        public string NombreModel { get; set; }
        public string ApellidoModel { get; set; }

        public UsuarioModel()
        {
            this.IdModel = Id;
            this.EmailModel = Email;
            this.ContraseniaModel = Contrasenia;
            this.AdminModel = Admin;
            this.ApellidoModel = Apellido;

        }

    }
}