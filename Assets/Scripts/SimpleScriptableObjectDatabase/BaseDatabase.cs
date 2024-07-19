using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

//--------------------------------------------------------------------------
// Inherit from this class to create simple database using Scriptable Object
//--------------------------------------------------------------------------
public class BaseDatabase<T> : AbstractDatabase where T : IDatabaseItem
{
	[SerializeField] private List<T> _items = new List<T>();

	#region Properties

	public List<T> Items
	{
		get => _items;
		private set => _items = value;
	}

	#endregion

	#region Mono

#if UNITY_EDITOR

	private void OnValidate()
	{
		EnsureUniqueIDs();
	}

#endif

	#endregion

	#region Public

	public T GetItem(IDatabaseItem databaseItem) => GetItem(databaseItem.ID);

	public T GetItem(int id) => Items.Find(item => item.ID == id);

	public List<T> GetItems() => Items;

	public bool TryAddItem(T item)
	{
		if (Contains(item) || ContainsEqualsItem(item)) { return false; }

		Items.Add(item);
		EnsureUniqueIDs();

		return true;
	}

	public bool TryRemoveItem(T item)
	{
		if (!Contains(item)) { return false; }

		Items.Remove(item);
		EnsureUniqueIDs();

		return true;
	}

	public bool ContainsEqualsItem(T item)
	{
		foreach (var existingItem in Items)
		{
			if (existingItem.IsEquals(item))
			{
				return true;
			}
		}

		return false;
	}

	public bool Contains(T item)
	{
		return Items.Contains(item);
	}

	#endregion

	#region Private

	private void EnsureUniqueIDs()
	{
		HashSet<int> existingIDs = new();
		int nextID = 0;

		foreach (T item in Items)
		{
			if (item == null) { continue; }

			// If the item's ID is already taken or is invalid, assign a new one
			while (item.ID <= 0 || existingIDs.Contains(item.ID))
			{
				item.ID = nextID++;
			}

			existingIDs.Add(item.ID);
		}

#if UNITY_EDITOR
		// Make sure the changes are saved in the editor
		EditorUtility.SetDirty(this);
#endif
	}

	#endregion
}

public abstract class AbstractDatabase : ScriptableObject { }