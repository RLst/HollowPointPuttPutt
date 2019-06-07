using UnityEngine;
namespace HollowPoint
{
    public class PlayerAim : MonoBehaviour
    {
        [SerializeField] LineRenderer trajectoryLine;
        [SerializeField] float lineLength = 5f;
        Gun gun;

        void Awake()
        {
            gun = GetComponentInChildren<Gun>();
        }

        void Start()
        {
            //Line renderer uses world space
            trajectoryLine.useWorldSpace = true;
        }

        void Update()
        {
            DrawTrajectoryLine();
        }

        void DrawTrajectoryLine()
        {
            //If the gun is aiming within the bounds of the ball
            if (gun.Raycast<Ball>(out Ball ball, out RaycastHit hitInfo))
            {
                //Get normalized trajectory vector
                var trajectory = (ball.transform.position - hitInfo.point).normalized;

                //Draw trajectory line from the center of the ball
                Vector3[] linePoints = { ball.transform.position, ball.transform.position + trajectory * lineLength };
                trajectoryLine.SetPositions(linePoints);
            }
            //Otherwise don't set the trajectory line
            else {
                Vector3[] linePoints = { transform.position + transform.forward * 1f - transform.right * 1f, transform.position + transform.forward * 1f + transform.right * 1f };
                trajectoryLine.SetPositions(linePoints);
            }
        }

    }
}
