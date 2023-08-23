using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Scripting;
using UnityEngine.UI;
using static System.Net.WebRequestMethods;

namespace Ejer1
{
    public class HttpsText : MonoBehaviour
    {
        public string URL = "https://my-json-server.typicode.com/Gotensfer/SD_Study/users/"; //access my json user. Edit in unity editor
        public string ImageURL = "https://rickandmortyapi.com/api/character/avatar/"; //access the image

        #region Txts_and_raws
        public RawImage[] cardImages = new RawImage[5];

        public TMP_Text[] cardTxt = new TMP_Text[5];

        #endregion

        public TMP_Text UsernameLabel;
        public TMP_Text UserIdLabel;

        public string UserId = "2";

        private void Start()
        {
            URL = URL + UserId;
        }
        public void SendRequest()
        {
            StartCoroutine(GetUser());

        }

        IEnumerator GetUser()
        {
            UnityWebRequest request = UnityWebRequest.Get(URL);

            yield return request.SendWebRequest();



            if (request.result == UnityWebRequest.Result.ConnectionError)
            {
                Debug.Log("NETWORK ERROR" + request.error);
            }
            else
            {
                Debug.Log(request.downloadHandler.text);
                if (request.responseCode == 200)
                {
                    users users = JsonUtility.FromJson<users>(request.downloadHandler.text);

                    //Debug.Log("id " + users.id + " username " + users.username);
                    UsernameLabel.text = "user name is " + users.username;
                    UserIdLabel.text = "User ID is " + users.id;
                    for (int i = 0; i < 5; i++)
                    {
                        Debug.Log(users.deck[i]);
                        StartCoroutine((downloadImage(users.deck[i], cardImages[i])));
                        //StartCoroutine((characterInfo(users.deck[i], cardTxt[i] )));
                        cardTxt[i].text = "" + users.deck[i];
                    }


                }
                else
                {
                    Debug.Log(request.error);
                }

            }
        }
        IEnumerator downloadImage(int number, RawImage imogen)
        {

            UnityWebRequest image = UnityWebRequestTexture.GetTexture(ImageURL + number + ".jpeg");

            yield return image.SendWebRequest();
            if (image.result == UnityWebRequest.Result.ConnectionError)
            {
                Debug.Log("NETWORK ERROR" + image.error);
            }
            else if (image.result != UnityWebRequest.Result.ProtocolError)
            {
                imogen.texture = ((DownloadHandlerTexture)image.downloadHandler).texture;
            }
        }

        IEnumerator characterInfo(int number, TMP_Text text)
        {
            UnityWebRequest request = UnityWebRequestTexture.GetTexture(ImageURL + number);
            Character character = JsonUtility.FromJson<Character>(request.downloadHandler.text);
            yield return request.SendWebRequest();
            text.text = ((DownloadHandler)request.downloadHandler).text;

        }


    }


    [System.Serializable]

    public class usersList
    {
        public List<users> users;

    }

    [System.Serializable]
    public class users
    {
        public int id;
        public string username;
        public bool state;
        public int[] deck;
    }


    [System.Serializable]
    public class Character
    {
        string name;
    }

}
