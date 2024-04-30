using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication31
{


    public partial class Form1 : Form
    {


        private Stack<Node> stack;
        private HashSet<Node> visitedNodes;
        private bool dfsRunning;
        private Timer dfsTimer;

        public Form1()
        {
            InitializeComponent();
            resetGame();
            dfsTimer = new Timer();
            dfsTimer.Tick += new EventHandler(dfsTimer_Tick);
        }


        private void resetGame()
        {
            picwolf.Location = new Point(762, 312);
            picgoat.Location = new Point(914, 312);
            piccarrot.Location = new Point(838, 312);
            picship.Location = new Point(547, 413);

            picwolf.Show();
            picgoat.Show();
            piccarrot.Show();

            stack = new Stack<Node>();
            visitedNodes = new HashSet<Node>();
            stack.Push(new Node(picgoat.Location, picwolf.Location, piccarrot.Location, picship.Location));

            label1.Text = ".........";
            dfsRunning = false;
        }


        private void DepthFirstSearchStep()
        {
            if (stack.Count > 0)
            {
                Node currentNode = stack.Pop();



                picwolf.Location = currentNode.WolfPosition;
                picgoat.Location = currentNode.GoatPosition;
                piccarrot.Location = currentNode.CarrotPosition;
                picship.Location = currentNode.BoatPosition;


                if (currentNode.Equals(new Node(new Point(162, 312), new Point(10, 312), new Point(86, 312), new Point(270, 413))))
                {
                    label1.Text = "successfully done";
                    dfsRunning = false;
                    dfsTimer.Stop();
                    return;
                }

                visitedNodes.Add(currentNode);

                foreach (var successor in currentNode.GetSuccessorNodes())
                {
                    if (!visitedNodes.Contains(successor))
                    {
                        stack.Push(successor);
                    }
                }

                this.Refresh();

            }
            else
            {
                label1.Text = "No solution found";
                dfsRunning = false;
                dfsTimer.Stop();
            }
        }


        private void PerformNextDFSStep()
        {
            if (dfsRunning)
            {
                DepthFirstSearchStep();
            }
        }

        private void dfsTimer_Tick(object sender, EventArgs e)
        {
            PerformNextDFSStep();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            dfsRunning = true;
            dfsTimer.Start();
        }



        private void btnReset_Click(object sender, EventArgs e)
        {
            resetGame();
        }

        public void goatClick()
        {
            if (piccarrot.Location == new Point(616, 312)) { piccarrot.Location = new Point(838, 312); }
            if (picwolf.Location == new Point(616, 312)) { picwolf.Location = new Point(762, 312); }

            if (piccarrot.Location == new Point(335, 312)) { piccarrot.Location = new Point(86, 312); }
            if (picwolf.Location == new Point(335, 312)) { picwolf.Location = new Point(10, 312); }


            //اذا كان الماعز على الجزيرة الاولى
            if (picgoat.Location == new Point(914, 312) && picship.Location == new Point(547, 413))
            {
                picgoat.Location = new Point(616, 312);

            }
            //اذا كان الماعز على القارب من ناحية الجزيرة الثانية
            else if (picgoat.Location == new Point(335, 312))
            {
                picgoat.Location = new Point(162, 312);
                UpdateGameState();
            }
            //الماعز على الجزيرة الثانية
            else if (picgoat.Location == new Point(162, 312) && picship.Location == new Point(270, 413))
            {
                picgoat.Location = new Point(335, 312);



            }
            //اذا كان القارب على الضفة الاولى
            else if (picship.Location == new Point(547, 413) && picgoat.Location == new Point(616, 312))
            {
                picgoat.Location = new Point(914, 312);
            }
            this.Refresh();

        }

        public void carrotClick()
        {

            if (picgoat.Location == new Point(616, 312)) { picgoat.Location = new Point(914, 312); }
            if (picwolf.Location == new Point(616, 312)) { picwolf.Location = new Point(762, 312); }

            if (picgoat.Location == new Point(335, 312)) { picgoat.Location = new Point(162, 312); }
            if (picwolf.Location == new Point(335, 312)) { picwolf.Location = new Point(10, 312); }



            //اذا كان الجزر على الجزيرة الاولى
            if (piccarrot.Location == new Point(838, 312) && picship.Location == new Point(547, 413))
            {
                piccarrot.Location = new Point(616, 312);

            }
            //اذا كان الجزر على القارب من ناحية الجزيرة الثانية
            else if (piccarrot.Location == new Point(335, 312))
            {
                piccarrot.Location = new Point(86, 312);
                UpdateGameState();
                //

                //اذا كانت الجزرة على الضفة الثانية
            }
            else if (piccarrot.Location == new Point(86, 312) && picship.Location == new Point(270, 413))
            {
                piccarrot.Location = new Point(335, 312);
                UpdateGameState();


            }
            else if (picship.Location == new Point(547, 413) && piccarrot.Location == new Point(616, 312))
            {
                piccarrot.Location = new Point(838, 312);
            }
            this.Refresh();

        }


        public void wolfClick()
        {
            if (picgoat.Location == new Point(616, 312)) { picgoat.Location = new Point(914, 312); }
            if (piccarrot.Location == new Point(616, 312)) { piccarrot.Location = new Point(838, 312); }

            if (picgoat.Location == new Point(335, 312)) { picgoat.Location = new Point(162, 312); }
            if (piccarrot.Location == new Point(335, 312)) { piccarrot.Location = new Point(86, 312); }


            //اذا كان الذئب على الجزيرة الاولى
            if (picwolf.Location == new Point(762, 312) && picship.Location == new Point(547, 413))
            {
                picwolf.Location = new Point(616, 312);
            }
            ////اذا كان الذئب على القارب من ناحية الجزيرة الثانية
            else if (picwolf.Location == new Point(335, 312))
            {
                picwolf.Location = new Point(10, 312);
                UpdateGameState();
            }
            ////اذا كان الذئب على الجزيرة الثانية
            else if (picwolf.Location == new Point(10, 312) && picship.Location == new Point(270, 413))
            {
                picwolf.Location = new Point(335, 312);
                UpdateGameState();
            }

            else if (picship.Location == new Point(547, 413) && picwolf.Location == new Point(616, 312))
            {
                picwolf.Location = new Point(762, 312);
            }
            this.Refresh();

        }


        public void shipClick()
        {
            //من اليسار الى اليمين
            //تحريك الذئب مع القارب الى الضفة الثانية
            if (picwolf.Location == new Point(616, 312))
            {
                picship.Location = new Point(270, 413); picwolf.Location = new Point(335, 312);
            }
            ////تحرييك الجزر مع القارب الى الضفة الثانية
            else if (piccarrot.Location == new Point(616, 312))
            {
                picship.Location = new Point(270, 413); piccarrot.Location = new Point(335, 312);
            }
            //تحريك الماعز مع القارب الى الضفة الثانية
            else if (picgoat.Location == new Point(616, 312))
            {
                picship.Location = new Point(270, 413); picgoat.Location = new Point(335, 312);
            }

            //left to  right
            //wolf
            else if (picwolf.Location == new Point(335, 312))
            {
                picship.Location = new Point(547, 413); picwolf.Location = new Point(616, 312);
            }
            //carrot
            else if (piccarrot.Location == new Point(335, 312))
            {
                picship.Location = new Point(547, 413); piccarrot.Location = new Point(616, 312);
            }
            //goat
            else if (picgoat.Location == new Point(335, 312))
            {
                picship.Location = new Point(547, 413); picgoat.Location = new Point(616, 312);
            }



            else
            {
                picship.Location = new Point(547, 413);

            }

            this.Refresh();

        }

        public bool isWin()
        {
            return (picwolf.Location == new Point(10, 312) &&
                    picgoat.Location == new Point(162, 312) &&
                    piccarrot.Location == new Point(86, 312));
        }   

        public bool isLoss()
        {
            return (picwolf.Location.X == 10 && picgoat.Location.X == 162) ||
                   (picgoat.Location.X == 162 && piccarrot.Location.X == 86) ||
                   (picwolf.Location.X == 10 && picgoat.Location.X == 914 && piccarrot.Location.X == 838) ||
                   (picwolf.Location.X == 762 && picgoat.Location.X == 914 && piccarrot.Location.X == 86);
        }





        private void picgoat_Click(object sender, EventArgs e)
        {

            this.goatClick();

        }

        private void piccarrot_Click(object sender, EventArgs e)
        {
            this.carrotClick();


        }
        private void picwolf_Click(object sender, EventArgs e)
        {

            this.wolfClick();



        }

        private void picship_Click(object sender, EventArgs e)
        {
            this.shipClick();

        }



        private void UpdateGameState()
        {
            if (isWin())
            {
                label1.Text = "successfuly done";
            }
            else if (isLoss())
            {
                string message = "";
                if ((picwolf.Location.X == 10 && picgoat.Location.X == 162) ||
                    (picwolf.Location.X == 762 && picgoat.Location.X == 914 && piccarrot.Location.X == 86))
                {
                    message = "wolf devours the goat";
                }
                else if ((picgoat.Location.X == 162 && piccarrot.Location.X == 86) ||
                         (picwolf.Location.X == 10 && picgoat.Location.X == 914 && piccarrot.Location.X == 838))
                {
                    message = "goat eat carrot";
                }
                label1.Text = $"{message}، اضغط للاعادة";
                piccarrot.Hide();
                picgoat.Hide();
                picwolf.Hide();
            }
        }

  
        private void label1_Click(object sender, EventArgs e)
        {
            this.resetGame();
            label1.Text = ".........";
        }


    }
}
