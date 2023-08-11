using System;
using System.Collections;
using UnityEngine;
using Firebase;
using Firebase.Auth;
using Firebase.Database;
using Firebase.Extensions;

namespace jdmozo.Backend
{
    public class AuthController : MonoBehaviour
    {
        public static AuthController instance;

        public static Action OnLogged;

        [Header("Loading")]
        public bool ready = false;
        public bool logged = false;
        private bool readyFirebase = false;

        [HideInInspector] public DependencyStatus dependencyStatus;
        public FirebaseApp app;
        public FirebaseAuth auth;
        public FirestoreDataBaseController database;
        public DatabaseReference DbRegerence;
        public FirebaseUser user;

        public AuthErrorHandler AuthErrorHandler;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(this);

                SetFirebaseDependecy();
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void SetFirebaseDependecy()
        {
            StartCoroutine(InitializeFirebase());

            FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task =>
            {
                dependencyStatus = task.Result;
                if (dependencyStatus == DependencyStatus.Available)
                {
                    readyFirebase = true;
                }
                else
                {
                    Debug.LogError($"<color=orange>Could not resolve all Firebase dependencies: {dependencyStatus}</color>");
                }
            });
        }

        private IEnumerator InitializeFirebase()
        {
            Debug.Log("<color=orange>Init Firebase</color>");
            app = FirebaseApp.DefaultInstance;
            auth = FirebaseAuth.DefaultInstance;
            yield return new WaitUntil(() => readyFirebase);

            Debug.Log("<color=orange>Firebase is ready to use</color>");

            ready = true;
        }

        public void AuthEmail(string email, string password)
        {
            auth.SignInWithEmailAndPasswordAsync(email, password).ContinueWithOnMainThread(task =>
            {
                if (task.IsCanceled)
                {
                    Debug.Log("<color=orange>Task Canceled</color>");
                    return;
                }
                if (task.IsFaulted)
                {
                    AuthErrorHandler.HandleCodeErrors((FirebaseException)task.Exception.InnerException.InnerException);
                    return;
                }

                user = task.Result.User;
                logged = true;

                Debug.Log($"<color=orange>El usuario inició sesión correctamente: {user.DisplayName} ({user.UserId})</color>");
            });
        }

        public void SignUpEmail(string email, string password)
        {
            auth.CreateUserWithEmailAndPasswordAsync(email, password).ContinueWithOnMainThread(task =>
            {
                if (task.IsCanceled)
                {
                    Debug.Log("<color=orange>Task Canceled</color>");
                    return;
                }
                if (task.IsFaulted)
                {
                    AuthErrorHandler.HandleCodeErrors((FirebaseException)task.Exception.InnerException.InnerException);
                    return;
                }

                user = task.Result.User;
                Debug.LogWarning($"<color=orange>El usuario se registró correctamente: {user.DisplayName} ({user.UserId})</color>");

                AuthEmail(email, password);
            });
        }
    }
}
