namespace Logic.Consumables
{
    public interface IConsumablesSpawner
    {
        void ReturnConsumable();
        void Initialize();
        void RandomSpawn();
    }
}