using ReadyPlayerMe.Core.Analytics;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace jdmozo.ReadyPlayerMe
{
    public class OptionsHUD : MonoBehaviour
    {
        [Header("UI")]
        [SerializeField] private Button _danceHipHop;
        [SerializeField] private Button _danceSwing;
        [SerializeField] private Button _danceReggeton;
        [SerializeField] private TMP_InputField _avatarUrlField;
        [SerializeField] private Button _loadAvatarButton;
        [SerializeField] private AvatarLoading _avatarLoading;

        private const string _danceHiphopID = "Dance_HipHop";
        private const string _danceTwerkID = "Dance_Twerk";
        private const string _danceSwingID = "Dance_Swing";

        private void Start()
        {
            AnalyticsRuntimeLogger.EventLogger.LogRunQuickStartScene();
            _avatarUrlField.onValueChanged.AddListener(OnAvatarUrlFieldValueChanged);
            _danceHipHop.onClick.AddListener(delegate { ChangeAnimation(0, _danceHiphopID); });
            _danceSwing.onClick.AddListener(delegate { ChangeAnimation(1, _danceTwerkID); });
            _danceReggeton.onClick.AddListener(delegate { ChangeAnimation(2, _danceSwingID); });
            _loadAvatarButton.onClick.AddListener(OnLoadAvatarButton);
        }

        private void OnEnable()
        {
            AnalyticsRuntimeLogger.EventLogger.LogLoadPersonalAvatarButton();
            _loadAvatarButton.interactable = false;
        }

        private void OnLoadAvatarButton()
        {
            AnalyticsRuntimeLogger.EventLogger.LogPersonalAvatarLoading(_avatarUrlField.text);

            _avatarLoading.ChangeAvatar(_avatarUrlField.text);
        }

        private void OnAvatarUrlFieldValueChanged(string url)
        {
            if (!string.IsNullOrEmpty(url) && Uri.TryCreate(url, UriKind.Absolute, out Uri _))
                _loadAvatarButton.interactable = true;
            else
                _loadAvatarButton.interactable = false;
        }

        private void ChangeAnimation(int id, string name)
        {
            switch (id)
            {
                case 0:
                    AvatarLoading.instance.ChangeAnim(name);
                    break;
                case 1:
                    AvatarLoading.instance.ChangeAnim(name);
                    break;
                case 2:
                    AvatarLoading.instance.ChangeAnim(name);
                    break;
                default:
                    break;
            }
        }
    }
}
