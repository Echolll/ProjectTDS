using ProjectTDS.Unit.Player;
using ProjectTDS.Unit.Player.Input;
using Zenject;

namespace ProjectTDS.Managers
{
    public class InstallerManager : MonoInstaller
    {
        public override void InstallBindings()
        {
            var player = FindObjectOfType<PlayerUnitComponent>();

            Container.BindInstance(new PlayerInputHandler()).AsSingle();
            Container.BindInstance(new PlayerActionHandler()).AsSingle();   
            Container.BindInstance(player).AsSingle();
            Container.BindInstance(GetComponent<LevelManager>()).AsSingle();
        }
    }
}
