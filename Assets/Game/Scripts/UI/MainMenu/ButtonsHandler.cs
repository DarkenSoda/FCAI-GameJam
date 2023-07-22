
using UnityEngine;

using UnityEngine.UI;
public class ButtonsHandler : UIShowHide
{
   public Button continueBtn;
   public Button startButton;
   public Button optionsButton;
   public Button quit;

   public Button credits;
   
   public void Start() {
      
      quit.onClick.AddListener ( () => {
         Application.Quit();  
      });

      startButton.onClick.AddListener (() => {
         Loader.StartNewGame();
      });
      continueBtn.onClick.AddListener(() => {
         Loader.LoadLastLevelReached();
      });
      if (Loader.lastLevelReachedIndex <= 1) {
         continueBtn.gameObject.SetActive(false);
      }
      else {
         continueBtn.gameObject.SetActive(true);
      }
   }
}
