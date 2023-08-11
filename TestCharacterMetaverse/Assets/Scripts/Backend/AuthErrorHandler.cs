using System;
using UnityEngine;
using Firebase;
using Firebase.Auth;

namespace jdmozo.Backend
{
    public class AuthErrorHandler : MonoBehaviour
    {
        public static AuthErrorHandler Instance;

        public static Action<string> ErrorFinded;
        public static Action<string> ErrorEmail;
        public static Action<string> ErrorPassword;

        public void HandleCodeErrors(FirebaseException ex)
        {
            GetErrorMessage((AuthError)ex.ErrorCode);
            
            if (ex.ErrorCode == 14)
            {
                PlayerPrefs.DeleteKey("_autoLogin_Type");
                PlayerPrefs.DeleteKey("_autoLogin_email");
                PlayerPrefs.DeleteKey("_autoLogin_pass");
                PlayerPrefs.DeleteKey("_autoLogin_Key");
                PlayerPrefs.DeleteKey("_autoLogin");
            }
        }

        public void HandleCodeErrors(Exception ex)
        {
            Debug.LogWarning("_-HandleCodeErrors 2 Exeption-_ \n Message: |\" + ex.Message + \"|");
            FirebaseException firebaseEx = ex as FirebaseException;
            GetErrorMessage((AuthError)firebaseEx.ErrorCode);
        }

