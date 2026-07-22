function render() { 
	_usingShader_("Unlit/sdf");
	_usingTexture_("res/image/Shaders/mat4.png");
	SDF();
};
function SDF() { 
	_Elipsoid_(
	"obj1",//-curent template object
	"0,0",//-pos x
	"0,0",//-pos y
	"0,3",//-pos z
	"2,0",//-scale x
	"2,0",//-scale y
	"3,0",//-scale z
	"2,0"//-size step 4 too much 1 too low
	);
	_Elipsoid_(
	"obj2",//-curent template object
	"0,0",//-pos x
	"0,0",//-pos y
	"-0,2",//-pos z
	"3,0",//-scale x
	"3,0",//-scale y
	"3,5",//-scale z
	"2,0"//-size step 4 too much 1 too low
	);
	_sdfApposition_("format:Soft","12,0");
	_MathPos_(
	"obj1",
	"X",
	"400",
	"20"
	);
	_MathPos_(
	"obj2",
	"Y",
	"50",
	"40"
	);
	_MathPos_(
	"obj1",
	"3D",
	"50",
	"70"
	);
};
 
render();