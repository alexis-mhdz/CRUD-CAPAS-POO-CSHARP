using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaEntidades;

namespace CapaNegocio
{
    public class N_Empleado
    {
        D_Empleado objetoDato = new D_Empleado();
        public List<E_Empleado> ListandoEmpleados(string buscar)
        {
            return objetoDato.ListarEmpleados(buscar);
        }

        public void InsertandoEmpleado(E_Empleado empleado)
        {
            objetoDato.InsertarEmpleado(empleado);
        }

        public void EditandoEmpleado(E_Empleado empleado)
        {
            objetoDato.EditarEmpleado(empleado);
        }

        public void EliminadoEmpleado(E_Empleado empleado)
        {
            objetoDato.EliminarEmpleado(empleado);
        }
    }
}
