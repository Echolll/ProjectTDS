using ProjectTDS.UI.HubMenu;
using UnityEngine;
using Zenject;

public class MissionListBlock : MonoBehaviour
{
    [Inject]
    private MissionConfiguration _config;

    [Header("Основные настройки:")]
    [SerializeField]
    private MissionBlock _missionBlock;
    [SerializeField]
    private RectTransform _content;

    private void Awake()
    {
        foreach(var config in _config._missions)
        {
            MissionBlock block = Instantiate(_missionBlock);
            block.Initialize(
                config._missionImage,
                config._missionType,
                config._missionName,
                config._sceneMissionName);
            block.gameObject.transform.SetParent(_content);
        }
    }
}
