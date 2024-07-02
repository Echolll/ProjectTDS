using ProjectTDS.Managers;
using UnityEngine;
using Zenject;

public class ProjectInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
         Container.BindInstance(GetComponent<PlayerManager>()).AsSingle();
    }
}
