using UnityEngine;
using UnityEngine.UI;
using TMPro;
[RequireComponent(typeof(Canvas))]
public class PlantUI : MonoBehaviour
{
    private int time;
    private int currentTime;

    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private Slider timerSlider;
    private void Start()
    {
        GetComponent<Canvas>().worldCamera = Camera.main;
    }
    public void SetTime(int time)
    {
        this.time = time;
    }
    public void SetCurrentTime(int time)
    {
        currentTime = time;
        timerText.text = time.ToString();
        timerSlider.value = 1 - ((float)currentTime / this.time);
        if(currentTime == 0)
        {
            timerText.gameObject.SetActive(false);
            timerSlider.gameObject.SetActive(false);
        }
        else
        {
            timerText.gameObject.SetActive(true);
            timerSlider.gameObject.SetActive(true);
        }
    }
    private void Update()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - Camera.main.transform.position);
    }
}