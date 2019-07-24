$(document).ready(function () {

    $("#newPlayerBtn").on("click", function () {
        let attr = $("#entryForm")[0].attributes;
        showForm();
        //if (hiddenCheck(attr)) {
        //    showForm();
        //} else {
        //    hideForm();
        //}
    });

    function hiddenCheck(object) {
        let hiddenBool = false;
        if (object) {
            for (var i = 0; i < object.length; i++) {
                if (object[i] == 'hidden') {
                    hiddenBool = true;
                } else {
                    hiddenBool = false;
                }
            }
        }
        return hiddenBool;
    }

    function showForm() {
        $("#entryForm").removeAttr("hidden");
    }

    function hideForm() {
        $("#entryForm").attr("hidden");
    }
   
    function getValues() {
        var name = $("#name").val();
        var nickname = $("#nickname").val();
        var style = $("#gripStyleDropDown").val();
        var skillLevel = $("#skillLevel").val();
        var stats = {
            Name: name,
            Nickname: nickname,
            GripStyleId: style,
            SkillLevelId: skillLevel
        }
        console.log("User input values are: " + name + " " + style + " " + skillLevel);
        populateList(stats);

        savePlayer(stats);

        resetFields();
    }

    function savePlayer(player) {
        $.ajax({
            url: "api/player",
            type: "POST",
            data: JSON.stringify(player)
        }).done(function () {
            alert("done");
        })
    }

    function resetFields() {
        $("#name").val("");
        $("#nickname").val("");
        $("#gripStyleDropDown").val("");
        $("#skillLevel").val("");
    }

    function populateList(stats) {
        if (stats.Name != "") {
            $("#playerList").append("<li> " + stats.Name + " | Style: " + stats.Style + " | Level: " + stats.Level + " </li>");
        }
    }

    var button = $("#submitBtn");
    button.on("click", function () {
        getValues();
    })
});