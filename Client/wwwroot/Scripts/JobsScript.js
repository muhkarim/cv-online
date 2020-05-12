var table = null;
$(document).ready(function () {
    //debugger;
    table = $('#jt').dataTable({
        "ajax": {
            url: "/Jobs/LoadJobs",
            type: "GET",
            dataType: "json",
            dataSrc: ""
        },
        "columnDefs": [
            { "orderable": false, "targets": 3 },
            { "searchable": false, "targets": 3 }
        ],
        "columns": [
            {
                data: null, render: function (data, type, row, meta)
                {
                    return meta.row + meta.settings._iDisplayStart + 1;
                }
            },
            { "data": "jobName" },
            { "data": "requirements" },
            {
                "data": "isActive", "render": function (data) {
                    var statusaktif = "Aktif";
                    var statuspasif = "Non Aktif";
                    var nulldate = null;
                    if (data == true) {
                        return statusaktif;
                    } else {
                        return statuspasif;
                    }
                }
            },
            {
                "data": "dueDate", "render": function (data) {
                    return moment(data).format('DD/MM/YYYY');
                }
            },
            {
                data: null, render: function (data, type, row) {
                    return '<button type="button" class="btn btn-warning" id="BtnEdit" data-toggle="tooltip" data-placement="top" title="Edit" onclick="return GetById(' + row.id + ')"><i class="mdi mdi-pencil"></i></button> &nbsp; <button type="button" class="btn btn-danger" id="BtnDelete" data-toggle="tooltip" data-placement="top" title="Delete" onclick="return Delete(' + row.id + ')"><i class="mdi mdi-delete"></i></button>';
                }
            }
        ]
    });

    HideSidebar();

});




document.getElementById("btncreatedept").addEventListener("click", function () {
    $('#Id').val('');
    $('#JobName').val('');
    $('#DueDate').val('');
    $('#isActive').val(true);
    $("#SaveBtn").show();
    $("#UpdateBtn").hide();
});


function Save() {
    debugger;
    var Jobs = new Object();
    Jobs.JobName = $('#JobName').val();
    Jobs.DueDate = $('#DueDate').val();
    Jobs.isActive = $('#isActive').val();
    Jobs.Requirements = $('#Requirements').val();
    if ($('#JobName').val() == "") {
        debugger;
        Swal.fire({
            icon: 'error',
            title: 'Error',
            text: 'Job Name Cannot be Empty',
        })
        return false;
    } else {
        $.ajax({
            type: 'POST',
            url: '/Jobs/InsertOrUpdate',
            data: Jobs
        }).then((result) => {
            if (result.statusCode == 201 || result.statusCode == 200) {
                Swal.fire({
                    icon: 'success',
                    position: 'center',
                    type: 'success',
                    showConfirmButton: false,
                    timer: 1500,
                    title: 'Added Succesfully'
                }).then(function () {
                    table.ajax.reload();
                    ClearScreen();
                });
            }
            else {
                Swal.fire('Error', 'Failed to Add', 'error');
            }
        })
    }
}

function GetById(Id) {
    debugger;
    $.ajax({
        url: "/Jobs/GetById/" + Id,
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (result) {
            debugger;
            $('#Id').val(result.id);
            $('#JobName').val(result.jobName);
            $('#DueDate').val(moment(result.birthDate).format('YYYY-MM-DD'));
            $('#isActive').val(result.isActive);
            $('#Requirements').val(result.requirements);
            $("#exampleModal").modal('show');
            $("#SaveBtn").hide();
            $('#EditBtn').show();
            
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

function Edit() {
    debugger;
    var Job = new Object();
    Job.Id = $('#Id').val();
    Job.JobName = $('#JobName').val();
    Job.DueDate = $('#DueDate').val();
    Job.isActive = $('#isActive').val();
    Job.Requirements = $('#Requirements').val();
    $.ajax({
        type: 'POST',
        url: '/Jobs/InsertOrUpdate',
        data: Job
    }).then((result) => {
        debugger;
        if (result.statusCode == 200) {
            Swal.fire({
                icon: 'success',
                position: 'center',
                title: 'Update Successfully',
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

function Delete(Id) {
    debugger;
    Swal.fire({
        title: "Are you sure?",
        text: "You won't be able to revert this!",
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result.value) {
            $.ajax({
                url: "/Jobs/Delete/" + Id,
                data: { Id: Id }
            }).then((result) => {
                if (result.statusCode == 200) {
                    Swal.fire({
                        icon: 'success',
                        position: 'center',
                        title: 'Delete Successfully',
                        timer: 5000
                    }).then(function () {
                        table.ajax.reload();
                        ClearScreen(); 
                    });
                }
                else {
                    Swal.fire('Error', 'Failed to Delete Job', 'error');

                }
            });
        }
    });
}

function ClearScreen() {
    $('#Id').val('');
    $('#JobName').val('');
    $('#DueDate').val('');
    $('#isActive').val('');
    $('#Requirements').val('');
    $("#SaveBtn").show();
    $('#EditBtn').hide();
    $('#exampleModal').modal('hide');
}

function HideSidebar() {
    $('#hide-menu-myprofile').hide();
    $('#hide-menu-joblist').hide();
    $('#hide-menu-inputprofile').hide();
}