using System;
using System.Collections.Generic;
using System.Text;

namespace PrimerParcialAplicada.Entidades
{
    public class Productos
    {
        public int ProductoId { get; set; }
        public string  Descripcion { get; set; }
        public int Existencia { get; set; }
        public decimal Costo { get; set; }
        public decimal ValorInventario { get; set; }

        public Productos()
        {
            ProductoId = 0;
            Descripcion = string.Empty;
            Existencia = 0;
            Costo = 0;
            ValorInventario = 0;
        }
    }
}
