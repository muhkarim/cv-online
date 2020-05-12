$(document).ready(function () {
    //debugger;
    HideSidebar();
    
});




function SaveApplicant() {
    //debugger;
    var Applicants = new Object();
    //Applicants.User_Id = $('#User_Id').val();
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
        url: '/UserApplicants/Insert',
        data: Applicants
    }).then((result) => {
        //debugger;
        if (result.statusCode == 201 || result.statusCode == 200) {
            Swal.fire({
                icon: 'success',
                potition: 'center',
                title: 'Data Update Successfully',
                timer: 2000
            });
        }
        else {
            Swal.fire('Error', 'Failed to Add', 'error');
        }
    })

}

function HideSidebar() {
    $('#hide-menu-jobs').hide();
    $('#hide-menu-users').hide();
    $('#hide-menu-requests').hide();
}






