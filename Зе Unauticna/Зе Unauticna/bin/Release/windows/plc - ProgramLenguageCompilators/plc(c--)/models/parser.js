

function parser(lexems, dic) {
    let start = `#include <stdio.h>\n
#include <windows.h>\n\nint main () {\nSetConsoleOutputCP(65001);\n
    SetConsoleCP(65001);\n`;
    let curent = ``;
    let end = `\n
    getchar();\n
    return 0;\n}`
    if (lexems && lexems.length != 0) {
        for (let i = 0; i < lexems.length; i++) {
            let functionName = lexems[i]["function"] ? lexems[i]["function"] : lexems[i]["undef_function"];
            let valueobj = lexems[i]["value"];
            if (lexems[i]["function"] && dic["function"][functionName.toLowerCase()]) {

                    let currentFunction = dic["function"][functionName.toLowerCase()];
                    if (valueobj.type != "sig") {


                        curent += currentFunction(valueobj);
                    } if (valueobj.type === "sig") {


                      console.log(valueobj.value);
                    }
            }
            else {
                console.error("Ne suwestvuuwaya function "+functionName);
            }
        }
        
        return start + curent + end;
    }
    else
    {
        console.error("where code??");
    }
};

module.exports.parser = parser;