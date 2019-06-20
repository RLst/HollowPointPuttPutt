using UnityEngine;
using UnityEngine.UI;
namespace HollowPoint
{
    [CreateAssetMenu(menuName = "HollowPoint/Bullet")]
    public class Bullet : ScriptableObject
    {
        public Image icon;
        public float maxPower = 10f;
        



        public float verticalPower = 1f;  //Probably not needed
    }
}
