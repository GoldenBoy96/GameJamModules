using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    public float minRad = 0f;
    public float maxRad = 0f;


    // Start is called before the first frame update
    void Start()
    {
        
        //InvokeRepeating("Test", 2f, 2f);
        StartCoroutine(SpawnMeme(GameController.Instance.enermyPrefabs[Random.Range(0, GameController.Instance.enermyPrefabs.Count)], minRad, maxRad, Random.Range(2f, 7f)));
    }

    // Update is called once per frame
    void Update()
    {

    }

    

    public IEnumerator SpawnMeme(GameObject enermyPrefab, float minRad, float maxRad, float delay)
    {
        int luckyNum1 = Random.Range(0, 10);
        int luckyNum2 = Random.Range(0, 10);
        if (luckyNum1 == luckyNum2)
        {
            GameObject giftCat = Instantiate(GameController.Instance.giftCatPrefab);
            giftCat.transform.position = transform.position;
        }

        GameObject newEnermy = GameController.Instance.enermyPools[GameController.Instance.enermyPrefabs.IndexOf(enermyPrefab)].Pop();
        newEnermy.transform.localPosition = transform.position;
        newEnermy.transform.rotation = transform.rotation;
        newEnermy.transform.Rotate(0, 0, Random.Range(minRad, maxRad) , Space.Self);
        StartCoroutine(PushBackToPool(enermyPrefab, newEnermy));
        yield return new WaitForSeconds(delay);
        StartCoroutine(SpawnMeme(GameController.Instance.enermyPrefabs[Random.Range(0, GameController.Instance.enermyPrefabs.Count)], minRad, maxRad, Random.Range(2f, 7f)));
    }

    public IEnumerator PushBackToPool(GameObject enermyPrefab, GameObject enermy)
    {
        yield return new WaitForSeconds(30f);
        GameController.Instance.enermyPools[GameController.Instance.enermyPrefabs.IndexOf(enermyPrefab)].Push(enermy);
    }
}
