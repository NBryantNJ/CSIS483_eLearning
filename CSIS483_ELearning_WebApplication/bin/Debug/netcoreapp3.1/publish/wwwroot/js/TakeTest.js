
//--------------Submit test button clicked----------------------
$(".btnSubmitTest").on('click', function () {
    //Declare variables
    var allAnswersFromUser = { };
    var i = 0; 
    var courseID = $(".courseID").text(); 

    //Loop through each question and populate array
    $(".divTestContents select").each(function () {
        allAnswersFromUser[i] = $(this).val(); 
        i++;
    });

    //Send data to controller
    $.post("/home/gradeTest", { answers: allAnswersFromUser, courseID: courseID }, function success(data)
    {
        if (data === "true") {
            alert("Test submitted");
        }
        else {
            alert("Something went wrong."); 
        }
    });

});