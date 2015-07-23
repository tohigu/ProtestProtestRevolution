using UnityEngine;
using System.Collections;

public class Status : MonoBehaviour {

    public string status;
    TextMesh textMesh;

    void Awake()
    {
        textMesh = GetComponent<TextMesh>();
    }

    public void ChangeStatus(string status)
    {
        while (status.Length < 10)
            status = "STATUS: " + status;
        textMesh.text = status;
    }
}
