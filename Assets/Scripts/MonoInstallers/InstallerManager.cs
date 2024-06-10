using ProjectTDS.Unit.Player.Input;
using Zenject;

namespace ProjectTDS.Managers
{
    public class InstallerManager : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInstance(new PlayerInputHandler()).AsSingle();
            Container.BindInstance(new PlayerActionHandler()).AsSingle();                 
        }
    }
}
