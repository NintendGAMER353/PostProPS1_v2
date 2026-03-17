using UnityEngine;

public class InterferencesController : MonoBehaviour
{
    public Material InterferencesMaterial;
    public GameObject Pedro;

    [Header("Distancias")]
    public float minDistance = 1f;   // Muy cerca → máximo efecto
    public float maxDistance = 10f;  // Lejos → sin efecto

    [Header("Nitidez")]
    public float maxSharpness = 1f;
    public float minSharpness = 0f;

    private void Update()
    {
        if (Pedro == null || InterferencesMaterial == null) return;

        // Distancia desde la CÁMARA (este objeto) a Pedro
        float distance = Vector3.Distance(transform.position, Pedro.transform.position);

        // Normalizamos (0 = cerca, 1 = lejos)
        float t = Mathf.InverseLerp(minDistance, maxDistance, distance);

        // Invertimos para que cerca = más nitidez
        float sharpness = Mathf.Lerp(maxSharpness, minSharpness, t);

        // Aplicamos al material
        InterferencesMaterial.SetFloat("_Nitidez", sharpness);
    }
}