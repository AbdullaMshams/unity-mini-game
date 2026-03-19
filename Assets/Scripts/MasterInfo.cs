using UnityEngine;

public class MasterInfo : MonoBehaviour
{

    public static int coinCount = 0;
    [SerializeField] GameObject coinDisplay;
    public static int gemCount = 0;
    public static int distanceRun;
    [SerializeField] int internalDistance;

    // Update is called once per frame
    void Update()
    {
        internalDistance = distanceRun;
      coinDisplay.GetComponent<TMPro.TMP_Text>().text = "Coins: " + coinCount;
    }
}
