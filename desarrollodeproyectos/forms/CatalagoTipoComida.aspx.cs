using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace desarrollodeproyectos.forms
{
    public partial class CatalagoTipoComida : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarConsecutivo();
                CargarGrid();
            }
        }

        public void CargarConsecutivo()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connDB"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                SqlDataReader dr;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_TIPOCOMIDA";
                cmd.Parameters.Add("@OP", SqlDbType.TinyInt).Value = 4;
                cmd.Connection = conn;

                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        IdTipoComida.Text = dr.GetInt32(0).ToString();
                    }
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public void RegistrarTC()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connDB"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_TIPOCOMIDA";
                cmd.Parameters.Add("@OP", SqlDbType.TinyInt).Value = 1;
                cmd.Parameters.Add("@TC_Id", SqlDbType.Int).Value = IdTipoComida.Text.Trim();
                cmd.Parameters.Add("@TC_Nombre", SqlDbType.VarChar).Value = NombreTipoComida.Text.Trim();
                cmd.Connection = conn;

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public void CargarGrid()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connDB"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_TIPOCOMIDA";
                cmd.Parameters.Add("@OP", SqlDbType.TinyInt).Value = 3;
                cmd.Connection = conn;

                try
                {
                    conn.Open();
                    da.SelectCommand = cmd;
                    da.Fill(ds);

                    gvTipoComida.DataSource = ds;
                    gvTipoComida.DataBind();
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public void ClearTodo()
        {
            IdTipoComida.Text = "";
            NombreTipoComida.Text = "";
        }

        protected void BtnRegistrar_Click(object sender, EventArgs e)
        {
            if (NombreTipoComida.Text == "")
            {
                lblError.Visible = true;
                lblError.Text = "Falta el nombre de la comida";
            }
            else
            {
                lblError.Visible = false;
                RegistrarTC();
                ClearTodo();
                CargarConsecutivo();
                CargarGrid();
            }
        }

        protected void gvTipoComida_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Obtiene el índice de la fila seleccionada
            int index = gvTipoComida.SelectedIndex;

            IdTipoComida.Text = gvTipoComida.SelectedRow.Cells[1].Text;
            NombreTipoComida.Text = gvTipoComida.SelectedRow.Cells[2].Text;
        }
    }
}