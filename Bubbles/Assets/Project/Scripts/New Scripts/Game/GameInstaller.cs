using UnityEngine;
using Zenject;

namespace NewScripts
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private BubblePool _bubblePool;
        [SerializeField] private ParticlePool _particlePool;       
        [SerializeField] private GameView _gameView;
        [SerializeField] private AudioService _audioService;
        
        public override void InstallBindings()
        {
            // Регистрация (наследуются от MonoBehaviour)
            Container.Bind<BubblePool>().FromInstance(_bubblePool).AsSingle();
            Container.Bind<ParticlePool>().FromInstance(_particlePool).AsSingle();
            Container.Bind<IGameView>().FromInstance(_gameView).AsSingle();           
            Container.Bind<IAudioService>().FromInstance(_audioService).AsSingle();          

            // Создаём экземпляр и регистрируем (не наследуются от MonoBehaviour)
            Container.Bind<IGameModel>().To<GameModel>().AsSingle();
            Container.Bind<ILeaderboardService>().To<YGLeaderboardAdapter>().AsSingle();
        }
    }
}