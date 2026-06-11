let fs = require("fs");

let dic = require("./models/Dictionary").DICTIONARY;
let lexer = require("./models/Lexer.js").LEXER;
let parser = require("./models/parser.js").parser;



fs.readFile("obj.C††", "utf-8", function (error, content) {
    if (error === null) {
        content = content.replaceAll("C††.о.господи.скажи", "print");
        content = content.replaceAll("C††.о.господи.открой", "run");
        content = content.replaceAll("аминь", ";");
        let lexems = lexer(content, dic);
        let parsedString = parser(lexems, dic);
        console.log(parsedString);

  fs.writeFile("C_consle.c--",content, "utf8",function (error) {
 if (error) throw error; //                     
            console.log("                                  .                 :");
            let data = fs.readFileSync("C_consle.c--", "utf8");
            console.log(data);  //                         
        });

        fs.writeFile("C_consle.c", parsedString, function (error) {

            if (error) throw error; //                     
            console.log("                                  .                 :");
            let data = fs.readFileSync("C_consle.c", "utf8");
            console.log(data);  //                         
        });
       // console.log(JSON.stringify(lexems, null, 4));
    } else {
        console.error("ERROR!?");
        console.error(error);

    }

});