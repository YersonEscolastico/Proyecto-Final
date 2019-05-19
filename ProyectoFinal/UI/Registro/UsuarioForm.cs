using Registro.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Registro.BLL;
using System.Text.RegularExpressions;

namespace Registro
{
    public partial class PrincipalForm : Form
    {
        public PrincipalForm()
        {
            InitializeComponent();
            ClaveTextBox.PasswordChar = '*';
            ConfirmarClaveTextBox.PasswordChar= '*';
        }

        //Metodo para limpiar los componentes del registro
        private void Limpiar()
        {
            IDNumericUpDown.Value = 0;
            NombreTextBox.Text = string.Empty;
            EmailTextBox.Text = string.Empty;
            UsuariosTextBox.Text = string.Empty;
            ClaveTextBox.Text = string.Empty;
            ConfirmarClaveTextBox.Text = string.Empty;
            NivelUsuarioComboBox.Text = string.Empty;
            FechaIngreseDateTimePicker.Value = DateTime.Now;
            MyErrorProvider.Clear();
        }

        //Evento del boton nuevo en el que limpiamos los componentes del registro
        private void NuevoButton_Click_1(object sender, EventArgs e)
        {
            Limpiar();
        }


        private Usuario LlenaClase()
        {
            Usuario usuario = new Usuario();
            usuario.UsuarioId = Convert.ToInt32(IDNumericUpDown.Value);
            usuario.Nombre = NombreTextBox.Text;
            usuario.Email = EmailTextBox.Text;
            usuario.Usuarios = UsuariosTextBox.Text;
            usuario.NivelUsuario = NivelUsuarioComboBox.Text;
            usuario.Clave = ClaveTextBox.Text;
            usuario.Confirmar_Clave = ConfirmarClaveTextBox.Text;
            usuario.FechaIngreso = FechaIngreseDateTimePicker.Value;
            return usuario;
        }


        private void LlenaCampo(Usuario usuario)
        {
            IDNumericUpDown.Value = usuario.UsuarioId;
            NombreTextBox.Text = usuario.Nombre;
            EmailTextBox.Text = usuario.Email;
            UsuariosTextBox.Text = usuario.Usuarios;
            NivelUsuarioComboBox.Text = usuario.NivelUsuario;
            ClaveTextBox.Text = usuario.Clave;
            ConfirmarClaveTextBox.Text = usuario.Confirmar_Clave;
            FechaIngreseDateTimePicker.Value = usuario.FechaIngreso;
        }


        private bool Validar()
        {
            string clave = ClaveTextBox.Text;
            string confirmacion = ConfirmarClaveTextBox.Text;

            int result = 0;
            result = string.Compare(clave, confirmacion);

            bool paso = false;

            if (result != 0)
            {
                MyErrorProvider.SetError(ConfirmarClaveTextBox, "Las claves no coinciden");
                ConfirmarClaveTextBox.Focus();
                paso = true;
            }
            if (NombreTextBox.Text == string.Empty)
            {
                MyErrorProvider.SetError(NombreTextBox, "Este campo no puede estar vacio");
                NombreTextBox.Focus();
                paso = true;
            }
            if (EmailTextBox.Text == string.Empty)
            {
                MyErrorProvider.SetError(EmailTextBox, "Este campo no puede estar vacio");
                EmailTextBox.Focus();
                paso = true;
            }
            if (UsuariosTextBox.Text == string.Empty)
            {
                MyErrorProvider.SetError(UsuariosTextBox, "Este campo no puede estar vacio");
                UsuariosTextBox.Focus();
                paso = true;
            }
            if (NivelUsuarioComboBox.Text == string.Empty)
            {
                MyErrorProvider.SetError(NivelUsuarioComboBox, "No puede dejar este campo vacio");
                NivelUsuarioComboBox.Focus();
                paso = true;
            }
            if (ClaveTextBox.Text == string.Empty)
            {
                MyErrorProvider.SetError(ClaveTextBox, "Este campo no puede estar vacio");
                ClaveTextBox.Focus();
                paso = true;
            }
            if (ConfirmarClaveTextBox.Text == string.Empty)
            {
                MyErrorProvider.SetError(ConfirmarClaveTextBox, "Este campo no puede estar vacio");
                ConfirmarClaveTextBox.Focus();
                paso = true;
            }
            return paso;
        }


        private void BuscarButton_Click_1(object sender, EventArgs e)
        {
            int id;
            Usuario usuario = new Usuario();
            int.TryParse(IDNumericUpDown.Text, out id);
            Limpiar();
            usuario = UsuariosBll.Buscar(id);

            if (usuario != null)
            {
                MessageBox.Show("Usuario Encontrado");
                LlenaCampo(usuario);
            }
            else
            {
                MessageBox.Show("Usuario no Encontado");
            }
        }



        private void GuardarButton_Click_1(object sender, EventArgs e)
        {
            Usuario usuario;
            bool paso = false;

            if (Validar())
                return;

            usuario = LlenaClase();

            //Determinar si es guardar o modificar
            if (IDNumericUpDown.Value == 0)
                paso = UsuariosBll.Guardar(usuario);
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    MessageBox.Show("No se puede modificar una persona que no existe", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                paso = UsuariosBll.Modificar(usuario);
            }

            //Informar el resultado
            if (paso)
                MessageBox.Show("Guardado!!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No se pudo guardar!!", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Limpiar();
        }

        private bool ExisteEnLaBaseDeDatos()
        {
            Usuario usuario = UsuariosBll.Buscar((int)IDNumericUpDown.Value);

            return (usuario != null);
        }

        private void EliminarButton_Click_1(object sender, EventArgs e)
        {
            MyErrorProvider.Clear();
            int id;
            int.TryParse(IDNumericUpDown.Text, out id);

            if (!ExisteEnLaBaseDeDatos())
                return;
            if (UsuariosBll.Eliminar(id))
            {
                MessageBox.Show("Eliminado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpiar();
            }

            else
                MyErrorProvider.SetError(IDNumericUpDown, "No se puede eliminar una persona que no existe");
        }
    }
}
