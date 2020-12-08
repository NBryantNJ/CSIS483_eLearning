

//------------------------Locked Screen-----------------------------

//request for admin privileges button clicked
$('.btnRequestAdminAccess').on('click', function ()
{
    $.post("/home/requestAdminPrivileges", { didUserRequestAccess: true }, function success(data)
    {
        if (data === true) {
            window.location.reload(); 
        }
    });
});


/*------------------------Create course form----------------------*/
//Main create course button clicked
$(".btnMainCreateCourse").on('click', function () {
    $(".divCreateCourse").css('visibility', 'visible');
});

//Add another link button clicked
var numOfLinks = 1; 
$(".btnAddAnotherLink").on('click', function () {
    numOfLinks += 1;
    $(".divLinks").append("<input class='form-control inputWebLink"+numOfLinks+"' placeholder='Full Web Address Link' />");
    $(".divLinks").append("<select class='form-control selectLinkType"+numOfLinks+"' style='margin-left:6px'> <option selected hidden > Link Type</option><option>Video</option><option>Website</option><option>PDF</option></select >");
});

//Add another question button clicked
var numOfQuestions = 1;
$(".btnAddAnotherQuestion").on('click', function () {
    
    numOfQuestions += 1; 
    $(".divAddTestingQuestions").append("<hr/>");
    $(".divAddTestingQuestions").append("<p>Question #" + numOfQuestions + "</p>");
    $(".divAddTestingQuestions").append("<input class='form-control inputQuestion"+numOfQuestions+"' placeholder='Question' />");
    $(".divAddTestingQuestions").append("<input class='form-control inputOption1Question" + numOfQuestions + "' placeholder='Option 1' />");
    $(".divAddTestingQuestions").append("<select class='form-control selectCorrectOrIncorrectOption1Question" + numOfQuestions + "'><option selected > Correct</option ><option>Incorrect</option></select>");

    $(".divAddTestingQuestions").append("<input class='form-control inputOption2Question" + numOfQuestions + "' placeholder='Option 2' />");
    $(".divAddTestingQuestions").append("<select class='form-control selectCorrectOrIncorrectOption2Question" + numOfQuestions + "'><option selected > Correct</option ><option>Incorrect</option></select>");

    $(".divAddTestingQuestions").append("<input class='form-control inputOption3Question" + numOfQuestions + "' placeholder='Option 3' />");
    $(".divAddTestingQuestions").append("<select class='form-control selectCorrectOrIncorrectOption3Question" + numOfQuestions + "'><option selected > Correct</option ><option>Incorrect</option></select>");

    $(".divAddTestingQuestions").append("<input class='form-control inputOption4Question" + numOfQuestions + "' placeholder='Option 4' />");
    $(".divAddTestingQuestions").append("<select class='form-control selectCorrectOrIncorrectOption4Question" + numOfQuestions + "'><option selected > Correct</option ><option>Incorrect</option></select>");
});


//Choosing difficulty rating
var selectedDifficultyRating; 
function chooseDifficultyLevel(currentButton) {
    $(".divCourseDifficultyRating button").css("opacity", ".5");
    $(currentButton).css('opacity', '1');
    selectedDifficultyRating = $(currentButton).text(); 
}

