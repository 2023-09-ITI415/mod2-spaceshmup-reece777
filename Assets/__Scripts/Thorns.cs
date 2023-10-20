using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Thorns : MonoBehaviour
{
    public bool HasThorns = false;
    public Slider countdownSlider;
    private float countdownTime = 10.0f;
    private bool countdownStarted = false;

    // Start is called before the first frame update
    void Start()
    {
        countdownTime -= Time.deltaTime;
        //gradually fills the slider
        countdownSlider.value = Mathf.Lerp(10, 0, countdownTime / 10);
    }

    // Update is called once per frame
    void Update()
    {
        //If T is pressed, Thorns is set to true
        

       
           

            //timer ends after 10 seconds
            if(countdownTime <= 0.5f)
            {
                countdownStarted = false;
                HasThorns = false;

                Debug.Log("Thorns is finished");
            }

        

        else if (Input.GetKeyDown(KeyCode.T) && HasThorns == false)
        {
            HasThorns = true;
            Debug.Log("Thorns set to true");

            //begins timer

            countdownStarted = true;
            countdownTime = 10.0f;
        }
    }
}
