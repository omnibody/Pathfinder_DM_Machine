﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pathfinder
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            
            InitializeComponent(); 
            
        }

        private void Form1_Load()
        {
            // Creating and setting the properties of Button 
            Button Mybutton = new Button();
            Mybutton.Name = "Mybutton";
            Mybutton.Location = new Point(100, 100);
            Mybutton.Text = "Submit";
            Mybutton.AutoSize = true;
            Mybutton.BackColor = Color.Black;
            Mybutton.ForeColor = Color.White;
            Mybutton.Padding = new Padding(6);

            // Adding this button to form 
            Controls.Add(Mybutton);
        }

    }
}
