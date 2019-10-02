using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Udvoitel
{
	//Владимир Яшин
    static class Game
    {
        public static Udvoitel form;
        static int score = -1;
        static int turns = -1;
        static int targetScore;
        static List<int> turnlist; //история всех ходов

        public static void Launch()
        {
            form = new Udvoitel();
            Application.Run(form);
        }
        public static void Restart()
        {
            score = 0;
            turns = 0;
            Random rand = new Random();
            targetScore = rand.Next(100);
            UpdateInformers();
            form.pictureFail.Visible = false;
            form.pictureWin.Visible = false;
            turnlist = new List<int>();
        }

        static void UpdateInformers()
        {
            form.labelScore.Text = score.ToString();
            form.labelTarget.Text = targetScore.ToString() + " очков";
            form.labelTurns.Text = turns.ToString();
        }

        public static void Plus()
        {
            if (score == -1) return;
            turnlist.Add(score);
            score++;
            turns++;
            UpdateInformers();
            if (score == targetScore) Win();
            else if (score > targetScore) Lose();
        }

        public static void Mult()
        {
            if (score == -1) return;
            turnlist.Add(score);
            score *= 2;
            turns++;
            UpdateInformers();
            if (score == targetScore) Win();
            else if (score > targetScore) Lose();
        }

        public static void CancelTurn()
        {
            if (score == -1) return;
            if (turnlist.Count > 0)
            {
                score = turnlist[turnlist.Count - 1];
                turnlist.Remove(turnlist[turnlist.Count - 1]);
                turns++; //Отмена хода считается как ход (решил, что так правильнее)
                UpdateInformers();
            }
        }

        public static void Win()
        {
            form.pictureWin.Visible = true;
        }
        public static void Lose()
        {
            form.pictureFail.Visible = true;
        }

    }
}
