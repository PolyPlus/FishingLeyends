using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuevePez : MonoBehaviour
{
    public float speed;
    private GameObject latIz;
    private GameObject latDer;
    public bool derecha;

    
    // Start is called before the first frame update
    void Start()
    {
        latIz = GameObject.FindGameObjectWithTag("LatIz");
        latDer = GameObject.FindGameObjectWithTag("LatDer");
        if (transform.position==latIz.transform.position)  //Si se te escapa el powerUp y pasa ese margen
        {
            derecha = false;
        }
        else
        {
            derecha = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (derecha)
        {
            transform.Translate(new Vector2(-1, 0f) * Time.deltaTime * speed); //Se mueve en y (hacia abajo) cada frame
            if (transform.position.x < latIz.transform.position.x)  //Si se te escapa el powerUp y pasa ese margen
            {
                Destroy(gameObject); //Lo elimina
            }
        }
        else
        {
            transform.Translate(new Vector2(-1, 0f) * Time.deltaTime * speed); //Se mueve en y (hacia abajo) cada frame
            if (transform.position.x > latDer.transform.position.x)  //Si se te escapa el powerUp y pasa ese margen
            {
                Destroy(gameObject); //Lo elimina
            }
        }
    }
}