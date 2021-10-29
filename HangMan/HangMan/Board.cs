using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
namespace HangMan
{
    class Board
    {
        Image Image;
        GameLogic logic;
        MainPage mainPage;
        List<TextBlock> tbs;
        Canvas gameBoard;
        public Board(Canvas canvas, MainPage main, GameLogic gameLogic) //the game
        {
            Image = main.hangMan;
            logic = gameLogic;
            mainPage = main;
            tbs = new List<TextBlock>();//מאפס          
            gameBoard = canvas;
            LetterMaker();//ליצור כפתורים
        }
        public void TextBlockMaker(string mila)
        {
            GameLogic.wordLength = mila.Length;
            WordBank.SelectedWord = mila;
            for (int i = 0; i < mila.Length; i++)
            {
                TextBlock textBlock = new TextBlock();
                gameBoard.Children.Add(textBlock);
                textBlock.Text = "_";
                tbs.Add(textBlock);
                Canvas.SetLeft(textBlock, 20 + i * 40);
                Canvas.SetTop(textBlock, 180);
            }
        }
        public void LetterMaker()
        {
            string letter = "abcdefghijklmnopqrstuvwxyz";
            for (int i = 0; i < letter.Length; i++)
            {
                Button btn = new Button();
                btn.Content = letter[i];
                Canvas.SetTop(btn, 0);
                Canvas.SetLeft(btn, i * 30);
                gameBoard.Children.Add(btn);
                btn.Click += Btn_Click;
            }
        }
        static bool correctIndex;
        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            ((Button)sender).Visibility = Visibility.Collapsed; //כשלוחצים על הכפתור הוא נעלם
            string btnLetter = ((Button)sender).Content.ToString(); //להשוות סטרינג לכפתור 
            for (int i = 0; i < WordBank.SelectedWord.Length; i++)
            {
                if (WordBank.SelectedWord[i].ToString() == btnLetter)
                    correctIndex = true; //checking if true
            }
            if (correctIndex)
            {
                correctIndex = false; //לאפס
                InputLetters(btnLetter); //מחליף אותיות
            }
            else logic.WrongIndex(GameLogic.conection); // כשיש תשובה לא נכונה מעלה את הערך עד שנפסל
        }
        public void InputLetters(string inputLetter)
        {
            for (int i = 0; i < WordBank.SelectedWord.Length; i++)
            {
                if (WordBank.SelectedWord[i].ToString() == inputLetter)
                {
                    tbs[i].Text = inputLetter.ToString(); //המיקום של האות
                    logic.RightIndex(GameLogic.conection);
                }
            }
        }
        public void LoserScreen()
        {
            gameBoard.Visibility = Visibility.Collapsed;
            mainPage.loser.Visibility = Visibility.Visible;
        }
        public void ResetGameBoard()
        {
            tbs.Clear();
            gameBoard.Children.Clear();
            gameBoard.Children.Add(Image);
            LetterMaker();
            TextBlockMaker(WordBank.SelectedWord);
        }
    }
}
