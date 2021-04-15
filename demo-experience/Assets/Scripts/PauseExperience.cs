using UnityEngine;

public class PauseExperience : MonoBehaviour
{
	
   public void Pointer_Enter ()
   {
	   Application.Quit();
   }
   
   public void Pointer_Exit ()
   {
	   Debug.Log ("<color=red><b>" + "EXIT" + "</b></color>");
   }
   
   public void Pointer_Click ()
   {
	   Debug.Log ("<b>" + "Click" + "</b>");
   }
}