using UnityEngine;

public class carEffects : MonoBehaviour
{
    public Transform BLwheelEffect;
    public Transform BRwheelEffect;

    public ParticleSystem BLsmoke;
    public ParticleSystem BRsmoke;

    public ParticleSystem BLnitrous;
    public ParticleSystem BRnitrous;


    public AudioSource wheelAudioSource; // Reference to the AudioSource component
    public AudioClip skidSound; // Reference to the skid sound clip

    private CarController carController;
    private bool isWheelEffectsActive = false;
    private bool isSkidSoundPlaying = false;

    private void Start()
    {
        carController = GetComponent<CarController>();

        // Ensure the AudioSource component is assigned
        if (wheelAudioSource == null)
        {
            Debug.LogError("AudioSource component not assigned.");
        }
    }

    private void Update()
    {
        WheelEffects();
        PlaySkidSound();
    }

    void WheelEffects()
    {
        bool activate = Input.GetKey(KeyCode.Space) && carController.KPH >= 10.0f;

        if (activate != isWheelEffectsActive)
        {
            ActivateWheelEffects(activate);
            isWheelEffectsActive = activate;

            if (activate)
            {
                BLsmoke.Emit(10); // Emit a burst of smoke particles
                BRsmoke.Emit(10);
            }
        }
    }

    public void ActivateWheelEffects(bool activate)
    {
        var blTrailRenderer = BLwheelEffect.GetComponentInChildren<TrailRenderer>();
        var brTrailRenderer = BRwheelEffect.GetComponentInChildren<TrailRenderer>();

        blTrailRenderer.emitting = activate;
        brTrailRenderer.emitting = activate;
    }

    public void PlaySkidSound()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isSkidSoundPlaying && skidSound != null)
        {
            wheelAudioSource.clip = skidSound;
            wheelAudioSource.loop = true;
            wheelAudioSource.Play();
            isSkidSoundPlaying = true;
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            wheelAudioSource.Stop();
            isSkidSoundPlaying = false;
        }
    }
    public void StartNitrous()
    {
        // Start emitting nitrous particles
        BLnitrous.Emit(1);
        BRnitrous.Emit(1);
        // Add any other nitrous effects you want here
    }
    public void StopNitrous()
    {
        // Stop emitting nitrous particles
        BLnitrous.Stop();
        BRnitrous.Stop();
        // Add any other nitrous effects you want to stop here
    }

}
