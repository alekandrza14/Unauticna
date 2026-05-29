let DICTIONARY = {
    "function": {
        "print": function (el) {
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
                f = `printf(${type},${el.value});\n`;
            } if (type === "%s") {
                f = `printf(${el.value});\n`;
            }
            return f;
        }/*,"mul","save"*/
    }
};
module.exports.DICTIONARY = DICTIONARY;