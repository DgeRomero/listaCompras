using negocio;
using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.DynamicData;
using Microsoft.SqlServer.Server;

namespace MiCompras
{
    public partial class Default : System.Web.UI.Page
    {
        public decimal suma { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            if (!IsPostBack)
            {
                Session.Add("listado", negocio.listar());
                dvgLista.DataSource = negocio.listar();
                dvgLista.DataBind();
                sumar();
            }
            
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                Page.Validate();
                if (!Page.IsValid)
                    return;

                if(txtArticulo.Text != "")
                {
                    Articulo nuevo = new Articulo();
                    ArticuloNegocio negocio = new ArticuloNegocio();
                    nuevo.Nombre = txtArticulo.Text;
                    negocio.agregar(nuevo);
                    dvgLista.DataSource = negocio.listar();
                    dvgLista.DataBind();                    
                }
                txtArticulo.Text = "";
                
                
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void dvgLista_RowEditing(object sender, GridViewEditEventArgs e)
        {
    
            dvgLista.EditIndex = e.NewEditIndex;
            cargarTabla();
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
                sumar();                
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
                dvgLista.EditIndex = -1;
                negocio.modificar(seleccionado);
                cargarTabla();
                sumar();          
        }

        protected void dvgLista_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            dvgLista.EditIndex = -1;
            cargarTabla();
        }
        public void sumar()
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            if (negocio.listar() != null)
            {
                suma = 0;
                foreach (Articulo art in negocio.listar())
                {
                    suma += (art.Precio * art.Cantidad);
                }
                
                lblCuentaTotal.Text = "$ " + suma.ToString();
                lblTotal.Visible = true;
                lblCuentaTotal.Visible = true;
                lblCuentaTotal.Text = suma.ToString("c");
               
            }
            else
            {
                lblTotal.Visible = false;
                lblCuentaTotal.Visible = false;
                suma = 0;
            }
        }

        protected void btnCalcular_Click(object sender, EventArgs e)
        {
            
            sumar();
        }
    }
}