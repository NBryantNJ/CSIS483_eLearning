//------------------Email send button clicked-------------------------
$(".btnSubmitData").on('click', function () {
    var allFieldsCorrect = errorCheckInputFields();

    if (allFieldsCorrect === true)
    {
        //Create and populate variables
        var firstname = $(".inputFirstName").val(); 
        var lastname = $(".inputLastName").val(); 
        var email = $(".inputEmail").val(); 
        var username = $(".inputUsername").val(); 
        var reasonForContacting = $(".inputSelectReason option:selected").text();
        var additionalDetails = $(".textAreaMoreInfo").val(); 
        //Format Loading Style
        $(".btnSubmitData p").css("visibility", "hidden");
        $(".loadingGif").css("visibility", "visible");
        
        //Populate data from input sections
        $.post("/home/sendSupportMail", { firstname: firstname, lastname: lastname, username: username, email: email, reasonForContacting: reasonForContacting, additionalDetails:additionalDetails }, function success(data) {
            if (data === true) {
                ajaxSuccessDataStyling();
            }
        });
    }
});



//----------------Error check fields---------------------------
function errorCheckInputFields() {
    $(".divErrorBox p").remove();
    var allFieldsCorrect = true;
    var reg = /^[a-z]+$/i;

    if ($(".inputFirstName").val().length < 2) {
        allFieldsCorrect = false;
        $(".inputFirstName").css("border-color", "red");
        $(".divErrorBox").append("<p><span>*</span>Firstname must be at least two characters.");
    }
    else if (reg.test($(".inputFirstName").val()) === false) 
    {
        allFieldsCorrect = false;
        $(".divErrorBox").append("<p><span>*</span>Firstname can only contain letters.");
        $(".inputFirstName").css("border-color", "red");
    }
    else {
        $(".inputFirstName").css("border-color", "#ccc");
    }

    if ($(".inputLastName").val().length < 2) {
        allFieldsCorrect = false;
        $(".inputLastName").css("border-color", "red");
        $(".divErrorBox").append("<p><span>*</span>Lastname must be at least two characters.");
    }
    else if (reg.test($(".inputLastName").val()) === false) {
        allFieldsCorrect = false;
        $(".divErrorBox").append("<p><span>*</span>Lastname can only contain letters.");
        $(".inputLastName").css("border-color", "red");
    }
    else {
        $(".inputLastName").css("border-color", "#ccc");
    }


    if ($(".inputEmail").val().length < 2) {
        allFieldsCorrect = false;
        $(".inputEmail").css("border-color", "red");
        $(".divErrorBox").append("<p><span>*</span>Please enter a valid email.");
    }
    else {
        var pattern = /^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$/; 
        if (pattern.test($(".inputEmail").val()) === true)
        {
            $(".inputEmail").css("border-color", "#ccc");
        }
        else {
            allFieldsCorrect = false;
            $(".inputEmail").css("border-color", "red");
            $(".divErrorBox").append("<p><span>*</span>Please enter a valid email.");
        }

    }

    if ($(".inputSelectReason").val() === "") {
        allFieldsCorrect = false;
        $(".inputSelectReason").css("border-color", "red");
        $(".divErrorBox").append("<p><span>*</span>Please select a reason for contacting.");
    }
    else {
        $(".inputSelectReason").css("border-color", "#ccc");
    }

    if (allFieldsCorrect === false) {
        $(".divErrorBox").css('visibility', 'visible'); 
        $(".divErrorBox").append("<button class='btn btn-dark' onclick='closeOutErrorLog()' style='position:absolute; top:280px; left:50%; transform:translate(-50%);'>Close Message</button>");
        $(".emailBackgroundDimmmer").css('visibility', 'visible'); 
        $(".emailBackgroundDimmmer").css('opacity', '.3');

    }

    return allFieldsCorrect; 
}

//-----------------Data Sent Format-------------------------------
function ajaxSuccessDataStyling() {
    $(".btnSubmitData p").css("visibility", "visible");
    $(".btnSubmitData p").text("SENT");
    $(".btnSubmitData").attr('disabled', 'disabled');
    $(".btnSubmitData").css("background-color", "#4EC078")
    $(".btnSubmitData").css("opacity", "1")
    $(".btnSubmitData").css("border-style", "none")
    $(".loadingGif").css("visibility", "hidden");
    $(".emailBackgroundDimmmer").css("visibility", "visible");
    $(".emailBackgroundDimmmer").css("opacity", ".5");
    $(".emailSentPopUp").css("visibility", "visible");
    clearInputFields(); 
}


//--------------------------Clear fields---------------------------------------------
function clearInputFields() {
    $(".inputFirstName").val("");
    $(".inputLastName").val(""); 
    $(".inputEmail").val(""); 
    $(".inputUsername").val(""); 
    $(".inputSelectReason").val(""); 
    $(".textAreaMoreInfo").val(""); 
}

//---------------------Close out error log------------------------------------------
function closeOutErrorLog() {
    $(".emailBackgroundDimmmer").css("opacity", "0");
    $(".divErrorBox").css("visibility", "hidden");
    setTimeout(function () {
        $(".emailBackgroundDimmmer").css("visibility", "hidden");
    },300);
}

//------------------Close out button clicked on email pop up------------------------
$(".btnCloseOut").on('click', function () {
    $(".emailBackgroundDimmmer").css("opacity", "0");
    $(".emailSentPopUp").css("opacity", "0");

    setTimeout(function () {
        $(".emailSentPopUp").css("visibility", "hidden");
        $(".emailBackgroundDimmmer").css("visibility", "hidden");
    }, 1000);
});