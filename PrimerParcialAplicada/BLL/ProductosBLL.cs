using Microsoft.EntityFrameworkCore;
using PrimerParcialAplicada.DAL;
using PrimerParcialAplicada.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace PrimerParcialAplicada.BLL
{
    public class ProductosBLL
    {
        public static bool Guardar(Productos producto)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                if (db.productoTB.Add(producto) != null)
                    paso = (db.SaveChanges() > 0);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }

        private decimal Calcular(decimal costo, Decimal existencia)
        {
            return costo * existencia;
        }

        public static bool Modificar(Productos producto)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                db.Entry(producto).State = EntityState.Modified;
                    paso = (db.SaveChanges() > 0);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                var eliminar = db.productoTB.Find(id);
                db.Entry(eliminar).State = EntityState.Deleted;
                    paso = (db.SaveChanges() > 0);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }

        public static Productos Buscar (int id)
        {
            Productos productos = new Productos();
            Contexto db = new Contexto();

            try
            {
                productos = db.productoTB.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return productos;
        }

        public static List<Productos> GetList(Expression<Func<Productos, bool>> productos)
        {
            List<Productos> lista = new List<Productos>();
            Contexto db = new Contexto();

            try
            {
                lista = db.productoTB.Where(productos).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return lista;
        }
    }
}
