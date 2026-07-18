function render() { 
	_usingShader_("Unlit/sdf");
	_usingTexture_("res/image/Shaders/mat1.png");
	SDF();
};
function SDF() { 
	//♥ver sahider 1
	_Elipsoid_(
	"obj1",//-curent template object
	"0,0",//-pos x
	"0,0",//-pos y
	"0,0",//-pos z
	"5,0",//-scale x
	"4,0",//-scale y
	"5,0",//-scale z
	"2,0"//-size step 4 too much 1 too low
	);
	_Cube_(
	"obj2",//-curent template object
	"0,0",//-pos x
	"-0,34",//-pos y
	"0,0",//-pos z
	"5,0",//-scale x
	"1,33",//-scale y
	"5,0",//-scale z
	"2,0"//-size step 4 too much 1 too low
	);
	_C1ube_(
	"obj2",//-curent template object
	"0,0",//-pos x
	"-0,34",//-pos y
	"0,0",//-pos z
	"5,0",//-scale x
	"1,33",//-scale y
	"5,0",//-scale z
	"2,0"//-size step 4 too much 1 too low
	);
	//♥
	//♥ver sahider 2
	_Elipsoid_(
	"obj1",//-curent template object
	"0,0",//-pos x
	"0,0",//-pos y
	"0,0",//-pos z
	"5,0",//-scale x
	"4,0",//-scale y
	"5,0",//-scale z
	"2,0"//-size step 4 too much 1 too low
	);
	_CubeVer2_(
	"obj3",//-curent template object
	"0,0",//-pos x
	"0,17",//-pos y
	"0,0",//-pos z
	"5,0",//-scale x
	"3,0",//-scale y
	"5,0",//-scale z
	"2,0"//-size step 4 too much 1 too low
	);
	//♥
};
 
render();