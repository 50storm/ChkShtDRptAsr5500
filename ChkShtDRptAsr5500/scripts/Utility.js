function IsDateType(dateVal) {
    //http://www.megasoft.co.jp/mifes/seiki/
    var validatePattern = /^(\d{4})(\/|-)(\d{1,2})(\/|-)(\d{1,2})$/;
    return validatePattern.test(dateVal);//True or False
}

function getCurrentDate() {
    var now = new Date();
    var m = now.getMonth() + 1;
    var m = (m >= 1 && m <= 9) ? "0" + String(m) : String(m);  //TODO:01や1を選べるようにする 
    return (now.getFullYear() + '/' + m + '/' + now.getDate());
}

function getCurrentYear() {
    var now = new Date();
    return now.getFullYear();
}

function getCurrentMonth() {
    var now = new Date();
    return now.getMonth() + 1;
}

function getCurrentDateDD() {
    var now = new Date();
    return now.getDate();
}
//TODO:途中
function converMonthToEng(month_num) {
    var month_eng;

    month_num = int(month_num);
    switch (month_num) {
        case 1:
            month_eng = "Jan";
            break;

        case 2:
            month_eng = "Feb";
            break;

        case 3:
            month_eng = "Mar";
            break;

        case 4:
            month_eng = "Apr";
            break;

        case 5:
            month_eng = "May";
            break;

        case 6:
            month_eng = "Jun";
            break;

        case 7:
            month_eng = "Jul";
            break;

        case 8:
            month_eng = "Aug";
            break;

        case 9:
            month_eng = "Sep";
            break;

        case 10:
            month_eng = "Oct";
            break;

        case 11:
            month_eng = "Nov";
            break;

        case 12:
            month_eng = "Dec";
            break;
        default:
            month_eng = "数値[1-12]がセットされていません。";
            break;
    }
    return month_eng;

}


function splitString(stringToSplit, separator) {
    var arrayOfStrings = [];
    arrayOfStrings = stringToSplit.split(separator);
    //for (var i = 0; i < arrayOfStrings.length; i++) {
    //	print(arrayOfStrings[i] + " / ");
    //}
    //console.log(arrayOfStrings);
    //console.log(arrayOfStrings[0]);
    return arrayOfStrings;

}

function showMsg(id, msgTest, bgColor, fontColor) {
    $("" + id + "").text(msgTest);
    $("" + id + "").css("background-color", bgColor).css("color", fontColor);
}

function setBgColor(id, bgColor, fontColor) {
    $("" + id + "").css("background-color", bgColor).css("color", fontColor);
}

function validateDateFromTo(dateFrom, dateTo) {
    var dateFromArr = [], dateToArr = [];
    var separator = "/";
    dateFromArr = splitString(dateFrom, separator);
    for (var i = 0; i < dateFromArr.length ; i++) {
        console.log(dateFromArr[i]);
    }

    dateToArr = splitString(dateTo, separator);
    for (var i = 0; i < dateToArr.length ; i++) {
        console.log(dateToArr[i]);
    }

    var objDateFrom = {};
    objDateFrom.year = dateFromArr[0];
    objDateFrom.month = dateFromArr[1];
    objDateFrom.day = dateFromArr[2];

    var objDateTo = {};
    objDateTo.year = dateToArr[0];
    objDateTo.month = dateToArr[1];
    objDateTo.day = dateToArr[2];

    if (int(objDateFrom.year) > int(objDateTo.year)) {
        showMsg("#msg", "Error Year [From>To]", "white", "red");
        return false;
    }
    if (int(objDateFrom.year) === int(objDateTo.year)) {
        if (int(objDateFrom.month) > int(objDateTo.month)) {
            showMsg("#msg", "Error Month [From>To]", "white", "red");
            return false;
        }
    }

    if (int(objDateFrom.year) === int(objDateTo.year)) {
        if (int(objDateFrom.month) === int(objDateTo.month)) {
            if (int(objDateFrom.day) > int(objDateTo.day)) {
                showMsg("#msg", "Error Day [From>To]", "white", "red");
                return false;
            }

        }
    }
    showMsg("#msg", "日付チェックOK", "white", "red");
    return true;

}

function int(val) {
    return parseInt(val, 10);
}


function isLeapYear(dateVal) {
    var arrDate = [];
    arrDate = dateVal.split("/", 3);
    dateVal = arrDate[2];
    if (dateVal % 4 === 0) {
        if (dateVal % 100 === 0) {
            return false;
        } else {

            return true;
        }
    } else {
        return false;
    }

    if (dateVal % 400 === 0) {
        return true;
    } else {
        return false;
    }
}

function addDate(year, month, date, gap) {
    gap = typeof gap == 'undefined' ? 0 : gap;

    var objDate = new Date(int(year), int(month), int(date));
    // alert(dateFromArr)
    console.log(objDate.getFullYear());
    console.log(objDate.getMonth());
    console.log(objDate.getDate());
    objDate.setDate(objDate.getDate() + gap * 1);
    console.log(objDate.getFullYear());
    console.log(objDate.getMonth());
    console.log(objDate.getDate());
    //TODO
    //0付与
    //var m = (  int(month)  >= 1 && int(month) <= 9   )  ?  "0"+String(int(month)) : String(int(month));  //TODO    
    //return ( objDate.getFullYear() + "/" + "0" + objDate.getMonth() + "/" + objDate.getDate() );
    return (objDate.getFullYear() + "/" + objDate.getMonth() + "/" + objDate.getDate());
}


function setCmbYear(fromYear, toYear) {
    var year = [];

    for (var i = fromYear ; i <= toYear ; i++) {
        year.push(i);

    }
    console.log(year)
    return year;
}
