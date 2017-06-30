 $(document).ready(function(){
    var $select = $(".goodieQuantity");
    for (i=1;i<=100;i++){
        $select.append($('<option></option>').val(i).html(i))
    }
    var secretCodeGenerator = document.getElementById("secretID");
    secretCodeGenerator.innerText = GenerateRando();
    }
 );

function GenerateRando(){
    var lower_words_not_match = {
        "a": 1, "b": 2, "c": 3, "d": 4, "e": 5, "f": 6, "g": 7, "h": 8, "i": 9, "j": 10, "k": 11, "l": 12, "m": 13,
        "n": 14, "o": 15, "p": 16, "q": 17, "r": 18, "s": 19, "t": 20, "u": 21, "v": 22, "w": 23, "x": 24, "y": 25,
        "z": 26
    }

    var upper_words_not_match = {
        "A": 27, "B": 28, "C": 29, "D": 30, "E": 31, "F": 32, "G": 34, "H": 35, "I": 36, "J": 37, "K": 38, "L": 39, "M": 40,
        "N": 41, "O": 42, "P": 43, "Q": 44, "R": 45, "S": 46, "T": 47, "U": 48, "V": 49, "W": 50, "X": 51, "Y": 52,
        "Z": 53
    }

    var digits = {
        "1": 54, "2": 55, "3": 56 , "4": 57, "5": 58, "6": 59, "7": 60, "8": 61, "9": 62, "0": 63
    }
    var myRandomWord = "";
    for(var i = 0; i < 4; i++){
        var random_letter = Math.floor(Math.random() * (63-1))+1;
        // Lower letters
        for(var thing in lower_words_not_match){
            if(lower_words_not_match[thing] == random_letter){
                myRandomWord += thing;
            };
        };
        // Capped letters
        for(var otherThing in upper_words_not_match){
            if(upper_words_not_match[otherThing] ==random_letter){
                myRandomWord += otherThing;
            };
        };
        // Number!
        for(var kewlNumber in digits){
            if(digits[kewlNumber] == random_letter){
                myRandomWord += kewlNumber;
            };
        };
    };
    return myRandomWord;
};

function UpdateCC(){
    var elem = document.getElementById("UpdateCCButton");
    
    var newForm = document.createElement("form");
    newForm.setAttribute("action", "/hammyCC");
    newForm.setAttribute("method", "post");
    
    var newImg = document.createElement("img");
    newImg.setAttribute("class", "ccGroup");
    newImg.setAttribute("id", "ccPic");
    newImg.setAttribute("src", "/images/FakeCCImage.png");
    newImg.setAttribute("alt", "hammyCCImage");
    newForm.appendChild(newImg);

    var ccNumberLabel = document.createElement("label");
    ccNumberLabel.setAttribute("class", "ccGroup");
    ccNumberLabel.innerHTML = "Hammy Payment (CC)";
    newForm.appendChild(ccNumberLabel);

    var ccNumberInput = document.createElement("input");
    ccNumberInput.setAttribute("id", "SpecialInput");
    ccNumberInput.setAttribute("type", "text");
    ccNumberInput.setAttribute("name", "HammyCCNumber");
    ccNumberInput.setAttribute("placeholder", "CC number...");
    ccNumberInput.setAttribute("size", "30");
    newForm.appendChild(ccNumberInput);

    var firstUL = document.createElement("ul");
    var expLabel = document.createElement("label");
    expLabel.innerHTML = "Expiration Date";
    var cvnLabel = document.createElement("label");
    cvnLabel.innerHTML = "CVN";
    firstUL.appendChild(expLabel);
    firstUL.appendChild(cvnLabel);
    newForm.appendChild(firstUL);

    var secondUL = document.createElement("ul");
    var expInput = document.createElement("input");
    expInput.setAttribute("type", "text");
    expInput.setAttribute("name", "HammyCCDate");
    expInput.setAttribute("placeholder", "MM/YYYY");
    var cvnInput = document.createElement("input");
    cvnInput.setAttribute("type", "text");
    cvnInput.setAttribute("name", "HammyCCCVN");
    secondUL.appendChild(expInput);
    secondUL.appendChild(cvnInput);
    newForm.appendChild(secondUL);

    var saveButton = document.createElement("button");
    saveButton.setAttribute("type", "submit");
    saveButton.setAttribute("name", "HammyCCButton");
    saveButton.innerHTML = "Save CC Info";
    newForm.appendChild(saveButton);

   elem.parentNode.appendChild(newForm);
   elem.parentNode.removeChild(elem);
};

