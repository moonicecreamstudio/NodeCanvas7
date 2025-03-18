using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitBasketManager : MonoBehaviour
{
    public float numberOfOranges;
    public float numberOfApples;
    public GameObject decorativeOrange;
    public GameObject decorativeApple;
    public GameObject orangeArea;
    public GameObject appleArea;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Places the fruit in the corresponding basket
    public void AddApple()
    {
        Instantiate(decorativeApple, new Vector3(Random.Range(appleArea.transform.position.x + (appleArea.transform.localScale.x / 2), appleArea.transform.position.x - (appleArea.transform.localScale.x / 2)),
                                                Random.Range(appleArea.transform.position.y + (appleArea.transform.localScale.y / 2), appleArea.transform.position.y - (appleArea.transform.localScale.y / 2)),
                                                Random.Range(appleArea.transform.position.z + (appleArea.transform.localScale.z / 2), appleArea.transform.position.z - (appleArea.transform.localScale.z / 2))),
                                                Quaternion.identity);
    }

    public void AddOrange()
    {
        Instantiate(decorativeOrange, new Vector3(Random.Range(orangeArea.transform.position.x + (orangeArea.transform.localScale.x / 2), orangeArea.transform.position.x - (orangeArea.transform.localScale.x / 2)),
                                        Random.Range(orangeArea.transform.position.y + (orangeArea.transform.localScale.y / 2), orangeArea.transform.position.y - (orangeArea.transform.localScale.y / 2)),
                                        Random.Range(orangeArea.transform.position.z + (orangeArea.transform.localScale.z / 2), orangeArea.transform.position.z - (orangeArea.transform.localScale.z / 2))),
                                        Quaternion.identity);
    }
}
