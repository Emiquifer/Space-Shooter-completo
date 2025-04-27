using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

namespace Assets.Scripts
{
    public class Spawner : MonoBehaviour
    {

        [SerializeField] private GameObject enemyPrefab;
        [SerializeField] private TextMeshProUGUI levelText;
        // Use this for initialization
        void Start()
        {
            StartCoroutine(SpawnearEnemigos());
        }

        // Update is called once per frame
        void Update()
        {

        }

        IEnumerator SpawnearEnemigos()
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    levelText.text = "Nivel " + (i+1) + "- " + "Oleada " + (j+1);
                    yield return new WaitForSeconds(2f);
                    levelText.text = "";
                    for (int k = 0; k < 10; k++)
                    {
                        Vector3 randomPoint = new Vector3(transform.position.x, Random.Range(-4.5f, 4.5f), transform.position.z);
                        Instantiate(enemyPrefab, randomPoint, Quaternion.identity);
                        yield return new WaitForSeconds(0.5f);
                    }
                    yield return new WaitForSeconds(2f);
                }
                yield return new WaitForSeconds(5f);
            }
        }
    }
}