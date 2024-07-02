using UnityEngine;

namespace ProjectTDS.UI.HubMenu
{
    [System.Serializable]
    public struct MissionContext
    {
        [Header("Наименование сцены:")]
        public string _sceneMissionName;

        [Space,Header("Визуальная настройка:")]
        public Sprite _missionImage;
        public string _missionName;
        public MissionTypes _missionType;
    }

    public enum MissionTypes : byte
    {
        Pratice,
        Extermination,
        Murder
    }
}
