using UnityEngine;

public class RecogerSable : MonoBehaviour
{
    public Transform sableLaser;     // Arrastra aquí el sable desde la escena
    public Transform puntoAgarre;    // Arrastra aquí el GameObject vacío en la mano

    public void Agarrar()
    {
        if (sableLaser == null || puntoAgarre == null)
        {
            Debug.LogWarning("Faltan referencias");
            return;
        }

        // Quitar colisión si tiene
        Collider col = sableLaser.GetComponent<Collider>();
        if (col) col.enabled = false;

        // Pegar el sable a la mano
        sableLaser.SetParent(puntoAgarre);
        sableLaser.localPosition = Vector3.zero;
        sableLaser.localRotation = Quaternion.identity;

        Debug.Log("¡Sable agarrado!");
    }
}
