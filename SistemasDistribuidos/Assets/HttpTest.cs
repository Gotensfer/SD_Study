using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class HttpTest : MonoBehaviour
{
    public string URL = "https://my-json-server.typicode.com/juananre/jasonDB";
    public RawImage myRawimage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void boton()
    {
        StartCoroutine(DownloadImge());
    }
    
    /*IEnumerator GetUser()
    {
        UnityWebRequest www = UnityWebRequest.Get(URL + "/user");
        yield return www.SendWebRequest();

        if (www.isNetworkError)
        {
            Debug.Log("cagaste" + www.error);
        }
        else
        {
            Debug.Log(www.downloadHandler.text);

            if (www != null && www.responseCode == 200)
            {
                Userlist usetlist = JsonUtility.FromJson<Userlist>(www.downloadHandler.text);

                foreach (user user in usetlist.usuario)
                {
                    Debug.Log(user.username + " y " + user.id);
                }
            }
            else
            {
                Debug.Log(www.error);
            }
        }
    }*/

    IEnumerator DownloadImge()
    {
        string Mediaurl = "https://rickandmortyapi.com/api/character/1";
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(Mediaurl);
        yield return www.SendWebRequest();

        if (www.isNetworkError)
        {
            Debug.Log(www.error);
        }
        else if(!www.isHttpError)
        {
            myRawimage.texture = ((DownloadHandlerTexture)www.downloadHandler).texture;
        }
    }
}

[System.Serializable]
public class Userlist
{
    public List<user> usuario;
}
[System.Serializable]
public class user
{
    public int id;
    public string username; 
}

public class character
{

}
