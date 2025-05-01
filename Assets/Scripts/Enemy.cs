using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float velocidad;
    [SerializeField] private GameObject disparo;
    [SerializeField] private GameObject disparoSpawn;
    [SerializeField] private GameObject powerUpPrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(Disparar());
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Time.deltaTime * velocidad * new Vector3(-1, 0, 0));
    }

    IEnumerator Disparar()
    {
        while (true)
        {
            Instantiate(disparo, disparoSpawn.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(2.5f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("DisparoPlayer"))
        {
            if(Random.Range(1,3) == 1)
            {
                Instantiate(powerUpPrefab, this.gameObject.transform.position, Quaternion.identity);
            }
            Destroy(this.gameObject);
            Destroy(collision.gameObject);

        }
    }
}
