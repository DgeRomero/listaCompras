using negocio;
using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.DynamicData;

namespace MiCompras
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ArticuloNegocio negocio = new ArticuloNegocio();
                Session.Add("listado", negocio.listar());
                dvgLista.DataSource = negocio.listar();
                dvgLista.DataBind();    
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                Articulo nuevo = new Articulo();
                ArticuloNegocio negocio = new ArticuloNegocio();
                nuevo.Nombre = txtArticulo.Text;
                negocio.agregar(nuevo);
                dvgLista.DataSource=negocio.listar();
                dvgLista.DataBind();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void dvgLista_RowEditing(object sender, GridViewEditEventArgs e)
        {
    
            dvgLista.EditIndex = e.NewEditIndex;
            dvgLista.DataSource = Session["listado"];
            dvgLista.DataBind();
        }


        protected void dvgLista_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            if (e.CommandName == "btnEliminar")
            {
                int index = int.Parse(e.CommandArgument.ToString());
                Articulo seleccionado = negocio.listar()[index];
                int id = seleccionado.Id;
                negocio.eliminar(id);
                cargarTabla();
                
            }
        }
        public void cargarTabla()
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            dvgLista.DataSource = negocio.listar();
            dvgLista.DataBind();
        }

        protected void dvgLista_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            
            ArticuloNegocio negocio = new ArticuloNegocio();
            int index = int.Parse(e.RowIndex.ToString());
            Articulo seleccionado = negocio.listar()[index];
            seleccionado.Descripcion = (dvgLista.Rows[e.RowIndex].FindControl("txtDescripcion") as TextBox).Text;
            seleccionado.Precio = decimal.Parse((dvgLista.Rows[e.RowIndex].FindControl("txtPrecio") as TextBox).Text);
            seleccionado.Nombre = (dvgLista.Rows[e.RowIndex].FindControl("txtNombre") as TextBox).Text;
            seleccionado.Cantidad = int.Parse((dvgLista.Rows[e.RowIndex].FindControl("txtCantidad") as TextBox).Text);
            //int id = seleccionado.Id;
            //seleccionado.Id = id;
            negocio.modificar(seleccionado);
            dvgLista.EditIndex = -1;
            cargarTabla();
          
        }

        protected void dvgLista_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            dvgLista.EditIndex = -1;
            cargarTabla();
        }
    }
}