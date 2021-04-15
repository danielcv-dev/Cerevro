using UnityEngine;

public class DialogsManager : MonoBehaviour
{
	
    AudioSource dialog;
    public GameObject dialogInfo;

    void Start()
    {
        dialog = GetComponent<AudioSource>();   
        dialog.Pause();
    }

    void Update()
    {
        GameManager.Instance.isReproducing = dialog.isPlaying;
    }

    public void Start_Dialog()
    {
        if(!GameManager.Instance.isReproducing)
        {
            dialog.Play();
            dialogInfo.SetActive(false);
            GameManager.Instance.isReproducing = true;
        }

        
    }
}