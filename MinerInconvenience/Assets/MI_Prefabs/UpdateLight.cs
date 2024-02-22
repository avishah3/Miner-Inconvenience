using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class UpdateLight : MonoBehaviour
{
    public AudioClip enterTriggerSound;
    private AudioSource audioSource;
    public float albedoIncreaseRate = 0.1f;
    private Material cubeMaterial;
    public GameObject caveLight;
    private bool isTriggered = false;

    Color currentAlbedo;
    private void Start()
    {
        caveLight = GameObject.Find("CaveLight");
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            // If AudioSource component is not already attached, add it
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Set the assigned audio clip
        audioSource.clip = enterTriggerSound;
        


    }

    void Update()
    {
        if (isTriggered)
        {
            cubeMaterial = caveLight.GetComponent<Renderer>().material;
            // Get the current albedo color
            Color currentAlbedo = cubeMaterial.color;
            // Increase the albedo value over time
            float newAlbedoValue = Mathf.Clamp01(currentAlbedo.r + albedoIncreaseRate * Time.deltaTime);
            // Update the albedo color
            cubeMaterial.color = new Color(newAlbedoValue, newAlbedoValue, newAlbedoValue);
            Invoke("DestroyOBJ", 0.2f);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (audioSource != null && enterTriggerSound != null)
        {
            audioSource.Play();
        }
        isTriggered = true;
    }

    public void DestroyOBJ()
    {
        Destroy(gameObject);
    }
}