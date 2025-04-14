namespace NewScripts
{
    public interface IGameView
    {
        void UpdateScore(int score);
        void ShowGameOver();        
        void ShowTitleScreen();
        void HideTitleScreen();        
    }
}