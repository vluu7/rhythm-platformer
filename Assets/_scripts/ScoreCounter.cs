using UnityEngine;
using System.Collections;

public class ScoreCounter : MonoBehaviour
{
    public static int noteScore;
    private static int maxScore;

    /* Code to update score on Collision
    void OnCollisionEnter(Collision other) 
    {
        if(other.name == "note_spark_blue") 
        {
            ScoreCounter.noteScore += 1;
        }
    } */

    public static int GetScore() 
    {
        return noteScore;
    }

    public static void UpdateScore()
    {
        noteScore = noteScore += 1;
    }

}
