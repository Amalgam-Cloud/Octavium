﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class SheetViewer : Form
    {
        List<string> sheet_lists;
        int current;
        public SheetViewer(string sheet_path, string sheet_name)
        {
            if(!InterfaceFuncs.IsSheetGenerated(sheet_path,sheet_name))
            {
                throw new System.IO.FileNotFoundException("Наш генератор не смог справиться с мощью ваших нот!");
            }
            sheet_lists = new List<string>();
            foreach(var list in System.IO.Directory.GetFiles(sheet_path))
            {
                if (list.Contains(sheet_name))
                {
                    sheet_lists.Add(list);
                }
            }
            sheet_lists.Sort();
            InitializeComponent();
            current = 0;
            Image img;
            using (var bmpTemp = new Bitmap(sheet_lists[current]))
                img = new Bitmap(bmpTemp);
            pictureBox1.BackgroundImage = img;
            pictureBox1.Height = img.Height;
            pictureBox1.Width = img.Width;
        }



        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (current < sheet_lists.Count - 1)
            {
                current++;
                pictureBox1.BackgroundImage = Image.FromFile(sheet_lists[current]);
            }

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (current > 0)
            {
                current--;
                pictureBox1.BackgroundImage = Image.FromFile(sheet_lists[current]);
            }
        }
    }
}
