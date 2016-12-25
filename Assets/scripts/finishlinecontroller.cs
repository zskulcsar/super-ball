using UnityEngine;
using System.Collections;

public class finishlinecontroller : MonoBehaviour {
    private float startTime;

    private string[] lapTimes = new string[2];

    // Use this for initialization
    private void OnTriggerEnter(Collider other)
    {
        startTime = Time.time;
        lapTimes[1] = lapTimes[0];
        lapTimes[0] = null;
    }

    private void OnGUI()
    {
        showTimer();
    }

    private void showTimer()
    {
        float guiTime = Time.time - startTime;
        //
        int minutes = (int)guiTime / 60;
        int seconds = (int)guiTime % 60;
        int fraction = (int)(guiTime * 100) % 100;

        lapTimes[0] = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, fraction);

        GUI.Label(new Rect(400, 25, 100, 50), lapTimes[0] + "\n" + lapTimes[1]);
    }
}
