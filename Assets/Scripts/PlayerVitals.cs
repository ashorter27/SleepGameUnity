using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerVitals : MonoBehaviour
{
public Slider fatigueSlider;
public int maxFatigue;
public int fatigueFallRate;


void Start(){
fatigueSlider.maxValue = maxFatigue;
fatigueSlider.value = maxFatigue;

}
void Update(){

    //FATIGUE CONTROLLER
    if(fatigueSlider.value>= 0){
        fatigueSlider.value -= Time.deltaTime / fatigueFallRate * 2;
    }
    // if(fatigueSlider.value <= 0){
    //     CharacterSleeps();
    // }
    // else if (fatigueSlider.value <= 0){
    //     fatigueSlider.value = 0;
    // }
    // else if (fatigueSlider.value >= 0){
    //     fatigueSlider.value = maxFatigue;
    // }
    print("The Fatigue is:"+ fatigueSlider.value);
}
void CharacterSleeps(){
    //MAKE THE CHARACTER GO TO SLEEP
}
}
