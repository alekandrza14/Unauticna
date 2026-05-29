

function parser(lexems, dic) {
    let start = `#include <stdio.h>\n
#include <wchar.h>\n
#include <stdlib.h>\n
#include <windows.h>\n
\n
int main() {\n
    int s = 1;\n
    \nSetConsoleOutputCP(65001);\n
    SetConsoleCP(65001);\n
      FILE *file;\n
      \n
    // \n
    file = fopen("C:\\\\data\\\\solaryAdd", "r");\n
    \n
    if (file == NULL) {\n
        printf("\\n");\n
        return 1;\n
    }\n
    \n
    int number = 0;\n
    \n
    //
    fscanf(file, "%d", &number);\n
    \n
    fclose(file);\n`;
    let curent = ``;
    let end = `\n
    \n
    file = fopen("C:\\\\data\\\\solaryAdd", "w");\n

    if (file == NULL) {\n
        printf("\\n");\n
        return 1;\n
    }\n

    //
    fprintf(file, "%d", number);\n

    fclose(file);\n

    printf("%d\\n", number);\n
    return 0;\n}`;
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