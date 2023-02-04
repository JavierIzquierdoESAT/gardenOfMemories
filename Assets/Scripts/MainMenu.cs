using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public enum MenuState{
  Main,
  Options
};
public class MainMenu : MonoBehaviour
{
  public GameObject button_play_;
  public GameObject button_options_;
  public GameObject button_quit_;
  public GameObject button_credits_;
  public GameObject volume_slider_;
  // Start is called before the first frame update
  void Start()
  {
      
  }

  // Update is called once per frame
  void Update()
  {
    
  }

  public void OpenCredits(){
    button_play_.SetActive(false);
    button_options_.SetActive(false);
    button_quit_.SetActive(false);
    button_credits_.SetActive(false);
    volume_slider_.SetActive(true);
  }

  public void CloseCredits(){
    button_play_.SetActive(true);
    button_options_.SetActive(true);
    button_credits_.SetActive(true);
    button_quit_.SetActive(true);
    volume_slider_.SetActive(false);
  }

  public void EnterPlay(){
    SceneManager.LoadScene("level_01", LoadSceneMode.Single);
  }

  public void QuitGame(){
    Application.Quit();
  }
}
