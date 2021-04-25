using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
   [SerializeField]
   Button playButton;

   [SerializeField]
   Button exitButton;

   [SerializeField]
   GameObject panelObj;

   private bool gameLoaded = false;

   private void OnEnable()
   {
      playButton.onClick.AddListener(() => Play());
      exitButton.onClick.AddListener(() => Exit());
   }

   public void Play()
   {
      if (!gameLoaded)
      {
         SceneManager.LoadScene(1, LoadSceneMode.Additive);
         gameLoaded = true;
      }
      Time.timeScale = 1;
      panelObj.SetActive(false);
   }

   public void Exit()
   {
      Application.Quit();
   }

   private void OnDisable()
   {
      playButton.onClick.RemoveListener(() => Play());
      exitButton.onClick.RemoveListener(() => Exit());
   }

   private void Update()
   {
      if (Input.GetKeyUp(KeyCode.Escape))
         if (!panelObj.activeInHierarchy)
         {

            Time.timeScale = 0;
            panelObj.SetActive(true);
         }
         else if(panelObj.activeInHierarchy)
         {
            Time.timeScale = 1;
            panelObj.SetActive(false);
         }

   }

}
