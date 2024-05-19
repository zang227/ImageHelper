using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ImageHelper
{
    public partial class HotKeyConfig : Form
    {
        public readonly List<Button> _buttons;
        public string[] Hotkeys { get; private set; } = { "q", "w", "s", "e", "d", "a", "1", "2", "3", "4", "5", "6", "x", "u" };

        public HotKeyConfig()
        {
            InitializeComponent();
            _buttons = new List<Button> { btn0, btn1, btn2, btn3, btn4, btn5, btn6, btn7, btn8, btn9, btn10, btn11, btn12, btn13 };
            _buttons.ForEach(button => button.Click += RenameButton);
        }

        private void RenameButton(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                int index = _buttons.IndexOf(button);
                if (index >= 0)
                {
                    LockButtons(index);
                    button.Text = "Press any key...";
                    button.KeyPress += HotKeyListener;
                }
            }
        }

        private void HotKeyListener(object sender, KeyPressEventArgs e)
        {
            if (sender is Button button)
            {
                int index = _buttons.IndexOf(button);
                button.Text = e.KeyChar.ToString().ToUpper();
                Hotkeys[index] = e.KeyChar.ToString();

                for (int i = 0; i < _buttons.Count; i++)
                {
                    if (i != index && button.Text == _buttons[i].Text)
                    {
                        _buttons[i].Text = string.Empty;
                        Hotkeys[i] = string.Empty;
                    }
                }

                button.KeyPress -= HotKeyListener;
                LockButtons(-1);
            }
        }

        private void LockButtons(int index)
        {
            _buttons.ForEach(button => button.Enabled = index < 0 || _buttons.IndexOf(button) == index);
        }
    }
}
