﻿using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimiSoft.BML;

namespace SimiSoft
{
    public partial class frmLogin : DevExpress.XtraEditors.XtraForm
    {
        public frmLogin()
        {
            InitializeComponent();
        }

      

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {

                if (new Usuario
                {
                    username = txtUsuario.Text,
                    password = txtPassword.Text

                }.Login() != null)
                {
                    XtraMessageBox.Show("Acceso Correcto");
                    DialogResult = DialogResult.OK;

                }
                else
                {
                    XtraMessageBox.Show("Error en las credenciales");
                }
            }
        }
        private bool Validar()
        {
            var ban = false;
            if (string.IsNullOrEmpty(txtUsuario.Text))
            {
                txtUsuario.ErrorText = "Ingrese el usuario";
                txtUsuario.Focus();
                ban = true;
            }

            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                txtPassword.ErrorText = "Ingresa una contraseña";
                if (ban == false)
                {
                    txtPassword.Focus();
                    ban = true;
                }
            }
            return !ban;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}