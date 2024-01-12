namespace TestWork.Engine.Time
{
    //Using for optimization by avoid Unity loop system and looping not MonoBehaviour objects 
    public interface IGameLoopObject
    {
        void Tick(float deltaTime);
    }
}