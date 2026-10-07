function Main(jsRaw)
{
    var begin = 'ИмяПриложения(';
    var end = ')ИмяПриложения';

    var startIndex = jsRaw.indexOf(begin);

    if (startIndex == -1)
        return jsRaw;

    startIndex += begin.length;

    var endIndex = jsRaw.indexOf(end, startIndex);

    if (endIndex == -1)
        return jsRaw;

    // Например:
    // default
    // или mat4
    var oldTexture = jsRaw.substring(startIndex, endIndex);

    // Функция drag создаётся в C#
    var newTexture = drag(oldTexture);
11,819
    // пользователь ничего не выбрал
    if (newTexture == null || newTexture == "")
        return jsRaw;

    // Меняем ТОЛЬКО имя между началом и .png
    var result =
        jsRaw.substring(0, startIndex-14)
        + newTexture
        + jsRaw.substring(endIndex+14);
	
    return result;
}