using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public CharacterController characterController;
    public float speed = 6f; 
    public float mouseSensitivity = 2;
    public Transform cameraTransform;
    public float upperLimit = -50;
    public float lowerLimit = 50;
    private float gravity = 9.87f;
    private float verticalSpeed = 0;
    public float jumpHeight = 2f;
    public Slider fatigueSlider;
    public int maxFatigue;
    public int fatigueFallRate;

    // Start is called before the first frame update
    void Start()
    {
      fatigueSlider.maxValue = maxFatigue;
      fatigueSlider.value = maxFatigue;

    }

    // Update is called once per frame
    void Update(){
    Move();
    Rotate();
    UpdateFatigueSlider();
    }

    void UpdateFatigueSlider(){
      //FATIGUE CONTROLLER
    if(fatigueSlider.value>= 0){
        fatigueSlider.value -= Time.deltaTime / fatigueFallRate * 2;
    }

    //pull fatgue slider into its own script, player controller
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

    void Move(){
      float horizontalMovement = Input.GetAxis("Horizontal");
      float verticalMovement = Input.GetAxis("Vertical");
      if (characterController.isGrounded){
            verticalSpeed = 0;

            if (Input.GetButtonDown("Jump")){
                verticalSpeed += Mathf.Sqrt(jumpHeight * 2f * gravity);
            }
        }
        else {
            verticalSpeed -= gravity * Time.deltaTime;
        }
        Vector3 gravityMovement = new Vector3(0, verticalSpeed, 0);

      Vector3 movement = transform.forward* verticalMovement + transform.right*horizontalMovement;
      characterController.Move(movement* speed * Time.deltaTime + gravityMovement * Time.deltaTime);

    }
    void Rotate(){
      float horizontalRotation = Input.GetAxis("Mouse X");
      float verticalRotation = Input.GetAxis("Mouse Y");
      transform.Rotate(0,horizontalRotation* mouseSensitivity, 0);
      cameraTransform.Rotate(-verticalRotation*mouseSensitivity, 0, 0);

      Vector3 currentRotation = cameraTransform.localEulerAngles;
        if (currentRotation.x > 180){
            currentRotation.x -= 360;
        }
        currentRotation.x = Mathf.Clamp(currentRotation.x, upperLimit, lowerLimit);
        cameraTransform.localRotation = Quaternion.Euler(currentRotation);
    }
}
