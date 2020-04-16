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
        }
    }
}
