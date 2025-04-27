using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] private float velocidad;
    [SerializeField] private Vector3 direccion;
    //Diferencia entre la posicion x de nuestro background con respecto al background hijo
    [SerializeField] private float anchoImagen;

    private Vector3 posicionInicial;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        posicionInicial = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //V=S/T
        float espacio = velocidad * Time.time;
        //Cuando el resto sea 0, significa que hemos recorrido un ciclo de ancho de imagen completo
        float resto = espacio % anchoImagen;
        //La posicion se refresca desde la inicial sumando tanto como resto me quede en la direccion deseada
        transform.position = posicionInicial + resto * direccion;
    }
}
