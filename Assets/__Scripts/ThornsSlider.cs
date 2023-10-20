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
        countdownSlider.value = 0;
        StartCoroutine (FillSliderOverTime());

        ThornsReady.gameObject.SetActive(false);
        ThornsNotReady.gameObject.SetActive(true);
    }

    IEnumerator FillSliderOverTime()
    {
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
            ThornsReady.gameObject.SetActive(true);
            ThornsNotReady.gameObject.SetActive(false);
        }

        if (countdownSlider.value == 10 && Input.GetKeyDown(KeyCode.T))
        {
            Debug.Log("Thorns is Active");
            HasThorns = true;
            StartCoroutine(DecreaseSliderOverTime());

            ThornsReady.gameObject.SetActive(false);
            ThornsNotReady.gameObject.SetActive(true);
        }

        if(countdownSlider.value <= 0.01f)
        {
            HasThorns = false;
            Debug.Log("Thorns is Inactive");
            StartCoroutine(FillSliderOverTime());

            ThornsReady.gameObject.SetActive(false);
            ThornsNotReady.gameObject.SetActive(true);
        }
    }

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
