using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
public class MainMenu : MonoBehaviour
{   

   [SerializeField] GameObject PauseMenu;
   public void Playgame(){
    SceneManager.LoadSceneAsync(1);
   }
   public void QuitGame(){
    Application.Quit();
   
   #if UNITY_EDITOR 
      EditorApplication.isPlaying = false;
   #endif
   }

  public void PauseWithPauseMenu(){
         PauseMenu.SetActive(true);
         Time.timeScale = 0;
   }
   public void HomeWithPauseMenu(){
         SceneManager.LoadScene("MainMenu");
         Time.timeScale = 1;
      Debug.Log("dang ở home");

   }
    public void RestartWithPauseMenu(){
         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
         Time.timeScale = 1;
      Debug.Log("dang ở restart");

   }
    public void ReseumWithPauseMenu(){
      PauseMenu.SetActive(false);
      Time.timeScale = 1;
      Debug.Log("dang ở resume");
   }
}
