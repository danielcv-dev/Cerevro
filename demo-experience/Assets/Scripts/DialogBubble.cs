using UnityEngine;
using TMPro;

public class DialogBubble : MonoBehaviour
{
    public string dialogText;
    public TextMeshProUGUI  txtDialogBubble;
    public GameObject dialogBubble;

    void Start()
    {
        //PointerExit();
    }

    public void PointerEnter()
    {
        txtDialogBubble.text = GameManager.Instance.UserInfo.name;
        dialogBubble.SetActive(true);
    }

    public void PointerExit()
    {
        dialogBubble.SetActive(false);
    }
}
