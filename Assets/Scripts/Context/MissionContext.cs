using UnityEngine;

namespace ProjectTDS.UI.HubMenu
{
    [System.Serializable]
    public struct MissionContext
    {
        [Header("������������ �����:")]
        public string _sceneMissionName;

        [Space,Header("���������� ���������:")]
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
