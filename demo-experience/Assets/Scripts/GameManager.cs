using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Networking;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{

#region Singleton

	private static GameManager instance;
	public static GameManager Instance
	{
		get
		{
			if (instance == null)
			{
				instance = new GameManager ();
			}
			return instance;
		}
	}

	#endregion

	private void Awake ()
	{
		if (instance == null)
		{
			instance = this;
		}
		else
		{
			Destroy (gameObject);
		}
	}

	[Header ("Fade")]
	public Image imgFade;
    public Image imgFadeTeleport;
	[Range (0f, 5f)] public float timeFade = 2;
	[Range (0f, 5f)] public float delayFade = 1;

	public User UserInfo;

	public bool isReproducing = false;

	void Start ()
	{
		StartCoroutine (Get_User());
		Fade (false);
	}

	public void Fade (bool isFadeIn)
	{
		imgFadeTeleport.CrossFadeAlpha(0, 0, true);
		if (isFadeIn) Invoke ("Fade_In", delayFade);
		else Invoke ("Fade_Out", delayFade);
	}

	private void Fade_Out ()
	{
		imgFade.CrossFadeAlpha (0, timeFade, true);
	}

	private void Fade_In ()
	{
		imgFade.CrossFadeAlpha (1, timeFade, true);
	}

	IEnumerator Get_User()
	{
		WWWForm formData = new WWWForm();
        formData.AddField("token", "KXyUY7x9mSaSJpv6clbalQJZDbF2");

        UnityWebRequest www = UnityWebRequest.Post("https://us-central1-cerevro-cf50f.cloudfunctions.net/api/experiences/getUser", formData);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
			string fixedJson = www.downloadHandler.text;
			Debug.Log(fixedJson);
			ServiceResponse serviceResponse = JsonUtility.FromJson<ServiceResponse>(fixedJson);
			UserInfo = serviceResponse.body;
        }
	}

}

[System.Serializable]
public class ServiceResponse
{
	public string error;
	public User body;
}

[System.Serializable]
public class User{
	public bool state;
	public string avatar_url;
	public string grade_id;
	public int total_points;
	public string token;
	public string email;
	public string name;
	public string school_id;
}