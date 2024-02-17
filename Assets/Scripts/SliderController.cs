using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{

    int progress = 0;
    public Slider slider;
    public GameObject sliderGO;
    public GameObject check;
    public GameObject text;
    public GameObject text2;
    public GameObject AIFindingPanel;
    public GameObject ResearchPanel;
    public GameObject ResearchSubnodes;
    public GameObject CreationSubnodes;
    public GameObject CreationText;
    public AudioSource audioSource;
    public AudioClip clip;
    int sec = 1;

    private void Start()
    {

    }

    private void Update()
    {
        StartCoroutine(ExampleCoroutine());

        if (progress == 1000)
        {
            //Debug.Log("IN");
            check.SetActive(true);
            text.SetActive(false);
            text2.SetActive(true);
            sliderGO.SetActive(false);
            audioSource.PlayOneShot(clip);
            CreationSubnodes.SetActive(true);
            CreationText.SetActive(true);
        }
    }

    IEnumerator ExampleCoroutine()
    {
        //Print the time of when the function is first called.
        //Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.

        if (progress < 1000)
        {
            if (progress == 500)
            {
                ResearchPanel.SetActive(true);
                ResearchSubnodes.SetActive(true);
                yield return new WaitForSeconds(5);
                progress++;
                slider.GetComponent<RectTransform>().localPosition = new Vector3(5.7f,41.7f,0f);
                AIFindingPanel.SetActive(false);
            }

            else
            {
                progress++;
                slider.value = progress;
                //Debug.Log(progress);
                yield return new WaitForSeconds(1);
            }
        }



        //After we have waited 5 seconds print the time again.
        //Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }

    IEnumerator ExampleCoroutine2()
    {
        yield return new WaitForSeconds(100);
    }


}
