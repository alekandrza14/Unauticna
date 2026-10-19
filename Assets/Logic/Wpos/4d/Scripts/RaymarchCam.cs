using Unauticna.Mechanics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
[ExecuteInEditMode]

// ****************** Raymarching script that connects to the Shader ****************** 

[AddComponentMenu("Rendering/RayMarching Camera")]
public class RaymarchCam : SceneViewFilter
{

    MultyTransform instance;
    [SerializeField]
    [Header("Global Settings")]
    private Shader _shader;
    ComputeBuffer shapeBuffer;
    ShapeData[] shapeData = new ShapeData[0];
    float nextShapeScan, nextReferenceScan;
    NegativeLight negativeLight;
    int negativeGlasses;
    public void InvalidateScene() { nextShapeScan = 0f; }
    void Awake()
    {
        if (!Application.isPlaying) return;
        PlayerMechanics.Changed += MechanicsChanged;
        PlayerMechanics.Register(this, MechanicId.Raymarch);
        MechanicsChanged();
    }
    // Preserve any editor lifecycle callbacks inherited from SceneViewFilter.
    void MechanicsChanged() { if (!PlayerMechanics.Active(MechanicId.Raymarch)) ReleaseShapeBuffer(); }
    void OnDestroy()
    {
        PlayerMechanics.Changed -= MechanicsChanged;
        ReleaseShapeBuffer();
        if (_raymarchMat != null) DestroyImmediate(_raymarchMat);
        PlayerMechanics.Unregister(this);
    }
    void ReleaseShapeBuffer() { if (shapeBuffer != null) { shapeBuffer.Dispose(); shapeBuffer = null; } }

    public bool mat;

    public Material _raymarchMaterial
    {
        get
        {
            if (!_raymarchMat && _shader)
            {
                _raymarchMat = new Material(_shader);
                _raymarchMat.hideFlags = HideFlags.HideAndDontSave;
            }

            return _raymarchMat;
        }
    }

    private Material _raymarchMat;

    public Camera _camera
    {
        get
        {
            if (!_cam)
            {
                _cam = GetComponent<Camera>();
            }
            return _cam;
        }
    }
    private Camera _cam;
    private float _forceFieldRad;


    // all the variables send to the shader Bools are converted to ints because bools are not supported in shaders
    public Transform _directionalLight;
    public Transform _player;
    public float _precision;
    public Texture2D _globalGeometryTexture;
    public Texture2D _globalGeometryTexture1;
    public Texture2D _globalGeometryTexture2;
    public Texture2D _globalGeometryTexture3;
    public Texture2D _globalGeometryTexture4;
    public Texture2D _globalGeometryTexture5;
    public Texture2D _globalGeometryTexture6;
    public Texture2D _globalGeometryTexture7;
    public Texture2D _globalGeometryTexture8;
    public Texture2D _globalGeometryTexture9;
    public Texture2D _globalGeometryTexture10;
    public Texture2D _globalGeometryTexture11;
    public Texture2D _globalGeometryTexture12;
    public Texture2D _globalGeometryTexture13;
    public float _max_iteration;
    [Header ("Global Transform Settings")]
    public Vector3 _wRotation;
    public float _wPosition;
    [Header("Visual Settings")]
    
    public bool _useNormal;
    [Tooltip ("the number of cellshading cascades, set 0 for smooth lighting")]
    [Range (0,10)]
    public int _nrOfCascades;
    [Range(0, 1)]
    public float _lightIntensity;
    [Space (10)]
    public bool _useShadow;
    public bool _useSoftShadow;
    public bool _useCordinateTexture;
    public float _shadowSoftness;
    public float _maxShadowDistance;
    [Range(0, 1)]
    public float _shadowIntensity;
    [Space(10)]
    [Range(0, 1)]
    public float _aoIntensity;
    [Space(10)]
    [Tooltip ("The color of the depthbuffer")]
    public Color _skyColor;
    [Range(0, 1)]
    public float hue;
    public Color _ChaosColor = Color.white;


