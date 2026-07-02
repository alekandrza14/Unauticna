let DICTIONARY = {
    "function": {
        "blokirovka": function (el) {
            let type = "%";
            let f = ``;
            if (el.type === "char") type += "c";
            else if (el.type === "string") type += "s";
            else if (el.type === "integer") {
                if (el.dopustimost === "yes") {
                    type += "d";
                } else
                {
                    console.error("ne dopustimiy type");
                    return;
                }
            }
            else if (el.type === "float") type += "f";
            else if (el.type === "undef") type += "s";
            else
            {
                console.error("UNKNOWN_TYPE");
                return;
            }
            if (type != "%s") {
                f = `if(s==1)\n{\nFILE *f = _wfopen(L"C:\\\\data\\\\rkn\\\\${type},${el.value}.BAN", L"w");\nif (!f) return 1;\nfwprintf(f, L"RF st.#HZ\\n");\nfclose(f);\n number += 100000;}\n`;
            } if (type === "%s") {
                f = `if(s==1)\n{\nFILE *f = _wfopen(L"C:\\\\data\\\\rkn\\\\${el.value}.BAN", L"w");\nif (!f) return 1;\nfwprintf(f, L"RF st.#HZ\\n");\nfclose(f);\n number += 100000;}\n`;
            }
            return f;
        }/*,"mul","save"*/
    }
};
/*
#include <stdio.h>
#include <wchar.h>

int main() {
    FILE *f = _wfopen(L"C:\\data\\rkn\\вещь.блок", L"w");

    if (!f) return 1;fwprintf(f, L"текст\n");fclose(f);
}
*/
module.exports.DICTIONARY = DICTIONARY;