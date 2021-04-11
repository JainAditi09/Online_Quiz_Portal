var mins = 5;
var secs = mins * 60;
var currentSeconds = 0;
var currentMinutes = 0;

var ourtimer;
function StartCountDown() {
    ourtimer = setTimeout(Decrement, 1000);
}

function EndCountDown() {
    clearTimeout(ourtimer);
}

$(document).ready(function () { StartCountDown(); }); //start the countdown

function Decrement() {
    currentMinutes = Math.floor(secs / 60);
    currentSeconds = secs % 60;
    if (currentSeconds <= 9) currentSeconds = "0" + currentSeconds;
    secs--;
    document.getElementById("timerText").innerHTML = "Time Remaining " + currentMinutes + ":" + currentSeconds;
    if (secs !== -1) {
        setTimeout('Decrement()', 1000);
    }
    else {
        window.location.href = "Home.aspx?timeout=1"
    }
}

function CheckIfAllQuestionAnswerHasBeenSubmitted() {
    var numItems = $('.tblOptions').length;
    var flagtocheckcount = 0;
    $(".tblOptions").each(function () {
        var groupname = $('input[type=radio]:first', this).attr('name');
        if (!$("input[name='" + groupname + "']:checked").val()) {
            $(this).parents(".tableclass").addClass("border");
            var tableid = $(this).closest('table [class^="tableclass"]').attr("questionno");
        }
        else {
            flagtocheckcount = flagtocheckcount + 1;
        }
    })

    if (parseInt(flagtocheckcount) == parseInt(numItems)) {
        var CountFinalResult = 0;
        $(".tblOptions").each(function () {
            var groupname = $('input[type=radio]:first', this).attr('name');
            var radioId = $("input[name='" + groupname + "']:checked").attr("id")
            var UserSelectedAnswer = $("label[for='" + radioId + "']").text();
            var CorrectAnswer = $('span:last-child', this).text();
            var CorrectAnswerSpanId = $('span:last-child', this).attr("id");
            var QuestionStatus = $("span:nth-last-child(1)", this).attr("id");

            if (CorrectAnswer == UserSelectedAnswer) {
                $("#" + QuestionStatus).text("Correct Answer").css("color", "green");
                $('td.correctAnswer').find("td.correctAnswer", this).css("display", "none");
                CountFinalResult = CountFinalResult + 1;
            }
            else {
                //$('table.tblOptions tbody tr td:last-child').addClass("incorrect");
                $('span:last-child', this).css({ 'display': 'inline-flex' });
                $("#" + QuestionStatus).text("InCorrect Answer").css({ 'color': 'Red' });
                $('td.correctAnswer', this).css({ "display": "block", "background-color": "yellow", "color": "red" });

            }
        });
        $("#lbresult").text("Final Result-:" + CountFinalResult + "/7");
        $("#btnSubmit").attr("disabled", "disabled"); //disable button if all questions answer has been given
        $("#btnSubmit").removeClass("btn");
        $("#btnSubmit").addClass("btndiabled");
        EndCountDown();
        $("#timerText").css("display", "none");
        $("#spnthankyou").append("Thank You for submitting your test.")
        $("input[type=radio]").attr('disabled', true); //disable all radio button after test submitted by user
        return false;
    }
    else {
        return false;
    }
}

var CountCheckCheckQuestion = 0; //following function will work on every radio button click
var TotalQuestions = 0;
$("input[type=radio]").click(function () {
    var groupname = $(this).attr("name");
    $(this).parents(".tableclass").removeClass("border");
    CheckTheCountOfQuestionHasBeenAnswered();          //this function to check if all the answer given while selecting radio button you don't need.. 
    // to click on submit button
    if (parseInt(CountCheckCheckQuestion) == parseInt(TotalQuestions)) {
        CheckIfAllQuestionAnswerHasBeenSubmitted();
    }
});


function CheckTheCountOfQuestionHasBeenAnswered() {
    TotalQuestions = $('.tblOptions').length;
    var TotalGivenAnswerCount = 0;
    var flagtocheckcount = 0;
    $(".tblOptions").each(function () {
        var groupname = $('input[type=radio]:first', this).attr('name');
        if (!$("input[name='" + groupname + "']:checked").val()) {
        }
        else {
            TotalGivenAnswerCount = TotalGivenAnswerCount + 1;
        }
    })
    CountCheckCheckQuestion = TotalGivenAnswerCount;
}
