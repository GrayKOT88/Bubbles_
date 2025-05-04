namespace NewScripts
{
    public interface IGameView
    {
        void UpdateScore(int score);
        void ShowTitleScreen();
        void HideTitleScreen();        
        void ShowGameOver();
        void HideGameOver();
    }
}