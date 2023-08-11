using UnityEngine;
using ReadyPlayerMe.Core;
using System.Collections;
using UnityEditor.Animations;

namespace jdmozo.ReadyPlayerMe
{
    public class AvatarLoading : MonoBehaviour
    {
        public static AvatarLoading instance;

        [SerializeField, Tooltip("Set this to the URL or shortcode of the Ready Player Me Avatar you want to load.")]
        private string avatarUrl = "https://api.readyplayer.me/v1/avatars/638df693d72bffc6fa17943c.glb";

        [SerializeField] private GameObject avatar;
        [SerializeField] private AnimatorController _animatorController;
        [SerializeField] private AnimatorController _currentAnim;

        private void Awake() => instance = this;

        private void OnDisable() => Destroy(avatar);

        private void Start() => StartCoroutine(SetAvatar());

        private void OnDestroy()
        {
            if (avatar != null) Destroy(avatar);
        }

        private IEnumerator SetAvatar()
        {
            Destroy(avatar);
            avatar = null;

            ApplicationData.Log();
            var avatarLoader = new AvatarObjectLoader();
            // use the OnCompleted event to set the avatar and setup animator
            avatarLoader.OnCompleted += (_, args) =>
            {
                avatar = args.Avatar;
                AvatarAnimatorHelper.SetupAnimator(args.Metadata.BodyType, avatar);
            };
            avatarLoader.LoadAvatar(avatarUrl);

            yield return new WaitUntil(() => avatar != null);
            avatar.SetActive(false);

            avatar.GetComponent<Animator>().runtimeAnimatorController = _animatorController;
            
            avatar.GetComponent<Animator>().applyRootMotion = false;

            Vector3 newPos = avatar.transform.position;
            newPos.z = -3;

            Vector3 angles = avatar.transform.rotation.eulerAngles;
            angles.y = 180;

            avatar.transform.rotation = Quaternion.Euler(angles);
            avatar.transform.position = newPos;
            avatar.SetActive(true);

        }

        public void ChangeAnim(string id) => avatar.GetComponent<Animator>().SetTrigger(id);

        public void ChangeAvatar(string newURL)
        {
            avatarUrl = newURL;
            StartCoroutine(SetAvatar());
        }
    }
}
