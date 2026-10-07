*_Begin_*начать с sdf,начать с unlit*_Begin_**_BeginDialog_*Привет это создание скриптов через новелу! как мы начнём?*_BeginDialog_*
*_List1_*

*_начать с unlit_*

function render() { 
	_usingShader_("Unlit/Transparent");
	_usingTexture_("res/image/Shaders/default.png");
	
};
//Module"List2".Shader.jslib
//Module"List3".Shader.jslib
render();
*_начать с unlit_*


*_начать с sdf_*

function render() { 
	_usingShader_("Unlit/sdf");
	_usingTexture_("res/image/Shaders/mat4.png");
	SDF();
};
function SDF()
{ 
	_Elipsoid_(
	"obj1",//-curent template object
	"0,0",//-pos x
	"0,0",//-pos y
	"0,0",//-pos z
	"5,0",//-scale x
	"5,0",//-scale y
	"5,0",//-scale z
	"3,0"//-size step 4 too much 1 too low
	);
//Module"List2".Shader.jslib
//Module"List3".Shader.jslib
}
render();
*_начать с sdf_*

*_List1_*

*_List1.end_*вырать текстуру*_List1.end_**_List1Dialog_**_List1Dialog_*

*_List2_*



*_вырать текстуру_*



*_вырать текстуру_*

*_вырать текстуруJSRUN_*

Run("texture drag drop.js");

*_вырать текстуруJSRUN_*



*_List2_*
*_List2.end_*добавить волны на SDF модель,анимацию на SDF модель*_List2.end_**_List2Dialog_*выбираем текстуру для работы*_List2Dialog_*

*_List3_*

*_добавить волны на SDF модель_*

_MathSin_(
	"obj1",//обекст имя
	"3D",//кордината еффекта x or y or z or 3d
	"800,0",//1 параметр еффекта
	"1600",//2 параметр еффекта
	);
//Module"List4".Shader.jslib
*_добавить волны на SDF модель_*

*_анимацию на SDF модель_*

_MathPos_(
	"obj1",
	"X",
	"400",
	"20"
	);
//Module"List4".Shader.jslib
*_анимацию на SDF модель_*

*_List3_**_List3.end_*добавить волны на SDF модель,анимацию на SDF модель*_List3.end_**_List3Dialog_*выбор SDF функций 1/2*_List3Dialog_*
*_List4_*


*_добавить волны на SDF модель_*

_MathSin_(
	"obj1",//обекст имя
	"3D",//кордината еффекта x or y or z or 3d
	"800,0",//1 параметр еффекта
	"1600",//2 параметр еффекта
	);
//Module"List5".Shader.jslib
*_добавить волны на SDF модель_*

*_анимацию на SDF модель_*

_MathPos_(
	"obj1",
	"X",
	"400",
	"20"
	);
//Module"List5".Shader.jslib
*_анимацию на SDF модель_*


*_List4_**_List4.end_*жидкость,твёрдое,вырезать*_List4.end_**_List4Dialog_*параметры наложения*_List4Dialog_*

*_List5_*

*_жидкость_*
_sdfApposition_("format:Soft","12,0");
//Module"List6".Shader.jslib
*_жидкость_*
*_твёрдое_*
_sdfApposition_("format:Rigd","12,0");
//Module"List6".Shader.jslib
*_твёрдое_*
*_вырезать_*
_sdfApposition_("format:Cut","12,0");
//Module"List6".Shader.jslib
*_вырезать_*

*_List5_**_List5.end_*куб,сфера*_List5.end_**_List5Dialog_*2 объект*_List5Dialog_*

*_List6_*


*_куб_*
_Cube_(
	"obj2",//-curent template object
	"0,0",//-pos x
	"0,0",//-pos y
	"0,0",//-pos z
	"2,2",//-scale x
	"2,2",//-scale y
	"2,2",//-scale z
	"1,5"//-size step 4 too much 1 too low
	);
	//Module"List7".Shader.jslib
*_куб_*


*_сфера_*
_Elipsoid_(
	"obj2",//-curent template object
	"0,0",//-pos x
	"0,0",//-pos y
	"0,0",//-pos z
	"5,0",//-scale x
	"5,0",//-scale y
	"5,0",//-scale z
	"3,0"//-size step 4 too much 1 too low
	);
	//Module"List7".Shader.jslib
*_сфера_*


*_List6_**_List6.end_*добавить волны на SDF модель,анимацию на SDF модель*_List6.end_**_List6Dialog_*выбираем эффеты 1 из 2*_List6Dialog_*

*_List7_*

*_добавить волны на SDF модель_*

_MathSin_(
	"obj2",//обекст имя
	"3D",//кордината еффекта x or y or z or 3d
	"800,0",//1 параметр еффекта
	"1600",//2 параметр еффекта
	);
//Module"List8".Shader.jslib
*_добавить волны на SDF модель_*

*_анимацию на SDF модель_*

_MathPos_(
	"obj2",
	"X",
	"400",
	"20"
	);
//Module"List8".Shader.jslib
*_анимацию на SDF модель_*

*_List7_**_List7.end_*добавить волны на SDF модель,анимацию на SDF модель*_List7.end_**_List7Dialog_*выбираем эффеты 2 из 2*_List7Dialog_*
*_List8_*

*_добавить волны на SDF модель_*

_MathSin_(
	"obj2",//обекст имя
	"3D",//кордината еффекта x or y or z or 3d
	"800,0",//1 параметр еффекта
	"1600",//2 параметр еффекта
	);
//Module"List9".Shader.jslib
*_добавить волны на SDF модель_*

*_анимацию на SDF модель_*

_MathPos_(
	"obj2",
	"X",
	"400",
	"20"
	);
//Module"List9".Shader.jslib
*_анимацию на SDF модель_*

*_List8_**_List8.end_**_List8.end_**_List8Dialog_**_List8Dialog_*

*_List9_*

*_List9_**_List9.end_**_List9.end_**_List9Dialog_**_List9Dialog_*
