
function getProfileCount() {


    var member = $('#Client').val();


    $.getJSON("GetCount/" + member, { id: member },
    function (data) {
        console.log(data);
        $("#countResults").html(data.ProfileCount);
    });
}