        public static string GetErrorMessage(AuthError errorCode)
        {
            var message = "Unkown Error";

            switch (errorCode)
            {
                case AuthError.None: // 0
                    message = "Error 000";
                    break;
                case AuthError.Unimplemented: // -1
                    message = "Error -001";
                    break;
                case AuthError.Failure: // 1
                    message = "Error 001";
                    break;
                case AuthError.InvalidCustomToken: // 2
                    message = "Error 002";
                    break;
                case AuthError.CustomTokenMismatch: // 3
                    message = "Error 003";
                    break;
                case AuthError.InvalidCredential: // 4
                    message = "Error 004";
                    break;
                case AuthError.UserDisabled: // 5
                    message = "Error 005";
                    break;
                case AuthError.AccountExistsWithDifferentCredentials: // 6
                    message = "Error 006";
                    break;
                case AuthError.OperationNotAllowed: // 7
                    message = "Error 007";
                    break;
                case AuthError.EmailAlreadyInUse: // 8
                    message = "Error 008";
                    ErrorEmail?.Invoke(message);
                    break;
                case AuthError.RequiresRecentLogin: // 9
                    message = "Error 009";
                    break;
                case AuthError.CredentialAlreadyInUse: // 10
                    message = "Error 010";
                    break;
                case AuthError.InvalidEmail: // 11
                    message = "Error 011";
                    ErrorEmail?.Invoke(message);
                    break;
                case AuthError.WrongPassword: // 12
                    message = "Error 012";
                    ErrorPassword?.Invoke(message);
                    break;
                case AuthError.TooManyRequests: // 13
                    message = "Error 013";
                    break;
                case AuthError.UserNotFound: // 14
                    message = "Error 014: User NOT Found";
                    break;
                case AuthError.ProviderAlreadyLinked: // 15
                    message = "Error 015";
                    break;
                case AuthError.NoSuchProvider: // 16
                    message = "Error 016";
                    break;
                case AuthError.InvalidUserToken: // 17
                    message = "Error 017";
                    break;
                case AuthError.UserTokenExpired: // 18
                    message = "Error 018";
                    break;
                case AuthError.NetworkRequestFailed: // 19
                    message = "Error 019";
                    break;
                case AuthError.InvalidApiKey: // 20
                    message = "Error 020";
                    break;
                case AuthError.AppNotAuthorized: // 21
                    message = "Error 021";
                    break;
                case AuthError.UserMismatch: // 22
                    message = "Error 022";
                    break;
                case AuthError.WeakPassword: // 23
                    message = "Error 023";
                    ErrorPassword?.Invoke(message);
                    break;
                case AuthError.NoSignedInUser: // 24
                    message = "Error 024";
                    break;
                case AuthError.ApiNotAvailable: // 25
                    message = "Error 025";
                    break;
                case AuthError.ExpiredActionCode: // 26
                    message = "Error 026";
                    break;
                case AuthError.InvalidActionCode: // 27
                    message = "Error 027";
                    break;
                case AuthError.InvalidMessagePayload: // 28
                    message = "Error 028";
                    break;
                case AuthError.InvalidPhoneNumber: // 29
                    message = "Error 029";
                    break;
                case AuthError.MissingPhoneNumber: // 30
                    message = "Error 030";
                    break;
                case AuthError.InvalidRecipientEmail: // 31
                    message = "Error 031";
                    ErrorEmail?.Invoke(message);
                    break;
                case AuthError.InvalidSender: // 32
                    message = "Error 032";
                    break;
                case AuthError.InvalidVerificationCode: // 33
                    message = "Error 033";
                    break;
                case AuthError.InvalidVerificationId: // 34
                    message = "Error 034";
                    break;
                case AuthError.MissingVerificationCode: // 35
                    message = "Error 035";
                    break;
                case AuthError.MissingVerificationId: // 36
                    message = "Error 036";
                    break;
                case AuthError.MissingEmail: // 37
                    message = "Error 037";
                    ErrorEmail?.Invoke(message);
                    break;
                case AuthError.MissingPassword: // 38
                    message = "There is not password";
                    ErrorPassword?.Invoke(message);
                    break;
                case AuthError.QuotaExceeded: // 39
                    message = "Error 039";
                    break;
                case AuthError.RetryPhoneAuth: // 40
                    message = "Error 040";
                    break;
                case AuthError.SessionExpired: // 41
                    message = "Error 041";
                    break;
                case AuthError.AppNotVerified: // 42
                    message = "Error 042";
                    break;
                case AuthError.AppVerificationFailed: // 43
                    message = "Error 043";
                    break;
                case AuthError.CaptchaCheckFailed: // 44
                    message = "Error 044";
                    break;
                case AuthError.InvalidAppCredential: // 45
                    message = "Error 045";
                    break;
                case AuthError.MissingAppCredential: // 46
                    message = "Error 046";
                    break;
                case AuthError.InvalidClientId: // 47
                    message = "Error 047";
                    break;
                case AuthError.InvalidContinueUri: // 48
                    message = "Error 048";
                    break;
                case AuthError.MissingContinueUri: // 49
                    message = "Error 049";
                    break;
                case AuthError.KeychainError: // 50
                    message = "Error 050";
                    break;
                case AuthError.MissingAppToken: // 51
                    message = "Error 051";
                    break;
                case AuthError.MissingIosBundleId: // 52
                    message = "Error 052";
                    break;
                case AuthError.NotificationNotForwarded: // 53
                    message = "Error 053";
                    break;
                case AuthError.UnauthorizedDomain: // 54
                    message = "Error 054";
                    break;
                case AuthError.WebContextAlreadyPresented: // 55
                    message = "Error 055";
                    break;
                case AuthError.WebContextCancelled: // 56
                    message = "Error 056";
                    break;
                case AuthError.DynamicLinkNotActivated: // 57
                    message = "Error 057";
                    break;
                case AuthError.Cancelled: // 58
                    message = "Error 058";
                    break;
                case AuthError.InvalidProviderId: // 59
                    message = "Error 059";
                    break;
                case AuthError.WebInternalError: // 60
                    message = "Error 060";
                    break;
                case AuthError.WebStorateUnsupported: // 61
                    message = "Error 061";
                    break;
                case AuthError.TenantIdMismatch: // 62
                    message = "Error 062";
                    break;
                case AuthError.UnsupportedTenantOperation: // 63
                    message = "Error 063";
                    break;
                case AuthError.InvalidLinkDomain: // 64
                    message = "Error 064";
                    break;
                case AuthError.RejectedCredential: // 65
                    message = "Error 065";
                    break;
                case AuthError.PhoneNumberNotFound: // 66
                    message = "Error 066";
                    break;
                case AuthError.InvalidTenantId: // 67
                    message = "Error 067";
                    break;
                case AuthError.MissingClientIdentifier: // 68
                    message = "Error 068";
                    break;
                case AuthError.MissingMultiFactorSession: // 69
                    message = "Error 069";
                    break;
                case AuthError.MissingMultiFactorInfo: // 70
                    message = "Error 070";
                    break;
                case AuthError.InvalidMultiFactorSession: // 71
                    message = "Error 071";
                    break;
                case AuthError.MultiFactorInfoNotFound: // 72
                    message = "Error 072";
                    break;
                case AuthError.AdminRestrictedOperation: // 73
                    message = "Error 073";
                    break;
                case AuthError.UnverifiedEmail: // 74
                    message = "Error 074";
                    ErrorEmail?.Invoke(message);
                    break;
                case AuthError.SecondFactorAlreadyEnrolled: // 75
                    message = "Error 075";
                    break;
                case AuthError.MaximumSecondFactorCountExceeded: // 76
                    message = "Error 076";
                    break;
                case AuthError.UnsupportedFirstFactor: // 77
                    message = "Error 077";
                    break;
                case AuthError.EmailChangeNeedsVerification: // 78
                    message = "Error 078";
                    ErrorEmail?.Invoke(message);
                    break;
                default:
                    message = "Unkown Error";
                    break;
            }

            ErrorFinded?.Invoke(message);

            Debug.Log($"<color=#ff0000>Error: {message}. Code: {(int)errorCode}</color>");            

            return message;
        }

    }
}
