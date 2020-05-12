$(document).ready(function () {
    

    LoadMyProfile();

    HideSidebar();
    

});

function LoadMyProfile() {
    debugger;
    $.ajax({
        url: "/UserApplicants/LoadProfile/",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (result) {
            debugger;
            $('#Email').val(result.email);
            $('#Status').val(result.status);
            $('#User_Id').val(result.id);
            $('#IdCard').val(result.idCard);
            $('#FirstName').val(result.firstName);
            $('#LastName').val(result.lastName);
            $('#PlaceOfDate').val(result.placeOfDate);
            $('#BirthDate').val(moment(result.birthDate).format('YYYY-MM-DD'));

            $('#Gender').val(result.gender);
            $('#Religion').val(result.religion);
            $('#PhoneNumber').val(result.phoneNumber);
            $('#Address').val(result.address);
            $('#MaritalStatus').val(result.maritalStatus);

            $('#Level').val(result.level);
            $('#Name').val(result.name);
            $('#Majors').val(result.majors);
            $('#YearOfEntry').val(result.yearOfEntry);
            $('#GraduationYear').val(result.graduationYear);
            $('#Place').val(result.place);
            $('#FinalValue').val(result.finalValue);

            $('#CompanyName').val(result.companyName);
            $('#LastPosition').val(result.lastPosition);
            $('#TypeOfBussiness').val(result.typeOfBussiness);
            $('#YearStartedWorking').val(result.yearStartedWorking);
            $('#YearOfResign').val(result.yearOfResign);
            $('#LastSalary').val(result.lastSalary);

            $('#fIdCard').val(result.fIdCard);
            $('#fResume').val(result.fResume);
            $('#fCV').val(result.fCV);
            $('#fFamilyCard').val(result.fFamilyCard);
            $('#fTranscripts').val(result.fTranscripts);
            $('#fDiploma').val(result.fDiploma);
            $('#fCertificate').val(result.fCertificate);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

function Edit() {
    //debugger;
    var Applicants = new Object();
    Applicants.Id = $('#User_Id').val();
    Applicants.IdCard = $('#IdCard').val();
    Applicants.FirstName = $('#FirstName').val();
    Applicants.LastName = $('#LastName').val();
    Applicants.PlaceOfDate = $('#PlaceOfDate').val();
    Applicants.BirthDate = $('#BirthDate').val();
    Applicants.Gender = $('#Gender').val();
    Applicants.Religion = $('#Religion').val();
    Applicants.PhoneNumber = $('#PhoneNumber').val();
    Applicants.Address = $('#Address').val();
    Applicants.MaritalStatus = $('#MaritalStatus').val();

    Applicants.Level = $('#Level').val();
    Applicants.Name = $('#Name').val();
    Applicants.Majors = $('#Majors').val();
    Applicants.YearOfEntry = $('#YearOfEntry').val();
    Applicants.GraduationYear = $('#GraduationYear').val();
    Applicants.Place = $('#Place').val();
    Applicants.FinalValue = $('#FinalValue').val();

    Applicants.CompanyName = $('#CompanyName').val();
    Applicants.LastPosition = $('#LastPosition').val();
    Applicants.TypeOfBussiness = $('#TypeOfBussiness').val();
    Applicants.YearStartedWorking = $('#YearStartedWorking').val();
    Applicants.YearOfResign = $('#YearOfResign').val();
    Applicants.LastSalary = $('#LastSalary').val();

    Applicants.fIdCard = $('#fIdCard').val();
    Applicants.fResume = $('#fResume').val();
    Applicants.fCV = $('#fCV').val();
    Applicants.fFamilyCard = $('#fFamilyCard').val();
    Applicants.fTranscripts = $('#fTranscripts').val();
    Applicants.fDiploma = $('#fDiploma').val();
    Applicants.fCertificate = $('#fCertificate').val();
 
    $.ajax({
        type: 'POST',
        url: '/UserApplicants/Update',
        data: Applicants
    }).then((result) => {
        if (result.statusCode === 200 || result.statusCode === 201 || result.statusCode === 204) {
            Swal.fire({
                icon: 'success',
                position: 'center',
                title: 'Update Successfully',
                showConfirmButton: false,
                timer: 1500
            }).then(function () {
                //table.ajax.reload();
                //ClearScreen();
            });
        } else {
            Swal.fire('Error', 'Failed to input', 'error');
            //ClearScreen();
        }
    })
}

function HideSidebar()
{
    $('#hide-menu-jobs').hide();
    $('#hide-menu-users').hide();
    $('#hide-menu-requests').hide();
}