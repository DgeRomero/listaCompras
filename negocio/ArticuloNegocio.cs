using dominio;
using Acceso;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class ArticuloNegocio
    {
        public List<Articulo> mostrarArticulo(Articulo art)
        {
            AccesoDatos datos = new AccesoDatos();
            List<Articulo> lista = new List<Articulo>();

            try
            {
                datos.setearConsulta("select @nombre, @descripcion, @cantidad, @precio, @id from ARTICULOS");
                datos.setearParametro("@nombre", art.Nombre);
                datos.setearParametro("@descripcion", art.Descripcion);
                datos.setearParametro("@cantidad", art.Cantidad);
                datos.setearParametro("@precio", art.Precio);
                datos.setearParametro("@id", art.Id);
                datos.ejecutarAccion();

                lista.Add(art);
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public List<Articulo> listar()
        {
            List<Articulo> lista = new List<Articulo> ();
            AccesoDatos datos = new AccesoDatos ();
            try
            {
                datos.setearConsulta("select nombre, descripcion, cantidad, precio, id from ARTICULOS");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Precio = (decimal)datos.Lector["Precio"];
                    aux.Cantidad = (int)datos.Lector["Cantidad"];

                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally 
            { 
                datos.cerrarConexion ();
            }
        }
        public void agregar(Articulo nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("insert into ARTICULOS (Nombre, Descripcion, Cantidad, Precio) values (@nombre, '', 0, 0)");
                datos.setearParametro("@nombre", nuevo.Nombre);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public void modificar(Articulo art)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("update ARTICULOS set Nombre = @nombre, Descripcion = @desc, Cantidad = @cant, Precio = @precio where Id = @id");
                datos.setearParametro("@nombre", art.Nombre);
                datos.setearParametro("@desc", art.Descripcion);
                datos.setearParametro("@cant", art.Cantidad);
                datos.setearParametro("@precio", art.Precio);
                datos.setearParametro("@id", art.Id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public void eliminar(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("delete from Articulos where id = @id");
                datos.setearParametro("@id", id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
