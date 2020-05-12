var table = null;
$(document).ready(function () {
    debugger;
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
            { "data": "jobName" },
            { "data": "isActive" },
            {
                "data": "dueDate", "render": function (data) {
                    return moment(data).format('DD/MM/YYYY');
                }
            },
            {
                data: null, render: function (data, type, row) {
                    return '<button type="button" class="btn btn-success" id="BtnEdit" data-toggle="tooltip" data-placement="top" title="Approve Job" onclick="return ApproveJobs(' + row.id + ')"><i class="mdi mdi-check"></i></button> &nbsp; <button type="button" class="btn btn-danger" id="BtnEdit" data-toggle="tooltip" data-placement="top" title="Decline Job" onclick="return DeclineJobs(' + row.id + ')"><i class="mdi mdi-close"></i></button> &nbsp; <button type="button" class="btn btn-info" id="BtnInfo" data-toggle="tooltip" data-placement="top" title="View Data" onclick="return ViewData(' + row.id + ')"><i class="mdi mdi-eye"></i></button> &nbsp; ';
                }
            }
        ]
    });

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
    if ($('#JobName').val() == "") {
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
                    potition: 'center',
                    title: 'Job Add Successfully',
                    timer: 2000
                }).then(function () {
                    table.ajax.reload();
                    $('#exampleModal').modal('hide');
                    $('#Id').val('');
                    $('#JobName').val('');
                    $('#DueDate').val('');
                });
            }
            else {
                Swal.fire('Error', 'Failed to Add', 'error');
            }
        })
    }
}

function GetById(Id) {
    $.ajax({
        url: "/Jobs/GetById/" + Id,
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (result) {
            $('#Id').val(result.id);
            $('#JobName').val(result.jobName);
            $('#DueDate').val(result.dueDate);
            $('#isActive').val(result.isActive);
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

    var Job = new Object();
    Job.Id = $('#Id').val();
    Job.JobName = $('#JobName').val();
    Job.DueDate = $('#DueDate').val();
    Job.isActive = $('#isActive').val();
    $.ajax({
        type: 'POST',
        url: '/Jobs/InsertOrUpdate',
        data: Jobs
    }).then((result) => {
        //debugger;
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
                if (result.statusCode == 200 || result.statusCode == 201 || result.statusCode == 204) {
                    Swal.fire({
                        position: 'center',
                        type: 'success',
                        title: 'Job Deleted Succesfully'
                    }).then((result) => {
                        if (result.value) {
                            table.ajax.reload();
                        }
                    });
                }
                else {
                    Swal.fire('Error', 'Failed to Delete Job', 'error');

                }
            });
        }
    });
}