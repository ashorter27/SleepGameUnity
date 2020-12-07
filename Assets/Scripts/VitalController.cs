using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VitalController : MonoBehaviour
{
    
    public Slider fatigueSlider;
    public int maxFatigue;
    public int fatigueFallRate;
    public int NormallFallRate;
    public Slider sanitySlider;
    public int maxSanity;
    public int SanityFallRate;
    // Start is called before the first frame update
    void Start()
    {
      fatigueSlider.maxValue = maxFatigue;
      fatigueSlider.value = maxFatigue;
      sanitySlider.maxValue = maxSanity;
      sanitySlider.value = maxSanity;
      
    }

    // Update is called once per frame
    void Update()
    {
      UpdateSliders();
   
    }

    void UpdateSliders(){
      //FATIGUE CONTROLLER
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
        print("The Fatigue is:"+ fatigueSlider.value + "The Max Sanity is: "+sanitySlider.value);
    }

    public void FatigueDecreaseBuJump(){
      fatigueSlider.value = fatigueSlider.value - 5;
    }
    public void FatigueDecreaseByRunning(){
     int newFatigueFallRate = NormallFallRate/3;
     fatigueFallRate = newFatigueFallRate;
    }
    public void returnNormalFallRate(){
      fatigueFallRate = NormallFallRate;
    }
    public void IncreaseSanityByTalk(){
      if(sanitySlider.value + 5 <= 100){
        sanitySlider.value = sanitySlider.value + 5;
      }
    }

    void CharacterSleeps(){
    //MAKE THE CHARACTER GO TO SLEEP
    }

}
