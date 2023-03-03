public struct CRotator : IEcsResetComponent
{
    public float Speed;

    public void Reset()
    {
        Speed = 1;
    }
}