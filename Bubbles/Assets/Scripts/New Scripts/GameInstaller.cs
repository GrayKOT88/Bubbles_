using UnityEngine;
using Zenject;

namespace NewScripts
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private BubblePool _bubblePool;
        [SerializeField] private ParticlePool _particlePool;       
        [SerializeField] private GameView _gameView;

        public override void InstallBindings()
        {
            Container.Bind<BubblePool>().FromInstance(_bubblePool).AsSingle();
            Container.Bind<ParticlePool>().FromInstance(_particlePool).AsSingle();
            Container.Bind<IGameModel>().To<GameModel>().AsSingle();
            Container.Bind<IGameView>().FromInstance(_gameView).AsSingle();
        }
    }
}