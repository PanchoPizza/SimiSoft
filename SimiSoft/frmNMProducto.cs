using DevExpress.XtraEditors;
using SimiSoft.BML;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimiSoft
{
    public partial class frmNMProducto : DevExpress.XtraEditors.XtraForm
    {
     
        private Producto producto;
        public frmNMProducto()
        {
            InitializeComponent();
        
        }
        public frmNMProducto(int idProducto)
        {
            InitializeComponent();
        
            producto = new Producto
            {
                idProducto = idProducto
            }.GetById();
            txtId.Text = producto.idProducto.ToString();
            txtDescripccion.Text = producto.descripcion;
            txtUnidadM.Text = producto.unidadMedida;
            txtCodigo.Text = producto.codigo;
            txtPrecio.Text = producto.precio.ToString();
            txtStock.Text = producto.stock.ToString();
            txtMarca.Text = producto.marca;
        }
        private void labelControl1_Click(object sender, EventArgs e)
        {

        }

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void labelControl3_Click(object sender, EventArgs e)
        {

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

            if (Validar())
            {

                if (producto == null)
                {

                    if (new Producto
                    {

                        descripcion = txtDescripccion.Text,
                        unidadMedida = txtUnidadM.Text,
                        codigo = txtCodigo.Text,
                        precio = Convert.ToDecimal(txtPrecio.Text),
                        stock = Convert.ToInt32(txtStock.Text),
                        marca = txtMarca.Text
                    }.Add() > 0)
                    {
                        XtraMessageBox.Show("Producto Insertado Correctamente", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.Close();
                    }
                    else
                    {
                        XtraMessageBox.Show("Ocurrió un error inesperado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.Close();
                    }
                }
                else
                {
                    producto.descripcion=txtDescripccion.Text;
                    producto.unidadMedida = txtUnidadM.Text;
                    producto.codigo = txtCodigo.Text;
                    producto.precio = Convert.ToDecimal(txtPrecio.Text);
                    producto.stock = Convert.ToInt32(txtStock.Text);
                    producto.marca = txtMarca.Text;
                    if (producto.Update() > 0) {

                        XtraMessageBox.Show("Producto Modificado Correctamente", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.Close();
                    }
                    else
                    {
                        XtraMessageBox.Show("Ocurrió un error inesperado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.Close();
                    }
                }

            }
      
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private bool Validar()
        {
            var ban = false;
            if (string.IsNullOrEmpty(txtDescripccion.Text))
            {
                txtDescripccion.ErrorText = "Ingresa descripción ";
                txtDescripccion.Focus();
                ban = true;
            }

            if (string.IsNullOrEmpty(txtUnidadM.Text))
            {
                txtUnidadM.ErrorText = "Ingresa unidad de medida ";
                if (ban == false)
                {
                    txtUnidadM.Focus();
                    ban = true;
                }
            }
            if (string.IsNullOrEmpty(txtCodigo.Text))
            {
                txtCodigo.ErrorText = "Ingresa código ";
                if (ban == false)
                {
                    txtCodigo.Focus();
                    ban = true;
                }
            }
            if (string.IsNullOrEmpty(txtPrecio.Text))
            {
                txtPrecio.ErrorText = "Ingresa Precio ";
                if (ban == false)
                {
                    txtPrecio.Focus();
                    ban = true;
                }
            }
            if (string.IsNullOrEmpty(txtStock.Text))
            {
                txtStock.ErrorText = "Ingresa Stock ";
                if (ban == false)
                {
                    txtStock.Focus();
                    ban = true;
                }
            }
            if (string.IsNullOrEmpty(txtMarca.Text))
            {
                txtMarca.ErrorText = "Ingresa Marca ";
                if (ban == false)
                {
                    txtMarca.Focus();
                    ban = true;
                }
            }
            return !ban;
        }
    }

}