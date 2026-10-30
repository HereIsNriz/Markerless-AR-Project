using UnityEngine;

public static class AnimalCollection
{
    private const string CaughtPrefix = "AnimalCaught_";

    public static bool IsCaught(string animalId)
    {
        if (string.IsNullOrEmpty(animalId))
            return false;

        return PlayerPrefs.GetInt(CaughtPrefix + animalId, 0) == 1;
    }

    public static bool CatchAnimal(string animalId)
    {
        if (string.IsNullOrEmpty(animalId) || IsCaught(animalId))
            return false;

        PlayerPrefs.SetInt(CaughtPrefix + animalId, 1);
        PlayerPrefs.Save();

        return true;
    }
}