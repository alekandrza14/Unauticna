function Main(jsRaw)
{
    var begin = 'ИмяОкна(';
    var end = ')ИмяОкна';

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

    // пользователь ничего не выбрал
    if (newTexture == null || newTexture == "")
        return jsRaw;

    // Меняем ТОЛЬКО имя между началом и .png
    var result =
        jsRaw.substring(0, startIndex-8)
        + newTexture
        + jsRaw.substring(endIndex+8);

    return result;
}