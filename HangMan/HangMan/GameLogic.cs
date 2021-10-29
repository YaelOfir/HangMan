using System;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

namespace HangMan
{
    class GameLogic
    {
        public static int wordLength;
        public static int indexush = 0;
        public static Image _image;
        WordBank bank;
        public static string conection;
        Board board;
        public GameLogic(Canvas canvas, MainPage main, Image image)
        {
            _image = image;
            board = new Board(canvas, main, this);
            bank = new WordBank();
        }
        public void SelectWord(string gameType)
        {
            conection = gameType;
            switch (gameType)
            {
                case "easy":
                    board.TextBlockMaker(bank.Easy());
                    break;
                case "hard":
                    board.TextBlockMaker(bank.Hard());
                    break;
            }
        }
        public void WrongIndex(string wrongIndex)
        {
            conection = wrongIndex;
            switch (wrongIndex)
            {
                case "easy":
                    indexush++;
                    break;
                case "hard":
                    indexush += 2;
                    break;
            }
            string imgaeUri = $"ms-appx:///Assets/HangMan{indexush}.png";
            _image.Source = new BitmapImage(new Uri(imgaeUri)); //ביטמאפ אחראי על התמונות שאפשר לשנות אותם דרך קוד
            if (indexush >= 10)
            {
                indexush = -1; //איפוס
                board.ResetGameBoard();
                board.LoserScreen();
            }
        }
        public void RightIndex(string rightIndex)
        {
            wordLength--;
            if (wordLength == 0)
            {
                indexush = -1;
                SelectWord(rightIndex);
                board.ResetGameBoard();
            }
        }
    }
}
