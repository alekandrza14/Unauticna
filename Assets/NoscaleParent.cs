using UnityEngine;

public enum NoscaleParentSettings
{
    noMove = 0,
    noRotate = 1,
    MoveandRotate = 2,
    palyerY = 3,
    PlayerRayEnd = 4,
    PayerCamera = 5,
    rotateCameraP = 6,
    PlayerPos = 7,
    RotPlayer = 8,
    PatrulPlayer = 9,
    onlyScale = 10,
    Rand1MCube = 11,
    palyerXZ = 12,
    palyerV3 = 13
}

public class NoscaleParent : MonoBehaviour
{
    public Transform Obj;
    public NoscaleParentSettings settings;

    private Transform player;
    private Camera playerCamera;

    private Vector3 directional;
    private float timer;

    private void Start()
    {
        if (settings == NoscaleParentSettings.PatrulPlayer)
        {
            transform.SetParent(new GameObject().transform);
        }

        FindReferences();
    }

    private void FindReferences()
    {
        if (player == null)
        {
            var m = mover.main();

            if (m != null)
                player = m.transform;
        }

        if (playerCamera == null)
        {
            playerCamera = Camera.main;

            if (playerCamera != null)
                Globalprefs.camera = playerCamera;
        }
    }

    private void Update()
    {
        timer += Time.deltaTime;

        switch (settings)
        {
            case NoscaleParentSettings.noMove:

                if (Obj != null)
                    transform.rotation = Obj.rotation;

                break;


            case NoscaleParentSettings.noRotate:

                if (Obj != null)
                    transform.position = Obj.position;

                break;


            case NoscaleParentSettings.MoveandRotate:

                if (Obj != null)
                {
                    transform.position = Obj.position;
                    transform.rotation = Obj.rotation;
                }

                break;


            case NoscaleParentSettings.palyerY:

                if (player != null)
                {
                    Vector3 p = transform.position;
                    p.y = player.position.y;
                    transform.position = p;
                }

                break;


            case NoscaleParentSettings.palyerXZ:

                if (player != null)
                {
                    Vector3 p = transform.position;

                    p.x = player.position.x;
                    p.z = player.position.z;

                    transform.position = p;
                }

                break;


            case NoscaleParentSettings.palyerV3:

                if (player != null)
                    transform.position = player.position;

                break;


            case NoscaleParentSettings.PlayerRayEnd:

                transform.position = MainRay.MainHit.point;

                break;


            case NoscaleParentSettings.PayerCamera:

                if (playerCamera != null)
                {
                    transform.position =
                        playerCamera.transform.position;

                    transform.rotation =
                        playerCamera.transform.rotation;
                }

                break;


            case NoscaleParentSettings.rotateCameraP:

                if (playerCamera != null)
                {
                    transform.rotation =
                        Quaternion.Lerp(
                            transform.rotation,
                            playerCamera.transform.rotation,
                            0.1f
                        );
                }

                break;


            case NoscaleParentSettings.PlayerPos:

                if (playerCamera != null)
                    transform.position =
                        playerCamera.transform.position;

                break;


            case NoscaleParentSettings.RotPlayer:

                if (player != null)
                {
                    transform.rotation =
                        player.rotation;

                    transform.Rotate(0f, 180f, 0f);
                }

                break;


            case NoscaleParentSettings.PatrulPlayer:

                if (player != null)
                {
                    if (timer > 5f)
                    {
                        directional =
                            Global.math.randomCube(-50, 50);

                        timer = 0f;
                    }

                    transform.position =
                        player.position + directional;

                    transform.Rotate(
                        0f,
                        180f,
                        0f
                    );
                }

                break;


            case NoscaleParentSettings.onlyScale:

                if (Obj != null)
                    transform.localScale =
                        Obj.localScale;

                break;


            case NoscaleParentSettings.Rand1MCube:

                if (Obj != null)
                {
                    transform.position =
                        Obj.position +
                        Global.math.randomCube(-100, 100) / 80;
                }

                break;
        }
    }
}