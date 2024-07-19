using UnityEngine;

public class TestPlayerProfileDatabase : MonoBehaviour
{
	private void Start()
	{
		if (!DatabaseCollection.TryGet(out PlayerProfileDatabase playerProfileDatabase)) { return; }

		//Getting a player profile from the database by ID
		var desiredId = 1;
		var playerProfile = playerProfileDatabase.GetItem(desiredId);
		if (playerProfile != null)
		{
			Debug.Log($"[TestPlayerProfileDatabase] Printing player profile of ID {desiredId}");
			Debug.Log($"[TestPlayerProfileDatabase] Player profile: {playerProfile.Name}, Age: {playerProfile.Age}, IsNoob: {playerProfile.IsNoob}");
		}

		//Getting all profiles from the database
		var allProfiles = playerProfileDatabase.GetItems();
		Debug.Log($"[TestPlayerProfileDatabase] Printing all profiles:");
		foreach (var profile in allProfiles)
		{
			Debug.Log($"[TestPlayerProfileDatabase] Player profile of ID {profile.ID}: {profile.Name}, Age: {profile.Age}, IsNoob: {profile.IsNoob}");
		}

		//Adding a new player profile to the database
		var newProfile = PlayerProfile.Create("Maya", 25, false);
		if (playerProfileDatabase.TryAddItem(newProfile))
		{
			Debug.Log($"[TestPlayerProfileDatabase] Player profile {newProfile.Name} added successfully.");
		}
	}
}