    [HideInInspector]
    public int _renderNr = 0;
    [HideInInspector]
    public List<Shape4D> orderedShapes = new List<Shape4D>();


    // the main function that sends the data to the shader
    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        if ((Application.isPlaying && !PlayerMechanics.Active(MechanicId.Raymarch)) || !_raymarchMaterial)
        { Graphics.Blit(source, destination); return; }
        CreateScene();
        SetParameters();



        if (!_raymarchMaterial)
        {
            Graphics.Blit(source, destination);
            return;
        }



        RenderTexture.active = destination;
        _raymarchMaterial.SetTexture("_MainTex", source);

        GL.PushMatrix();
        GL.LoadOrtho();
        _raymarchMaterial.SetPass(0);
        GL.Begin(GL.QUADS);

        //BL
        GL.MultiTexCoord2(0, 0.0f, 0.0f);
        GL.Vertex3(0.0f, 0.0f, 3.0f);

        //BR
        GL.MultiTexCoord2(0, 1.0f, 0.0f);
        GL.Vertex3(1.0f, 0.0f, 2.0f);

        //TR
        GL.MultiTexCoord2(0, 1.0f, 1.0f);
        GL.Vertex3(1.0f, 1.0f, 1.0f);

        //TL
        GL.MultiTexCoord2(0, 0.0f, 1.0f);
        GL.Vertex3(0.0f, 1.0f, 0.0f);

