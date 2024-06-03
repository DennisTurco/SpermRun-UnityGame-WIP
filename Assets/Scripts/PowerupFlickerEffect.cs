using UnityEngine;
using System.Collections;

public class PowerupFlickerEffect : MonoBehaviour
{
    [Tooltip("Materials to switch between during the flash.")]
    [SerializeField] private Material[] flickerMaterials;

    [Tooltip("Total duration of the flicker effect.")]
    [SerializeField] private float totalDuration = 7f;

    [Tooltip("Interval between color changes.")]
    [SerializeField] private float flickerInterval = 0.1f;

    // The SpriteRenderer that should flicker.
    private SpriteRenderer spriteRenderer;

    // The material that was in use when the script started.
    private Material originalMaterial;

    // The currently running coroutine.
    private Coroutine flickerRoutine;

    void Start()
    {
        // Get the SpriteRenderer to be used.
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Get the material that the SpriteRenderer uses.
        originalMaterial = spriteRenderer.material;
    }

    public void StartFlicker()
    {
        // If the flickerRoutine is not null, then it is currently running.
        if (flickerRoutine != null)
        {
            // Stop the current routine before starting a new one.
            StopCoroutine(flickerRoutine);
        }

        // Start the Coroutine and store the reference for it.
        flickerRoutine = StartCoroutine(FlickerRoutine());
    }

    private IEnumerator FlickerRoutine()
    {
        float elapsed = 0f;
        int materialIndex = 0;

        while (elapsed < totalDuration)
        {
            // Cycle through the materials.
            spriteRenderer.material = flickerMaterials[materialIndex];
            materialIndex = (materialIndex + 1) % flickerMaterials.Length;

            yield return new WaitForSeconds(flickerInterval);
            elapsed += flickerInterval;
        }

        // After the flicker effect ends, revert to the original material.
        spriteRenderer.material = originalMaterial;

        // Set the routine to null, signaling that it's finished.
        flickerRoutine = null;
    }

    public float GetTotalDuration()
    {
        return totalDuration;
    }
}