//Submit Course
$(".btnSubmitNewCourseForm").on('click', function () {
    var createcoursemodel = {};
    var indexNum = 0;

    //Index 0 holds number of links and questions
    createcoursemodel[indexNum] = { numberOfLinks: numOfLinks, numberOfQuestions: numOfQuestions };
    indexNum++; 

    //Index 1 holds difficulty rating
    createcoursemodel[indexNum] = { difficultyRating: selectedDifficultyRating};
    indexNum++;

    //Index 2 holds course name
    createcoursemodel[indexNum] = { courseName: $(".inputCourseName").val() };
    indexNum++;

    //Index 3 holds course notes
    createcoursemodel[indexNum] = { notes: $(".textareaAddNotes").val() }; 
    indexNum++; 

    //Populate links and link types
    for (var i = 1; i <= numOfLinks; i++) {
        createcoursemodel[indexNum] = { link: $(".inputWebLink"+i+" ").val(), linktype: $(".selectLinkType"+i+" option:selected").text()};
        indexNum++;
    }

    //Populate question and option data
    for (var i = 1; i <= numOfLinks; i++)
    {
        createcoursemodel[indexNum] = {
            question: $(".inputQuestion" + i + " ").val(),
            option1: $(".inputOption1Question" + i + " ").val(),
            isOptionCorrectOrIncorrect1: $(".selectCorrectOrIncorrectOption1Question" + i + " option:selected").text(),
            
            option2: $(".inputOption2Question" + i + " ").val(), 
            isOptionCorrectOrIncorrect2: $(".selectCorrectOrIncorrectOption2Question" + i + " option:selected").text(),

            option3: $(".inputOption3Question" + i + " ").val(),
            isOptionCorrectOrIncorrect3: $(".selectCorrectOrIncorrectOption3Question" + i + " option:selected").text(),

            option4: $(".inputOption4Question" + i + " ").val(),
            isOptionCorrectOrIncorrect4: $(".selectCorrectOrIncorrectOption4Question" + i + " option:selected").text(),

        };
        indexNum++;
    }


    $.post("/home/submitNewCourse", { createcoursemodel: createcoursemodel }, function success(data) { alert("Done");});
});


/*-------------------------------Assign courses----------------------------------*/
//Main assign course button clicked
$(".btnMainAssignCourse").on('click', function () {
    $(".divStudentCourseAssigner").css('visibility', 'visible');
});


$(".btnAssignCourse").on('click', function ()
{

    //Get values of all checked usernames
    var indexNum = 0;
    var allCheckedValuesObject = {}; 
    $(".assignUsernameCheckBox").each(function () {
        if ($(this).is(':checked')) {
            allCheckedValuesObject[indexNum] = { user: $(this).val() };
            indexNum++;
        }
    });

    //Get value of all checked courses
    $(".assignCourseCheckBox").each(function () {
        if ($(this).is(':checked')) {
            allCheckedValuesObject[indexNum] = { course: $(this).val() };
            indexNum++;
        }
    });

    //Send to controller
    $.post("/home/assignCoursesToUsers", { assigncoursemodel: allCheckedValuesObject }, function success(data) { alert("done"); });
});

/*-----------------------Get user report---------------------------*/
//Main report button clicked
$(".btnMainViewReports").on('click', function () {
    $(".divStudentGradeChecker").css('visibility', 'visible');
});

$(".btnSeachStudentReports").on('click', function () {

    $.post("/home/retreieveUsersReport", { username: $(".inputStudentReportUsername").val() }, function success(data)
    {
        $(".divreportHolder").empty();
        var tag;
        //If no results for username
        if (data.length === 0) {
            tag = "<p>Sorry, this user has no records.</p>";
            $(tag).appendTo($(".divreportHolder"));
        }
        //If results
        else
        {
            var iterator = 0;
            tag = "<table>";
            tag += "<tr>";
            tag += "<th>Course Name</th>";
            tag += "<th>Assigned By</th>";
            tag += "<th>Date assigned</th>";
            tag += "<th>Date taken</th>";
            tag += "<th>Grade</th>";
            tag += "</tr>";
            $(data).each(function () {
                tag += "<tr>";

                tag += "<td>" + data[iterator].courseName + "</td>";
                tag += "<td>" + data[iterator].assignedBy + "</td>";
                tag += "<td>" + data[iterator].dateAssigned + "</td>";
                tag += "<td>" + data[iterator].dateTaken + "</td>";
                tag += "<td>" + data[iterator].grade + "</td>";

                tag += "</tr>";

                iterator++;
            });
            tag += "</table>";
            $(tag).appendTo($(".divreportHolder"));
        }

    });
});

//----------------------------close all pages buttons-----------------------
$(".btnCloseStudentReport").on('click', function () {
    $(".divStudentGradeChecker").css("visibility", "hidden");
});


$(".btnCloseAssignCourse").on('click', function () {
    $(".divStudentCourseAssigner").css("visibility", "hidden");
});


$(".btnCloseCreateCourse").on('click', function () {
    $(".divCreateCourse").css("visibility", "hidden");
});