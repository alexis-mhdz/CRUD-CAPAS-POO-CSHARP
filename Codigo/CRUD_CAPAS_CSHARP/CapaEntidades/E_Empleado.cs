using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class E_Empleado
    {
        private int id;
        private string folio;
        private string nombre;
        private string apellidos;
        private string sexo;
        private DateTime fechaNacimiento;
        private string puesto;
        private decimal sueldo;

        public int Id { get => id; set => id = value; }
        public string Folio { get => folio; set => folio = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellidos { get => apellidos; set => apellidos = value; }
        public string Sexo { get => sexo; set => sexo = value; }
        public DateTime FechaNacimiento { get => fechaNacimiento; set => fechaNacimiento = value; }
        public string Puesto { get => puesto; set => puesto = value; }
        public decimal Sueldo { get => sueldo; set => sueldo = value; }
    }
}
