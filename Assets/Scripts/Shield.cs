using UnityEngine;

public class Shield : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("DisparoEnemy") || collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            this.gameObject.SetActive(false);
        }
    }
}
