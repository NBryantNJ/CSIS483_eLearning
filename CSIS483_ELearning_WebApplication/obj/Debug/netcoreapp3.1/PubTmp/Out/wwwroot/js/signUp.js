
//------------Sign Up button clicked--------------------
$(".btnSignUp").on('click', function ()
{
    var fName = $(".inputFirstName").val(); 
    var lName = $(".inputLastName").val(); 
    var emailInput = $(".inputEmail").val(); 
    var usernameInput = $(".inputUsername").val(); 
    var passwordInput = $(".inputPassword").val(); 
    if (checkDataFormatting() === true) {
        //Display Loading Gif
        $(".loadingGif").css('visibility', 'visible');
        $(".btnSignUp").text("");

        //Send data to server
        $.post("/home/RegisterNewUser", { firstName: fName, lastName: lName, email: emailInput, username: usernameInput, password: passwordInput }, function success(data) {
            if (data === "true") {
                signUpSuccessFormatting();
                setTimeout(function () {
                    window.location.href = "/home/index";
                }, 1000);
            }
            else if (data === "username taken") {
                formatErrorLogForTakenUsername();
            }
            else {
                alert(data); 
            }
        });
        //Pause for 500ms so loading gif is able to display (Style purpose only*)
        setTimeout(function () {
            $(".loadingGif").css('visibility', 'hidden');
            $(".btnSignUp").text("Sign Up");
        }, 500);
    }
});

//------------------Check data formatting--------------------------
function checkDataFormatting() {
    var isFormattingCorrect = true; 
    var errors = ""; 

    //Check firstname
    if ($(".inputFirstName").val().length < 2) {
        $(".inputFirstName").css("border-color", "red");
        isFormattingCorrect = false; 
        errors += "<p><span>*</span>First name must be at least 2 characters</p>"; 
    }
    else {
        var reg = /^[a-z]+$/i;
        if (reg.test($(".inputFirstName").val()) === true) {
            $(".inputFirstName").css("border-color", "#ccc");
        }
        else {
            $(".inputFirstName").css("border-color", "red");
            isFormattingCorrect = false;
            errors += "<p><span>*</span>First name must be only letters.</p>";
        }
    }

    //Check lastname
    if ($(".inputLastName").val().length < 2) {
        $(".inputLastName").css("border-color", "red");
        isFormattingCorrect = false;
        errors += "<p><span>*</span>Lastname must be at least 2 characters</p>"; 
    }
    else {
        var reg = /^[a-z]+$/i;
        if (reg.test($(".inputLastName").val()) === true) {
            $(".inputLastName").css("border-color", "#ccc");
        }
        else {
            $(".inputLastName").css("border-color", "red");
            isFormattingCorrect = false;
            errors += "<p><span>*</span>Last name must be only letters.</p>";
        }
    }

    //Check email
    if ($(".inputEmail").val().length < 7) {
        $(".inputEmail").css("border-color", "red");
        isFormattingCorrect = false;
        errors += "<p><span>*</span>Please enter a valid email.</p>";
    }
    else {
        var reg = /[a-z1-9][@][a-z]+\.[a-z]*$/i;
        if (reg.test($(".inputEmail").val()) === true) {
            $(".inputEmail").css("border-color", "#ccc");
        }
        else {
            $(".inputEmail").css("border-color", "red");
            isFormattingCorrect = false;
            errors += "<p><span>*</span>Please enter a valid email.</p>";
        }
    }

    //check username
    if ($(".inputUsername").val().length < 5) {
        $(".inputUsername").css("border-color", "red");
        isFormattingCorrect = false;
        errors += "<p><span>*</span>Username must be at least 5 characters.</p>";
    }
    else {
        var reg = /[a-zA-Z1-9]/;
        if (reg.test($(".inputUsername").val()) === true) {
            $(".inputUsername").css("border-color", "#ccc");
        }
        else {
            $(".inputUsername").css("border-color", "red");
            isFormattingCorrect = false;
            errors += "<p><span>*</span>Username can only contain letters and numbers.</p>";
        }
    }

    //check password
    if ($(".inputPassword").val().length < 5) {
        $(".inputPassword").css("border-color", "red");
        isFormattingCorrect = false;
        errors += "<p><span>*</span>Password must be at least 5 characters.</p>";
    }
    else {
        $(".inputPassword").css("border-color", "#ccc");
    }

    if (isFormattingCorrect === false) {
        $(".divErrorBox p").remove();
        $(".divErrorBox button").remove(); 
        $(".divErrorBox").css('visibility', 'visible');
        $(".divErrorBox").append(errors);
        $(".divErrorBox").append("<button class='btn btn-dark' onclick='closeOutErrorLog()' style='position:absolute; top:280px; left:50%; transform:translate(-50%);'>Close Message</button>"); 
        $(".divSignUpDimmer").css('visibility', 'visible'); 
        $(".divSignUpDimmer").css('opacity', '.3');
    }

    return isFormattingCorrect;
}

//-------------Username taken formatting------------------------
function formatErrorLogForTakenUsername() {
    $(".divErrorBox p").remove();
    $(".divErrorBox button").remove();
    $(".divErrorBox").css('visibility', 'visible');
    $(".divErrorBox").append("<p><span>*</span>Sorry, the username " + $(".inputUsername").val() + " is taken.</p>");
    $(".divErrorBox").append("<button class='btn btn-dark' onclick='closeOutErrorLog()' style='position:absolute; top:280px; left:50%; transform:translate(-50%);'>Close Message</button>"); 
}

//-------------Error close message button clicked---------------
function closeOutErrorLog() {
    $(".divSignUpDimmer").css('opacity', '0');
    $(".divErrorBox").css('visibility', 'hidden');
    setTimeout(function () {
        $(".divSignUpDimmer").css('visibility', 'hidden');
    }, 500);
}



//-------------Success sign up formatting-----------------------
function signUpSuccessFormatting() {
    $(".btnSignUp").css('background-color', '#4EC078')
    $(".btnSignUp").attr('disbaled', 'disabled');
    $(".btnSignUp").css('box-shadow', 'none');
    $(".btnSignUp").css('border-style', 'none');
}
