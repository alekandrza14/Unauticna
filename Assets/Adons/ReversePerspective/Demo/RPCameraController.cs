using UnityEngine;
using System.Collections;

[RequireComponent(typeof(RPCamera))]
public class RPCameraController : MonoBehaviour
{
	public RPCamera rPCamera = null;

	private Camera m_camera = null;
	private float m_cameraInitialSize = 0.0f;

	private Quaternion m_movingFlatDirection = Quaternion.identity;

	private SmoothValue m_smoothMouseX = new SmoothValue(0.0f, 10f);
	private SmoothValue m_smoothMouseY = new SmoothValue(0.0f, 10f);

	private SmoothValue m_smoothPerspective = new SmoothValue(0.0f, 10f);
	private SmoothValue m_smoothSizeScale   = new SmoothValue(0.0f, 10f);

	void Start() {
		if (rPCamera == null) throw new UnityException ("Perspective Camera not set");
		if (rPCamera.pivot == null) throw new UnityException ("Pivot not set");

		m_camera = GetComponent<Camera>();
		m_cameraInitialSize = m_camera.orthographicSize;

		m_movingFlatDirection = Quaternion.Euler(0f, rPCamera.pivot.localRotation.eulerAngles.y, 0f);
	}


	void Update() {

		float mx = Input.mousePosition.x / Screen.width  * 2f - 1f; // -1..1
		float my = Input.mousePosition.y / Screen.height * 2f - 1f;
		
		m_smoothMouseX.target = mx;
		m_smoothMouseY.target = my;
		float mxs = m_smoothMouseX.GetValue();
		float mys = m_smoothMouseY.GetValue();

		// rotate
		m_movingFlatDirection *= Quaternion.Euler(0f, Mathf.Pow(mxs, 3) * 2f, 0f);
	//	Quaternion movingDirection = m_movingFlatDirection * Quaternion.Euler(0f, mxs * 60f, 0f);

	//	Quaternion cameraRotation = Quaternion.Euler(-mys * 90f, movingDirection.eulerAngles.y, 0);
		if (Input.GetKey(KeyCode.Mouse1))
		{
		//	rPCamera.pivot.localRotation = cameraRotation;
		}
		// move
		float mv = Input.GetAxis("Vertical");
		float mh = Input.GetAxis("Horizontal");
	//	Vector3 move = movingDirection * (Vector3.forward * mv + Vector3.right * mh) * m_camera.orthographicSize * 0.03f;

		//rPCamera.pivot.position += move;


		// mouse wheel - zoom and FOV
		float w = Input.GetAxis("Mouse ScrollWheel");
		if (w != 0) {
			if (Input.GetKey(KeyCode.LeftAlt)) { // change orthographic Size (FOV)
				m_smoothSizeScale.target += w;
			} else { // change perspective
				m_smoothPerspective.target += w / m_camera.orthographicSize;
			}
		}

		bool prepareProjection = false;
		bool updateProjection  = false;

		if (m_smoothSizeScale.IsMoving())
		{
			float v = m_smoothSizeScale.GetValue();
			float newSize = m_cameraInitialSize * Mathf.Exp(v * 2.0f);
			m_smoothPerspective.target *= m_camera.orthographicSize / newSize;
			m_camera.orthographicSize = newSize;
			prepareProjection = true;
		}
		if (m_smoothPerspective.IsMoving())
		{
			//Debug.Log("smoothPerspective: " + m_smoothPerspective.value + " " + m_smoothPerspective.target);
			float v = m_smoothPerspective.GetValue();
			rPCamera.perspective = -v * 0.8f * 100f;
			updateProjection = true;
		}

		// update camera projection
		if (prepareProjection || updateProjection) {
			rPCamera.UpdateProjection(prepareProjection);
		}

    }

}


public class SmoothValue {
	public float target = 0.0f;
	private float value = 0.0f;
	private float velocity = 0.1f;
	public SmoothValue(float value, float velocity) {
		this.value = this.target = value;
		this.velocity = velocity;
	}
	public bool IsMoving() {
		return Mathf.Abs(target - value) > 0.000001f;  // !!! make configurable
	}
	public float GetValue() {
		value = Mathf.Lerp(value, target, velocity * Time.deltaTime);
		return value;
	}
}

