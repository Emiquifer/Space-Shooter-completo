using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private float velocidad;
    [SerializeField] private float ratioDisparo;
    [SerializeField] private GameObject disparoPrefab;
    [SerializeField] private GameObject spawnPoint;
    [SerializeField] private GameObject spawnPointDual;
    [SerializeField] private GameManager gameManager;

    private float timer = 0.5f;
    private float vidas = 5;
    private Boolean dualShot = false;
    private GameObject shield;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        shield = this.gameObject.transform.Find("Shield").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Disparar();
    }

    void Movement()
    {
        transform.Translate(new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized * velocidad * Time.deltaTime);

        float xClamped = Mathf.Clamp(transform.position.x, -8.4f, 8.4f);
        float yClamped = Mathf.Clamp(transform.position.y, -4.5f, 4.5f);
        transform.position = new Vector3(xClamped, yClamped, 0);
    }

    void Disparar()
    {  
        timer += 1 * Time.deltaTime;
        if (Input.GetKey(KeyCode.Space) && timer > ratioDisparo)
        {
            if(dualShot)
            {
                foreach(Transform t in spawnPointDual.transform.GetComponentsInChildren<Transform>())
                {
                    if (t.CompareTag("SpawnPoint"))
                    {
                        Instantiate(disparoPrefab, t.position, Quaternion.identity);
                    }
                }

            } else
            {
                Instantiate(disparoPrefab, spawnPoint.transform.position, Quaternion.identity);
            }
            timer = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("DisparoEnemy") || collision.gameObject.CompareTag("Enemy"))
        {
            if (shield.activeSelf)
            {
                shield.SetActive(false);
                Destroy(collision.gameObject);
            }
            else
            {
                vidas -= 1;
                Destroy(collision.gameObject);
                if (vidas == 0)
                {
                    Destroy(this.gameObject);
                    gameManager.EndGame();
                }
            }
        }
        else if (collision.gameObject.CompareTag("Dual"))
        {
            dualShot = true;
            Invoke(nameof(DeleteDual), 5f);
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("ShieldPU"))
        {
            shield.SetActive(true);
            Invoke(nameof(DeleteShield), 5f);
            Destroy(collision.gameObject);

        }
    }

    private void DeleteDual()
    {
        dualShot = false;
    }

    private void DeleteShield()
    {
        shield.SetActive(false);
    }
}
