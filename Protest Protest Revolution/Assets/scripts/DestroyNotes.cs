using UnityEngine;
using System.Collections;

public class DestroyNotes : MonoBehaviour
{
    [SerializeField] private string button;

    void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.tag == "Good" && Input.GetKey(button))
        
        {
            GameObject.FindGameObjectWithTag("Score").GetComponent<Score>().Increment(50);
            GameObject.FindGameObjectWithTag("Status").GetComponent<Status>().ChangeStatus("Good!");
            GameObject.Destroy(gameObject);
            print("Reached good");
        }
        else if (col.gameObject.tag == "Great" && Input.GetKey(button))
        {
            GameObject.FindGameObjectWithTag("Score").GetComponent<Score>().Increment(100);
            GameObject.FindGameObjectWithTag("Status").GetComponent<Status>().ChangeStatus("Great!");
            GameObject.Destroy(gameObject);
            print("Reached great");
        }
        else if (col.gameObject.tag == "Bad")
        {
            GameObject.FindGameObjectWithTag("Status").GetComponent<Status>().ChangeStatus("Bad!");
            GameObject.Destroy(gameObject);
            print("Reached bad");
        }

    }
}
