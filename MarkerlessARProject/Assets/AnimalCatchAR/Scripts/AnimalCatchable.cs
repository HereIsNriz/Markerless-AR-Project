using UnityEngine;

public class AnimalCatchable : MonoBehaviour
{
    [Header("Animal Settings")]
    [SerializeField] private string animalId = "cat";
    [SerializeField] private int tapsRequired = 5;

    private int tapCount;

    public string AnimalId => animalId;
    public int TapCount => tapCount;

    public void RegisterTap()
    {
        if (AnimalCollection.IsCaught(animalId))
            return;

        tapCount++;

        Debug.Log(animalId + ": " + tapCount + "/" + tapsRequired + " taps");

        if (tapCount >= tapsRequired)
        {
            if (AnimalCollection.CatchAnimal(animalId))
            {
                Debug.Log(animalId + " caught!");

                Destroy(transform.root.gameObject);
            }
        }
    }
}