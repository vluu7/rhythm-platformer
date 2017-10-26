using UnityEngine;
using System.Collections;

public class HitNote : MonoBehaviour
{
    void OnCollisionEnter(Collision col)
    {
        // example collision with blue spark
        if ((col.gameObject.name == "note_spark_blue") /* && (playerObject.color == blue) */)
        {
            ScoreCounter.UpdateScore();
            Destroy(col.gameObject);
        }
    }
}