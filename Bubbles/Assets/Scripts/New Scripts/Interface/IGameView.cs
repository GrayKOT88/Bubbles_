namespace NewScripts
{
    public interface IGameView
    {
        void UpdateScore(int score);
        void ShowGameOver();
        void HideGameOver();
        void ShowTitleScreen();
        void HideTitleScreen();
    }
}