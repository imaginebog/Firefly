using UnityEngine;
using System.Collections;
using Tobii.EyeX.Framework;

/// MouseLook rotates the transform based on the mouse delta.
/// Minimum and Maximum values can be used to constrain the possible rotation

/// To make an FPS style character:
/// – Create a capsule.
/// – Add the MouseLook script to the capsule.
/// -> Set the mouse look to use LookX. (You want to only turn character but not tilt it)
/// – Add FPSInputController script to the capsule
/// -> A CharacterMotor and a CharacterController component will be automatically added.

/// – Create a camera. Make the camera a child of the capsule. Reset it’s transform.
/// – Add a MouseLook script to the camera.
/// -> Set the mouse look to use LookY. (You want the camera to tilt up and down like a head. The character already turns.)
[AddComponentMenu("Camera-Control/Gaze Look")]
public class gazeLook : MonoBehaviour {
	
	public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
	public RotationAxes axes = RotationAxes.MouseXAndY;
	public float sensitivityX = 2F;
	public float sensitivityY = 2F;
	
	public float minimumX = -360F;
	public float maximumX = 360F;
	
	public float minimumY = -60F;
	public float maximumY = 60F;

	public float leftBorder = -0.7F;
	public float rightBorder = 0.7F;

	public float topBorder = 0.7F;
	public float bottomBorder = -0.7F;

	private EyeXHost _eyeXHost;
	private IEyeXDataProvider<EyeXFixationPoint> _fixationDataProvider;
	private int _fixationCount;
	//private GazePointDataComponent _gazePointDataComponent;
	
	#if UNITY_EDITOR
	private FixationDataMode _oldFixationDataMode;
	#endif
	
	/// <summary>
	/// Choice of fixation data stream to be visualized.
	/// </summary>
	public FixationDataMode fixationDataMode = FixationDataMode.Sensitive;
	
	float rotationY;
	float rotationX;
	
	public void Awake()
	{
		_eyeXHost = EyeXHost.GetInstance();
		_fixationDataProvider = _eyeXHost.GetFixationDataProvider(fixationDataMode);
		
		#if UNITY_EDITOR
		_oldFixationDataMode = fixationDataMode;
		#endif
	}
	
	public void OnEnable()
	{
		_fixationDataProvider.Start();
	}
	
	public void OnDisable()
	{
		_fixationDataProvider.Stop();
	}
	
	void Update ()
	{
		var fixationPoint = _fixationDataProvider.Last;

		float gazeX = 0;
		float gazeY = 0;
		if (fixationPoint.IsValid) {
			gazeX= (2f * ((float)fixationPoint.GazePoint.Viewport.x - 0.5f));
			gazeY = (2f * ((float)fixationPoint.GazePoint.Viewport.y - 0.5f));
		}
		//print ("gazeZy before floating="+fixationPoint.GazePoint.Viewport.y);


		if (axes == RotationAxes.MouseXAndY)
		{
			//float rotationX = transform.localEulerAngles.y + Input.GetAxis(“Mouse X”) * sensitivityX;

			if(gazeX> rightBorder || gazeX< leftBorder){
				rotationX = transform.localEulerAngles.y + gazeX * sensitivityX * Time.deltaTime;
			}			
			
			//rotationY += Input.GetAxis(“Mouse Y”) * sensitivityY;
			if(gazeY> topBorder || gazeY< bottomBorder){
				rotationY += gazeY * sensitivityY * Time.deltaTime;
				rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);
			}		

			transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
		}
		else if (axes == RotationAxes.MouseX)
		{
			//transform.Rotate(0, Input.GetAxis(“Mouse X”) * sensitivityX, 0);
				transform.Rotate(0, gazeX * sensitivityX, 0);
			
		}
		else
		{
			//rotationY += Input.GetAxis(“Mouse Y”) * sensitivityY;			
			rotationY += gazeY * sensitivityY;
			rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);
			//print (“rotationY AFTER=”+rotationY);
			transform.localEulerAngles = new Vector3(-rotationY, 0, 0);
		}
	}
}