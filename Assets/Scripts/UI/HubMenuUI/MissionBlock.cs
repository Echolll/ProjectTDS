using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ProjectTDS.UI.HubMenu
{
    public class MissionBlock : MonoBehaviour
    {
        [SerializeField]
        private Image _missionImage;
        [SerializeField]
        private TextMeshProUGUI _missionName;
        [SerializeField]
        private TextMeshProUGUI _missionType;

        private string _sceneName;

        public void Initialize(Sprite image, MissionTypes type, string name, string scene)
        {
            _missionImage.sprite = image;
            _missionName.text = name;
            _missionType.text = type.ToString();
            _sceneName = scene;
        }

        public void StartMission_UnityEvent()
        {
            SceneLoader.Instance.OnLoadScene(_sceneName, true);
        }

    }
}
