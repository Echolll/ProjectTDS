using UnityEngine;

namespace ProjectTDS.UI.HubMenu
{
    [CreateAssetMenu(fileName = "NewMissionsConfiguration", menuName = "ScriptableObjects/Contexts/Missions Configuration", order = 1)]
    public class MissionConfiguration : ScriptableObject
    {
        public MissionContext[] _missions;
    }
}
