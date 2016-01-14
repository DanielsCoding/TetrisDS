using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TetrisVersuch2
{
    public partial class Form01 : Form
    {
        TetrisPanel[,] panelArray = new TetrisPanel[25, 15];
        TetrisPanel[,] panelArrayVorschau = new TetrisPanel[2, 4];
        BlockItem block = new BlockItem();
        BlockItem neuerBlock = new BlockItem();
        List<int> werte = new List<int>();
        int i;
        int s;

        public Form01()
        {
            InitializeComponent();
            AddPanels();
            CreateNewBlockOnStartPosition();
        }

        private void CreateNewBlockOnStartPosition()
        {
            neuerBlock = GameHelper.GetBlockItem();
            block = GameHelper.GetBlockItem();

            UpdateGui();
        }

        private void UpdateGui()
        {

            if (Convert.ToInt32(labelAusgabePunkte.Text) >= 50000)
            {
                timer1.Interval = 999999999;
                int a = Convert.ToInt32(labelAusgabePunkte.Text);
                int b = a / 150;
                int level = (b / 7) + 1;

                var c = MessageBox.Show("Highscore! Herzlichen Glückwunsch! Sie haben den Highscore mit " + labelAusgabePunkte.Text + " Punkten und " + b + " Reihen erreicht.  Wollen Sie neu Starten?", "HIGHSCORE/NEU START?", MessageBoxButtons.YesNo);
                if (c == System.Windows.Forms.DialogResult.Yes)
                {
                    Application.Restart();
                }
                else if (c == System.Windows.Forms.DialogResult.No)
                {
                    Environment.Exit(0);
                }
            }
            #region löschenVolleReihe

            int? isfulli = null;

            for (int i = 0; i < 25; i++)
            {
                var fullColumnCount = 0;

                for (int j = 0; j < 15; j++)
                {
                    if (panelArray[i, j].IsFix)
                    {
                        fullColumnCount += 1;
                    }
                }

                if (fullColumnCount == 15)
                {
                    isfulli = i;
                    break;
                }

            }

            if (isfulli.HasValue)
            {
                for (int j = 0; j < 15; j++)
                {
                    panelArray[isfulli.Value, j].IsFix = false;
                    panelArray[isfulli.Value, j].BackColor = Color.Black;
                    i = Convert.ToInt32(labelAusgabePunkte.Text);
                    labelAusgabePunkte.Text = Convert.ToString(RechnenPunkte(i));
                }

                for (int i = isfulli.Value - 1; i >= 0; i--)
                {
                    for (int j = 0; j < 15; j++)
                    {
                        if (panelArray[i, j].IsFix)
                        {
                            panelArray[i + 1, j].IsFix = true;
                            panelArray[i + 1, j].BackColor = panelArray[i, j].BackColor;

                            panelArray[i, j].IsFix = false;
                            panelArray[i, j].BackColor = Color.Black;
                        }

                    }
                }
            }

            #endregion

            var blockPistiionX = block.X;
            var blockPistiionY = block.Y;

            var canMoveDown = true;

            foreach (var item in block.BlockList)
            {
                var nextStep = item.Y + block.Y;

                if (nextStep == 24)
                {
                    var y = block.Y + item.Y;
                    var x = block.X + item.X;

                    canMoveDown = false;
                }
            }

            var maxValueLinq = block.BlockList.Max(x => x.Y);
            var bottomBlocks = block.BlockList.Where(x => x.Y == maxValueLinq).ToList();

            foreach (var bottomsBlockItem in bottomBlocks)
            {
                var yValue = bottomsBlockItem.Y + block.Y;
                var xValue = bottomsBlockItem.X + block.X;

                if (yValue + 1 < 25)
                {
                    if (panelArray[bottomsBlockItem.Y + block.Y + 1, bottomsBlockItem.X + block.X].IsFix)
                    {
                        canMoveDown = false;
                    }
                    else if (panelArray[bottomsBlockItem.Y + block.Y, bottomsBlockItem.X + block.X].IsFix)
                    {
                        canMoveDown = false;
                    }
                }

            }

            if (!canMoveDown)
            {
                foreach (var item in block.BlockList)
                {
                    if (block.Y + item.Y < 0)
                    {
                        timer1.Interval = 999999999;
                        int a = Convert.ToInt32(labelAusgabePunkte.Text);
                        int b = a / 150;
                        int level = (b / 7) + 1;

                        var c = MessageBox.Show("GAME OVER! Punkte: " + labelAusgabePunkte.Text + "/50.000  Reihen: " + b + "/333  Level: " + level + "/48  Wollen Sie neu Starten?", "GAME OVER/NEU START?", MessageBoxButtons.YesNo);
                        if (c == System.Windows.Forms.DialogResult.Yes)
                        {
                            Application.Restart();
                            break;
                        }
                        else if (c == System.Windows.Forms.DialogResult.No)
                        {
                            Environment.Exit(0);
                        }

                    }

                    var y = block.Y + item.Y;
                    var x = block.X + item.X;

                    panelArray[y, x].IsFix = true;
                    panelArray[y, x].BackColor = item.Color;

                }
            }
            else
            {
                foreach (var newItem in block.BlockList)
                {
                    #region Startposition

                    var y = block.Y + newItem.Y;
                    var x = block.X + newItem.X;

                    if (y > 24)
                    {
                        y = 24;
                        panelArray[y, x].IsFix = true;
                    }
                    if (y == -1)   //das ist wegen der start position
                    {
                        y = y + 1;
                    }
                    if (x == -1)
                    {
                        x = x + 1;
                    }

                    #endregion

                    panelArray[y, x].BackColor = newItem.Color;
                }

                foreach (var newItem in neuerBlock.BlockList)
                {
                    #region neuerBlockZeichnen

                    var y = newItem.Y + 1;
                    var x = newItem.X + 1;

                    if (neuerBlock.BlockType == BlockType.LBlockLeft)
                    {
                        x += 1;
                    }

                    #endregion

                    panelArrayVorschau[y, x].BackColor = newItem.Color;
                }
            }
        }

        public void AddPanels()
        {
            for (int i = 0; i < 25; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    var currentPanel = new TetrisPanel();
                    currentPanel.IsFix = false;
                    currentPanel.Width = 20;
                    currentPanel.Height = 20;
                    currentPanel.BackColor = Color.Black;
                    currentPanel.Margin = new Padding(1);

                    ToolTip toolTip1 = new ToolTip();

                    toolTip1.AutoPopDelay = 5000;
                    toolTip1.InitialDelay = 1000;
                    toolTip1.ReshowDelay = 500;
                    toolTip1.ShowAlways = true;

                    // Set up the ToolTip text for the Button and Checkbox.
                    toolTip1.SetToolTip(currentPanel, i + ":" + j);

                    panelArray[i, j] = currentPanel;        //i = x und j = y
                    tableLayoutPanel1.Controls.Add(panelArray[i, j]);
                }
            }

            for (int a = 0; a < 2; a++)
            {
                for (int b = 0; b < 4; b++)
                {
                    var currentPanel = new TetrisPanel();
                    currentPanel.IsFix = false;
                    currentPanel.Width = 20;
                    currentPanel.Height = 20;
                    currentPanel.BackColor = Color.Black;
                    currentPanel.Margin = new Padding(1);

                    ToolTip toolTip2 = new ToolTip();

                    toolTip2.AutoPopDelay = 5000;
                    toolTip2.InitialDelay = 1000;
                    toolTip2.ReshowDelay = 500;
                    toolTip2.ShowAlways = true;

                    toolTip2.SetToolTip(currentPanel, a + ":" + b);

                    panelArrayVorschau[a, b] = currentPanel;
                    tableLayoutPanelVorschau.Controls.Add(panelArrayVorschau[a, b]);
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Interval = 200;

            ResetGui();

            #region ausprogrammierter Weg
            //var maxValue = 0;

            //foreach (var item in block.BlockList)
            //{
            //    if (maxValue < item.Y)
            //    {
            //        maxValue = item.Y;
            //    }
            //}
            #endregion

            var maxValueLinq = block.BlockList.Max(x => x.Y);


            var maxValueOnField = maxValueLinq + block.Y;
            var bottomBlocks = block.BlockList.Where(x => x.Y == maxValueLinq).ToList();
            var canMoveDown = true;

            foreach (var bottomsBlockItem in bottomBlocks)
            {
                var yValue = bottomsBlockItem.Y + block.Y;
                var xValue = bottomsBlockItem.X + block.X;

                if (yValue + 1 < 25)
                {
                    if (panelArray[bottomsBlockItem.Y + block.Y + 1, bottomsBlockItem.X + block.X].IsFix)
                    {
                        canMoveDown = false;
                    }
                    else if (panelArray[bottomsBlockItem.Y + block.Y, bottomsBlockItem.X + block.X].IsFix)
                    {
                        canMoveDown = false;
                    }
                }
            }

            if (maxValueOnField < 24 && canMoveDown)
            {
                block.Y += 1; // <----------------------------------------------------------------------------------------  hier wird y + 1 gemacht(nach unten bewegt)
            }
            else
            {
                block = neuerBlock; //<---------------------------------------------- hier wird dem block, der block der Vorschau (unten rechts)zugewiesen
                neuerBlock = GameHelper.GetBlockItem();
            }

            UpdateGui();

            this.Invalidate();
        }

        private void ResetGui()
        {
            if (block.Y < 24)
            {
                for (int i = 0; i < 15; i++)
                {
                    for (int j = 0; j < 25; j++)
                    {
                        if (!panelArray[j, i].IsFix)
                        {
                            panelArray[j, i].BackColor = Color.Black;
                        }

                    }
                }
            }
            if (neuerBlock.Y < 4)
            {
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        if (!panelArrayVorschau[j, i].IsFix)
                        {
                            panelArrayVorschau[j, i].BackColor = Color.Black;
                        }

                    }
                }
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            var mainItem = block.BlockList.First(x => x.MainItem);

            var leftexists = block.BlockList.Any(x => x.X == mainItem.X - 1);
            var zweiLeftexists = block.BlockList.Any(x => x.X == mainItem.X - 2);
            var rightexists = block.BlockList.Any(x => x.X == mainItem.X + 1);
            var zweirightexists = block.BlockList.Any(x => x.X == mainItem.X + 2);


            if (!block.BlockList.Any(x => x.Y + block.Y <0))
            {
                
         

            #region keinerLinks
            if (e.KeyCode == Keys.Left && leftexists == false)
            {
                var minRightValue = block.BlockList.Min(x => x.X);

                var listMinItems = block.BlockList.Where(x => x.X == minRightValue);

                var myList = new List<Block>();

                //transofrmieren auf Spieleld
                foreach (var item in listMinItems)
                {
                    myList.Add(new Block
                    {
                        X = item.X + block.X,
                        Y = item.Y + block.Y
                    });

                }

                //prüfen ob links was da ist
                var canMoveLeft = true;

                foreach (var item in myList)
                {
                    int leftPostion;
                    if (item.X < 0)
                    {
                        leftPostion = item.X - 1;
                    }
                    else
                    {
                        leftPostion = item.X;
                    }
                  
                    if (panelArray[item.Y, leftPostion].IsFix)   // hier sagt es der y wert ist zu niedrig (bei -1) ist iwas mit dem item.Y flasch glaube ich
                    {
                        canMoveLeft = false;
                    }
                }

                if (canMoveLeft)
                {
                    if ((block.X - mainItem.X) > 0)
                    {
                        block.X = block.X - 1;
                    }
                }
            }
            #endregion

            #region einerLinks
            if (e.KeyCode == Keys.Left && leftexists == true && zweiLeftexists == false)
            {
                var minRightValue = block.BlockList.Min(x => x.X);

                var listMinItems = block.BlockList.Where(x => x.X == minRightValue);

                var myList = new List<Block>();

                //transofrmieren auf Spieleld
                foreach (var item in listMinItems)
                {
                    myList.Add(new Block
                    {
                        X = item.X + block.X,
                        Y = item.Y + block.Y + 1
                    });

                }

                //prüfen ob links was da ist
                var canMoveLeft = true;

                foreach (var item in myList)
                {

                    int leftPostion;
                    if (item.X < 0)
                    {
                        leftPostion = item.X - 1;
                    }
                    else
                    {
                        leftPostion = item.X;
                    }
                 
                    if (panelArray[item.Y, leftPostion].IsFix)
                    {
                        canMoveLeft = false;
                    }
                }

                if (canMoveLeft)
                {
                    if ((block.X - mainItem.X) > 1)
                    {
                        block.X = block.X - 1;
                    }
                }
            }
            #endregion             

            #region zweiLinks
            if (e.KeyCode == Keys.Left && zweiLeftexists == true)
            {
                var minRightValue = block.BlockList.Min(x => x.X);

                var listMinItems = block.BlockList.Where(x => x.X == minRightValue);

                var myList = new List<Block>();

                //transofrmieren auf Spieleld
                foreach (var item in listMinItems)
                {
                    myList.Add(new Block
                    {
                        X = item.X + block.X,
                        Y = item.Y + block.Y
                    });

                }

                //prüfen ob links was da ist
                var canMoveLeft = true;

                foreach (var item in myList)
                {
                    int leftPostion;
                    if (item.X < 0)
                    {
                        leftPostion = item.X - 1;
                    }
                    else
                    {
                        leftPostion = item.X;
                    }
 
                    if (panelArray[item.Y, leftPostion].IsFix)
                    {
                        canMoveLeft = false;
                    }
                }

                if (canMoveLeft)
                {
                    if ((block.X - mainItem.X) > 3)
                    {
                        block.X = block.X - 1;
                    }
                }
            }
            #endregion

            #region keinerRechts
            if (e.KeyCode == Keys.Right && rightexists == false)
            {
                var maxRightValue = block.BlockList.Max(x => x.X);

                var listMaxItems = block.BlockList.Where(x => x.X == maxRightValue);

                var myList = new List<Block>();

                //transofrmieren auf Spieleld
                foreach (var item in listMaxItems)
                {
                    myList.Add(new Block
                    {
                        X = item.X + block.X,
                        Y = item.Y + block.Y
                    });

                }

                //prüfen ob rechts was da ist
                var canMoveRight = true;

                foreach (var item in myList)
                {
                    int rightPostion;
                    if (item.X < 14)
                    {
                        rightPostion = item.X + 1;
                    }
                    else
                    {
                        rightPostion = item.X;
                    }

                    if (panelArray[item.Y, rightPostion].IsFix)
                    {
                        canMoveRight = false;
                    }
                }

                if (canMoveRight)
                {
                    if ((block.X + mainItem.X) < 14)
                    {
                        block.X = block.X + 1;
                    }
                }
            }
            #endregion

            #region einerRechts
            if (e.KeyCode == Keys.Right && rightexists == true && zweirightexists == false)
            {
                var maxRightValue = block.BlockList.Max(x => x.X);

                var listMaxItems = block.BlockList.Where(x => x.X == maxRightValue);

                var myList = new List<Block>();

                //transofrmieren auf Spieleld
                foreach (var item in listMaxItems)
                {
                    myList.Add(new Block
                    {
                        X = item.X + block.X,
                        Y = item.Y + block.Y
                    });


                }
                //prüfen ob rechts was da ist
                var canMoveRight = true;

                foreach (var item in myList)
                {
                    int rightPostion;
                    if (item.X < 14)
                    {
                        rightPostion = item.X + 1;
                    }
                    else
                    {
                        rightPostion = item.X;
                    }

                    if (panelArray[item.Y, rightPostion].IsFix)
                    {
                        canMoveRight = false;
                    }
                }

                if (canMoveRight)
                {
                    if ((block.X + mainItem.X) < 13)
                    {
                        block.X = block.X + 1;
                    }
                }
            }
            #endregion

            #region zweiRechts
            if (e.KeyCode == Keys.Right && zweirightexists == true)
            {
                var maxRightValue = block.BlockList.Max(x => x.X);

                var listMaxItems = block.BlockList.Where(x => x.X == maxRightValue);

                var myList = new List<Block>();

                //transofrmieren auf Spieleld
                foreach (var item in listMaxItems)
                {
                    myList.Add(new Block
                    {
                        X = item.X + block.X,
                        Y = item.Y + block.Y
                    });

                }

                //prüfen ob rechts was da ist
                var canMoveRight = true;

                foreach (var item in myList)
                {
                    int rightPostion;
                    if (item.X < 14)
                    {
                        rightPostion = item.X + 1;
                    }
                    else
                    {
                        rightPostion = item.X;
                    }
                  

                    if (panelArray[item.Y, rightPostion].IsFix)
                    {
                        canMoveRight = false;
                    }
                }

                if (canMoveRight)
                {
                    if ((block.X + mainItem.X) < 12)
                    {
                        block.X = block.X + 1;
                    }
                }
            }
            #endregion


            }
            if (e.KeyCode == Keys.Down)
            {
                timer1.Enabled = true;
                timer1.Interval = 15;
            }

            if (e.KeyCode == Keys.A)
            {
                //Rotation
                if (block.BlockType == BlockType.DiceBlock || block.X > 13 || block.X < 2 || block.BlockType == BlockType.IBlock && block.X > 12 || block.BlockType == BlockType.LBlockLeft && block.X > 12 || block.BlockType == BlockType.LBlockRight && block.X > 12) // -> damit es nicht gedreht werden kann wenn der x wert zu hoch bzw zu niedrig ist
                {
                    //mach nichts, da dieser Block sich nicht dreht
                }
                else
                {
                    var nextDirection = GameHelper.GetNextDirection(block.Direction);

                    var newBlock = GameHelper.GetBlockByTypeAndDirection(block.BlockType, nextDirection);

                    newBlock.X = block.X;
                    newBlock.Y = block.Y;
                    block = newBlock;
                }
            }

            #region CheatjfF
            if (e.KeyCode == Keys.VolumeMute && block.BlockType == BlockType.DiceBlock)
            {
                if (s == 0)
                {
                    MessageBox.Show("Cheat Aktiviert! (PunkteBonus)");
                    int a = Convert.ToInt32(labelAusgabePunkte.Text);
                    int b = a + 600;
                    labelAusgabePunkte.Text = Convert.ToString(b);
                    s++;
                }
                else
                {
                    int a = Convert.ToInt32(labelAusgabePunkte.Text);
                    int b = a + 600;
                    labelAusgabePunkte.Text = Convert.ToString(b);
                    s++;
                }
            }
            if (e.KeyCode == Keys.C)
            {
                i++;
                if (i == 1)
                {
                    tableLayoutPanel1.BackColor = Color.GreenYellow;
                }
                else if (i == 2)
                {
                    tableLayoutPanel1.BackColor = Color.Blue;
                }
                else if (i == 3)
                {
                    tableLayoutPanel1.BackColor = Color.HotPink;
                }
                else if (i == 4)
                {
                    tableLayoutPanel1.BackColor = Color.OrangeRed;
                }
                else if (i == 5)
                {
                    tableLayoutPanel1.BackColor = Color.Gold;
                }
                else if (i == 6)
                {
                    tableLayoutPanel1.BackColor = Color.DarkOrchid;
                }
                else
                {
                    tableLayoutPanel1.BackColor = tableLayoutPanel1.ForeColor;
                    i = i - 7;
                }
            }
            #endregion
        }

        private int RechnenPunkte(int i)
        {
            return i + 10;
        }
    }
}
