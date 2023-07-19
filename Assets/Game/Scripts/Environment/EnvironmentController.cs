using UnityEngine;

public class EnvironmentController : MonoBehaviour
{
    [SerializeField] Seasons currentSeason;
    [SerializeField] GameObject[] seasonObjects;
    private int previousSeasonIndex;
    
    public void Start()
    {
        previousSeasonIndex = (int)currentSeason;
        seasonObjects[previousSeasonIndex].SetActive(false);
        switch (currentSeason)
        {
            case Seasons.Winter:
                seasonObjects[0].SetActive(true);
                break;
            case Seasons.Summer:
                seasonObjects[1].SetActive(true);
                break;
            case Seasons.Autumn:
                seasonObjects[2].SetActive(true);
                break;
            case Seasons.Spring:
                seasonObjects[3].SetActive(true);
                break;
            default: 
                break;
        }
    }
    public void ChangeEnvironment()
    {
        previousSeasonIndex = (int)currentSeason;
        seasonObjects[previousSeasonIndex].SetActive(false);
        
        int nextSeasonIndex = (((int)currentSeason)+1) % 4;
        Seasons nextSeasonValue = (Seasons)nextSeasonIndex;     
        currentSeason = nextSeasonValue;
        
        seasonObjects[nextSeasonIndex].SetActive(true); 
    }
}
