using System.Security.Authentication;
using System.Threading.Tasks;
using Oculus.Platform;
using Oculus.Platform.Models;
using UnityEngine;

namespace jdmozo.Backend
{
    public class OculusAuth : MonoBehaviour
    {
        private string userId;

        private void Start()
        {
            Core.AsyncInitialize().OnComplete(OnInitializationCallback);
        }

        private void OnInitializationCallback(Message<PlatformInitialize> msg)
        {
            if (msg.IsError)
            {
                Debug.LogErrorFormat("Oculus: Error during initialization. Error Message: {0}",
                    msg.GetError().Message);
            }
            else
            {
                Entitlements.IsUserEntitledToApplication().OnComplete(OnIsEntitledCallback);
            }
        }

        private void OnIsEntitledCallback(Message msg)
        {
            if (msg.IsError)
            {
                Debug.LogErrorFormat("Oculus: Error verifying the user is entitled to the application. Error Message: {0}",
                    msg.GetError().Message);
            }
            else
            {
                GetLoggedInUser();
            }
        }

        private void GetLoggedInUser()
        {
            Users.GetLoggedInUser().OnComplete(OnLoggedInUserCallback);
        }

        private void OnLoggedInUserCallback(Message<User> msg)
        {
            if (msg.IsError)
            {
                Debug.LogErrorFormat("Oculus: Error getting logged in user. Error Message: {0}",
                    msg.GetError().Message);
            }
            else
            {
                userId = msg.Data.ID.ToString(); // do not use msg.Data.OculusID;
                GetUserProof();
            }
        }

        private void GetUserProof()
        {
            Users.GetUserProof().OnComplete(OnUserProofCallback);
        }

        private void OnUserProofCallback(Message<UserProof> msg)
        {
            if (msg.IsError)
            {
                Debug.LogErrorFormat("Oculus: Error getting user proof. Error Message: {0}",
                    msg.GetError().Message);
            }
            else
            {
                string oculusNonce = msg.Data.Value;
                // Authentication can be performed here
            }
        }

        private async Task SignInWithOculusAsync(string nonce, string userId)
        {
            //try
            //{
            //    await AuthenticationService.Instance.SignInWithOculusAsync(nonce, userId);
            //    Debug.Log(“SignIn is successful.”);
            //}
            //catch (AuthenticationException ex)
            //{
            //    // Compare error code to AuthenticationErrorCodes
            //    // Notify the player with the proper error message
            //    Debug.LogException(ex);
            //}
            //catch (RequestFailedException ex)
            //{
            //    // Compare error code to CommonErrorCodes
            //    // Notify the player with the proper error message
            //    Debug.LogException(ex);
            //}
        }
    }
}
