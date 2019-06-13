namespace HollowPoint
{
public interface IInput
{
    //Direction
    UnityEngine.Quaternion rotation { get; }

    //Touchpad
    UnityEngine.Vector2 axis { get; }

    bool touch { get; }
    bool touched { get; }

    bool click { get; }
    bool clicked { get; }

    //Trigger
    bool fire { get; }
    bool fired { get; }

    //Back button
    bool back { get; }
    bool backed { get; }
}
}