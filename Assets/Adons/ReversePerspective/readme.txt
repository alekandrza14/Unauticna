Reverse Perspective Camera
-----------------------------------------------------------------

The script allows to make a continuous perspective distortion: 
direct perspective - parallel projection - reverse perspective.
Kind of an ultimate Dolly zoom.

Related links:
    https://en.wikipedia.org/wiki/Perspective_distortion_(photography)
    https://en.wikipedia.org/wiki/Reverse_perspective
    https://en.wikipedia.org/wiki/Dolly_zoom

-----------------------------------------------------------------

Asset contents:
    ReversePerspective
        RPCamera.cs                 - The main component which extends a standard orthographic camera.
        Demo
            RPCameraController.cs   - Extends RPCamera adding a controlling to the camera.
            Demo.unity              - Demo scene with a pregenerated city model.

-----------------------------------------------------------------

Properties used for geometry of RPCamera component:
	Size        - property of Camera component, works as FOV;
	Perspective - perspective coefficient:
                        positive - direct perspective
                        zero     - parallel projection
                        negative - reverse perspective
	Pivot       - objects located here stay the same size on perspective distortion. (world's origin by default)

-----------------------------------------------------------------
            
RPCameraController controlling:
	w/a/s/d           - moving
	mouse move        - looking
	mouse wheel       - perspective
	alt + mouse wheel - FOV

-----------------------------------------------------------------

Demo video:
    Using the component in the Editor
        https://www.youtube.com/watch?v=LrLJMP0Pi9E
    Camera controller demo
        https://www.youtube.com/watch?v=yvxw8pkG_Ac
        "Japanese Otaku City" asset by ZENRIN (https://www.assetstore.unity3d.com/en/#!/content/20359) used.

-----------------------------------------------------------------

Viktor Massalogin
massalogin@gmail.com
