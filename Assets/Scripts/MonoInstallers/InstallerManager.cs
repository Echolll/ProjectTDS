using ProjectTDS.Unit.Player;
using UnityEngine;
using Zenject;

namespace ProjectTDS.Managers
{
    public class InstallerManager : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInstance(new PlayerInputs()).AsSingle();
        }
    }
}
