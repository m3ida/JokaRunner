using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    public GameObject thePlatform;
    public Transform generationPoint;
    public float distanceBetween;

    private float platformWidth;

    public float distanceBetweenMin;
    public float distanceBetweenMax;

    private int platformSelector;
    private float[] platformWidths;

    public ObjectPooler[] theObjectPools;

    private float minHeight;
    public Transform maxHeightPoint;
    private float maxHeight;
    public float maxHeightChange;
    private float HeightChange;

    private CoinGenerator theCoinGenerator;
    public float randomCoinThreshold;

    public float randomSpikeThreshold;
    public ObjectPooler SpikePool;

    public float powerupHeight;
    public ObjectPooler powerupPool;
    public float powerupThreshold;


    // Start is called before the first frame update
    void Start()
    {
        platformWidths = new float[theObjectPools.Length];
        
        for(int i = 0; i < theObjectPools.Length; i++)
        {
            platformWidths[i] = theObjectPools[i].pooledObject.GetComponent<BoxCollider2D>().size.x;
        }

        minHeight = transform.position.y;
        maxHeight = maxHeightPoint.position.y;

        theCoinGenerator = FindObjectOfType<CoinGenerator>();

    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.x < generationPoint.position.x)
        {
            distanceBetween = Random.Range(distanceBetweenMin, distanceBetweenMax);

            platformSelector = Random.Range(0, theObjectPools.Length);

            HeightChange = transform.position.y + Random.Range(maxHeightChange, -maxHeightChange);

            if (HeightChange > maxHeight)
            {
                HeightChange = maxHeight;

            } else if (HeightChange < minHeight)
            {
                HeightChange = minHeight;
            }

            if (Random.Range(0f, 100f) < powerupThreshold)
            {
                GameObject newPowerup = powerupPool.GetPooledObject();
                newPowerup.transform.position = transform.position + new Vector3(distanceBetween / 2f, Random.Range(powerupHeight / 2, powerupHeight), 0f);
                newPowerup.SetActive(true);


            }

            transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector]/2) + distanceBetween, HeightChange, transform.position.z);

            //Instantiate(thePlatform, transform.position, transform.rotation);
            GameObject newPlatform = theObjectPools[platformSelector].GetPooledObject();

            newPlatform.transform.position = transform.position;
            newPlatform.transform.rotation = transform.rotation;
            newPlatform.SetActive(true);


            if (Random.Range(0f, 100f) < randomCoinThreshold)
            {
                theCoinGenerator.SpawnCoins(new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z));
            }

            if (Random.Range(0f, 100f) < randomSpikeThreshold)
            {
                if (platformSelector != 0)
                {
                    GameObject newSpike = SpikePool.GetPooledObject();

                    float spikeXPosition = Random.Range(-platformWidths[platformSelector] / 2 + 1f, platformWidths[platformSelector] / 2 - 1f);

                    Vector3 spikeposition = new Vector3(spikeXPosition, 0.5f, 0f);

                    newSpike.transform.position = transform.position + spikeposition;
                    newSpike.transform.rotation = transform.rotation;
                    newSpike.SetActive(true);
                }
            }


                transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector] / 2)  , transform.position.y, transform.position.z);

        }


    }
}
