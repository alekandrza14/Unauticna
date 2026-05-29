let LEXER = function (content, dictionary) {
    
    let text = content.replace(/\s\s+/gm, " ");
    let strings = text.split(";");

    let lexems = [];
    for (let i = 0; i < strings.length; i++) {
        let curendstring = strings[i].trim();
        if (curendstring !== "") {
            let words = curendstring.split(" ");
            let CopyString = curendstring;
            let stringObject = {};
            let command = words[0];
            let value = CopyString.replace(new RegExp(command+" = ", "g"), "");
            if (dictionary["function"][command.toLowerCase()]) {
                Object.assign(stringObject, { "function": command });
            } else {
                Object.assign(stringObject, { "undef_function": command });
            }
            
            if (/\"(.*)\"/gim.test(value)) {
                if (value.length === 1) {
                    Object.assign(stringObject, {
                        "value": {
                            "type": "char",
                            "value": value
                        }
                    });
                }
                else {


                    // Object.assign(stringObject, { "string" : value });
                    Object.assign(stringObject, {
                        "value": {
                            "type": "string",
                            "value": value
                        }
                    });
                }
            } if (/\'(.*)\'/gim.test(value)) {
                if (value.length === 1) {
                    Object.assign(stringObject, {
                        "value": {
                            "type": "char",
                            "value": value
                        }
                    });
                }
                else {


                    // Object.assign(stringObject, { "string" : value });
                    Object.assign(stringObject, {
                        "value": {
                            "type": "string",
                            "value": value
                        }
                    });
                }
            }
            else if (Number(value)) {
                if (Number(value) % 1 === 0) {
                    //long
                    if (Number(value) > -2147483648 && Number(value) < 2147483648) {
                        Object.assign(stringObject, {
                            "value": {
                                "type": "integer",
                                "dopustimost": "yes",
                                "value": Number(value)
                            }
                        });
                    } else {
                        if (Number(value) > -9223372036854775808 && Number(value) < 9223372036854775807) {
                            Object.assign(stringObject, {
                                "value": {
                                    "type": "integer",
                                    "subtype": "long",
                                    "dopustimost": "no",
                                    "value": Number(value)
                                }

                            });
                        } else {
                            Object.assign(stringObject, {
                                "value": {
                                    "type": "integer",
                                    "subtype": "RealyBig",
                                    "dopustimost": "no",
                                    "value": Number(value)
                                }

                            });
                        }
                    }
                } else {
                    //float
                  //  Object.assign(stringObject, { "float": Number(value) });
                    Object.assign(stringObject, {
                        "value": {
                            "type": "float",
                            "value": Number(value)
                        }
                    });
                }
            } else if (/sig.(.*)/gim.test(value)) {
               // Object.assign(stringObject, { "sig": value });
                Object.assign(stringObject, {
                    "value": {
                        "type": "sig",
                        "value": value
                    }
                });
                
            } else {
               // Object.assign(stringObject, { "undef": value });
                Object.assign(stringObject, {
                    "value": {
                        "type": "undef",
                        "value": value
                    }
                });
            }
            lexems.push(stringObject);
            /*
            for (let j = 0; j < words.length; j++) {
                if (words[j].toLowerCase() === "print") {
                    stringObject["id"] = "print";
                } if (words[j].toLowerCase() === "print.") {
                    stringObject["id"] = "print.";
                }
                else if (words[j].toLowerCase() === "=") {
                    stringObject["operator"] = "=";
                } else if (words[j].toLowerCase() === "+") {
                    stringObject["operator"] = "+";
                }
                else if (words[j].toLowerCase() === "!") {
                    stringObject["operator"] = "!";
                }
                else if (words[j].toLowerCase() === "-") {
                    stringObject["operator"] = "-";
                }
                else if (words[j].toLowerCase() === "*") {
                    stringObject["operator"] = "*";
                }
                else if (words[j].toLowerCase() === "/") {
                    stringObject["operator"] = "/";
                } else if (words[j].toLowerCase() === "&") {
                    stringObject["operator"] = "&";
                }
                else {
                    
                    if (/PRINT = \((.*)\)/gim.test(CopyString)) {
                        let str = CopyString.replace(/PRINT = \((.*)\)/gim, "$1");
                        stringObject["string"] = str;
                    } else if (/PRINT = \'(.*)\'/gim.test(CopyString)) {
                        let str = CopyString.replace(/PRINT = \((.*)\)/gim, "$1");
                        stringObject["string"] = str;
                    } else if (/PRINT = \"(.*)\"/gim.test(CopyString)) {
                        let str = CopyString.replace(/PRINT = \((.*)\)/gim, "$1");
                        stringObject["string"] = str;
                    } else if (/PRINT = sig.(.*)/gim.test(CopyString)) {
                        let str = CopyString.replace(/PRINT = sig.(.*)/gim, "$1");
                        stringObject["error"] = str;
                    } else if (/PRINT. = sig.(.*)/gim.test(CopyString)) {
                        let str = CopyString.replace(/PRINT. = sig.(.*)/gim, "$1");
                        stringObject["sig"] = str;
                    } else if (/PRINT = (.*)/gim.test(CopyString)) {
                        let str = CopyString.replace(/PRINT = (.*)/gim, "$1");
                        stringObject["number"] = str;
                    }
                }
            }
            lexems.push(stringObject);
            */
        }
        
    }
    return lexems;
}
module.exports.LEXER = LEXER;