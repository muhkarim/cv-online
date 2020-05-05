var table = null;
$(document).ready(function () {
    //debugger;
    table = $('#ut').DataTable({
        "ajax": {
            url: "/Users/LoadUsers",
            type: "GET",
            dataType: "json",
            dataSrc: ""
        },
        "columnDefs": [
            { "orderable": false, "targets": 2 },
            { "searchable": false, "targets": 2 }
        ],
        "columns": [
            { "data": "email" },
            { "data": "password" },
            {
                data: null, render: function (data, type, row) {
                    return '<button type="button" class="btn btn-warning" id="BtnEdit" data-toggle="tooltip" data-placement="top" title="Edit" onclick="return GetById(' + row.id + ')"><i class="mdi mdi-pencil"></i></button> &nbsp; <button type="button" class="btn btn-danger" id="BtnDelete" data-toggle="tooltip" data-placement="top" title="Delete" onclick="return Delete(' + row.id + ')"><i class="mdi mdi-delete"></i></button>';
                }
            }
        ]
    });
});



function Save() {
    var User = new Object();
    User.Email = $('#Email').val();
    User.Password = $('#Password').val();

    if ($('#Email').val() == "") {
        Swal.fire({
            icon: 'info',
            title: 'Require',
            text: 'Email Cannot be Empty',
        })
        return false;
    } else {
        $.ajax({
            type: 'POST',
            url: '/Users/InsertOrUpdate/',
            data: User
        }).then((result) => {
            debugger;
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
                Swal.fire('Error', 'Failed to Add User', 'error');
                ShowModal();
            }
        })
    }

}

function GetById(Id) {
    debugger;
    $.ajax({
        url: "/Users/GetById/" + Id,
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (result) {
            //const obj = JSON.parse(result);
            // # atribut id pada html
            $('#Id').val(result.id);
            $('#Email').val(result.email);
            $('#Password').val(result.password);
            $('#exampleModal').modal('show');
            $('#Update').show();
            $('#Save').hide();

        },

        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });

}

function Edit() {
    debugger;
    var User = new Object();
    User.Id = $('#Id').val();
    User.Email = $('#Email').val();
    User.Password = $('#Password').val();
    $.ajax({
        type: 'POST',
        url: '/Users/InsertOrUpdate',
        data: User
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
                ClearScreen();
            });
        } else {
            Swal.fire('Error', 'Failed to input', 'error');
            ClearScreen();
        }
    })
}


function Delete(Id) {
    Swal.fire({
        title: "Are you sure ?",
        text: "You won't be able to Revert this!",
        showCancelButton: true,
        confirmButtonText: "Yes, Delete it!"
    }).then((result) => {
        if (result.value) {
            //debugger;
            $.ajax({
                url: "/Users/Delete/",
                data: { Id: Id }
            }).then((result) => {
                //debugger;
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
                } else {
                    Swal.fire({
                        icon: 'error',
                        title: 'Error',
                        text: 'Failed to Delete',
                    })
                }
            })
        }
    });
}

function ClearScreen() {
    $('#Id').val('');
    $('#Email').val('');
    $('#Password').val('');
    $('#exampleModal').modal('hide');
}



// handle error after action edit
document.getElementById("btncreate").addEventListener("click", function () {
    $('#Id').val('');
    $('#Email').val('');
    $('#Password').val('');
    $('#Save').show();
    $('#Update').hide();
});