using UnityEngine;
namespace HollowPoint
{
    [CreateAssetMenu(menuName = "HollowPoint/Bullet")]
    public class Bullet : ScriptableObject
    {
        [SerializeField] float power = 1f;
        [SerializeField] float verticalPower = 1f;
    }
}
