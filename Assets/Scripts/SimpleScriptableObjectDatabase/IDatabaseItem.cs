/*
We must implement this interface in the objects that 
will be the database items, so we can use the ID property!
*/
public interface IDatabaseItem
{
	int ID { get; set; }
	bool IsEquals(IDatabaseItem other);
}