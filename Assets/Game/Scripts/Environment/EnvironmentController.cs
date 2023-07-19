using UnityEngine;

public class EnvironmentController : MonoBehaviour
{
    [SerializeField] Seasons currentSeason;
    [SerializeField] GameObject[] seasonObjects;
    private int previousSeasonIndex;

    public void Awake()
    {
        foreach (var season in seasonObjects)
        {
            season.SetActive(false);
        }
        GameInput.Instance.OnPlayerChangeEnvironment += OnPlayerChangeEnvironment;
    }

    private void OnPlayerChangeEnvironment(object sender, System.EventArgs e)
    {
        previousSeasonIndex = (int)currentSeason;
        seasonObjects[previousSeasonIndex].SetActive(false);

        int nextSeasonIndex = (((int)currentSeason) + 1) % 4;
        Seasons nextSeasonValue = (Seasons)nextSeasonIndex;
        currentSeason = nextSeasonValue;

        seasonObjects[nextSeasonIndex].SetActive(true);
    }

    public void Start()
    {
        switch (currentSeason)
        {
            case Seasons.Spring:
                seasonObjects[0].SetActive(true);
                break;
            case Seasons.Summer:
                seasonObjects[1].SetActive(true);
                break;
            case Seasons.Autumn:
                seasonObjects[2].SetActive(true);
                break;
            case Seasons.Winter:
                seasonObjects[3].SetActive(true);
                break;
            default: 
                break;
        }
    }
    private void OnDestroy()
    {
        GameInput.Instance.OnPlayerChangeEnvironment -= OnPlayerChangeEnvironment;
    }
}
