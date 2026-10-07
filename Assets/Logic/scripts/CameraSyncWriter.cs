using System;
using System.IO.MemoryMappedFiles;
using UnityEngine;

public class CameraSyncWriter : MonoBehaviour
{
    public Camera sourceCamera;

    private MemoryMappedFile mmf;
    private MemoryMappedViewAccessor view;

    private const long Size = 128;

    void Start()
    {
        if (sourceCamera == null)
            sourceCamera = Camera.main;

        mmf = MemoryMappedFile.CreateOrOpen(
            "UnauticnaCameraSync",
            Size,
            MemoryMappedFileAccess.ReadWrite
        );

        view = mmf.CreateViewAccessor(
            0,
            Size,
            MemoryMappedFileAccess.Write
        );
    }

    void LateUpdate()
    {
        if (sourceCamera == null)
            return;

        Vector3 p = sourceCamera.transform.position;
        Quaternion r = sourceCamera.transform.rotation;

        // Позиция
        view.Write(0, p.x);
        view.Write(4, p.y);
        view.Write(8, p.z);

        // Rotation
        view.Write(12, r.x);
        view.Write(16, r.y);
        view.Write(20, r.z);
        view.Write(24, r.w);

        // FOV
        view.Write(28, sourceCamera.fieldOfView);

        // Размер
        view.Write(32, Screen.width);
        view.Write(36, Screen.height);

        // Флаг "данные готовы"
        view.Write(40, 1);
    }

    void OnDestroy()
    {
        view?.Dispose();
        mmf?.Dispose();
    }
}