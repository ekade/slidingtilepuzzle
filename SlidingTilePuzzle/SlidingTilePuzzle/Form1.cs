using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SlidingTilePuzzle
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        #region Events

        private void button1_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            MoveTile(button);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            MoveTile(button);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            MoveTile(button);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            MoveTile(button);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            MoveTile(button);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            MoveTile(button);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            MoveTile(button);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            MoveTile(button);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                button1.Parent = tbLayout.GetControlFromPosition(0, 0);
                button2.Parent = tbLayout.GetControlFromPosition(1, 0);
                button3.Parent = tbLayout.GetControlFromPosition(2, 0);

                button4.Parent = tbLayout.GetControlFromPosition(0, 1);
                button5.Parent = tbLayout.GetControlFromPosition(2, 1);

                button6.Parent = tbLayout.GetControlFromPosition(0, 2);
                button7.Parent = tbLayout.GetControlFromPosition(1, 2);
                button8.Parent = tbLayout.GetControlFromPosition(2, 2);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRandom_Click(object sender, EventArgs e)
        {
            try
            {
                var usedNumbers = new List<int>();
                int number = GetRandomNumber(usedNumbers);

                Controls.Find("button" + number, true).First().Parent = tbLayout.GetControlFromPosition(0, 0);
                usedNumbers.Add(number);
                number = GetRandomNumber(usedNumbers);

                Controls.Find("button" + number, true).First().Parent = tbLayout.GetControlFromPosition(1, 0);
                usedNumbers.Add(number);
                number = GetRandomNumber(usedNumbers);

                Controls.Find("button" + number, true).First().Parent = tbLayout.GetControlFromPosition(2, 0);
                usedNumbers.Add(number);
                number = GetRandomNumber(usedNumbers);

                Controls.Find("button" + number, true).First().Parent = tbLayout.GetControlFromPosition(0, 1);
                usedNumbers.Add(number);
                number = GetRandomNumber(usedNumbers);

                Controls.Find("button" + number, true).First().Parent = tbLayout.GetControlFromPosition(2, 1);
                usedNumbers.Add(number);
                number = GetRandomNumber(usedNumbers);

                Controls.Find("button" + number, true).First().Parent = tbLayout.GetControlFromPosition(0, 2);
                usedNumbers.Add(number);
                number = GetRandomNumber(usedNumbers);

                Controls.Find("button" + number, true).First().Parent = tbLayout.GetControlFromPosition(1, 2);
                usedNumbers.Add(number);
                number = GetRandomNumber(usedNumbers);

                Controls.Find("button" + number, true).First().Parent = tbLayout.GetControlFromPosition(2, 2);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region Private Methods

        private void MoveTile(Button tile)
        {
            try
            {
                var tilePosition = tbLayout.GetCellPosition(tile.Parent);

                if (tilePosition.Row + 1 < tbLayout.RowCount && IsThereGap(tilePosition.Row + 1, tilePosition.Column))
                    tile.Parent = tbLayout.GetControlFromPosition(tilePosition.Column, tilePosition.Row + 1);

                if (tilePosition.Row - 1 >= 0 && IsThereGap(tilePosition.Row - 1, tilePosition.Column))
                    tile.Parent = tbLayout.GetControlFromPosition(tilePosition.Column, tilePosition.Row - 1);

                if (tilePosition.Column - 1 >= 0 && IsThereGap(tilePosition.Row, tilePosition.Column - 1))
                    tile.Parent = tbLayout.GetControlFromPosition(tilePosition.Column - 1, tilePosition.Row);

                if (tilePosition.Column + 1 < tbLayout.ColumnCount && IsThereGap(tilePosition.Row, tilePosition.Column + 1))
                    tile.Parent = tbLayout.GetControlFromPosition(tilePosition.Column + 1, tilePosition.Row);

                tile.BringToFront();
                tbLayout.Update();

                if (GameWon())
                    MessageBox.Show("¡¡ Conseguido !!", "Fin");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Movimiento no permitido");
            }
        }

        private bool IsThereGap(int row, int column)
        {
            var control = tbLayout.GetControlFromPosition(column, row);
            return control.Controls.Count == 0;
        }

        private bool GameWon()
        {
            var gameWon = button1.Parent == tbLayout.GetControlFromPosition(0, 0)
                && button2.Parent == tbLayout.GetControlFromPosition(1, 0)
                && button3.Parent == tbLayout.GetControlFromPosition(2, 0)

                && button4.Parent == tbLayout.GetControlFromPosition(0, 1)
                && button5.Parent == tbLayout.GetControlFromPosition(2, 1)

                && button6.Parent == tbLayout.GetControlFromPosition(0, 2)
                && button7.Parent == tbLayout.GetControlFromPosition(1, 2)
                && button8.Parent == tbLayout.GetControlFromPosition(2, 2);

            return gameWon;
        }

        private int GetRandomNumber(List<int> excludedNumbers)
        {
            Random rnd = new Random();

            int number = rnd.Next(1, 9);

            while (excludedNumbers.Contains(number))
                number = rnd.Next(1, 9);

            return number;
        }

        #endregion
    }
}