        GL.End();
        GL.PopMatrix();


    }
    private void SetParameters()
    {
        if (Time.realtimeSinceStartup >= nextReferenceScan)
        {
            nextReferenceScan = Time.realtimeSinceStartup + 1f;
            if (!instance) instance = FindFirstObjectByType<MultyTransform>();
            if (!negativeLight) negativeLight = FindFirstObjectByType<NegativeLight>();
            if (Application.isPlaying) negativeGlasses = VarSave.GetInt("НегативныеОчки");
        }
        if (_useNormal)
        {
            _raymarchMaterial.SetInt("_useNormal", 1);
            _raymarchMaterial.SetInt("_nrOfCascades", _nrOfCascades);
        }
        else _raymarchMaterial.SetInt("_useNormal", 0);

        if (_useShadow)
        {
            _raymarchMaterial.SetInt("_useShadow", 1);

            if (_useSoftShadow)
            {
                _raymarchMaterial.SetInt("_useShadow", 2);
                _raymarchMaterial.SetFloat("_shadowSoftness", _shadowSoftness);
            }
        }
        else _raymarchMaterial.SetInt("_useShadow", 0);

        _raymarchMaterial.SetMatrix("_CamFrustrum", CamFrustrum(_camera));
        _raymarchMaterial.SetMatrix("_CamToWorld", _camera.cameraToWorldMatrix);
        _raymarchMaterial.SetFloat("_maxDistance", _camera.farClipPlane);
        _raymarchMaterial.SetTexture("_GeometryTex", _globalGeometryTexture);
        _raymarchMaterial.SetTexture("_GeometryTex1", _globalGeometryTexture1);
        _raymarchMaterial.SetTexture("_GeometryTex2", _globalGeometryTexture2);
        _raymarchMaterial.SetTexture("_GeometryTex3", _globalGeometryTexture3);
        _raymarchMaterial.SetTexture("_GeometryTex4", _globalGeometryTexture4);
        _raymarchMaterial.SetTexture("_GeometryTex5", _globalGeometryTexture5);
        _raymarchMaterial.SetTexture("_GeometryTex6", _globalGeometryTexture6);
        _raymarchMaterial.SetTexture("_GeometryTex7", _globalGeometryTexture7);
        _raymarchMaterial.SetTexture("_GeometryTex8", _globalGeometryTexture8);
        _raymarchMaterial.SetTexture("_GeometryTex9", _globalGeometryTexture9);
        _raymarchMaterial.SetTexture("_GeometryTex10", _globalGeometryTexture10);
        _raymarchMaterial.SetTexture("_GeometryTex11", _globalGeometryTexture11);
        _raymarchMaterial.SetTexture("_GeometryTex12", _globalGeometryTexture12);
        _raymarchMaterial.SetTexture("_GeometryTex13", _globalGeometryTexture13);


        _raymarchMaterial.SetFloat("_precision", _precision);
        if (Application.isPlaying) _raymarchMaterial.SetFloat("_max_iteration", _max_iteration);
        if (!Application.isPlaying) _raymarchMaterial.SetFloat("_max_iteration", _max_iteration/3);
        _raymarchMaterial.SetFloat("_maxShadowDistance", _maxShadowDistance);
        _raymarchMaterial.SetFloat("_lightIntensity", _lightIntensity);
        _raymarchMaterial.SetFloat("_shadowIntensity", _shadowIntensity);
        _raymarchMaterial.SetFloat("_aoIntensity", _aoIntensity);
        _raymarchMaterial.SetFloat("hue", hue);
        _raymarchMaterial.SetVector("_lightDir", _directionalLight ? _directionalLight.forward : Vector3.down);
        _raymarchMaterial.SetVector("_player", _player ? _player.position : Vector3.zero);
        _raymarchMaterial.SetColor("_skyColor", _skyColor);
        _raymarchMaterial.SetColor("_ChaosColor", _ChaosColor);
        _raymarchMaterial.SetInt("_useNegativeLight", negativeLight != null && negativeLight.isActiveAndEnabled ? 1 : 0);
        _raymarchMaterial.SetInt("_useNegative", Globalprefs.item == "НегативныеОчки" || negativeGlasses > 0 ? 1 : 0);
        //_useCordinateTexture
        _raymarchMaterial.SetInt("_use14texture", _useCordinateTexture ? 1 : 0);
        _raymarchMaterial.SetVector("_wRotation", _wRotation * Mathf.Deg2Rad);
        _raymarchMaterial.SetFloat("w", _wPosition);
       if(instance) _raymarchMaterial.SetFloat("_hxRotation", instance.HX_Rotation);
      if(_player!=null)  if (instance) if (instance.HX_Rotation == 0) _raymarchMaterial.SetFloat("lpx", _player.position.x);


        _raymarchMaterial.SetInt("_renderNr", _renderNr);
    }
    public void SetParameters2()
    {
        if (_useNormal)
        {
            _raymarchMaterial.SetInt("_useNormal", 1);
            _raymarchMaterial.SetInt("_nrOfCascades", _nrOfCascades);
        }
        else _raymarchMaterial.SetInt("_useNormal", 0);

        if (_useShadow)
        {
            _raymarchMaterial.SetInt("_useShadow", 1);

            if (_useSoftShadow)
            {
                _raymarchMaterial.SetInt("_useShadow", 2);
                _raymarchMaterial.SetFloat("_shadowSoftness", _shadowSoftness);
            }
        }
        else _raymarchMaterial.SetInt("_useShadow", 0);

        _raymarchMaterial.SetMatrix("_CamFrustrum", CamFrustrum(_camera));
        _raymarchMaterial.SetMatrix("_CamToWorld", _camera.cameraToWorldMatrix);
        _raymarchMaterial.SetFloat("_maxDistance", _camera.farClipPlane);


        _raymarchMaterial.SetFloat("_precision", _precision);
        _raymarchMaterial.SetFloat("_max_iteration", _max_iteration);
        _raymarchMaterial.SetFloat("_maxShadowDistance", _maxShadowDistance);
        _raymarchMaterial.SetFloat("_lightIntensity", _lightIntensity);
        _raymarchMaterial.SetFloat("_shadowIntensity", _shadowIntensity);
        _raymarchMaterial.SetFloat("_aoIntensity", _aoIntensity);
        _raymarchMaterial.SetFloat("hue", hue);
        _raymarchMaterial.SetVector("_lightDir", _directionalLight ? _directionalLight.forward : Vector3.down);
        _raymarchMaterial.SetVector("_player", _player ? _player.position : Vector3.zero);
        _raymarchMaterial.SetColor("_skyColor", _skyColor);
        _raymarchMaterial.SetColor("_ChaosColor", _ChaosColor);


        _raymarchMaterial.SetVector("_wRotation", _wRotation * Mathf.Deg2Rad);
        _raymarchMaterial.SetFloat("w", _wPosition);


        _raymarchMaterial.SetInt("_renderNr", _renderNr);
    }


    private Matrix4x4 CamFrustrum(Camera cam)
    {
        Matrix4x4 frustrum = Matrix4x4.identity;
        float fov = Mathf.Tan((cam.fieldOfView * 0.5f) * Mathf.Deg2Rad);

        Vector3 goUp = Vector3.up * fov;
        Vector3 goRight = Vector3.right * fov * cam.aspect;

        Vector3 TL = (-Vector3.forward - goRight + goUp);
        Vector3 TR = (-Vector3.forward + goRight + goUp);
        Vector3 BL = (-Vector3.forward - goRight - goUp);
        Vector3 BR = (-Vector3.forward + goRight - goUp);

        frustrum.SetRow(0, TL);
        frustrum.SetRow(1, TR);
        frustrum.SetRow(2, BR);
        frustrum.SetRow(3, BL);


        return frustrum;
    }

    void CreateScene()
    {
        if (mat) { orderedShapes.Clear(); nextShapeScan = 0; _raymarchMaterial.SetInt("numShapes", 0); return; }
        if (Time.realtimeSinceStartup >= nextShapeScan || orderedShapes.Exists(shape => shape == null))
        {
            nextShapeScan = Time.realtimeSinceStartup + 0.5f;
            var shapes = new List<Shape4D>(FindObjectsByType<Shape4D>(FindObjectsSortMode.None));
            shapes.Sort((a, b) => a.operation.CompareTo(b.operation));
            orderedShapes.Clear();
            foreach (var shape in shapes)
            {
                if (!shape.isActiveAndEnabled) continue;
                Transform parent = shape.transform.parent;
                if (parent != null && parent.GetComponent<Shape4D>() != null) continue;
                orderedShapes.Add(shape); shape.numChildren = 0;
                for (int j = 0; j < shape.transform.childCount; j++)
                    if (shape.transform.GetChild(j).TryGetComponent<Shape4D>(out var child) && child.isActiveAndEnabled)
                    { orderedShapes.Add(child); child.numChildren = 1; shape.numChildren++; }
            }
        }
        int count = orderedShapes.Count;
        if (count == 0) { _raymarchMaterial.SetInt("numShapes", 0); return; }
        if (shapeData.Length != count) shapeData = new ShapeData[count];
        for (int i = 0; i < count; i++)
        {
            var s = orderedShapes[i];
            shapeData[i] = new ShapeData { position = s.Position(), scale = s.Scale(), rotation = s.Rotation(),
                rotationW = s.RotationW(), colour = new Vector3(s.colour.r, s.colour.g, s.colour.b),
                shapeType = (int)s.shapeType, operation = (int)s.operation, blendStrength = s.smoothRadius * 3,
                numChildren = s.numChildren, numTexture = s.numTexture };
        }
        if (shapeBuffer == null || shapeBuffer.count != count)
        { ReleaseShapeBuffer(); shapeBuffer = new ComputeBuffer(count, ShapeData.GetSize()); }
        shapeBuffer.SetData(shapeData);
        _raymarchMaterial.SetBuffer("shapes", shapeBuffer); _raymarchMaterial.SetInt("numShapes", count);
    }
    struct ShapeData
    {
        public Vector4 position;
        public Vector4 scale;
        public Vector3 rotation;
        public Vector3 rotationW;
        public Vector3 colour;
        public int shapeType;
        public int operation;
        public float blendStrength;
        public int numChildren;
        public int numTexture;

        public static int GetSize()
        {
            //Debug.Log(sizeof(float) * 10 + sizeof(int) * 3);
            return 88;//sizeof(float) * 10 + sizeof(int) * 3;
        }
    }

}
