using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThornsSlider : MonoBehaviour
{
    public bool HasThorns = false;
    public Slider countdownSlider;
    private float countdownDuration = 10.0f;
    public Text ThornsReady;
    public Text ThornsNotReady;

    // Start is called before the first frame update
    void Start()
    {
        //begins filling slider
        countdownSlider.value = 0;
        StartCoroutine (FillSliderOverTime());

        //ready indicator set to false
        ThornsReady.gameObject.SetActive(false);
        ThornsNotReady.gameObject.SetActive(true);
    }

    IEnumerator FillSliderOverTime()
    {
        //fills bar over time
        //uses a coroutine instead of method because needs to be excecuted
        //asynchronously over multiple frames.

        float elapsedTime = 0f;
        while(elapsedTime < 10.0f)
        {
            countdownSlider.value = Mathf.Lerp(0, 10, elapsedTime / 10);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        countdownSlider.value = 10;
    }

    // Update is called once per frame
    void Update()
    {
        if (countdownSlider.value == 10)
        {
            //when slider is full, indicates to player that thorns is ready
            ThornsReady.gameObject.SetActive(true);
            ThornsNotReady.gameObject.SetActive(false);
        }

        if (countdownSlider.value == 10 && Input.GetKeyDown(KeyCode.T))
        {
            //if bar is full and player presses T, thorns is activated and slider 
            //begins depleting
            Debug.Log("Thorns is Active");
            HasThorns = true;
            StartCoroutine(DecreaseSliderOverTime());

            ThornsReady.gameObject.SetActive(false);
            ThornsNotReady.gameObject.SetActive(true);
        }

        if(countdownSlider.value <= 0.01f)
        {
            //thorns is set to false when the slider is empty
            HasThorns = false;
            Debug.Log("Thorns is Inactive");
            //slider begins filling up again
            StartCoroutine(FillSliderOverTime());

            //text indicates that thorns is not ready. 
            ThornsReady.gameObject.SetActive(false);
            ThornsNotReady.gameObject.SetActive(true);
        }
    }

    //coroutine that smoothly decreases slider to 0 over 10 seconds
    IEnumerator DecreaseSliderOverTime()
    {
        float elapsedTime = 0f;

        while(elapsedTime < countdownDuration)
        {
            float normalizedTime = elapsedTime / countdownDuration;
            countdownSlider.value = Mathf.Lerp(10, 0, normalizedTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }
}
