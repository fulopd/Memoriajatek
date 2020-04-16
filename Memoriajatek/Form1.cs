using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Memoriajatek
{
    public partial class Form1 : Form
    {

        // A Random objektum fogja kiválasztani az ikonokat a cellákba
        Random random = new Random();

        // Mindegyik betű egy érdekes ikon
        // a Webdings font készletében
        // és mindegyik ikon kétszer szerepel a listában
        List<string> icons = new List<string>()
        {
            "j", "j", "Y", "Y", ",", ",", "!", "!",
            "-", "-", "#", "#", "$", "$", "b", "b"
        };

        
       
       
        public Form1()
        {
            InitializeComponent();
            AssignIconsToSquares();

        }




        /// <summary>
        /// Minden ikont hozzárendel egy véletlenszerű négyzethez
        /// </summary>
        private void AssignIconsToSquares()
        {
            // A TableLayoutPanel-nek 16 címkéje van,
            // és a listának 16 ikonja,
            // tehát véletlenszerűen mindegyik ikont hozzá kell adni
            // mindegyik címkéhez a nézetben
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                Label iconLabel = control as Label;
                if (iconLabel != null)
                {
                    int randomNumber = random.Next(icons.Count);
                    iconLabel.Text = icons[randomNumber];
                    iconLabel.ForeColor = iconLabel.BackColor;
                    icons.RemoveAt(randomNumber);
                }
            }
        }

        /// <summary>
        /// Minden címke Klikk eseményét kezeli
        /// </summary>
        /// <param name="sender">A címke, amire kattintottak</param>
        /// <param name="e"></param>
        private void label_Click(object sender, EventArgs e)
        {
            Label clickedLabel = sender as Label;

            if (clickedLabel != null)
            {
                // Ha a címke színe fekete, akkor a játékos már rákattintott
                // és az ikon is megjelent
                // így hagyja figyelmen kívül az utasítást
                if (clickedLabel.ForeColor == Color.Black)
                    return;

                clickedLabel.ForeColor = Color.Black;
            }
        }

    }
}
