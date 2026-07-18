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
	"2,2",//-scale x
	"2,2",//-scale y
	"50,0",//-scale z
	"1,5"//-size step 4 too much 1 too low
	);
	_MathSin_(
	"obj1",//обекст имя
	"Z",//кордината еффекта x or y or z or 3d
	"957,0",//1 параметр еффекта
	"64",//2 параметр еффекта
	);
	_MathSin_(
	"obj2",//обекст имя
	"Y",//кордината еффекта x or y or z or 3d
	"114,0",//1 параметр еффекта
	"108",//2 параметр еффекта
	);
	_MathSin_(
	"obj2",//обекст имя
	"3D",//кордината еффекта x or y or z or 3d
	"395,0",//1 параметр еффекта
	"300",//2 параметр еффекта
	);
	_Cube_(
	"obj2",//-curent template object
	"0,0",//-pos x
	"0,0",//-pos y
	"0,0",//-pos z
	"5,0",//-scale x
	"5,0",//-scale y
	"5,0",//-scale z
	"2,0"//-size step 4 too much 1 too low
	);
	_sdfApposition_("format:Cut","12,0");
};
 
render();