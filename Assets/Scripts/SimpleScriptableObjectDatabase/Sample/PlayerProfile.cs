using UnityEngine;

[System.Serializable]
public class PlayerProfile : IDatabaseItem
{
	public int ID { get; set; }

	[SerializeField] private string _name;
	[SerializeField] private int _age;
	[SerializeField] private bool _isNoob;

	public string Name => _name;
	public int Age => _age;
	public bool IsNoob => _isNoob;

	public static PlayerProfile Create(string name, int age, bool IsNoob)
	{
		var profile = new PlayerProfile()
		{
			_name = name,
			_age = age,
			_isNoob = IsNoob
		};

		return profile;
	}

	public bool IsEquals(IDatabaseItem other)
	{
		if (other is PlayerProfile otherProfile)
		{
			return _name == otherProfile._name &&
				   _age == otherProfile._age &&
				   _isNoob == otherProfile._isNoob;
		}

		return false;
	}
}