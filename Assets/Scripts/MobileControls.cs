using UnityEngine;

public class MobileControls : MonoBehaviour
{
    // Reference to the InputManager script
    public InputManager inputManager;

    // Reference to the car effects script
    public carEffects carEffects;

    public AudioSource wheelAudioSource; // Reference to the AudioSource component
    public AudioClip skidSound;
    private bool isSkidSoundPlaying = false;

    private void Start()
    {
        inputManager=GameObject.FindGameObjectWithTag("Player").GetComponent<InputManager>();
        carEffects = GameObject.FindGameObjectWithTag("Player").GetComponent<carEffects>();


    }

    // Function to handle the accelerate button click
    public void OnAccelerateButtonDown()
    {
        inputManager.vertical = 1f;
    }

    // Function to handle the accelerate button release
    public void OnAccelerateButtonUp()
    {
        inputManager.vertical = 0f;
    }

    // Function to handle the brake button click
    public void OnBrakeButtonDown()
    {
        inputManager.vertical = -1f;
        carEffects.ActivateWheelEffects(true); // Activate skid marks
        carEffects.BLsmoke.Emit(2); // Emit smoke particles from the left wheel
        carEffects.BRsmoke.Emit(2); // Emit smoke particles from the right wheel

        wheelAudioSource.clip = skidSound;
        wheelAudioSource.loop = true;
        wheelAudioSource.Play();
        isSkidSoundPlaying = true;
    }

    // Function to handle the brake button release
    public void OnBrakeButtonUp()
    {
        inputManager.vertical = 0f;
        carEffects.ActivateWheelEffects(false); // Deactivate skid marks and smoke

        wheelAudioSource.Stop();
        isSkidSoundPlaying = false;
    }

    // Function to handle the left steering button click
    public void OnSteerLeftButtonDown()
    {
        inputManager.horizontal = -1f;
    }

    // Function to handle the left steering button release
    public void OnSteerLeftButtonUp()
    {
        inputManager.horizontal = 0f;
    }

    // Function to handle the right steering button click
    public void OnSteerRightButtonDown()
    {
        inputManager.horizontal = 1f;
    }

    // Function to handle the right steering button release
    public void OnSteerRightButtonUp()
    {
        inputManager.horizontal = 0f;
    }

    // Function to handle the nitrous button click
    public void OnNitrousButtonDown()
    {
        inputManager.boosting = true;
    }

    // Function to handle the nitrous button release
    public void OnNitrousButtonUp()
    {
        inputManager.boosting = false;
    }
}
