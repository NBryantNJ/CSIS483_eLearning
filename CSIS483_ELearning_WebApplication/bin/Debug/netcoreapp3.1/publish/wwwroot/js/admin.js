


/*------------------------Create course form----------------------*/

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


 //public int numberOfLinks { get; set; }
 //       public string link { get; set; }
 //       public string linkType { get; set; }
 //       public int numberOfQuestions { get; set; }
 //       public string question { get; set; }
 //       public string option1 { get; set; }
 //       public string option2 { get; set; }
 //       public string option3 { get; set; }
 //       public string option4 { get; set; }
//                       isOptionCorrectOrIncorrect
 //       public string difficultyRating { get; set; }
 //       public string courseName { get; set; }