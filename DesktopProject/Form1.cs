using DesktopProject.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace DesktopProject
{
    public partial class HomeForm : Form
    {
        private Point offset;
        private bool mouseDown;
        readonly HomeControl hc = new HomeControl();
        
        public HomeForm()
        {
            InitializeComponent();
            loadHomeControl();
        }

        private void loadHomeControl()
        {
            if (!panelControl.Controls.Contains(HomeControl.Inctance))
            {
                panelControl.Controls.Add(HomeControl.Inctance);
                HomeControl.Inctance.Dock = DockStyle.Fill;
                HomeControl.Inctance.BringToFront();
            }
            else
            {
                HomeControl.Inctance.BringToFront();
            }
        }

        private void btnSlide_Click(object sender, EventArgs e)
        {
            if (MenuVertical.Width == 250)
            {
                MenuVertical.Width = 45;
                
            }
            else
            {
                MenuVertical.Width = 250;
                
            }            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            btnRestore.Visible = true;
            btnMaximize.Visible = false;
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            btnRestore.Visible = false;
            btnMaximize.Visible = true;
        }

        private void NavBar_MouseMove(object sender, MouseEventArgs e)
        {
            if(mouseDown)
            {
                Point currentScreenPos = PointToScreen(e.Location);
                Location = new Point(currentScreenPos.X - offset.X, currentScreenPos.Y - offset.Y); 
            }
        }

        private void NavBar_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void BtnDashboard_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void NavBar_MouseDown(object sender, MouseEventArgs e)
        {
            offset.X = e.X;
            offset.Y = e.Y;
            mouseDown = true;
        }

        private void panelContent_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cartesianChart1_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {

        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            if (!panelControl.Controls.Contains(ProductControl.Inctance))
            {
                panelControl.Controls.Add(ProductControl.Inctance);
                ProductControl.Inctance.Dock = DockStyle.Fill;
                ProductControl.Inctance.BringToFront();
            }
            else
            {
                ProductControl.Inctance.BringToFront();
            }
        }

        private void Logo_Click(object sender, EventArgs e)
        {
            loadHomeControl();
        }

        private void HomeForm_Shown(object sender, EventArgs e)
        {
            
        }
    }
}
