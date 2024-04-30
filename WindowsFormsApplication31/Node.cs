using System;   
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication31
{
    public class Node
    {
        public Point GoatPosition { get; }
        public Point WolfPosition { get; }
        public Point CarrotPosition { get; }
        public Point BoatPosition { get; }

        public Node(Point goat, Point wolf, Point carrot, Point boat)
        {
            GoatPosition = goat;
            WolfPosition = wolf;
            CarrotPosition = carrot;
            BoatPosition = boat;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Node other = (Node)obj;
            return GoatPosition.Equals(other.GoatPosition) &&
                   WolfPosition.Equals(other.WolfPosition) &&
                   CarrotPosition.Equals(other.CarrotPosition) &&
                   BoatPosition.Equals(other.BoatPosition);
        }


        public List<Node> GetSuccessorNodes()
        {
            var successorNodes = new List<Node>();

            var possibleBoatMoves = new List<Point> { new Point(547, 413), new Point(270, 413) };

            var goatMoves = new List<Point> { new Point(616, 312), new Point(914, 312), new Point(162, 312) };
            var wolfMoves = new List<Point> { new Point(616, 312), new Point(762, 312), new Point(10, 312) };
            var carrotMoves = new List<Point> { new Point(616, 312), new Point(838, 312), new Point(86, 312) };

            foreach (var boatMove in possibleBoatMoves)
            {
                foreach (var goatMove in goatMoves)
                {
                    foreach (var wolfMove in wolfMoves)
                    {
                        foreach (var carrotMove in carrotMoves)
                        {
                            if (IsValidMove(goatMove, wolfMove, carrotMove, boatMove))
                            {
                                var successorNode = new Node(goatMove, wolfMove, carrotMove, boatMove);

                                successorNodes.Add(successorNode);
                            }
                        }
                    }
                }
            }

            return successorNodes;
        }

        private bool IsValidMove(Point goatPos, Point wolfPos, Point carrotPos, Point boatPos)
        {
            if ((boatPos.X != 547 && boatPos.X != 270) || boatPos.Y != 413)
            {
                return false;
            }

            if ((goatPos == wolfPos && goatPos != boatPos) ||
                (goatPos == carrotPos && goatPos != boatPos))
            {
                return false;
            }

            if (goatPos.X < 0 || goatPos.Y < 0 ||
                wolfPos.X < 0 || wolfPos.Y < 0 ||
                carrotPos.X < 0 || carrotPos.Y < 0 ||
                boatPos.X < 0 || boatPos.Y < 0 ||
                goatPos.X > 1024 || goatPos.Y > 768 ||
                wolfPos.X > 1024 || wolfPos.Y > 768 ||
                carrotPos.X > 1024 || carrotPos.Y > 768 ||
                boatPos.X > 1024 || boatPos.Y > 768)
            {
                return false;
            }


            return true;
        }






    }
}
