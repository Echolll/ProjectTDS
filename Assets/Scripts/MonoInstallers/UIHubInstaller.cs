using ProjectTDS.UI.HubMenu;
using UnityEngine;
using Zenject;

namespace ProjectTDS.Managers
{
    public class UIHubInstaller : MonoInstaller
    {
        [SerializeField]
        private MissionConfiguration _missionsConfig;
        [SerializeField]
        private WeaponConfiguration _weaponConfig;

        public override void InstallBindings()
        {
            Container.BindInstance(_missionsConfig).AsSingle();
            Container.BindInstance(_weaponConfig).AsSingle();
        }
    }
}