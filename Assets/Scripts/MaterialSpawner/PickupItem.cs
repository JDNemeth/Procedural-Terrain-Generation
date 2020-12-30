using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickupItem : MonoBehaviour
{
    public Text scoreText;
    private int scoreNum;
    private void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.tag == "Cube")
        {
            scoreNum--;
            scoreText.text = scoreNum.ToString();
            Destroy(col.transform.parent.gameObject);

        }
        if (col.gameObject.tag == "Sphere")
        {
            scoreNum++;
            scoreText.text = scoreNum.ToString();
            Destroy(col.transform.parent.gameObject);

        }
    }
}
