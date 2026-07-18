function render() { 
	_usingShader_("Unlit/sdf");
	_usingTexture_("res/image/Shaders/mat1.png");
	SDF();
};
function SDF() { 
	_Cube_(
	"obj1",//-curent template object
	"0,0",//-pos x
	"0,0",//-pos y
	"0,0",//-pos z
	"5,0",//-scale x
	"2,5",//-scale y
	"5,0",//-scale z
	"3,0"//-size step 4 too much 1 too low
	);
	//_MathSin_(
	//"obj1",//обекст имя
	//"3D",//кордината еффекта x or y or z or 3d
//	"800,0",//1 параметр еффекта
//	"1600",//2 параметр еффекта
//	);
	_sdfApposition_("format:Rigd","12,0");
};
 
render();