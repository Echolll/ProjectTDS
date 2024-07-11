using ProjectTDS.Managers;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace ProjectTDS.UI.HubMenu
{
    public class MissionListBlock : MonoBehaviour
    {
        [Inject]
        private MissionConfiguration _config;
        [Inject]
        private PlayerManager _player;

        [Header("Основные настройки:")]
        [SerializeField]
        private MissionBlock _missionBlock;
        [SerializeField]
        private RectTransform _content;

        private List<MissionBlock> _missonBlocks;

        private void Awake()
        {
            _missonBlocks = new List<MissionBlock>();
            
            foreach (var config in _config._missions)
            {
                MissionBlock block = Instantiate(_missionBlock);
                block.Initialize(
                    config._missionImage,
                    config._missionType,
                    config._missionName,
                    config._sceneMissionName);
                block.gameObject.transform.SetParent(_content); 
                
                _missonBlocks.Add(block);
            }
        }

        private void OnEnable()
        {
            if (_player.CheckWeaponList()) 
                foreach (var missionBlock in _missonBlocks) missionBlock.ButtonSwitch(true);
            else
                foreach (var missionBlock in _missonBlocks) missionBlock.ButtonSwitch(false);

        }
    }
}
