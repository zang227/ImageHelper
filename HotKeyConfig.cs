using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageHelper
{
    public partial class HotKeyConfig : Form
    {
        // Scaling, Next Directory, Previous Directory, Move Directory, Next Image, Previous Image, 1, 2, 3, 4, 5, 6
        public Button[] buttons;
        public String[] Hotkeys = { "q", "w", "s", "e", "d", "a", "1", "2", "3", "4", "5", "6", "x"};
        public HotKeyConfig()
        {
            InitializeComponent();
            buttons = new Button[]{btn0,btn1,btn2,btn3,btn4,btn5,btn6,btn7,btn8,btn9,btn10,btn11,btn12};
            for(int i = 0; i < buttons.Length; i++)
            {
                buttons[i].Click += BTNRename;
            }


        }

        private void HotKeyListener(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            var button = ((Button)sender);
            int index = ButtonIndex(button);
            button.Text = e.KeyChar.ToString().ToUpper();
            Hotkeys[index] = e.KeyChar.ToString();
            for (int i = 0; i < buttons.Length; i++)
            {
                if (i != index)
                    if (button.Text == buttons[i].Text)
                    {
                        buttons[i].Text = "";
                        Hotkeys[i] = "";
                    } 
            }
            button.KeyPress -= HotKeyListener;
            ButtonLock(-1);

        }

        public void BTNRename(object sender, EventArgs e)
        {
            int index = ButtonIndex((Button)sender);
            if(index > -1)
            {
                ButtonLock(index);
                buttons[index].Text = "Press any key...";
                buttons[index].KeyPress += HotKeyListener;
            }
            
        }

        public int ButtonIndex(Button b)
        {
            for(int i = 0; i < buttons.Length; i++)
            {
                if (b.Name == buttons[i].Name)
                    return i;
            }
            return -1;
        }

        public void ButtonLock(int index)//Send -1 index to unlock buttons
        {
            if(index > -1)
            {
                for (int i = 0; i < buttons.Length; i++)
                {
                    if (i != index)
                    {
                        buttons[i].Enabled = false;
                    }
                }
            }
            else
            {
                for (int i = 0; i < buttons.Length; i++)
                {
                        buttons[i].Enabled = true;
                }
            }
        }

    }
}
