var table = null;
$(document).ready(function () {
    debugger;
    table = $('#rt').DataTable({
        "ajax": {
            url: "/Requests/LoadRequest",
            type: "GET",
            dataType: "json",
            dataSrc: ""
        },
        "columnDefs": [
            { "orderable": false, "targets": 5 },
            { "searchable": false, "targets": 5 }
        ],
        "columns": [
            {
                data: null, render: function (data, type, row, meta) {
                    return meta.row + meta.settings._iDisplayStart + 1;
                }
            },
            { "data": "firstName" },
            { "data": "lastName" },
            //{
            //    "data": null, render: function (data, type, row) {
            //        return data.firstName + ' ' + data.lastName;
            //    }
            //},
            { "data": "status" },
            {
                "data": "createDate", "render": function (data) {
                    return moment(data).format('DD/MM/YYYY');
                }
            },
            {
                data: null, render: function (data, type, row) {
                    return '<button type="button" class="btn btn-info" id="BtnInfo" data-toggle="tooltip" data-placement="top" title="View Data" onclick="return GetById(' + row.id + ')"><i class="mdi mdi-eye"></i></button> &nbsp; ';
                }
            }
        ]
    });

    HideSidebar();

    if ($('#Status').val(result.status == "Approve")) {
        $('#ApproveJobs').hide();
        $('#DeclineJobs').show();
    }

    
});


function ApproveJobs() {
    debugger;
    var acc = new Object();
    acc.Id = $('#Id').val();
    acc.Email = $('#Email').val();
    acc.FirstName = $('#FirstName').val();
    $.ajax({
        type: 'PUT',
        url: '/Requests/ApproveJobs/' + Id,
        data: acc
    }).then((result) => {
        debugger;
        if (result.statusCode === 200) {
            Swal.fire({
                icon: 'success',
                position: 'center',
                title: 'Approve Successfully',
                showConfirmButton: false,
                timer: 1500
            }).then(function () {
                table.ajax.reload();
                $("#exampleModal").modal('hide');
            });
        } else {
            Swal.fire('Error', 'Failed', 'error');
            table.ajax.reload();
        }
    });
}

function DeclineJobs() {
    debugger;
    var acc = new Object();
    acc.Id = $('#Id').val();
    acc.Email = $('#Email').val();
    acc.FirstName = $('#FirstName').val();
    $.ajax({
        type: 'PUT',
        url: '/Requests/DeclineJobs/' + Id,
        data: acc
    }).then((result) => {
        if (result.statusCode === 200) {
            Swal.fire({
                icon: 'success',
                position: 'center',
                title: 'Decline Jobs Successfully',
                showConfirmButton: false,
                timer: 1500
            }).then(function () {
                table.ajax.reload();
                $("#exampleModal").modal('hide');
            });
        } else {
            Swal.fire('Error', 'Failed', 'error');
            table.ajax.reload();
        }
    });
}

function GetById(Id) {
    debugger;
    $.ajax({
        url: "/Requests/GetById/" + Id,
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        data: { Id: Id },
        async: false,
        success: function (result) {
            debugger;
            $('#Id').val(result.id);
            $('#FirstName').val(result.firstName);
            $('#IdCard').val(result.idCard);
            $('#LastName').val(result.lastName);
            $('#PlaceOfDate').val(result.placeOfDate);
            $('#BirthDate').val(moment(result.birthDate).format('YYYY-MM-DD'));
            $('#Gender').val(result.gender);
            $('#Religion').val(result.religion);
            $('#PhoneNumber').val(result.phoneNumber);
            $('#Address').val(result.address);
            $('#MaritalStatus').val(result.maritalStatus);
            $('#Email').val(result.email);
            $("#exampleModal").modal('show');

            if (result.status == "Waiting") {
                $('#ApproveJobs').show();
                $('#DeclineJobs').show();
            }
            if (result.status == "Approve") {
                $('#ApproveJobs').hide();
                $('#DeclineJobs').show();
            }
            if (result.status == "Decline") {
                $('#ApproveJobs').show();
                $('#DeclineJobs').hide();
            }

            //result.status == "Decline" 
           
            //$('#ApproveJobs').show();
            //$('#DeclineJobs').show();
            

            //ClearScreen();
            
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}


function ClearScreen() {
    $('#Id').val('');
    $('#ApproveJobs').show();
    $('#DeclineJobs').show();
}

//function ViewData(id) {
//    //debugger;
//    var Request = new Object();
//    Request.Id = $('#Id').val();
//    Request.FirstName = $('#FirstName').val();
//    Request.LastName = $('#LastName').val();
//    Request.PlaceOfDate = $('#PlaceOfDate').val();
//    Request.BirthDate = $('#BirthDate').val();
//    Request.Gender = $('#Gender').val();
//    Request.Religion = $('#Religion').val();
//    Request.PhoneNumber = $('#PhoneNumber').val();
//    Request.Address = $('#Address').val();
//    Request.MaritalStatus = $('#MaritalStatus').val();
//    $.ajax({
//        type: 'POST',
//        url: '/Jobs/InsertOrUpdate',
//        data: Request
//    }).then((result) => {
//        debugger;
//        if (result.statusCode == 200) {
//            Swal.fire({
//                icon: 'success',
//                position: 'center',
//                title: 'Update Successfully',
//                showConfirmButton: false,
//                timer: 1500
//            }).then(function () {
//                table.ajax.reload();
//                ClearScreen(); // delete value name department
//            });
//        } else {
//            Swal.fire('Error', 'Failed to input', 'error');
//            ClearScreen();
//        }
//    })
//}

function HideSidebar() {
    $('#hide-menu-myprofile').hide();
    $('#hide-menu-joblist').hide();
    $('#hide-menu-inputprofile').hide();

}

