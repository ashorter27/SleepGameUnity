using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;


public class VitalController : MonoBehaviour
{
    
    public Slider fatigueSlider;
    public int maxFatigue;
    public int fatigueFallRate;
    public int NormallFallRate;
    public Slider sanitySlider;
    public int maxSanity;
    public int SanityFallRate;
    public Slider staminaSlider;
    public int maxStamina;
    public int StaminaIcreaseRate;
    public int staminaNormalRate;
    // Start is called before the first frame update
    public UnityEvent CheckStaminaEvent;
    void Start()
    {
      fatigueSlider.maxValue = maxFatigue;
      fatigueSlider.value = maxFatigue;
      sanitySlider.maxValue = maxSanity;
      sanitySlider.value = maxSanity;
      staminaSlider.maxValue = maxStamina;
      staminaSlider.value = maxStamina;
      
    }

    // Update is called once per frame
    void Update()
    {
      UpdateSliders();
    }

    void UpdateSliders(){
    //   //FATIGUE CONTROLLER
        if(fatigueSlider.value>= 0){
        fatigueSlider.value -= Time.deltaTime / fatigueFallRate * 2;
        }
        if(fatigueSlider.value <= 0){
        CharacterSleeps();
        }
      else if (fatigueSlider.value <= 0){
        fatigueSlider.value = 0;
        }
      else if (fatigueSlider.value >= 100){
        fatigueSlider.value = maxFatigue;
        }

        if(sanitySlider.value>= 0){
        sanitySlider.value -= Time.deltaTime / SanityFallRate * 2;
        }
        if(sanitySlider.value <= 0){
        CharacterSleeps();
        }
      else if (sanitySlider.value <= 0){
        sanitySlider.value = 0;
        }
      else if (sanitySlider.value >= 100){
        sanitySlider.value = maxSanity;
        }

        if(staminaSlider.value>= 0){
          if(StaminaIcreaseRate > 0){
        staminaSlider.value += Time.deltaTime / StaminaIcreaseRate * 10;
          }else if (StaminaIcreaseRate < 0 ){
            staminaSlider.value -= Time.deltaTime / -StaminaIcreaseRate * 100 ;
          }
        }

        if(staminaSlider.value <= 0){
        CharacterSleeps();
        }
      else if (staminaSlider.value <= 0){
        staminaSlider.value = 0;
        }
      else if (staminaSlider.value >= 100){
        staminaSlider.value = maxStamina;
        }
        // else if (IfStillEnergyLeft()){
        //   CheckStaminaEvent.Invoke();
        // }
        print("The Fatigue is:"+ fatigueSlider.value + "The Max Sanity is: "+sanitySlider.value + "The Stamina Value is: " + staminaSlider.value);
    }

    public void StaminaDecreaseByJump(){
      staminaSlider.value = staminaSlider.value - 5;
    }
    public void StaminaDecreaseByRunning(){
     int newStaminaFallRate = -StaminaIcreaseRate/5;
     StaminaIcreaseRate = newStaminaFallRate;
    }
    public void returnNormalstaminaIncreaseRate(){
      StaminaIcreaseRate = staminaNormalRate;
    }
    public void IncreaseSanityByTalk(){
      if(sanitySlider.value + 5 <= 100){
        sanitySlider.value = sanitySlider.value + 5;
      }
    }
    // public bool IfStillEnergyLeft(){
    //   if(staminaSlider.value > 5){
    //   return true;
    //   }
    //   return false;
    // }
    void CharacterSleeps(){
    //MAKE THE CHARACTER GO TO SLEEP
    }

    public void RestoreSanityTalking(){
      sanitySlider.value = sanitySlider.value + 10;
    }

}
