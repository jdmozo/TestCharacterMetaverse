using Firebase.Extensions;
using Firebase.Firestore;
using System.Collections.Generic;
using UnityEngine;

namespace jdmozo.Backend
{
    public class FirestoreDataBaseController : MonoBehaviour
    {
        public void AddFirestoreData(string Collection, string DataReference, string DataValue)
        {
            FirebaseFirestore db = FirebaseFirestore.DefaultInstance;
            DocumentReference docRef = db.Collection(Collection).Document(AuthController.instance.user.UserId);

            Dictionary<string, object> data = new Dictionary<string, object>
            {
                { DataReference, DataValue }
            };

            docRef.SetAsync(data).ContinueWithOnMainThread(task =>
            {
                Debug.Log($"<color=orange>Added data to the {Collection} document in the Reference {DataReference}</color>");
            });

        }

        public void GetFirestoreData(string Collection, string DataReference) 
        {
            string DataValue = null;

            FirebaseFirestore db = FirebaseFirestore.DefaultInstance;
            CollectionReference userRef = db.Collection(Collection);

            userRef.GetSnapshotAsync().ContinueWithOnMainThread(task =>
            {
                QuerySnapshot snapshot = task.Result;
                foreach (DocumentSnapshot document in snapshot.Documents)
                {
 
                    Dictionary<string, object> documentDictionary = document.ToDictionary();

                    if (documentDictionary.ContainsKey(DataReference))
                        DataValue = documentDictionary[DataReference].ToString();
                    else
                    {
                        Debug.Log($"<color=orange>Tehre is not data with: {DataReference}</color>");
                        DataValue = null;
                    }
                }
            });

        }
    }
}
