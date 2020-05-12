var table = null;
$(document).ready(function () {


    LoadJobs();

    HideSidebar();

});


function LoadJobs() {
    //debugger;
    $.ajax({
        url: "/JobsList/LoadJobsList",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            var html = '';
            debugger;
            $.each(result, function (i) {
                var templateString = '<article class="card"><h2>' + result[i].jobName + '</h2><p>' + result[i].dueDate + '</p><p>' + result[i].requirements + '</p><button id="tes" onclick="return GetById(' + result[i].id + ')">Detail</button></article>';
                $('#test12').append(templateString);
            })

            //$("#test12").on("click", function () {
            //    alert("test");
            //});
            
            
        },
        error: function (errormsg) {
            alert(errormessage.responseText);
        }
    });
}

function GetById(Id) {
    debugger;
    $.ajax({
        url: "/JobsList/GetById/" + Id,
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (result) {
            $('#Applicant_Id').val(result.user_Id);
            $('#Job_Id').val(result.id); // id of jobs
            $('#JobName').val(result.jobName);
            $('#DueDate').val(moment(result.birthDate).format('YYYY-MM-DD'));
            $('#isActive').val(result.isActive);
            $('#Requirements').val(result.requirements);
            $("#exampleModal").modal('show');
            $('#Apply').show();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

function Apply() {
    debugger;
    var Request = new Object();
    Request.Jobs_Id = $('#Job_Id').val();
    //Request.Applicant_Id = $('#Applicant_Id').val();
    $.ajax({
        type: 'POST',
        url: '/Requests/ApplyJobClient',
        data: Request
    }).then((result) => {
        debugger;
        if (result.statusCode == 200 || result.statusCode == 201) {
            Swal.fire({
                icon: 'success',
                position: 'center',
                title: 'Apply Job Successfully',
                showConfirmButton: false,
                timer: 1500
            }).then(function () {
                table.ajax.reload();
                ClearScreen(); // delete value name department
            });
        } else {
            Swal.fire('Error', 'Failed to input', 'error');
            ClearScreen();
        }
    })


}

function HideSidebar() {
    $('#hide-menu-jobs').hide();
    $('#hide-menu-users').hide();
    $('#hide-menu-requests').hide();
}