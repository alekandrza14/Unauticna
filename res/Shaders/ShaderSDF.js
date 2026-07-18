function render() { 
	_usingShader_("Unlit/sdf");
	_usingTexture_("res/image/Shaders/default.png");
	SDF();
};
function SDF() { 
	_Elipsoid_(
	"obj1",//-curent template object
	"0,0",//-pos x
	"0,0",//-pos y
	"0,0",//-pos z
	"5,0",//-scale x
	"3,0",//-scale y
	"5,0",//-scale z
	"2,0"//-size step 4 too much 1 too low
	);
};
 
render();