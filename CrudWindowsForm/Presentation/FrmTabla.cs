using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrudWindowsForm.Models;

namespace CrudWindowsForm.Presentation
{
    public partial class FrmTabla : Form
    {

        public int? id;
        tabla oTabla = null;

        public FrmTabla(int? id = null)
        {
            InitializeComponent();

            this.id = id;
            if (id != null)
            {
                CargaDatos();
            }
        }

        private void CargaDatos()
        {
            using (CrudWindowsFormEntities db = new CrudWindowsFormEntities())
            {
                oTabla = db.tabla.Find(id);
                textboxNombre.Text = oTabla.nombre;
                textboxCorreo.Text = oTabla.correo;
                textboxFecha.Value = oTabla.fecha_nacimiento;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (CrudWindowsFormEntities db = new CrudWindowsFormEntities())
            {
                if (id == null)
                    oTabla = new tabla();

                oTabla.nombre = textboxNombre.Text;
                oTabla.correo = textboxCorreo.Text;
                oTabla.fecha_nacimiento = textboxFecha.Value;

                if (id == null)
                    db.tabla.Add(oTabla);
                else
                {
                    db.Entry(oTabla).State = System.Data.Entity.EntityState.Modified;
                }

                db.SaveChanges();

                this.Close();
            }
        }
    }
}
