using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    // variables

    [SerializeField] Color32 hasPackageColor = new Color32 (0, 1, 1, 1); //color cuando tiene el paquete
    [SerializeField] Color32 hasNoPackageColor = new Color32 (0, 0, 0, 1); //color cuando NO tiene el paquete

    [SerializeField] float destroyDelay = 1.0f; // tiempo que tardará en destruirse el objeto con tag paquete (1 segundo)
    
    bool hasPackage; //siempre se inicializa como falso en Unity

    //referencia a nuestro sprite renderer
    SpriteRenderer spriteRenderer;

    void Start() 
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // OnCollisionEnter
    private void OnCollisionEnter2D(Collision2D other) 
    {
        Debug.Log("¡¡¡AHHHHH me golpeaste mamahuevo!!!");
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        // Debug.Log("Estas en la zona naranja!!!!!");
        
        if(other.tag == "Package" && !hasPackage) //comprobamos que no tiene más de un paquete
        {
            Debug.Log("Paquete recogido!!!");
            hasPackage = true;
            spriteRenderer.color = hasPackageColor;
            Destroy(other.gameObject, destroyDelay); // destruimos el objeto cuando ya no es necesario 
        }

        if(other.tag == "Customer" && hasPackage) // no es necesario el == true, porque siempre quiere probar el verdadero
        {
            Debug.Log("Paquete entregado!!!");
            hasPackage = false; //le quitamos el paquete para que no haga puntos infinitos
            spriteRenderer.color = hasNoPackageColor;
        }
    }
}