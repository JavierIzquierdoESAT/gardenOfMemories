using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
  public AudioSource ambient_1_;
  public AudioSource ambient_2_;
  public AudioSource win_sound;
  public AudioSource pupusito_death_;
  public AudioSource footSteps_grass_;
  public AudioSource footSteps_intermediate_;
  public AudioSource footSteps_solid_;
  public AudioSource groan_;
  public AudioSource rana_groan_;
  public bool isWalking = false;
  // Start is called before the first frame update
  void Start()
  {
    
  }

  // Update is called once per frame
  void Update()
  {
    PlayAmbient1();
    if(isWalking){
      PlayFootsteps(2);
    }else{
      if(footSteps_intermediate_.isPlaying){
        footSteps_intermediate_.Stop();
      }
    }
  }

  public void PlayAmbient1(){
    
    if(!ambient_1_.isPlaying){
      ambient_1_.Play();
    }
  }

  public void PlayAmbient2(){
    if(!ambient_2_.isPlaying){
      ambient_2_.Play();
    }
  }

  public void PlayPupusitoDeath(){
    if(!pupusito_death_.isPlaying){
      pupusito_death_.Play();
    }
  }

  public void PlayWinSound(){
    if(!win_sound.isPlaying){
      win_sound.Play();
    }
  }

  public void PupusitoDeathSound(){
    if(!pupusito_death_.isPlaying){
      pupusito_death_.Play();
    }
  }

  public void MisterDDeathSound(){
    if(!groan_.isPlaying){
      groan_.Play();
    }
  }

  public void RanaDeathSound(){
    if(rana_groan_.isPlaying){
      rana_groan_.Play();
    }
  }

  public void PlayFootsteps(int index){
    switch(index){
      case 0:{
        if(!footSteps_grass_.isPlaying){
          footSteps_grass_.Play();
        }
        break;
      }
      case 1:{
        
        if(!footSteps_intermediate_.isPlaying){
          footSteps_intermediate_.Play();
        }
        break;
      }
      case 2:{
        if(!footSteps_solid_.isPlaying){
          footSteps_solid_.Play();
        }
        break;
      }
    }
  }
}
