using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace ProjectTDS
{
    public class SceneLoader : MonoBehaviour
    {
        public static SceneLoader Instance { get; private set; }

        [SerializeField]
        private GameObject _loadingPanel;

        [Space,SerializeField]
        private Image _fillImage;
        [SerializeField]
        private TextMeshProUGUI _loadText;
        [SerializeField]
        private GameObject _pressAnyKeyText;

        [Space, SerializeField]
        private Image _backgroundImage;
        [SerializeField]
        private Sprite[] _sourceImages;

        AsyncOperation _asynsLoadOperation;

        private void Awake()
        {
            if(Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
            
        }

        private void OnEnable()
        {
            _backgroundImage.sprite = _sourceImages[Random.Range(0, _sourceImages.Length)];
        }

        private void OnDisable()
        {
            _pressAnyKeyText.SetActive(false);
            _loadText.gameObject.SetActive(true);
            _asynsLoadOperation = null;
        }

        public void OnLoadScene(string name, bool isMission)
        {
            _loadingPanel.SetActive(true);
            StartCoroutine(LoadSceneAsyns(name, isMission));
        }

        private IEnumerator LoadSceneAsyns(string sceneName, bool isMission)
        {
            float loadingProgress;

            _asynsLoadOperation = SceneManager.LoadSceneAsync(sceneName);
            _asynsLoadOperation.allowSceneActivation = isMission;

            while(_asynsLoadOperation.progress < 0.9f)
            {
                loadingProgress = Mathf.Clamp01(_asynsLoadOperation.progress / 0.9f);

                _loadText.text = $"Loading {(loadingProgress * 100).ToString("0")}%";
                _fillImage.fillAmount = loadingProgress;
                yield return true;
            }

            if (!isMission)
            {
                _pressAnyKeyText.SetActive(true);
                _loadText.gameObject.SetActive(false);
            }
            else
            {
                _loadingPanel.SetActive(false);
                if (Time.timeScale <= 0) Time.timeScale = 1f;
            }
        }

        public void RestartCurrentScene()
        {
            string currentScene = SceneManager.GetActiveScene().name;
            OnLoadScene(currentScene, false);
        }

        private void Update()
        {
            if (_pressAnyKeyText.activeSelf)
            {
                if (Input.anyKeyDown)
                {
                    _asynsLoadOperation.allowSceneActivation = true;
                    _loadingPanel.SetActive(false);
                    if (Time.timeScale <= 0) Time.timeScale = 1f;
                }               
            }
        }
    }
}
