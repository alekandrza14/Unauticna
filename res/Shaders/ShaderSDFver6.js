function render() { 
	_usingShader_("Unlit/sdf");
	_usingTexture_("res/image/Shaders/White.png");
	SDF();
};
function SDF() { 
	_Cube_(
	"obj1",//-curent template object
	"0,0",//-pos x
	"0,0",//-pos y
	"0,0",//-pos z
	"4,2",//-scale x
	"4,2",//-scale y
	"4,2",//-scale z
	"1,5"//-size step 4 too much 1 too low
	);
	_MathSin_(
	"obj1",//обекст имя
	"3D",//кордината еффекта x or y or z or 3d
	"95,0",//1 параметр еффекта
	"150",//2 параметр еффекта
	);
	_MathPos_(
	"obj1",
	"Y",
	"400",
	"20"
	);



};
 
render();