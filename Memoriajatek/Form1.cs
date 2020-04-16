﻿using System;
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


        // firstClicked az elsőnek kiválasztott címkére fog mutatni 
        // amire a játékos klikkelt, de ennek értéke addig null 
        // amíg a játékos rá nem kattintott egy címkére
        Label firstClicked = null;

        // secondClicked a második címkére fog hivatkozni 
        // amire a játékos kattint
        Label secondClicked = null;

        


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

            
            // The stopper csak akkor működik, ha két nem egyező 
            // ikont jelenített meg a játékosnak,
            // addig minden klikkelést figyelmen kívül hagy
            if (timer1.Enabled == true)
                return;

            Label clickedLabel = sender as Label;

            if (clickedLabel != null)
            {
                // Ha a címke színe fekete, akkor a játékos már rákattintott
                // és az ikon is megjelent
                // így hagyja figyelmen kívül az utasítást
                if (clickedLabel.ForeColor == Color.Black)
                    return;

                // Ha a firstClicked értéke null, akkor ez az első ikon 
                // a párok közül, amit a játékos választott ki,
                // így a firstClicked a kiválasztott címkével lesz egyenlő 
                // a szöveg színe fekete lesz, majd visszatér
                if (firstClicked == null)
                {
                    firstClicked = clickedLabel;
                    firstClicked.ForeColor = Color.Black;

                    return;
                }

                // Ha a stopper még nem indult el
                // és a firstClicked értéke nem null,
                // így a második ikonnak, amire a játékos klikkelt
                // a színe fekete lesz
                secondClicked = clickedLabel;
                secondClicked.ForeColor = Color.Black;

                // Ha a játékos két különböző ikonra kattint,
                // akkor indítsa el a Stopper időmérését 
                // (várni fog háromnegyed másodpercet 
                // azután elrejti az ikonokat)
                timer1.Start();
            

            }

        }
        /// <summary>
        /// Az stopper elindul, ha a játékos
        /// két ikonra klikkel, amik nem egyeznek meg,
        /// addig elszámol háromnegyed másodpercig,
        /// majd leáll és elrejti mindkét ikont
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            // Megállítja a stoppert
            timer1.Stop();

            // Elrejti mindkét ikont
            firstClicked.ForeColor = firstClicked.BackColor;
            secondClicked.ForeColor = secondClicked.BackColor;

            // Visszaállítja a firstClicked és secondClicked 
            // értékét, így legközelebb ha címkére kattint,
            // akkor tudja majd a program, hogy ez lesz az első kattintás
            firstClicked = null;
            secondClicked = null;
        }








    }
}
