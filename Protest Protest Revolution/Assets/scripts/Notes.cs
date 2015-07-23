using UnityEngine;
using System.Collections;

public class Notes : MonoBehaviour
{

    [SerializeField]
    private GameObject red;
    [SerializeField]
    private GameObject blue;
    [SerializeField]
    private GameObject green;
    [SerializeField]
    private GameObject yellow;

    private Vector3 redPos;
    private Vector3 bluePos;
    private Vector3 greenPos;
    private Vector3 yellowPos;

    private float randomTimer;
    private float randomTimer2;
    private float randomTimer3;
    private float randomTimer4;

	// Use this for initialization
	void Start ()
	{
	    redPos = new Vector3(-4.56f, 8f, -1f);
	    bluePos = new Vector3(-3.06f, 8f, -1f);
	    greenPos = new Vector3(-1.565f, 8f, -1f);
	    yellowPos = new Vector3(-0.058f, 8f, -1f);

	    randomTimer = Random.Range(1f, 4f);
        randomTimer2 = Random.Range(12f, 12.5f);
	    randomTimer3 = Random.Range(5f, 10f);
	    randomTimer4 = Random.Range(22f, 33f);
	}

    void Update()
    {
        CreateRed();
        CreateBlue();
        CreateGreen();
        CreateYellow();
    }

    void CreateRed()
    {
        
        randomTimer -= Time.deltaTime;
        if (randomTimer <= 0f)
        {
            GameObject obj = (GameObject)Instantiate(red, redPos, Quaternion.identity);
            obj.GetComponent<Rigidbody>().velocity = new Vector3(0, -10f, 0);
            randomTimer = Random.Range(10f, 15f);
        }
    }

    void CreateBlue()
    {
        randomTimer2 -= Time.deltaTime;
        if (randomTimer2 <= 0f)
        {
            GameObject obj = (GameObject)Instantiate(blue, bluePos, Quaternion.identity);
            obj.GetComponent<Rigidbody>().velocity = new Vector3(0, -5f, 0);

            randomTimer2 = Random.Range(5f, 10f);
        }
    }

    void CreateGreen()
    {
        randomTimer3 -= Time.deltaTime;
        if (randomTimer3 <= 0f)
        {
            GameObject obj = (GameObject)Instantiate(green, greenPos, Quaternion.identity);
            obj.GetComponent<Rigidbody>().velocity = new Vector3(0, -7f, 0);
            randomTimer3 = Random.Range(5f, 20f);
        }
    }

    void CreateYellow()
    {
        randomTimer4 -= Time.deltaTime;
        if (randomTimer4 <= 0f)
        {
            GameObject obj = (GameObject)Instantiate(yellow, yellowPos, Quaternion.identity);
            obj.GetComponent<Rigidbody>().velocity = new Vector3(0, -3.5f, 0);
            randomTimer4 = Random.Range(10f, 20f);
        }
    }


}
