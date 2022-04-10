using System;

public class Events : SingletonClass<Events>
{
    public Action OnCharacterEnter;
    public Action OnCharacterGetToTheTop;
}
