using System.Collections.Generic;
using UnityEngine;

//-----------------------------------------------------------------------
// This class aims to bring together all databases to facilitate access 
// to them globally through a static getter, like so:
// DatabaseCollection.TryGet<DatabaseType>(out DatabaseType database);
//-----------------------------------------------------------------------

[CreateAssetMenu(menuName = "Database/Database Collection", fileName = "DatabaseCollection", order = 0)]
public class DatabaseCollection : ScriptableObject
{
	private const string DATABASE_ASSETS_PATH = "Database/DatabaseCollection"; //This is the Assets/Resources path to the DatabaseCollection asset in the Assets folder.
	private static DatabaseCollection _instance;

	[SerializeField] private List<AbstractDatabase> _databaseCollection;

	#region Properties

	public static DatabaseCollection Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = Resources.Load<DatabaseCollection>(DATABASE_ASSETS_PATH);
			}

			return _instance;
		}
	}

	#endregion

	#region Public

	public static T Get<T>() where T : AbstractDatabase
	{
		foreach (var database in Instance._databaseCollection)
		{
			if (database is T databaseToReturn)
			{
				return databaseToReturn;
			}
		}

		return null;
	}

	public static bool TryGet<T>(out T databaseToReturn) where T : AbstractDatabase
	{
		databaseToReturn = null;

		foreach (var database in Instance._databaseCollection)
		{
			if (database is T)
			{
				databaseToReturn = (T)database;
				return true;
			}
		}

		return false;
	}

	#endregion
}