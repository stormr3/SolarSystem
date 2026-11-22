using UnityEngine;
public class CameraController : MonoBehaviour
{
        public float dst;
        public float mouseSensitivity = 1;
        public bool flipCamAtStart;
        bool turning;
        Vector2 mousePosOld;

        public Vector3 upAxis;
        public Vector3 horizontalAxis;
        public float animSpeed;
        public Vector3 animAxisT;

        Vector3 startPos;
        Quaternion startRot;

        void Start()
        {
            startPos = transform.position;
            startRot = transform.rotation;
            UpdateAxes();

            if (flipCamAtStart) FlipCam();
        }

        void FlipCam()
        {
            Debug.Log("Flip cam");
            transform.position = new Vector3(transform.position.x, -transform.position.y, transform.position.z);
            Vector3 angles = transform.localEulerAngles;
            transform.localEulerAngles = new Vector3(-angles.x, angles.y, angles.z + 180);
        }

        void Update()
        {
            
            if (Input.GetMouseButtonUp(1))
            {
                turning = false;
                UpdateAxes();
            }

            if (Input.GetMouseButton(1))
            {
                if (turning)
                {
                    Vector2 mouseDelta = (Vector2)Input.mousePosition - mousePosOld;
                    Quaternion r = transform.rotation;
                    transform.RotateAround(Vector3.zero, upAxis, mouseDelta.x * mouseSensitivity);
                    transform.RotateAround(Vector3.zero, transform.right, -mouseDelta.y * mouseSensitivity);
                }
                else
                {
                    turning = true;
                }

                mousePosOld = Input.mousePosition;
            }

            if (Input.GetMouseButtonDown(2))
            {
                transform.SetPositionAndRotation(startPos, startRot);
            }

            transform.position = transform.rotation * -Vector3.forward * dst;
        }

        static readonly Vector3Int[] faceDirections = new Vector3Int[]
        {
            Vector3Int.left, Vector3Int.forward, Vector3Int.right, Vector3Int.back, Vector3Int.up, Vector3Int.down
        };

        void UpdateAxes()
        {
            float bestH = float.MinValue;
            float bestV = float.MinValue;

            for (int i = 0; i < 6; i++)
            {
                Vector3 axis = faceDirections[i];
                float v = Vector3.Dot(transform.up, axis);
                float h = Vector3.Dot(transform.right, axis);
                if (v > bestV)
                {
                    bestV = v;
                    upAxis = axis;
                }

                if (h > bestH)
                {
                    bestH = h;
                    horizontalAxis = axis;
                }
            }
        }

}