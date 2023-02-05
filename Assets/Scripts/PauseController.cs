using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour
{
  private bool paused_ = false;
  public GameObject canvas_;
  // Start is called before the first frame update
  void Start()
  {
    
  }

  // Update is called once per frame
  void Update()
  {
    if(Input.GetButtonDown("Cancel")){
      if(paused_){
        Resume();
      }else{
        PauseGame();
      }
    }
  }

  public void Resume(){
    paused_ = false;
    Time.timeScale = 1;
    canvas_.SetActive(false);
  }

  void PauseGame(){
    paused_ = true;
    Time.timeScale = 0;
    canvas_.SetActive(true);
  }

  public void OpenOptions(){

  }

  public void CloseOptions(){

  }

  public void QuitGame(){
    Application.Quit();
  }
}
